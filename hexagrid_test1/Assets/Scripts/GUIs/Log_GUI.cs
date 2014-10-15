using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/* Log_GUI
 * par Charles Hunter-Roy, 2014
 * simple interface de connexion,
 * pour le projet de fin de D.E.C - Throne Wars
 */
public class Log_GUI : MonoBehaviour
{

    private const string URL_REGISTER = "www.thronewars.ca"; //placeholders
    private const string URL_RECOVER = "www.thronewars.ca";

    private string _user = "";
    private string _pass = "";

    private Rect _containerBox = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 85, 400, 150);
    private Rect _userField;
    private Rect _passField;
    private Rect _recoverLink;
    private Rect _registerLink;
    private Rect _connectButton;
    private Rect _quitButton;

    private bool GuiOn;

    public GUISkin _skin;

    public Log_GUI()
    {

        _userField = new Rect(Screen.width / 2 - 70, Screen.height / 2 - 50, 230, 20);
        _passField = new Rect(Screen.width / 2 - 70, Screen.height / 2 - 25, 230, 20);

        _recoverLink = new Rect(Screen.width / 2 - 170, Screen.height / 2, 230, 20);
        _registerLink = new Rect(Screen.width / 2 - 30, Screen.height / 2, 230, 20);

        _connectButton = new Rect(Screen.width / 2 + 20, Screen.height / 2 + 40, 80, 20);
        _quitButton = new Rect(Screen.width / 2 + 100, Screen.height / 2 + 40, 80, 20);

    }
    void OnGUI()
    {
        GUI.skin = _skin;

        if (GuiOn)
        {//check if gui should be on. If false, the gui is off, if true, 
            // Make a background box
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 75, 200, 150), "Etes-vous sur?");
            // Make the first button. If pressed, quit game 
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 20, 160, 20), "Oui"))
            {
                Application.Quit();
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 40, 160, 20), "Non"))
            {
                GuiOn = false;
            }
        }
        else
        {
            // Make a background box
            GUI.Box(_containerBox, "Throne Wars - Connexion");

            GUI.Label(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 50, 80, 20), "Usager:");
            GUI.Label(new Rect(Screen.width / 2 - 162, Screen.height / 2 - 25, 150, 20), "Mot de passe:");

            //champs d'identifications 
            _user = GUI.TextField(_userField, _user);
            _pass = GUI.PasswordField(_passField, _pass, '*');

            //liens vers le site
            if (Event.current.type == EventType.MouseUp && _recoverLink.Contains(Event.current.mousePosition))
                Application.OpenURL(URL_RECOVER);
            GUI.Label(_recoverLink, "Mot de passe oublié?");

            if (Event.current.type == EventType.MouseUp && _registerLink.Contains(Event.current.mousePosition))
                Application.OpenURL(URL_REGISTER);
            GUI.Label(_registerLink, "Inscription");


            if (GUI.Button(_connectButton, "Connexion"))
            {
                //appel au serveur, confirmation de l'identité du joueur
                if (ConnectToServer())
                {
                    //récupération du joueur
                    GetPlayerInfo();

                    //chargement du menu principal
                    Application.LoadLevel("MainMenu");
                }
            }
            if (GUI.Button(_quitButton, "Quitter"))
            {
                GuiOn = true;
            }
        }
    }
    private bool ConnectToServer()
    {
        bool connect = true;



        return connect;
    }
    private void GetPlayerInfo()
    {
        CharacterInventory characterInvent = new CharacterInventory();
        PlayerInventory playerInvent = null;
        List<UseableItem> list = new List<UseableItem>();
        UseableItem uItem;
        EquipableItem eItem;
        //infos venant du serveur
        //for (int i = 0; i < 4; ++i)
        //{
            //PlayerManager._instance._characters[i] = Character.CreateCharacter("Guerrier", 1, 3, 100, 10, characterInvent, 10, 10, 10, 10);
        //}

        uItem = new UseableItem(1, "All", "Potion de soins", "Guérit de 20 points de vie", "", 20, 0, 10);
        list.Add(uItem);

        uItem = new UseableItem(1, "All", "Potion de magie", "Guérit de 10 points de magie", "", 20, 0, 5);
        list.Add(uItem);

        playerInvent = new PlayerInventory(list);
        
        eItem = new EquipableItem(1, "Guerrier", "Épée de fer", "Une simple épée en fer", "WATK", 10, "Weapon", 1);
        characterInvent._invent.Add(eItem);

        PlayerManager._instance._characters[0] = Character.CreateCharacter("Bartoc", "Guerrier", 1, 3, 100, 10, characterInvent, 20, 10, 0, 10);
        PlayerManager._instance._characters[1] = Character.CreateCharacter("Kodak", "Mage", 1, 2, 50, 50, characterInvent, 10, 10, 10, 10);
        PlayerManager._instance._characters[2] = Character.CreateCharacter("Bubulle","Archer", 1, 4, 100, 10, characterInvent, 10, 10, 10, 10);
        PlayerManager._instance._characters[3] = Character.CreateCharacter("MrPoire","Prêtre", 1, 2, 60, 40, characterInvent, 10, 10, 10, 10);

        PlayerManager._instance._playerInventory = playerInvent;
    }
}