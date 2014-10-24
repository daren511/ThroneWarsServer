using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using ControleBD;

/// <summary>
/// Initialize the login screen
/// </summary>
public class onStartUp : MonoBehaviour
{
    //---------- VARIABLES
    private bool hasUpdatedGui = false;
    private string userValue = "";
    private string pwdvalue = "";
    private bool canConnect = true;
    private GUIStyle lblError = new GUIStyle();
    // Connection
    private static Socket sck;
    private static IPEndPoint localEndPoint;
    private static string ip = "thronewars.ca";
    private static int port = 50052;
    // Login window
    private static float wL = 430.0f;
    private static float hL = 210.0f;
    // Colors
    public Color primaryColor;
    public Color secondaryColor;
    // Window rectangles
    public Texture background;
    public Texture logo;
    private Rect rectLogin = new Rect((Screen.width - wL) / 2, (Screen.height - hL) / 2, wL, hL);


    void OnGUI()
    {
        hasUpdatedGui = onMenuLoad.updateGUI(hasUpdatedGui, primaryColor, secondaryColor);
        onMenuLoad.createBackground(background);
        onMenuLoad.createLogo(logo);

        onMenuLoad.createQuitWindow();
        GUILayout.Window(2, rectLogin, doLoginWindow, "Login");   // Draw the login window
        onMenuLoad.createMenuWindow(false);
    }

    void doLoginWindow(int windowID)
    {
        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        // Username
        GUILayout.Space(35);
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Usager");
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        userValue = GUILayout.TextField(userValue, GUILayout.Width(300));
        GUILayout.EndHorizontal();

        // Password
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Mot de passe");
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        pwdvalue = GUILayout.PasswordField(pwdvalue, '*', GUILayout.Width(300));
        GUILayout.EndHorizontal();

        // If the user can't connect
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        lblError.normal.textColor = Color.red;
        if (!canConnect)
            GUILayout.Label("Erreur dans la connexion au serveur", lblError);
        else
            GUILayout.Label("");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        if (userValue.Trim() == "" || pwdvalue.Trim() == "")    // Enable or disable the button is username and password are empty
        {
            GUI.enabled = false;
        }
        else
            GUI.enabled = true;

        // Login button
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Connexion", GUILayout.Width(170), GUILayout.Height(40)))
        {
            try
            {

                // So the main menu can have the same colors has the login screen
                onMainMenu.background = background;
                onMainMenu.primaryColor = primaryColor;
                onMainMenu.secondaryColor = secondaryColor;

                ConnectToServer();
                bool validInfos = true;

                if (sck.Connected)
                {
                    //on vérifie les infos entrées par le joueur(usager, mot de passe)
                    validInfos = CheckPasswordUser();

                    if (validInfos)
                    {
                        GetPlayerInfo();
                        Application.LoadLevel("MainMenu");
                    }
                    else
                    {
                        //modifier l'interface: le mot de passe ou usager n'est pas bon
                    }
                }
            }
            catch (SocketException ex)   // The user can't connect to the server
            {
                Debug.Log(ex.Message.ToString());
                canConnect = false;
            }
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
    private void ConnectToServer()
    {
        // Connect the user to the server
        sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        localEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
        sck.Connect(localEndPoint);
    }
    private bool CheckPasswordUser()
    {
        byte[] data = Encoding.ASCII.GetBytes(userValue + " " + Controle.HashPassword(pwdvalue, null, System.Security.Cryptography.SHA256.Create()));
        sck.Send(data); //on envoie les infos du joueur au serveur        

        byte[] buffer;
        buffer = new byte[sck.SendBufferSize];
        int bytesRead = sck.Receive(buffer);

        //on lit au socket pour un vrai ou faux
        byte[] formatted = new byte[bytesRead];
        for (int i = 0; i < bytesRead; i++)
        {
            formatted[i] = buffer[i];
        }        
        return formatted.ToString() == "True";
    }
    private void GetPlayerInfo()
    {

        byte[] buffer;
        buffer = new byte[sck.SendBufferSize];
        int bytesRead = sck.Receive(buffer);

        byte[] formatted = new byte[bytesRead];
        for (int i = 0; i < bytesRead; i++)
        {
            formatted[i] = buffer[i];
        }
        

        CharacterInventory characterInvent = new CharacterInventory();
        PlayerInventory playerInvent = null;
        List<Potion> list = new List<Potion>();
        Potion uItem;
        EquipableItem eItem;

        GameManager._instance._enemySide = 2;
        PlayerManager._instance._playerSide = 1;
        //infos venant du serveur

        /*
         *  CES LIGNES SERVENT AUX TESTS, LES VALEURS SONT BIDONS, ET PROVIENDRONT DE LA BD LORSQUE PRÊT
         * */

        //on génère l'inventaire du joueur, peut être mis dans la DLL commune au serveur, pour recevoir l'inventaire complet plutôt
        //que de le génèrer du côté client
        uItem = new Potion(1, "", "Potion de soins", "Guérit de 20 points de vie", 0, 10, 0, 0, 0, 0, 20);
        list.Add(uItem);
        uItem = new Potion(2, "", "Potion d'attaque", "Augmente les capacités physiques", 3, 5, 10, 0, 0, 0, 0);
        list.Add(uItem);

        //on crée l'inventaire de chaque personnage, encore içi, peut être mis dans la DLL commune au serveur, pour reçevoir les infos
        //directement
        playerInvent = new PlayerInventory(list);
        eItem = new EquipableItem(1, "Guerrier", "Épée de fer", "Une simple épée en fer", "WATK", 10, "Weapon", 1);
        characterInvent._invent.Add(eItem);

        //tout les personnages du joueur, pour le menu prinçipal
        PlayerManager._instance._characters.Add(Character.CreateCharacter("Bartoc", "Guerrier", 2, 3, 2, 100, 10, characterInvent, 20, 10, 0, 10));
        PlayerManager._instance._characters.Add(Character.CreateCharacter("Kodak", "Mage", 1, 2, 1, 50, 50, characterInvent, 10, 10, 10, 10));
        PlayerManager._instance._characters.Add(Character.CreateCharacter("Bubulle", "Archer", 1, 4, 10, 100, 10, characterInvent, 10, 10, 10, 10));
        PlayerManager._instance._characters.Add(Character.CreateCharacter("Mr Poire", "Prêtre", 1, 2, 1, 60, 40, characterInvent, 10, 10, 10, 10));

        //quand on choisit un personnage qui participera à la partie
        PlayerManager._instance._chosenTeam[0] = Character.CreateCharacter("Bartoc", "Guerrier", 2, 3, 1, 100, 10, characterInvent, 20, 10, 0, 10);
        PlayerManager._instance._chosenTeam[1] = Character.CreateCharacter("Kodak", "Mage", 1, 3, 1, 50, 50, characterInvent, 10, 10, 10, 10);
        PlayerManager._instance._chosenTeam[2] = Character.CreateCharacter("Bubulle", "Archer", 1, 5, 3, 100, 10, characterInvent, 10, 10, 10, 10);
        PlayerManager._instance._chosenTeam[3] = Character.CreateCharacter("Mr Poire", "Prêtre", 1, 3, 1, 60, 40, characterInvent, 10, 10, 10, 10);


        PlayerManager._instance._playerInventory = playerInvent;
    }
}