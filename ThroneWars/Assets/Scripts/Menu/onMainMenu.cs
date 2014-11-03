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
    private static int selectedTeam;
    private static int selectedCharac;
    private static int selectedInvent;  // For the player inventory
    private static int selectedItem;    // For the character inventory
    private static Vector2 scrollPos;
    // Lists
    private static List<string> tabTeam = new List<string>();
    private static List<string> tabCharac = new List<string>();
    private static List<string> tabInvent = new List<string>();
    private static List<string> tabItem = new List<string>();
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
    private static float hP = Screen.height - hC - 25;
    private static Rect rectPlay = new Rect((Screen.width - wP) / 2, Screen.height - hP - 10, wP, hP);
    // Inventory window  (player)
    private static float wI = wP / 2;
    private static float hI = (Screen.height - hP) / 2;
    private static Rect rectInvent = new Rect((Screen.width - wI) / 1.37f, (Screen.height - hI) / 1.455f, wI, hI);
    // Character stats window
    private static float wS = wP;
    private static float hS = hI - 10;
    private static Rect rectStats = new Rect((Screen.width - wS) / 2, 3, wS, hS);
    // Item window  (character)
    private static Rect rectItem = new Rect((Screen.width - wS) / 2, (Screen.height - hI) / 1.455f, wS / 2, hI);


    private int remainingPosition = PlayerManager._instance._chosenTeam.Length;
    private int chosenCharacters = 0;
    void Start()
    {
        remainingPosition = PlayerManager._instance._chosenTeam.Length;
        ShowAllCharacters();
        ShowSelectedCharacters();
        //ShowPlayerInventory();
    }


    void OnGUI()
    {
        hasUpdatedGui = ResourceManager.GetInstance.UpdateGUI(hasUpdatedGui);
        ResourceManager.GetInstance.CreateBackground();

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
        selectedTeam = GUILayout.SelectionGrid(selectedTeam, tabTeam.ToArray(), 1);
    }

    void doCharacWindow(int windowID)
    {
        GUILayout.Space(25);
        selectedCharac = GUILayout.SelectionGrid(selectedCharac, tabCharac.ToArray(), 1);
    }

    void doPlayWindow(int windowID)
    {
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        tabMap[0] = onMenuLoad.MyToggle(tabMap[0], "Map 1");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUI.enabled = chosenCharacters == PlayerManager._instance._chosenTeam.Length && tabMap[0];
        if (GUILayout.Button("Jouer"))
        {
            // Go to the place character screen
            GameControllerSample6.scene = "Map1";
            Application.LoadLevel("placement");
        }
    }

    void doInventWindow(int windowID)
    {
        GUILayout.Space(25);
        scrollPos = GUILayout.BeginScrollView(scrollPos, ColoredGUISkin.Skin.verticalScrollbar, GUIStyle.none);
        selectedInvent = GUILayout.SelectionGrid(selectedInvent, tabInvent.ToArray(), 1);
        GUILayout.EndScrollView();
    }

    void doItemWindow(int windowID)
    {
        GUILayout.Space(25);
        selectedItem = GUILayout.SelectionGrid(selectedItem, tabItem.ToArray(), 1);
    }
        
    void doStatsWindow(int windowID)
    {
        GUILayout.Space(25);
        GUILayout.BeginArea(new Rect(rectStats.xMax / 6, rectStats.yMin + rectStats.height - 44, rectStats.width, 30));
        GUILayout.BeginHorizontal();
        GUI.enabled = remainingPosition > 0;
        if (GUILayout.Button("Ajouter", GUILayout.Height(35), GUILayout.Width(200)))
        {
            SelectCharacter(selectedCharac);
        }
        GUI.enabled = chosenCharacters > 0;
        if(GUILayout.Button("Retirer", GUILayout.Height(35), GUILayout.Width(200)))
        {
            UnselectCharacter(selectedTeam);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    void SelectCharacter(int pos)
    {
        string name = tabCharac[selectedCharac];
        int indexOfChar = PlayerManager._instance._characters.IndexOf(PlayerManager._instance._characters.Find(x => x._name == name));
        PlayerManager._instance._chosenTeam[chosenCharacters] = PlayerManager._instance._characters[indexOfChar];
        tabCharac.RemoveAt(pos);
        remainingPosition--;
        chosenCharacters++;
        ShowSelectedCharacters();
    }
    void UnselectCharacter(int pos)
    {
        tabCharac.Add(tabTeam[pos]);
        tabTeam.RemoveAt(pos);
        remainingPosition++;
        chosenCharacters--;

        string name = tabTeam[selectedTeam];
        int indexOfChar = PlayerManager._instance._characters.IndexOf(PlayerManager._instance._characters.Find(x => x._name == name));
        PlayerManager._instance._chosenTeam[indexOfChar] = null;
    }
    void ShowAllCharacters()
    {
        tabCharac.Clear();
        Character c;
        for (int i = 0; i < PlayerManager._instance._characters.Count; ++i)
        {
            c = PlayerManager._instance._characters[i];
            tabCharac.Add(c._name.ToString());
        }
    }
    private void ShowSelectedCharacters()
    {
        tabTeam.Clear();
        Character c;
        for (int i = 0; i < PlayerManager._instance._chosenTeam.Length; ++i)
        {
            c = PlayerManager._instance._chosenTeam[i];
            if(c != null)
                tabTeam.Add(c._name.ToString());
        }
    }
    private void ShowPlayerInventory()
    {
        tabInvent.Clear();
        EquipableItem item;
        for(int i = 0; i < PlayerManager._instance._playerInventory._equips.Count; ++i)
        {
            item = PlayerManager._instance._playerInventory._equips[i];
            tabInvent.Add(item._itemName);
        }
    }
    private void ShowChosenCharacterInventory()
    {
        tabItem.Clear();
        string name = tabCharac[selectedCharac].Remove(tabCharac[selectedCharac].LastIndexOf(','));
        Character c = PlayerManager._instance._characters.Find(x => x._name == name);
        EquipableItem item;
        for (int i = 0; i < c._characterInventory._invent.Count; ++i)
        {
            item = PlayerManager._instance._characters[i]._characterInventory._invent[i];
            tabItem.Add(item._itemName);
        }
    }
}