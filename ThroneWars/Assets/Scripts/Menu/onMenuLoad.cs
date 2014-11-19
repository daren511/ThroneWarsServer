using UnityEngine;
using System.Collections;

public class onMenuLoad : MonoBehaviour
{
    //---------- VARIABLES
    private static bool wantToQuit = false;
    private static bool isMainMenu = false;
    private static bool wantToDelete = false;
    private static bool wantToCreate = false;
    // Menu window
    private static float wM = 190.0f;
    private static float hM = 115.0f;
    private static Rect rectMenu = new Rect(Screen.width - wM - 8, Screen.height - hM - 10, wM, hM);
    // Character manager window
    private static float wC = 190.0f;
    private static float hC = 80.0f;
    private static Rect rectManager = new Rect(8, Screen.height - hC - 10, wC, hC);
    // Quit window
    private static float wQ = 240.0f;
    private static float hQ = 110.0f;
    private static Rect rectQuit = new Rect((Screen.width - wQ) / 2, (Screen.height - hQ) / 2, wQ, hQ);
    // Delete window
    private static float wD = 305.0f;
    private static float hD = 110.0f;
    private static Rect rectDelete = new Rect((Screen.width - wD) / 2, (Screen.height - hD) / 2, wD, hD);
    // Create window
    private static float wCr = 400.0f;
    private static float hCr = 300.0f;
    public static Rect rectCreate = new Rect((Screen.width - wCr) / 2, (Screen.height - hCr) / 2 + 25, wCr, hCr);
    // Character infos
    private static string characName = "";
    private static string characClass = "";
    // Character ComboBox
    public static ComboBox cb;
    public static GUIContent[] contents = { new GUIContent("Guerrier"), new GUIContent("Archer"), 
                                    new GUIContent("Mage"), new GUIContent("Prêtre") };

    public static GUIStyle listStyle = new GUIStyle();


    public static void createQuitWindow()
    {
        if (wantToQuit)
            GUILayout.Window(0, rectQuit, doQuitWindow, "Quitter");   // Draw the quit window
    }

    public static void createDeleteWindow()
    {
        if (wantToDelete)
            GUILayout.Window(-3, rectDelete, doDeleteWindow, "Supprimer");   // Draw the delete window
    }

    public static void createCreationWindow()
    {
        if(wantToCreate)
            GUILayout.Window(-3, rectCreate, doCreateWindow, "Créer un personage");
    }
    public static void createMenuWindow(bool isMM)
    {
        isMainMenu = isMM;
        GUILayout.Window(-1, rectMenu, doMenuWindow, "", GUIStyle.none);   // Draw the menu window
    }

    public static void createManagerWindow()
    {
        GUILayout.Window(-2, rectManager, doManagerWindow, "", GUIStyle.none);   // Draw the character manager window
    }

    private static void doMenuWindow(int windowID)
    {
        if (GUILayout.Button("Options"))
        {
            // Show the options
        }
        if (GUILayout.Button("Crédits"))
        {
            // Show the credits
        }
        if (!isMainMenu)
        {
            if (GUILayout.Button("Quitter"))
            {
                // Show the option to quit or not
                wantToQuit = true;
            }
        }
        else
        {
            if (GUILayout.Button("Retour"))
            {
                // Back to the login screen
                onMainMenu.tabCharac.Clear();
                onMainMenu.tabInvent.Clear();
                onMainMenu.tabTeam.Clear();
                onMainMenu.tabItem.Clear();
                PlayerManager._instance._playerInventory._equips.Clear();
                PlayerManager._instance._playerInventory._potions.Clear();
               // PlayerManager._instance._chosenTeam
                Application.LoadLevel("Login");
            }
        }
    }

    private static void doQuitWindow(int windowID)
    {
        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        GUILayout.Space(35);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Voulez-vous vraiment quitter le jeu?");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.Space(7);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Oui", GUILayout.Height(37)))
        {
            Application.Quit();
        }
        if (GUILayout.Button("Non", GUILayout.Height(37)))
        {
            wantToQuit = false;
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(3);
    }

    private static void doManagerWindow(int windowID)
    {
        GUI.enabled = onMainMenu.tabCharac.Count < 8;
        if (GUILayout.Button("Créer"))
        {
            // Create a character
            wantToCreate = true;
            
        }
        GUI.enabled = onMainMenu.tabCharac.Count > 0;
        if (GUILayout.Button("Supprimer"))
        {
            // Delete a character
            wantToDelete = true;
        }
    }

    private static void doCreateWindow(int windowID)
    {

        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        GUILayout.Space(30);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Nom:", ColoredGUISkin.Skin.label);
        characName = GUILayout.TextField(characName, ColoredGUISkin.Skin.textField);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Classe:", ColoredGUISkin.Skin.label);
        cb.SelectedItemIndex = cb.Show();
        GUILayout.EndHorizontal();

        GUILayout.Space(100);
        GUILayout.BeginHorizontal();
        GUI.enabled = characName.Trim() != "";
        if (GUILayout.Button("Créer", GUILayout.Height(37)))
        {
            // Create the character
            characClass = contents[cb.SelectedItemIndex].text;

            if(PlayerManager._instance.CreateCharacter(characName, characClass))
            {
                wantToCreate = false;
                
            }
            else
            {
                //message d'erreur : nom de personnage déjà utilisé
            }

        }
        GUI.enabled = true;
        if (GUILayout.Button("Annuler", GUILayout.Height(37)))
        {
            wantToCreate = false;
        }
        GUILayout.EndHorizontal();
    }

    private static void doDeleteWindow(int windowID)
    {
        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        GUILayout.Space(35);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Voulez-vous vraiment supprimer ce personnage?");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.Space(7);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Oui", GUILayout.Height(37)))
        {
            // Delete the character
            //todo: mettre le personnage inactif, rafraichir la liste personnages
            if(PlayerManager._instance.DeleteCharacter(PlayerManager._instance._selectedCharacter._name))
            {
                wantToDelete = false;
                //remove character in game
            }
        }
        if (GUILayout.Button("Non", GUILayout.Height(37)))
        {
            wantToDelete = false;
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(3);
    }

    public static bool MyToggle(bool variable, string text)
    {
        GUILayout.Box(text, ColoredGUISkin.Skin.button, GUILayout.Width(130), GUILayout.Height(43.5f));
        Rect toggleRect = GUILayoutUtility.GetLastRect();
        toggleRect.x += ColoredGUISkin.Skin.button.padding.left;
        toggleRect.y += ColoredGUISkin.Skin.button.padding.top;
        return GUI.Toggle(toggleRect, variable, "");
    }
}