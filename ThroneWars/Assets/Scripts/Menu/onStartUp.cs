using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;
using ControleBD;
using System;
using System.Runtime.Serialization;

/// <summary>
/// Initialize the login screen
/// </summary>
public class onStartUp : MonoBehaviour
{

    private const char SPLITTER = '?';

    //---------- VARIABLES
    private bool hasUpdatedGui = false;
    private string userValue = "";
    private string pwdvalue = "";
    private bool canConnect = true;
    private bool validInfos = true;
    private bool confirmed = true;
    private GUIStyle lblError = new GUIStyle();
    // Connection
    private static Socket sck;
    private static IPEndPoint localEndPoint;
    private static string ip = "bd.thronewars.ca";
    private static int port = 50052;
    // Login window
    private static float wL = 430.0f;
    private static float hL = 210.0f;
    private Rect rectLogin = new Rect((Screen.width - wL) / 2, (Screen.height - hL) / 2, wL, hL);

    private DataSet playerData;
    void OnGUI()
    {
        hasUpdatedGui = ResourceManager.GetInstance.UpdateGUI(hasUpdatedGui);
        ResourceManager.GetInstance.CreateBackground();
        ResourceManager.GetInstance.CreateLogo();

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
        else if (!validInfos)
            GUILayout.Label("Usager/Mot de passe invalide", lblError);
        else if (!confirmed)
            GUILayout.Label("Votre compte n'est pas confirmé", lblError);

        else
            GUILayout.Label("");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        if (userValue.Trim() == "" || pwdvalue.Trim() == "")    // Enable or disable the button is username and password are empty
            GUI.enabled = false;
        else
            GUI.enabled = true;

        // Login button
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Connexion", GUILayout.Width(170), GUILayout.Height(40)))
        {
            try
            {
                ConnectToServer();

                ////à titre de tests
                //GetBidonPlayer();
                //Application.LoadLevel("MainMenu");

                if (sck.Connected)
                {
                    // on vérifie les infos entrées par le joueur(usager, mot de passe)
                    CheckPasswordUser();

                    if (validInfos && confirmed)
                    {
                        try
                        {
                            playerData = GetJoueurData();

                            DataTable dt = playerData.Tables["StatsJoueur"];
                            foreach (DataRow dr in dt.Rows)
                            {
                                Debug.Log(dr["Nom"].ToString());
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Log(e);
                        }
                        //Application.LoadLevel("MainMenu");
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
        localEndPoint = new IPEndPoint(Dns.GetHostAddresses(ip)[0], port);
        sck.Connect(localEndPoint);
    }
    private void CheckPasswordUser()
    {
        byte[] data = Encoding.ASCII.GetBytes(userValue + SPLITTER + Controle.HashPassword(pwdvalue, null, System.Security.Cryptography.SHA256.Create()));
        sck.Send(data); //on envoie les infos du joueur au serveur        

        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];

        sck.Receive(buffer);

        //on lit au socket pour un vrai ou faux
        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }
        string ans = Encoding.ASCII.GetString(formatted).ToString();
        validInfos = ans.Split(SPLITTER)[0].Contains("True");
        confirmed = ans.Split(SPLITTER)[1].Contains("True");
    }

    private Joueur GetJoueur()
    {
        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];
        sck.Receive(buffer);

        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }
        Joueur joueur = null;
        BinaryFormatter receive = new BinaryFormatter();
        using (var recstream = new MemoryStream(formatted))
        {
            joueur = receive.Deserialize(recstream) as Joueur;
        }
        return joueur;
    }

    private DataSet GetJoueurData()
    {
        DataSet data = new DataSet();
        try
        {
            byte[] buffer = new byte[sck.SendBufferSize];
            int bytesRead = sck.Receive(buffer);
            byte[] formatted = new byte[bytesRead];

            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = buffer[i];
            }
            BinaryFormatter receive = new BinaryFormatter();           
            using (var recstream = new MemoryStream(formatted))
            {
                data = receive.Deserialize(recstream) as DataSet;
            }
        }
        catch (SerializationException e)
        {
            Debug.Log(e.Message);
        }
        return data;
    }

