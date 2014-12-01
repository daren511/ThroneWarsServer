﻿using UnityEngine;
using System.Collections;

public class CombatMenu : MonoBehaviour
{
    #region GUIElements
    private Rect _menuContainer;
    private Rect _characterStats = new Rect(0, 0, 300, 100);
    private Rect _itemContainer;
    #endregion

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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        hasUpdatedGUI = ResourceManager.GetInstance.UpdateGUI(hasUpdatedGUI);
        if(!gameOver)
        {
            DisplayCharacterStats();
            InitializeStats();

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
        GUI.Label(new Rect(10f, 5f, 100, 100), charClass);
        GUI.Label(new Rect(235f, 5f, 100, 100), "Niv. " + lvl.ToString());

        GUI.DrawTexture(new Rect(10f, 20f, 20, 20), _healthTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Box(new Rect(50f, 30f, 180, 0.01f * Screen.height), "");
        GUI.Box(new Rect(50f, 30f, 180 * (hpLeft / hpMax), 0.01f * Screen.height), "", _healthBarFront);
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
        Vector3 pos = selectedCharacter.GetComponent<Character>().transform.position;
        pos = Camera.main.WorldToScreenPoint(pos);
        _menuContainer = new Rect(pos.x, pos.y, 100, 80);

        GUI.Box(_menuContainer, "");

        GUI.enabled = !selectedCharacter.GetComponent<Character>().didMove;
        if (GUI.Button(new Rect(_menuContainer.x, _menuContainer.y, 100, 20), "Déplacer"))
        {
            GameController.FindObjectOfType<GameController>().allowInput = false;
            GameController.FindObjectOfType<GameController>().attackRangeMarker.HideAll();
            StartCoroutine(AllowMovement());
        }

        GUI.enabled = !selectedCharacter.GetComponent<Character>().didAttack;
        if (GUI.Button(new Rect(_menuContainer.x, _menuContainer.y + 20, 100, 20), "Attaquer"))
        {
            GameController.FindObjectOfType<GameController>().allowInput = false;
            GameController.FindObjectOfType<GameController>().map.ShowAllTileNodes(false);
            StartCoroutine(AllowAttack());
        }

        GUI.enabled = !selectedCharacter.GetComponent<Character>().didAttack;
        if (GUI.Button(new Rect(_menuContainer.x, _menuContainer.y + 40, 100, 20), "Item"))
        {
            showItems = true;
        }
        GUI.enabled = true;
        if (GUI.Button(new Rect(_menuContainer.x, _menuContainer.y + 60, 100, 20), "Défendre"))
        {
            ///augmente la défense et passe le tour du personnage
            selectedCharacter.GetComponent<Character>().Defend();
            GameController.FindObjectOfType<GameController>().ClickNextActiveCharacter();
        }
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
        _itemContainer = new Rect(_menuContainer.x - _menuContainer.width, _menuContainer.y, 450, 200);
        Rect button;
        GUI.Box(_itemContainer, "");

        ///affichage de la légende
        GUI.Label(new Rect(_itemContainer.x + 50, _itemContainer.y, 150, 25), "Item");
        GUI.DrawTexture(new Rect(_itemContainer.x + 125, _itemContainer.y, 20, 20), _healthTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(_itemContainer.x + 175, _itemContainer.y, 20, 20), _atkTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(_itemContainer.x + 225, _itemContainer.y, 20, 20), _defTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(_itemContainer.x + 275, _itemContainer.y, 20, 20), _matkTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.DrawTexture(new Rect(_itemContainer.x + 325, _itemContainer.y, 20, 20), _mdefTexture, ScaleMode.StretchToFill, true, 0.0f);
        GUI.Label(new Rect(_itemContainer.x + 375, _itemContainer.y, 150, 25), "Quantité");

        ///pour revenir au menu  de commandes de combat
        if (GUI.Button(new Rect(_itemContainer.x + _itemContainer.width - 100, _itemContainer.y + _itemContainer.height - 20, 100, 20),
                        "Retour"))
        {
            characterChosen = true;
            showItems = false;
        }

        ///début du menu déroulant
        scrollViewVector = GUI.BeginScrollView(new Rect(_itemContainer.x, _itemContainer.y, _itemContainer.width, _itemContainer.height - 20),
                                                         scrollViewVector, new Rect(_itemContainer.x, _itemContainer.y, 200, 400));

        int displayed = 0;
        for (int i = 0; i < PlayerManager._instance._playerInventory._potions.Count; ++i)
        {
            Potion playerItem = PlayerManager._instance._playerInventory._potions[i];

            button = new Rect(_itemContainer.x, _itemContainer.y + (displayed * 25) + 20, 100, 25);

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
                GUI.Label(new Rect(_itemContainer.x + 125, _itemContainer.y + (displayed * 25) + 20, 20, 20), playerItem._lifeRestore.ToString());
                GUI.Label(new Rect(_itemContainer.x + 175, _itemContainer.y + (displayed * 25) + 20, 20, 20), playerItem._bonusPhysAtk.ToString());
                GUI.Label(new Rect(_itemContainer.x + 225, _itemContainer.y + (displayed * 25) + 20, 20, 20), playerItem._bonusPhysDef.ToString());
                GUI.Label(new Rect(_itemContainer.x + 275, _itemContainer.y + (displayed * 25) + 20, 20, 20), playerItem._bonusMagicAtk.ToString());
                GUI.Label(new Rect(_itemContainer.x + 325, _itemContainer.y + (displayed * 25) + 20, 20, 20), playerItem._bonusMagicDef.ToString());
                GUI.Label(new Rect(_itemContainer.x + 390, _itemContainer.y + (displayed * 25) + 20, 20, 20), playerItem._quantity.ToString());
                displayed++;
            }
        }
        //le "tooltip" fournissant des informations de base sur l'item
        GUI.Label(new Rect(_itemContainer.x, _itemContainer.y + _itemContainer.height - 40, _itemContainer.width, 20), GUI.tooltip);

        //fin du menu déroulant
        GUI.EndScrollView();
    }

    void DisplayEndResults()
    {
        string msg = "";
        if(winner == PlayerManager._instance._playerSide)
        {
            msg = "Vous avez gagné!";
        }
        else
        {
            msg = "Vous avez perdu!";
        }

        GUI.Box(new Rect(Screen.width * 0.3f, Screen.height * 0.3f, Screen.width/2, Screen.height/2), msg);
        if (GUI.Button(new Rect(200 + (Screen.width * 0.3f), 100 + (Screen.height * 0.3f), 200, 100), "Retour au menu principal"))
        {
            PlayerManager._instance._characters.Clear();
            Object[] allObjects = GameController.FindObjectsOfType(typeof(Character));

            for (int i = 0; i < allObjects.Length; ++i)
            {
                Destroy(allObjects[i]);
            }

            PlayerManager._instance.ClearPlayer();
            GameManager._instance.ClearEnemy();
            Application.LoadLevel("MainMenu");            
        }
    }
}
