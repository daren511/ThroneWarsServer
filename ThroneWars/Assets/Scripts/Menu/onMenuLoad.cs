using UnityEngine;
using System.Collections;
using ControleBD;
using System.Collections.Generic;

public class onMenuLoad : MonoBehaviour
{
    //---------- VARIABLES
    private static bool wantToQuit = false;
    private static bool isMainMenu = false;
    private static bool wantToDelete = false;
    private static bool wantToCreate = false;
    private static List<Texture2D> listIcons = ResourceManager.GetInstance.GetResourcesIcons();
    private static Texture2D sprite1 = null;
    private static Texture2D sprite2 = null;
    // Menu window
    private static float wM = 190.0f;
    private static float hM = 115.0f;
    private static Rect rectMenu = new Rect(Screen.width - wM - 8, Screen.height - hM - 10, wM, hM);
    // Character manager window
    private static float wC = 190.0f;
    private static float hC = 80.0f;
    private static Rect rectManager = new Rect(8, Screen.height - hC - 10, wC, hC);
    // Quit window
    private static float wQ = 275.0f;
    private static float hQ = 110.0f;
    private static Rect rectQuit = new Rect((Screen.width - wQ) / 2, (Screen.height - hQ) / 2, wQ, hQ);
    // Delete window
    private static float wD = 370.0f;
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
    private static GUIStyle lblError = new GUIStyle();
    private static bool error = false;
    private static Personnages perso;


    public static void createQuitWindow()
    {
        if (wantToQuit)
            GUILayout.Window(0, rectQuit, doQuitWindow, "Quitter");   // Draw the quit window
    }

    public static void createDeleteWindow()
    {
        if (wantToDelete)
            GUILayout.Window(-4, rectDelete, doDeleteWindow, "Supprimer");   // Draw the delete window
    }

    public static void createCreationWindow()
    {
        if (wantToCreate)
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
        if (GUILayout.Button("Crédits"))
        {
            // Show the credits (web site)
            Application.OpenURL("www.thronewars.ca");
        }
        if (!isMainMenu)
        {
            if (GUILayout.Button("Inscription"))
            {
                // Sign up the player (web site)
                Application.OpenURL("www.thronewars.ca/Inscription.aspx");
            }
            if (GUILayout.Button("Quitter"))
            {
                // Show the option to quit or not
                wantToQuit = true;
            }
        }
        else
        {
            if (GUILayout.Button("Magasin"))
            {
                // Go to the online store
                Application.OpenURL("www.thronewars.ca");
            }
            if (GUILayout.Button("Déconnexion"))
            {
                // Back to the login screen
                wantToDelete = false;
                wantToCreate = false;
                characName = "";
                error = false;
                cb.ResetContent();

                PlayerManager._instance.SendObject(Controle.Actions.QUIT);
                PlayerManager._instance.ClearPlayer();
                Application.LoadLevel("Login");
                onStartUp.SetInfos(PlayerManager.USERNAME, PlayerManager.PASSWORD);
            }
        }
    }

    private static void doQuitWindow(int windowID)
    {
        GUI.BringWindowToFront(windowID);
        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        GUILayout.Space(35);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Voulez-vous vraiment quitter le jeu?");
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
        GUI.enabled = (onMainMenu.tabCharac.Count + onMainMenu.tabTeam.Count) < 8;
        if (GUILayout.Button("Créer"))
        {
            // Create a character
            wantToCreate = true;
            wantToDelete = false;

        }
        GUI.enabled = onMainMenu.tabCharac.Count > 0;
        if (GUILayout.Button("Supprimer"))
        {
            // Delete a character
            wantToCreate = false;
            characName = "";
            wantToDelete = true;
        }
    }

