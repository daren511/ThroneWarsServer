using UnityEngine;
using System.Collections;

public class CombatMenu : MonoBehaviour
{
    private Rect _menuContainer;
    private Rect _characterStats = new Rect(0, 0, 300, 100);
    private Rect _itemContainer;

    public GameObject go;


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

    public float characterPositionX,
                 characterPositionY;

    public bool characterChosen = false;
    public bool showItems = false;


    public bool attackEnabled = true;
    public bool moveEnabled = true;
    public bool itemEnabled = true;

    public GUISkin _skin;
    public GUIStyle _healthBarFront;
    public GUIStyle _magicBarFront;
    public GUIStyle _barBackground;

    public Texture2D _healthTexture;
    public Texture2D _magicTexture;
    public Texture2D _atkTexture;
    public Texture2D _defTexture;
    public Texture2D _matkTexture;
    public Texture2D _mdefTexture;
    
    public Texture2D _returnTexture;

    private Vector2 scrollViewVector = Vector2.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void InitializeStats()
    {
        charName = go.GetComponent<Character>()._name;
        charClass = go.GetComponent<Character>()._characterClass._className;
        lvl = go.GetComponent<Character>()._characterClass._classLevel;

        hpMax = go.GetComponent<Character>()._maxHealth;
        hpLeft = go.GetComponent<Character>()._currHealth;
        mpMax = go.GetComponent<Character>()._maxMagic;
        mpLeft = go.GetComponent<Character>()._currMagic;

        patk = go.GetComponent<Character>()._physAttack;
        matk = go.GetComponent<Character>()._magicAttack;
        pdef = go.GetComponent<Character>()._physDefense;
        mdef = go.GetComponent<Character>()._magicDefense;
    }

