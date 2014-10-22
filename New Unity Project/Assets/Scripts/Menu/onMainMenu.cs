using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Initialize the main menu screen
/// </summary>
public class onMainMenu : MonoBehaviour
{
    //---------- VARIABLES
    GUIStyle mapStyle;
    private bool hasUpdatedGui = false;
    private bool[] tabMap = { false };
    private static string[] tabTeam;
    private static string[] tabCharac;
    private static string[] tabInvent;  // For the player inventory
    private static string[] tabItem;    // For the character inventory
    private static int selectedTeam;
    private static int selectedCharac;
    private static int selectedInvent;
    private static int selectedItem;
    // Colors
    public static Color primaryColor;
    public static Color secondaryColor;
    // Background
    public static Texture background;
    // Team window
    private static float wT = 190.0f;
    private static float hT = Screen.height - 145;
    private static Rect rectTeam = new Rect(Screen.width - wT - 8, 10, wT, hT);
    // Characters window
    private static float wC = 190.0f;
    private static float hC = Screen.height - 110;
    private static Rect rectCharac = new Rect(10, 10, wC, hC);
    // Play window
    private static float wP = Screen.width - wT - wC - 20;
    private static float hP = Screen.height - hC - 30;
    private static Rect rectPlay = new Rect((Screen.width - wP) / 2, Screen.height - hP - 10, wP, hP);
    // Inventory window  (player)
    private static float wI = wP / 2;
    private static float hI = (Screen.height - hP) / 2;
    private static Rect rectInvent = new Rect((Screen.width - wI) / 1.335f, (Screen.height - hI) / 1.455f, wI, hI);
    // Item window  (character)
    private static Rect rectItem = new Rect((Screen.width - wI) / 4, (Screen.height - hI) / 1.455f, wI, hI);
    // Character stats window
    private static float wS = wP;
    private static float hS = hI - 10;
    private static Rect rectStats = new Rect((Screen.width - wS) / 2, 3, wS, hS);


    void OnGUI()
    {
        hasUpdatedGui = onMenuLoad.updateGUI(hasUpdatedGui, primaryColor, secondaryColor);
        onMenuLoad.createBackground(background);

        onMenuLoad.createDeleteWindow();
        onMenuLoad.createQuitWindow();
        onMenuLoad.createMenuWindow(true);
        onMenuLoad.createManagerWindow();
        GUILayout.Window(2, rectTeam, doTeamWindow, "Équipe");
        GUILayout.Window(3, rectCharac, doCharacWindow, "Personnages");
        GUILayout.Window(4, rectPlay, doPlayWindow, "", GUIStyle.none);
        GUILayout.Window(5, rectInvent, doInventWindow, "Inventaire", ColoredGUISkin.Skin.customStyles[4]);
        GUILayout.Window(6, rectItem, doItemWindow, "", ColoredGUISkin.Skin.box);
        GUILayout.Window(7, rectStats, doStatsWindow, "", ColoredGUISkin.Skin.box);
    }

    void doTeamWindow(int windowID)
    {
        GUILayout.Space(25);
        selectedTeam = GUILayout.SelectionGrid(selectedTeam, tabTeam, 1);
    }

    void doCharacWindow(int windowID)
    {
        GUILayout.Space(25);
        selectedCharac = GUILayout.SelectionGrid(selectedCharac, tabCharac, 1);
        
    }

    void doPlayWindow(int windowID)
    {
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        tabMap[0] = onMenuLoad.MyToggle(tabMap[0], "Map 1");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Jouer"))
        {
            // Go to the place character screen
            Application.LoadLevel("placement");
        }
    }

    void doInventWindow(int windowID)
    {
        GUILayout.Space(25);
        selectedInvent = GUILayout.SelectionGrid(selectedInvent, tabInvent, 8);
    }

    void doItemWindow(int windowID)
    {
        GUILayout.Space(25);
        selectedItem = GUILayout.SelectionGrid(selectedItem, tabItem, 8);
    }

    void doStatsWindow(int windowID)
    {
        GUILayout.Space(25);
    }
}