    private static void doCreateWindow(int windowID)
    {
        GUI.BringWindowToFront(windowID);
        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        GUILayout.Space(30);
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Nom:", ColoredGUISkin.Skin.label);
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();

        GUI.SetNextControlName("name");
        GUI.FocusControl("name");
        characName = GUILayout.TextField(characName, 12, ColoredGUISkin.Skin.textField, GUILayout.MaxWidth(185)).Replace("\n", "");
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Classe:", ColoredGUISkin.Skin.label);
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();

        cb.SelectedItemIndex = cb.Show();
        perso = cb.GetStats();

        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUI.DrawTexture(new Rect(15.0f, 145f, 32, 32), listIcons[0], ScaleMode.StretchToFill, true, 0.0f);  // Health
        GUI.Label(new Rect(50.0f, 150f, 32, 32), ": " + perso.Health);
        GUI.DrawTexture(new Rect(115.0f, 145f, 32, 32), listIcons[1], ScaleMode.StretchToFill, true, 0.0f); // Magic
        GUI.Label(new Rect(150.0f, 150f, 32, 32), ": " + perso.Magic);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUI.DrawTexture(new Rect(15.0f, 185f, 32, 32), listIcons[2], ScaleMode.StretchToFill, true, 0.0f);  // Watk
        GUI.Label(new Rect(50.0f, 190f, 32, 32), ": " + perso.PhysAtk);
        GUI.DrawTexture(new Rect(115.0f, 185f, 32, 32), listIcons[3], ScaleMode.StretchToFill, true, 0.0f); // Wdef
        GUI.Label(new Rect(150.0f, 190f, 32, 32), ": " + perso.PhysDef);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUI.DrawTexture(new Rect(15.0f, 220f, 32, 32), listIcons[4], ScaleMode.StretchToFill, true, 0.0f);  // Matk
        GUI.Label(new Rect(50.0f, 225f, 32, 32), ": " + perso.MagicAtk);
        GUI.DrawTexture(new Rect(115.0f, 220f, 32, 32), listIcons[5], ScaleMode.StretchToFill, true, 0.0f); // Mdef
        GUI.Label(new Rect(150.0f, 225f, 32, 32), ": " + perso.MagicDef);
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        sprite1 = ResourceManager.GetSprite(perso.ClassName, 1);
        sprite2 = ResourceManager.GetSprite(perso.ClassName, 2);

        GUILayout.BeginHorizontal();
        GUILayout.BeginArea(new Rect(200f, 165f, 150, 150));
        GUI.DrawTexture(new Rect(20f, 10f, 50, 50), sprite1, ScaleMode.StretchToFill, true, 0.0f);
        GUILayout.EndArea();
        GUILayout.BeginArea(new Rect(270f, 165f, 150, 150));
        GUI.DrawTexture(new Rect(60f, 10f, 50, 50), sprite2, ScaleMode.StretchToFill, true, 0.0f);
        GUILayout.EndArea();
        GUILayout.EndHorizontal();

        GUILayout.EndHorizontal();
        GUILayout.Space(100);
        GUILayout.BeginHorizontal();
        GUI.enabled = characName.Trim() != "";

        if (GUILayout.Button("Créer", GUILayout.Height(37)))
        {
            // Create the character
            characClass = contents[cb.SelectedItemIndex].text;

            if (PlayerManager._instance.CreateCharacter(characName, characClass))
            {
                wantToCreate = false;
                PlayerManager._instance._characNames.Add(characName);
                onMainMenu.tabCharac = PlayerManager._instance._characNames;
                characName = "";
                cb.ResetContent();
                error = false;
            }
            else
            {
                error = true;
            }
        }
        GUI.enabled = true;
        if (error)
        {
            lblError.normal.textColor = Color.red;
            GUI.Label(new Rect(rectCreate.width / 2 + (rectCreate.width * 0.03f), rectCreate.height / 2 - 53, 200, 40),
                "Ce nom est déjà utilisé!", lblError);
        }
        else
        {
            GUI.Label(new Rect(rectCreate.width / 2 + (rectCreate.width * 0.03f), rectCreate.height / 2 - 50, 100, 40),
                "", lblError);
        }

        if (GUILayout.Button("Annuler", GUILayout.Height(37)))
        {
            wantToCreate = false;
            characName = "";
            cb.ResetContent();
            error = false;
        }
        GUILayout.EndHorizontal();
    }

    private static void doDeleteWindow(int windowID)
    {
        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        GUILayout.Space(35);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Voulez-vous vraiment supprimer ce personnage?");
        GUILayout.EndHorizontal();
        GUILayout.Space(7);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Oui", GUILayout.Height(37)))
        {
            // Delete the character
            if (PlayerManager._instance.DeleteCharacter(PlayerManager._instance._selectedCharacter._name))
            {
                if (onMainMenu.tabCharac.IndexOf(PlayerManager._instance._selectedCharacter._name) == onMainMenu.tabCharac.Count - 1)
                {
                    onMainMenu.selectedCharac = 0;
                }
                onMainMenu.tabCharac.Remove(PlayerManager._instance._selectedCharacter._name);
                wantToDelete = false;
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