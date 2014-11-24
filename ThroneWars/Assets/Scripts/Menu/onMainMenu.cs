using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ControleBD;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/// <summary>
/// Initialize the main menu screen
/// </summary>
public class onMainMenu : MonoBehaviour
{
    //---------- VARIABLES
    private bool hasUpdatedGui = false;
    private bool[] tabMap = { false };
    private List<bool> itemsToggles = new List<bool>();
    private static int selectedTeam;
    public static int selectedCharac;
    private static int selectedInvent;  // For the player inventory
    private static int selectedItem;    // For the character inventory
    private static Vector2 scrollPos;
    // Lists
    public static List<string> tabTeam = new List<string>();
    public static List<string> tabCharac = new List<string>();
    public static List<string> tabInvent = new List<string>();
    public static List<string> tabItem = new List<string>();
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
    // Item window  (character) (left side)
    private static float hIt = (Screen.height - hP) / 1.35f;
    private static Rect rectItem = new Rect((Screen.width - wP) / 2, rectPlay.yMin - hIt + 3, wP / 2, hIt);
    // Character stats window
    private static float wS = wP / 2;
    private static float hS = (((Screen.height - hP) / 2) - 10) / 2;
    private static Rect rectStats = new Rect((Screen.width - wP) / 2, rectItem.yMin - hS, wS, hS);
    // Inventory window  (player) (right side)
    private static float hI = hT + (hP / 2);
    private static float wI = wP / 2;
    private static Rect rectInvent = new Rect(rectItem.xMax - 1, Screen.height - rectPlay.yMax, wI, hI);
    // Character stats icons
    public Texture2D _healthTexture;
    public Texture2D _magicTexture;
    public Texture2D _atkTexture;
    public Texture2D _defTexture;
    public Texture2D _matkTexture;
    public Texture2D _mdefTexture;

    private string __spriteClass;
    private Texture2D sprite1 = null;
    private Texture2D sprite2 = null;


    private int remainingPosition = PlayerManager._instance._chosenTeam.Length;
    private int chosenCharacters = 0;
    void Start()
    {
        remainingPosition = PlayerManager._instance._chosenTeam.Length;

        ShowPlayerInventory();

        // Combobox style
        onMenuLoad.listStyle.normal.textColor = Color.white;
        onMenuLoad.listStyle.alignment = TextAnchor.MiddleCenter;
        onMenuLoad.listStyle.onHover.background =
            onMenuLoad.listStyle.hover.background = (Texture2D)Resources.Load("Menu/img_invisible");
        onMenuLoad.listStyle.onHover.textColor = Color.yellow;
        onMenuLoad.listStyle.hover.textColor = Color.yellow;
        onMenuLoad.listStyle.padding.top = 5;
        onMenuLoad.listStyle.padding.bottom = 5;

        onMenuLoad.cb = new ComboBox(new Rect(onMenuLoad.rectCreate.width / 2 + (onMenuLoad.rectCreate.width * 0.02f),
            onMenuLoad.rectCreate.height / 2 - 40, 185, 40), onMenuLoad.contents[0],
            onMenuLoad.contents, "box", "box", onMenuLoad.listStyle);

        if (PlayerManager._instance._selectedCharacter != null)
        {
            __spriteClass = PlayerManager._instance._selectedCharacter._characterClass._className;
            sprite1 = GetSprite(__spriteClass, 1);
            sprite2 = GetSprite(__spriteClass, 2);
            ShowChosenCharacterInventory();
        }
    }


    void OnGUI()
    {
        hasUpdatedGui = ResourceManager.GetInstance.UpdateGUI(hasUpdatedGui);
        ResourceManager.GetInstance.CreateBackground();

        onMenuLoad.createCreationWindow();
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

        if (tabCharac != null && PlayerManager._instance._selectedCharacter != null)
        {
            if (selectedCharac > tabCharac.Count - 1)
                selectedCharac = 0;
            if (PlayerManager._instance._selectedCharacter._name != tabCharac[selectedCharac])
            {
                GetHighlightedCharacter();
            }
        }
    }