    private DataSet DeserializeByteArrayToDataSet(byte[] byteArrayData)
    {
        DataSet tempDataSet = new DataSet();
        DataTable dt;
        // Deserializing into datatable    
        using (MemoryStream stream = new MemoryStream(byteArrayData))
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            dt = (DataTable)bformatter.Deserialize(stream);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Debug.Log("----------------------");
                    Debug.Log(row[0]);
                    Debug.Log(row[1]);
                    Debug.Log(row[2]);
                    Debug.Log("----------------------");
                }
            }
        }
        // Adding DataTable into DataSet    
        tempDataSet.Tables.Add(dt);
        return tempDataSet;
    }
    private void GetPlayerInfo()
    {
        Joueur joueur = GetJoueur();
        PlayerInventory playerInvent = null;
        List<Potion> list = new List<Potion>();
        Potion uItem;
        EquipableItem eItem;

        Personnages perso;
        string charClass;

        for (int i = 0; i < joueur.Persos.Count; ++i)
        {
            perso = joueur.Persos[i];
            charClass = GetCharacterClass(perso.ClassId);
            //ici traiter l'inventaire du personnage
            CharacterInventory characterInvent = GetCharacterInventory(i);

            PlayerManager._instance._characters.Add(Character.CreateCharacter(perso.Nom, charClass, perso.Level, perso.Xp, perso.Moves,
                perso.Range, perso.Health, perso.Magic, characterInvent, perso.PhysAtk, perso.PhysDef, perso.MagicAtk, perso.MagicDef));

        }
        PlayerManager._instance._playerInventory = playerInvent;
    }
    private CharacterInventory GetCharacterInventory(int pos)
    {
        CharacterInventory characterInvent = new CharacterInventory();

        for (int i = 0; i < PlayerManager._instance._characters[i]._characterInventory._invent.Count; ++i)
        {
            characterInvent._invent.Add(PlayerManager._instance._characters[i]._characterInventory._invent[i]);
        }
        return characterInvent;
    }
    public static void GetBidonPlayer()
    {
        CharacterInventory characterInvent = new CharacterInventory();
        PlayerInventory playerInvent = null;
        List<Potion> list = new List<Potion>();
        Potion uItem;
        EquipableItem eItem;



        //on génère l'inventaire du joueur, peut être mis dans la DLL commune au serveur, pour recevoir l'inventaire complet plutôt
        //que de le génèrer du côté client
        uItem = new Potion(1, "", "Potion de soins", "Guérit de 20 points de vie", 0, 10, 0, 0, 0, 0, 20);
        list.Add(uItem);
        uItem = new Potion(1, "", "Potion d'attaque", "Augmente les capacités physiques", 3, 5, 10, 0, 0, 0, 0);
        list.Add(uItem);

        //on crée l'inventaire de chaque personnage, encore içi, peut être mis dans la DLL commune au serveur, pour reçevoir les infos
        //directement
        playerInvent = new PlayerInventory(list);
        eItem = new EquipableItem(1, "Guerrier", "Épée de fer", "Une simple épée en fer", "WATK", 10, "Weapon", 1);
        characterInvent._invent.Add(eItem);
        playerInvent._equips.Add(eItem);

        //tout les personnages du joueur, pour le menu prinçipal
        PlayerManager._instance._characters.Add(Character.CreateCharacter("Bartoc", "Guerrier", 2, 3, 2, 100, 10, characterInvent, 20, 10, 0, 10));
        PlayerManager._instance._characters.Add(Character.CreateCharacter("Kodak", "Mage", 1, 2, 1, 50, 50, characterInvent, 10, 10, 10, 10));
        PlayerManager._instance._characters.Add(Character.CreateCharacter("Bubulle", "Archer", 1, 4, 10, 100, 10, characterInvent, 10, 10, 10, 10));
        PlayerManager._instance._characters.Add(Character.CreateCharacter("Mme Poire", "Prêtre", 1, 2, 1, 60, 40, characterInvent, 10, 10, 10, 10));
        PlayerManager._instance._characters.Add(Character.CreateCharacter("Poire", "Archer", 1, 2, 1, 60, 40, characterInvent, 10, 10, 10, 10));
        PlayerManager._instance._characters.Add(Character.CreateCharacter("Patate", "Mage", 1, 2, 1, 60, 40, characterInvent, 10, 10, 10, 10));
        PlayerManager._instance._characters.Add(Character.CreateCharacter("Bobbychou", "Mage", 1, 2, 1, 60, 40, characterInvent, 10, 10, 10, 10));
        PlayerManager._instance._characters.Add(Character.CreateCharacter("Mr Poire", "Guerrier", 1, 2, 1, 60, 40, characterInvent, 10, 10, 10, 10));


        PlayerManager._instance._playerInventory = playerInvent;
    }

    private string GetCharacterClass(int id)
    {
        string classe = "";
        switch (id)
        {
            case 1:
                classe = "Guerrier";
                break;
            case 2:
                classe = "Archer";
                break;
            case 3:
                classe = "Mage";
                break;
            case 4:
                classe = "Prêtre";
                break;
        }
        return classe;
    }
}