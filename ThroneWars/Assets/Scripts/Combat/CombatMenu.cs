using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ControleBD;

public class CombatMenu : MonoBehaviour
{
    #region GUIElements
    private Rect _menuContainer;
    private Rect _characterStats = new Rect(0, 0, 330, 110);
    private Rect _itemContainer;
    #endregion

    // Quit window
    private static float wQ = 275.0f;
    private static float hQ = 170.0f;
    private static Rect rectQuit = new Rect((Screen.width - wQ) / 2, (Screen.height - hQ) / 2, wQ, hQ);
    // Winning window
    private static float wW = 490.0f;
    private static float hW = 250.0f;
    private static Rect rectWinning = new Rect((Screen.width - wW) / 2, (Screen.height - hW) / 2, wW, hW);
    // Losing window
    private static float wL = 490.0f;
    private static float hL = 250.0f;
    private static Rect rectLosing = new Rect((Screen.width - wL) / 2, (Screen.height - hL) / 2, wL, hL);

    ///le personnage sélectionné
    public GameObject selectedCharacter;

    public string charName = "",
                  charClass = "";

    public float hpLeft,
                 hpMax,
                 mpMax,
                 mpLeft;

    public int patk,
               matk,
               pdef,
               mdef;

    public int lvl;

    public bool characterChosen = false;
    public bool showItems = false;

    public int winner = 0;
    public bool gameOver = false;
    private bool wantToQuit = false;
    private bool enemyHasQuitOrDisconnected = false;

    public bool moveEnabled = true;
    public bool itemEnabled = true;
    private bool hasUpdatedGUI = false;

    #region textures
    public GUISkin _skin;
    public GUIStyle _healthBarFront;
    public GUIStyle _magicBarFront;
    public GUIStyle _barBackground;
    public GUIStyle _statsTexture;


    public Texture2D _healthTexture;
    public Texture2D _magicTexture;
    public Texture2D _atkTexture;
    public Texture2D _defTexture;
    public Texture2D _matkTexture;
    public Texture2D _mdefTexture;
    #endregion
    private Vector2 scrollViewVector = Vector2.zero;
    GUIStyle actionStyle = new GUIStyle();


    // Use this for initialization
    void Start()
    {
        actionStyle.normal.textColor = Color.white;
        actionStyle.alignment = TextAnchor.MiddleCenter;
        actionStyle.onHover.background =
            actionStyle.hover.background = (Texture2D)Resources.Load("Menu/img_invisible");
        actionStyle.onHover.textColor = Color.yellow;
        actionStyle.hover.textColor = Color.yellow;
        actionStyle.padding.top = 5;
        actionStyle.padding.bottom = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            wantToQuit = !wantToQuit;
        gameOver = winner > 0;
    }
    void InitializeStats()
    {
        charName = selectedCharacter.GetComponent<Character>()._name;
        charClass = selectedCharacter.GetComponent<Character>()._characterClass._className;
        lvl = selectedCharacter.GetComponent<Character>()._characterClass._classLevel;

        hpMax = selectedCharacter.GetComponent<Character>()._maxHealth;
        hpLeft = selectedCharacter.GetComponent<Character>()._currHealth;
        mpMax = selectedCharacter.GetComponent<Character>()._maxMagic;
        mpLeft = selectedCharacter.GetComponent<Character>()._currMagic;

        patk = selectedCharacter.GetComponent<Character>()._currPhysAttack;
        matk = selectedCharacter.GetComponent<Character>()._currMagicAttack;
        pdef = selectedCharacter.GetComponent<Character>()._currPhysDefense;
        mdef = selectedCharacter.GetComponent<Character>()._currMagicDefense;
    }

    void OnGUI()
    {
        //gameOver = true;
        hasUpdatedGUI = ResourceManager.GetInstance.UpdateGUI(hasUpdatedGUI);
        if (!gameOver)
        {
            DisplayCharacterStats();
            InitializeStats();

            if (wantToQuit)
                GUI.Window(0, rectQuit, doQuitWindow, "Quitter");

            if (characterChosen)
            {
                DisplayCombatCommands();
            }
            if (showItems)
            {
                DisplayItemMenu();
            }
        }
        else
        {
            DisplayEndResults();
        }
    }