    void doPlayWindow(int windowID)
    {
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        GUILayout.Box("Sélectionner la carte", GUILayout.Width(rectItem.width));
        tabMap[0] = onMenuLoad.MyToggle(tabMap[0], "Map 1");
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        //GUI.enabled = chosenCharacters == PlayerManager._instance._chosenTeam.Length && tabMap[0];
        GUI.enabled = false;
        if (GUILayout.Button("Jouer", GUILayout.Width(rectInvent.width)))
        {
            // Go to the place character screen
            GameControllerSample6.scene = "Map1";
            Application.LoadLevel("placement");
        }
        GUI.enabled = true;
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

    void doInventWindow(int windowID)
    {
        GUILayout.Space(25);

        GUILayout.BeginHorizontal();

        //GUI.DrawTexture(new Rect(95, 30, 20, 20), _atkTexture, ScaleMode.StretchToFill, true, 0.0f);
        //GUI.DrawTexture(new Rect(145, 30, 20, 20), _defTexture, ScaleMode.StretchToFill, true, 0.0f);
        //GUI.DrawTexture(new Rect(195, 30, 20, 20), _matkTexture, ScaleMode.StretchToFill, true, 0.0f);
        //GUI.DrawTexture(new Rect(245, 30, 20, 20), _mdefTexture, ScaleMode.StretchToFill, true, 0.0f);
        //GUI.Label(new Rect(295, 30, 150, 25), "QTE");
        GUI.DrawTexture(new Rect(95, 30, 20, 20), _atkTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(165, 30, 20, 20), _defTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(215, 30, 20, 20), _matkTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(265, 30, 20, 20), _mdefTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Label(new Rect(235 - 5, 30, 150, 25), "QTE");

        GUILayout.EndHorizontal();

        scrollPos = GUILayout.BeginScrollView(scrollPos, ColoredGUISkin.Skin.verticalScrollbar, ColoredGUISkin.Skin.scrollView);
        //selectedInvent = GUILayout.SelectionGrid(selectedInvent, tabInvent.ToArray(), 1);

        for (int i = 0; i < PlayerManager._instance._playerInventory._equips.Count; ++i)
        {
            int offset = i * 25;
            EquipableItem item = PlayerManager._instance._playerInventory._equips[i];
            Rect itemButton = new Rect(0, 20 + offset, 100, 20);
            if (item._quantity > 0)
            {
                GUI.enabled = PlayerManager._instance.VerifyCanEquip(item);
                if (GUILayout.Button(item._itemName, GUILayout.Height(30), GUILayout.Width(100)))
                {
                    PlayerManager._instance.EquipItem(item._itemID);
                    PlayerManager._instance._selectedCharacter._characterInventory._invent.Add(item);
                    tabItem.Add(item._itemName);
                    item._quantity -= 1;

                    PlayerManager._instance.Send("ok");
                    PlayerManager._instance.LoadPersonnage(PlayerManager._instance.GetPersonnage());
                }
                GUI.Label(new Rect(75, 20 + offset, 50, 20), item._bonusPhysAtk.ToString());
                GUI.Label(new Rect(125, 20 + offset, 50, 20), item._bonusPhysDef.ToString());
                GUI.Label(new Rect(175, 20 + offset, 50, 20), item._bonusMagicAtk.ToString());
                GUI.Label(new Rect(225, 20 + offset, 50, 20), item._bonusMagicDef.ToString());
                GUI.Label(new Rect(275, 20 + offset, 50, 20), item._quantity.ToString());
            }
        }
        GUILayout.EndScrollView();
    }

    void doItemWindow(int windowID)
    {
        GUILayout.Space(25);
        //selectedItem = GUILayout.SelectionGrid(selectedItem, tabItem.ToArray(), 1);

        GUILayout.BeginHorizontal();

        GUI.DrawTexture(new Rect(125, 20, 20, 20), _atkTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(175, 20, 20, 20), _defTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(225, 20, 20, 20), _matkTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(275, 20, 20, 20), _mdefTexture, ScaleMode.StretchToFill, true, 0.0f);

        GUILayout.EndHorizontal();

        if (PlayerManager._instance._selectedCharacter != null &&
            PlayerManager._instance._selectedCharacter._characterInventory._invent.Count > 0)
        {
            for (int i = 0; i < PlayerManager._instance._selectedCharacter._characterInventory._invent.Count; ++i)
            {
                int offset = i * 25;
                EquipableItem item = PlayerManager._instance._selectedCharacter._characterInventory._invent[i];
                Rect itemButton = new Rect(0, 20 + offset, 100, 20);

                if (PlayerManager._instance._selectedCharacter._characterInventory._invent.Contains(item))
                {
                    if (GUILayout.Button(item._itemName, GUILayout.Height(30), GUILayout.Width(100)))
                    {
                        PlayerManager._instance.UnequipItem(item._itemID);
                        int index = PlayerManager._instance._playerInventory._equips.IndexOf(
                            PlayerManager._instance._playerInventory._equips.Find(x => x._itemName == item._itemName));
                        PlayerManager._instance._playerInventory._equips[index]._quantity += 1;
                        PlayerManager._instance._selectedCharacter._characterInventory._invent.Remove(item);
                        tabItem.Remove(item._itemName);

                        PlayerManager._instance.Send("ok");
                        PlayerManager._instance.LoadPersonnage(PlayerManager._instance.GetPersonnage());
                    }

                    GUI.Label(new Rect(125, 20 + offset, 50, 20), item._bonusPhysAtk.ToString());
                    GUI.Label(new Rect(175, 20 + offset, 50, 20), item._bonusPhysDef.ToString());
                    GUI.Label(new Rect(225, 20 + offset, 50, 20), item._bonusMagicAtk.ToString());
                    GUI.Label(new Rect(275, 20 + offset, 50, 20), item._bonusMagicDef.ToString());
                }
            }
        }
    }

    void doStatsWindow(int windowID)
    {
        GUILayout.BeginVertical();
        GUI.DrawTexture(new Rect(325f, 20f, 32, 32), _healthTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(325f, 70f, 32, 32), _magicTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUILayout.EndVertical();

        if (tabCharac.Count > 0)
        {
            string name = tabCharac[selectedCharac];
            int indexOfChar = PlayerManager._instance._characters.IndexOf(PlayerManager._instance._characters.Find(x => x._name == name));
            Character c = PlayerManager._instance._selectedCharacter;

            if (__spriteClass != c._characterClass._className)
            {
                __spriteClass = c._characterClass._className;
                sprite1 = GetSprite(c._characterClass._className, 1);
                sprite2 = GetSprite(c._characterClass._className, 2);
            }

            GUILayout.BeginHorizontal();
            GUILayout.BeginArea(new Rect(20f, 10f, 150, 150));
            GUI.DrawTexture(new Rect(20f, 10f, 50, 50), sprite1, ScaleMode.StretchToFill, true, 0.0f);
            GUILayout.EndArea();
            GUILayout.BeginArea(new Rect(60f, 10f, 150, 150));
            GUI.DrawTexture(new Rect(60f, 10f, 50, 50), sprite2, ScaleMode.StretchToFill, true, 0.0f);
            GUILayout.EndArea();
            GUILayout.EndHorizontal();


            GUILayout.BeginVertical();
            GUILayout.BeginArea(new Rect(30f, 80f, 200, 32));
            GUILayout.Label(c._name + ", " + c._characterClass._className + " niveau " + c._characterClass._classLevel);
            GUILayout.EndArea();
            GUILayout.EndVertical();

            GUILayout.BeginHorizontal();

            GUILayout.BeginVertical();
            GUILayout.BeginArea(new Rect(360f, 20f, 100, 32));
            GUILayout.Label(": " + c._maxHealth);
            GUILayout.EndArea();
            GUILayout.BeginArea(new Rect(360f, 75f, 100, 32));
            GUILayout.Label(": " + c._maxMagic);
            GUILayout.EndArea();
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            GUI.DrawTexture(new Rect(425f, 20f, 32, 32), _atkTexture, ScaleMode.StretchToFill, true, 0.0f);
            GUI.DrawTexture(new Rect(425f, 70f, 32, 32), _defTexture, ScaleMode.StretchToFill, true, 0.0f);
            GUILayout.EndHorizontal();

            GUILayout.BeginVertical();
            GUILayout.BeginArea(new Rect(460f, 20f, 100, 32));
            GUILayout.Label(": " + c._physAttack);
            GUILayout.EndArea();
            GUILayout.BeginArea(new Rect(460f, 75f, 100, 32));
            GUILayout.Label(": " + c._physDefense);
            GUILayout.EndArea();
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            GUI.DrawTexture(new Rect(525f, 20f, 32, 32), _matkTexture, ScaleMode.StretchToFill, true, 0.0f);
            GUI.DrawTexture(new Rect(525f, 70f, 32, 32), _mdefTexture, ScaleMode.StretchToFill, true, 0.0f);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            GUILayout.BeginArea(new Rect(560f, 20f, 100, 32));
            GUILayout.Label(": " + c._magicAttack);
            GUILayout.EndArea();
            GUILayout.BeginArea(new Rect(560f, 75f, 100, 32));
            GUILayout.Label(": " + c._magicDefense);
            GUILayout.EndArea();
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();

        }
        GUILayout.BeginArea(new Rect(rectStats.width / 24, rectStats.height / 1.3f, rectStats.width, 40));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        GUI.enabled = remainingPosition > 0 && tabCharac.Count > 0;
        if (GUILayout.Button("Ajouter", GUILayout.Height(35), GUILayout.Width(200)))
        {
            SelectCharacter(selectedCharac);
        }
        GUI.enabled = chosenCharacters > 0 && tabTeam.Count > 0;
        if (GUILayout.Button("Retirer", GUILayout.Height(35), GUILayout.Width(200)))
        {
            UnselectCharacter(selectedTeam);
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    private void GetHighlightedCharacter()
    {
        //  Destroy(PlayerManager._instance._selectedCharacter);
        PlayerManager._instance.SendAction(Controle.Actions.CLICK);
        PlayerManager._instance.Send(tabCharac[selectedCharac]);
        PlayerManager._instance.LoadPersonnage(PlayerManager._instance.GetPersonnage());
    }

    private Texture2D GetSprite(string characterClass, int spriteID)
    {
        string classPrefab = "";
        switch (characterClass)
        {
            case "Guerrier":
                classPrefab = "Textures/MenuSprites/MenuWarrior" + spriteID;
                break;
            case "Prêtre":
                classPrefab = "Textures/MenuSprites/MenuPriest" + spriteID;
                break;
            case "Mage":
                classPrefab = "Textures/MenuSprites/MenuMage" + spriteID;
                break;
            case "Archer":
                classPrefab = "Textures/MenuSprites/MenuArcher" + spriteID;
                break;
        }
        return Resources.Load(classPrefab, typeof(Texture2D)) as Texture2D;
    }

    void SelectCharacter(int pos)
    {
        string name = tabCharac[selectedCharac];
        PlayerManager._instance._chosenTeam[chosenCharacters] = PlayerManager._instance._selectedCharacter;

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
            if (c != null)
                tabTeam.Add(c._name.ToString());
        }
    }
    private void ShowPlayerInventory()
    {
        EquipableItem item;
        for (int i = 0; i < PlayerManager._instance._playerInventory._equips.Count; ++i)
        {
            item = PlayerManager._instance._playerInventory._equips[i];
            tabInvent.Add(item._itemName);
        }
    }
    private void ShowChosenCharacterInventory()
    {
        string name = tabCharac[selectedCharac];
        Character c = PlayerManager._instance._selectedCharacter;
        EquipableItem item;
        for (int i = 0; i < c._characterInventory._invent.Count; ++i)
        {
            item = c._characterInventory._invent[i];
            tabItem.Add(item._itemName);
        }
    }
}