    void OnGUI()
    {
        DisplayCharacterStats();

        if(characterChosen) 
        {
            GameController.FindObjectOfType<GameController>().allowInput = false;
            InitializeStats();
            DisplayCombatCommands();
        }
        if (showItems)
        {
            GameController.FindObjectOfType<GameController>().allowInput = false;
            InitializeStats();
            DisplayItemMenu();
        }
    }
    void DisplayCharacterStats()
    {
        GUI.Box(_characterStats, charName);
        GUI.Label(new Rect(10f, 5f, 100, 100), charClass);
        GUI.Label(new Rect(235f, 5f, 100, 100), "Niv. " + lvl.ToString());

        GUI.DrawTexture(new Rect(10f, 20f, 20, 20), _healthTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Box(new Rect(50f, 30f, 180, 0.01f * Screen.height), "");
        GUI.Box(new Rect(50f, 30f, 180 * (hpLeft / hpMax), 0.01f * Screen.height), "",  _healthBarFront);
        GUI.Label(new Rect(235f, 22f, 100, 100), hpLeft + " / " + hpMax);

        GUI.DrawTexture(new Rect(10f, 40f, 20, 20), _magicTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Box(new Rect(50f, 45f, 180, 0.01f * Screen.height), "");
        GUI.Box(new Rect(50f, 45f, 180 * (mpLeft / mpMax), 0.01f * Screen.height), "", _magicBarFront);
        GUI.Label(new Rect(235f, 38f, 100, 100), mpLeft + " / " + mpMax);

        GUI.DrawTexture(new Rect(10f, 60f, 32, 32), _atkTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Label(new Rect(50f, 70f, 100, 100), patk.ToString());

        GUI.DrawTexture(new Rect(70f, 60f, 32, 32), _defTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Label(new Rect(110f, 70f, 100, 100), pdef.ToString());

        GUI.DrawTexture(new Rect(140f, 60f, 32, 32), _matkTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Label(new Rect(180f, 70f, 100, 100), matk.ToString());

        GUI.DrawTexture(new Rect(220f, 60f, 32, 32), _mdefTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Label(new Rect(260f, 70f, 100, 100), mdef.ToString());
    }
    void DisplayCombatCommands()
    {
        //_menuContainer = new Rect(characterPositionX, characterPositionY, 100, 60);
        _menuContainer = new Rect(Screen.width / 2 + 50, Screen.height / 2, 100, 80);

        GUI.Box(_menuContainer, "");

        GUI.enabled = moveEnabled;
        if (GUI.Button(new Rect(_menuContainer.x, _menuContainer.y, 100, 20), "Déplacer"))
        {
            GameController.FindObjectOfType<GameController>().movementAllowed = true;
            GameController.FindObjectOfType<GameController>().attackAllowed = false;
            GameController.FindObjectOfType<GameController>().FakeUnitClick(go);
            GameController.FindObjectOfType<GameController>().allowInput = true;
        }

        GUI.enabled = attackEnabled;
        if (GUI.Button(new Rect(_menuContainer.x, _menuContainer.y + 20, 100, 20), "Attaquer"))
        {
            GameController.FindObjectOfType<GameController>().attackAllowed = true;
            GameController.FindObjectOfType<GameController>().movementAllowed = false;
            //GameController.FindObjectOfType<GameController>().FakeUnitClick(go);
            GameController.FindObjectOfType<GameController>().allowInput = true;
        }

        GUI.enabled = itemEnabled;
        if (GUI.Button(new Rect(_menuContainer.x, _menuContainer.y + 40, 100, 20), "Item"))
        {
            characterChosen = false;
            showItems = true;
            GameController.FindObjectOfType<GameController>().movementAllowed = false;
            GameController.FindObjectOfType<GameController>().attackAllowed = false;
            //GameController.FindObjectOfType<GameController>().FakeUnitClick(go);
        }

        if (GUI.Button(new Rect(_menuContainer.x, _menuContainer.y + 60, 100, 20), "Défendre"))
        {
            //augmenter la défense et passer le tour du personnage
        }
    }
    void DisplayItemMenu()
    {
        _itemContainer = new Rect(_menuContainer.x - _menuContainer.width, _menuContainer.y, 400, 200);
        Rect button;
        GUI.Box(_itemContainer, "");

        GUI.Label(new Rect(_itemContainer.x + 100, _itemContainer.y, 150, 25), "Item");
        GUI.Label(new Rect(_itemContainer.x + 250, _itemContainer.y, 150, 25), "Quantité");


        if (GUI.Button(new Rect(_itemContainer.x + _itemContainer.width - 100, _itemContainer.y + _itemContainer.height - 20, 100, 20), "Retour"))
        {
            characterChosen = true;
            showItems = false;            
        }

        //scrollViewVector = GUILayout.BeginScrollView(scrollViewVector);
        scrollViewVector = GUI.BeginScrollView(new Rect(_itemContainer.x, _itemContainer.y, _itemContainer.width, _itemContainer.height - 20), scrollViewVector, new Rect(0, 0, 200, 400));
        //GUILayout.BeginArea(_itemContainer);
        //GUI.BeginGroup(_itemContainer);
        
        for (int i = 0; i < PlayerManager._instance._playerInventory._invent.Count; ++i)
        {
            button = new Rect(_itemContainer.x, _itemContainer.y + (i * 25) + 20, 150, 25);
            
            GUIContent content = new GUIContent(PlayerManager._instance._playerInventory._invent[i]._itemName, PlayerManager._instance._playerInventory._invent[i]._itemDescription);

            if (GUI.Button(button, content))
            {
                //utiliser l'item
            }
            GUI.Label(new Rect(_itemContainer.x + _itemContainer.width - 250, _itemContainer.y + (i * 25) + 20, 150, 25), PlayerManager._instance._playerInventory._invent[i]._quantity.ToString());
            GUI.Label(new Rect(button.x, button.y, 150, 20), GUI.tooltip);
            //GUILayout.Label(PlayerManager._instance._playerInventory._invent[i]._quantity.ToString());
            //GUILayout.Label(GUI.tooltip);
        }
        //GUILayout.EndArea();
        //GUILayout.EndScrollView();
        //GUI.EndGroup();
        GUI.EndScrollView();
    }

}