    /// <summary>
    /// Affichage du "HUD" de combat pour le personnage sélectionné, affichant ses informations, telles que sa classe, son nom, etc
    /// </summary>
    void DisplayCharacterStats()
    {
        GUI.Box(_characterStats, charName);
        GUI.Label(new Rect(_characterStats.xMin + 20f, _characterStats.yMin + 10f, 100, 100), charClass);
        GUI.Label(new Rect(_characterStats.xMax - 80f, _characterStats.yMin + 10f, 100, 100), "Niv. " + lvl.ToString());

        GUI.DrawTexture(new Rect(_characterStats.xMin + 20f, _characterStats.yMin + 33f, 15, 15), _healthTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Box(new Rect(_characterStats.xMin + 50f, _characterStats.yMin + 34f, 180 * (hpLeft / hpMax), 0.01f * Screen.height), "", _healthBarFront);
        GUI.Label(new Rect(_characterStats.xMax - 85f, _characterStats.yMin + 28f, 100, 100), hpLeft + " / " + hpMax);

        GUI.DrawTexture(new Rect(_characterStats.xMin + 20f, _characterStats.yMin + 49, 20, 20), _magicTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Box(new Rect(_characterStats.xMin + 50f, _characterStats.yMin + 53f, 180 * (mpLeft / mpMax), 0.01f * Screen.height), "", _magicBarFront);
        GUI.Label(new Rect(_characterStats.xMax - 85f, _characterStats.yMin + 47, 100, 100), mpLeft + " / " + mpMax);

        GUI.DrawTexture(new Rect(_characterStats.xMin + 15f, _characterStats.yMax - 35f, 20, 20), _atkTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Label(new Rect(_characterStats.xMin + 35f, _characterStats.yMax - 35f, 100, 100), patk.ToString());

        GUI.DrawTexture(new Rect(_characterStats.xMin + 90f, _characterStats.yMax - 35f, 20, 20), _defTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Label(new Rect(_characterStats.xMin + 110f, _characterStats.yMax - 35f, 100, 100), pdef.ToString());

        GUI.DrawTexture(new Rect(_characterStats.xMin + 170f, _characterStats.yMax - 35f, 20, 20), _matkTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Label(new Rect(_characterStats.xMin + 190f, _characterStats.yMax - 35f, 100, 100), matk.ToString());

        GUI.DrawTexture(new Rect(_characterStats.xMin + 250f, _characterStats.yMax - 35f, 20, 20), _mdefTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Label(new Rect(_characterStats.xMin + 270f, _characterStats.yMax - 35f, 100, 100), mdef.ToString());
    }
    void DisplayCombatCommands()
    {
        Vector3 pos = selectedCharacter.GetComponent<Character>().transform.position;
        pos = Camera.main.WorldToScreenPoint(pos);
        _menuContainer = new Rect(pos.x, pos.y, 100, 125);

        //GUI.Box(_menuContainer, "");
        GUILayout.BeginArea(_menuContainer, ColoredGUISkin.Skin.box);

        GUI.enabled = !selectedCharacter.GetComponent<Character>().didMove;
        if (GUILayout.Button("Déplacer", actionStyle))
        {
            GameController.FindObjectOfType<GameController>().allowInput = false;
            GameController.FindObjectOfType<GameController>().attackRangeMarker.HideAll();
            StartCoroutine(AllowMovement());
        }

        GUI.enabled = !selectedCharacter.GetComponent<Character>().didAttack;
        if (GUILayout.Button("Attaquer", actionStyle))
        {
            GameController.FindObjectOfType<GameController>().allowInput = false;
            GameController.FindObjectOfType<GameController>().map.ShowAllTileNodes(false);
            StartCoroutine(AllowAttack());
            GameController.wantToAttack = true;
        }

        GUI.enabled = !selectedCharacter.GetComponent<Character>().didAttack;
        if (GUILayout.Button("Item", actionStyle))
        {
            showItems = true;
        }
        GUI.enabled = true;
        if (GUILayout.Button("Terminé", actionStyle))
        {
            ///augmente la défense et passe le tour du personnage
            selectedCharacter.GetComponent<Character>().Defend();
            GameController.FindObjectOfType<GameController>().ClickNextActiveCharacter();
        }

        GUILayout.EndArea();
    }
    IEnumerator AllowMovement()
    {
        selectedCharacter.GetComponent<Character>().node.ShowNeighbours(selectedCharacter.GetComponent<Character>().currMoves, selectedCharacter.GetComponent<Character>().tileLevel, true, true);
        yield return new WaitForSeconds(0.05f);
        GameController.FindObjectOfType<GameController>().allowInput = true;
    }
    IEnumerator AllowAttack()
    {
        GameController.FindObjectOfType<GameController>().attackRangeMarker.Show(
            selectedCharacter.GetComponent<Character>().transform.position, selectedCharacter.GetComponent<Character>().attackRange);
        yield return new WaitForSeconds(0.05f);
        GameController.FindObjectOfType<GameController>().allowInput = true;
    }
    void DisplayItemMenu()
    {
        characterChosen = false;
        _itemContainer = new Rect(_menuContainer.x - _menuContainer.width, _menuContainer.y, 500, 200);
        Rect button;
        GUI.Box(_itemContainer, "");

        ///affichage de la légende
        GUI.Label(new Rect(_itemContainer.xMin + 95, _itemContainer.yMin + 10, 150, 25), "Item");
        GUI.DrawTexture(new Rect(_itemContainer.xMin + 190, _itemContainer.yMin + 10, 20, 20), _healthTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(_itemContainer.xMin + 240, _itemContainer.yMin + 10, 20, 20), _atkTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(_itemContainer.xMin + 290, _itemContainer.yMin + 10, 20, 20), _defTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(_itemContainer.xMin + 340, _itemContainer.yMin + 10, 20, 20), _matkTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(_itemContainer.xMin + 390, _itemContainer.yMin + 10, 20, 20), _mdefTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Label(new Rect(_itemContainer.xMin + 440, _itemContainer.yMin + 10, 150, 25), "QTE");

        ///pour revenir au menu  de commandes de combat
        if (GUI.Button(new Rect(_itemContainer.xMax - 110, _itemContainer.yMax - 40, 100, 30), "Retour"))
        {
            characterChosen = true;
            showItems = false;
        }

        int displayed = 0;
        for (int i = 0; i < PlayerManager._instance._playerInventory._potions.Count; ++i)
        {
            Potion playerItem = PlayerManager._instance._playerInventory._potions[i];

            button = new Rect(_itemContainer.x + 5, _itemContainer.y + (displayed * 25) + 30, 190, 25);

            //pour le "tooltip" du bouton, on stock le nom, ainsi que la description de l'objet
            GUIContent content = new GUIContent(playerItem._itemName, playerItem._itemDescription);

            //on ajoute la potion si la quantité est suffisante et que le personnage peut l'équipper
            if (playerItem.CanEquipUse(selectedCharacter.GetComponent<Character>()) && playerItem._quantity > 0)
            {
                if (GUI.Button(button, content))
                {
                    //utiliser l'item
                    GameObject.Find("StatusIndicator").transform.position = selectedCharacter.GetComponent<Character>().transform.position;
                    selectedCharacter.GetComponent<Character>().UsePotion(playerItem);
                    selectedCharacter.GetComponent<Character>().didAttack = true;
                    playerItem._quantity--;
                    characterChosen = true;
                    showItems = false;
                    GameController.FindObjectOfType<GameController>().attackAllowed = false;
                    itemEnabled = false;

                    selectedCharacter.GetComponentInParent<NaviUnit>().onUnitEvent(selectedCharacter.GetComponentInParent<NaviUnit>(), 2);
                }
                //affichage des stats de l'item
                GUI.Label(new Rect(_itemContainer.xMin + 195, _itemContainer.yMin + (displayed * 25) + 30, 20, 20), playerItem._lifeRestore.ToString());
                GUI.Label(new Rect(_itemContainer.xMin + 245, _itemContainer.yMin + (displayed * 25) + 30, 20, 20), playerItem._bonusPhysAtk.ToString());
                GUI.Label(new Rect(_itemContainer.xMin + 295, _itemContainer.yMin + (displayed * 25) + 30, 20, 20), playerItem._bonusPhysDef.ToString());
                GUI.Label(new Rect(_itemContainer.xMin + 345, _itemContainer.yMin + (displayed * 25) + 30, 20, 20), playerItem._bonusMagicAtk.ToString());
                GUI.Label(new Rect(_itemContainer.xMin + 395, _itemContainer.yMin + (displayed * 25) + 30, 20, 20), playerItem._bonusMagicDef.ToString());
                GUI.Label(new Rect(_itemContainer.xMin + 445, _itemContainer.yMin + (displayed * 25) + 30, 20, 20), playerItem._quantity.ToString());
                displayed++;
            }
        }
        //le "tooltip" fournissant des informations de base sur l'item
        GUI.Label(new Rect(_itemContainer.xMin + 13, _itemContainer.yMax - 55, _itemContainer.width, 30), GUI.tooltip);
    }

    void DisplayEndResults()
    {
        enemyHasQuitOrDisconnected = PlayerManager._instance.enemyHasLeft;

        if (winner == PlayerManager._instance._playerSide)
        {
            GUILayout.Window(-10, rectWinning, doWinningWindow, "Victoire!");
        }
        else
        {
            GUILayout.Window(-11, rectLosing, doLosingWindow, "Défaite!");
        }

        //GUI.Box(new Rect(Screen.width * 0.3f, Screen.height * 0.3f, Screen.width/2, Screen.height/2), msg);
        //if (GUI.Button(new Rect(200 + (Screen.width * 0.3f), 100 + (Screen.height * 0.3f), 200, 100), "Retour au menu principal"))
        //{
        //    PlayerManager._instance._characters.Clear();
        //    Object[] allObjects = GameController.FindObjectsOfType(typeof(Character));

        //    for (int i = 0; i < allObjects.Length; ++i)
        //    {
        //        Destroy(allObjects[i]);
        //    }

        //    PlayerManager._instance.ClearPlayer();
        //    GameManager._instance.ClearEnemy();
        //    Application.LoadLevel("MainMenu");            
        //}
    }

    private void doQuitWindow(int windowID)
    {
        GUI.BringWindowToFront(windowID);
        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        GUILayout.Space(35);
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Êtes-vous certain de vouloir quitter?");
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Vous allez perdre la partie.");
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUILayout.Space(7);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Oui", GUILayout.Height(37)))
        {
            PlayerManager._instance._characters.Clear();
            Object[] allObjects = GameController.FindObjectsOfType(typeof(Character));

            for (int i = 0; i < allObjects.Length; ++i)
            {
                Destroy(allObjects[i]);
            }
            PlayerManager._instance.ClearPlayer(false);
            GameManager._instance.ClearEnemy();
            PlayerManager._instance.SendObject(Controle.Game.CANCEL);
            PlayerManager._instance.LoadPlayer();
            Application.LoadLevel("MainMenu");
        }
        if (GUILayout.Button("Non", GUILayout.Height(37)))
        {
            wantToQuit = false;
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(3);
    }

    private void doWinningWindow(int windowID)
    {
        GUI.BringWindowToFront(windowID);
        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        GUILayout.Space(25);
        GUILayout.BeginHorizontal();
        GUI.Label(new Rect(rectWinning.width - 450, 45, 100, 30), "Personnages");
        GUI.Label(new Rect(rectWinning.width - 270, 45, 50, 30), "XP");
        GUI.Label(new Rect(rectWinning.width - 170, 45, 50, 30), "Morts");
        GUI.Label(new Rect(rectWinning.width - 70, 45, 50, 30), "Tués");
        GUILayout.EndHorizontal();

        int compteur = 0;
        for (int i = 0; i < PlayerManager._instance._chosenTeam.Count; ++i)
        {
            int offset = compteur * 25;
            GUILayout.BeginHorizontal();
            GUI.Label(new Rect(rectWinning.width - 450, 75 + offset, 100, 30), PlayerManager._instance._chosenTeam[i]._name);
            if (enemyHasQuitOrDisconnected)
                GUI.Label(new Rect(rectWinning.width - 267, 75 + offset, 50, 30), "0");
            else
                GUI.Label(new Rect(rectWinning.width - 267, 75 + offset, 50, 30), PlayerManager._instance._chosenTeam[i]._characterClass._exp.ToString());
            if (!PlayerManager._instance._chosenTeam[i]._isAlive)
                GUI.Label(new Rect(rectWinning.width - 168, 75 + offset, 50, 30), "Oui");
            else
                GUI.Label(new Rect(rectWinning.width - 168, 75 + offset, 50, 30), "Non");
            GUI.Label(new Rect(rectWinning.width - 62, 75 + offset, 50, 30), PlayerManager._instance._chosenTeam[i]._kills.ToString());
            GUILayout.EndHorizontal();
            compteur++;
        }

        GUILayout.BeginArea(new Rect(15, rectWinning.height - 38, rectWinning.width - 15, 40));
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        if (enemyHasQuitOrDisconnected)
            GUILayout.Label("Argent: 0");
        else
            GUILayout.Label("Argent: " + PlayerManager._instance._gold);
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();

        if (GUILayout.Button("Retour au menu principal", GUILayout.Height(35)))
        {
            PlayerManager._instance._characters.Clear();
            Object[] allObjects = GameController.FindObjectsOfType(typeof(Character));

            for (int i = 0; i < allObjects.Length; ++i)
            {
                Destroy(allObjects[i]);
            }

            PlayerManager._instance.ClearPlayer(false);
            GameManager._instance.ClearEnemy();
            PlayerManager._instance.LoadPlayer();
            Application.LoadLevel("MainMenu");
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
        GUILayout.Space(3);
    }

    private void doLosingWindow(int windowID)
    {
        GUI.BringWindowToFront(windowID);
        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        GUILayout.Space(25);
        GUILayout.BeginHorizontal();
        GUI.Label(new Rect(rectLosing.width - 450, 45, 100, 30), "Personnages");
        GUI.Label(new Rect(rectLosing.width - 270, 45, 50, 30), "XP");
        GUI.Label(new Rect(rectLosing.width - 170, 45, 50, 30), "Morts");
        GUI.Label(new Rect(rectLosing.width - 70, 45, 50, 30), "Tués");
        GUILayout.EndHorizontal();

        int compteur = 0;
        for (int i = 0; i < PlayerManager._instance._chosenTeam.Count; ++i)
        {
            int offset = compteur * 25;
            GUILayout.BeginHorizontal();
            GUI.Label(new Rect(rectLosing.width - 450, 75 + offset, 100, 30), PlayerManager._instance._chosenTeam[i]._name);
            GUI.Label(new Rect(rectLosing.width - 267, 75 + offset, 50, 30), PlayerManager._instance._chosenTeam[i]._characterClass._exp.ToString());
            if (!PlayerManager._instance._chosenTeam[i]._isAlive)
                GUI.Label(new Rect(rectLosing.width - 168, 75 + offset, 50, 30), "Oui");
            else
                GUI.Label(new Rect(rectLosing.width - 168, 75 + offset, 50, 30), "Non");
            GUI.Label(new Rect(rectLosing.width - 62, 75 + offset, 50, 30), PlayerManager._instance._chosenTeam[i]._kills.ToString());
            GUILayout.EndHorizontal();
            compteur++;
        }

        GUILayout.BeginArea(new Rect(15, rectLosing.height - 38, rectLosing.width - 15, 40));
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Argent: " + PlayerManager._instance._gold);
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();

        if (GUILayout.Button("Retour au menu principal", GUILayout.Height(35)))
        {
            PlayerManager._instance._characters.Clear();
            Object[] allObjects = GameController.FindObjectsOfType(typeof(Character));

            for (int i = 0; i < allObjects.Length; ++i)
            {
                Destroy(allObjects[i]);
            }

            PlayerManager._instance.ClearPlayer(false);
            GameManager._instance.ClearEnemy();
            PlayerManager._instance.LoadPlayer();
            Application.LoadLevel("MainMenu");
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
        GUILayout.Space(3);
    }
}