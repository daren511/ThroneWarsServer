// ====================================================================================================================
//
// Created by Leslie Young
// http://www.plyoung.com/ or http://plyoung.wordpress.com/
// ====================================================================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class GameControllerSample6 : MonoBehaviour
{
    // This is a simple sample of how to spawn a unit on a tile that was clicked

    public CameraMove camMover;	// used to move camera around (like make it follow a transform)
    public Camera rayCam;
    public GameObject unitFab;	// unit prefab
    public GameObject[] unitFabs = new GameObject[4];				// unit prefabs
    public GameObject[] enemyFabs = new GameObject[4];				// unit prefabs
    public MapNav map;			// the mapnav
    public LayerMask tilesLayer;// layer the tiles are on
    public static string scene;
    private bool hasUpdatedGui = false;
    private bool wantToQuit = false;

    // Character stats
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

    // 2D textures for stats
    public Texture2D _healthTexture;
    public Texture2D _magicTexture;
    public Texture2D _atkTexture;
    public Texture2D _defTexture;
    public Texture2D _matkTexture;
    public Texture2D _mdefTexture;

    private int placed = 0;
    List<GameObject> table = new List<GameObject>();

    // Quit window
    private static float wQ = 275.0f;
    private static float hQ = 110.0f;
    private static Rect rectQuit = new Rect((Screen.width - wQ) / 2, (Screen.height - hQ) / 2, wQ, hQ);

    private Rect _containerBox = new Rect(Screen.width - 150, 0, 150, Screen.height - 50);
    private Rect rectPlay = new Rect(Screen.width / 3, Screen.height - 50, Screen.width / 3, 50);



    IEnumerator Start()
    {
        // wait for a frame for everything else to start and then enable the colliders for the TielNodes
        yield return null;

        //InitializeEnemyUnits();

        //for (int i = 0; i < PlayerManager._instance._chosenTeam.Count; ++i)
        //{
        //    AddCharacterPrefab(i);
        //}
        //for (int i = 0; i < GameManager._instance._enemyTeam.Count; ++i)
        //{
        //    AddEnemyPrefab(i);
        //}

        // now enable the colliders of the TileNodes.
        // they are disabled by default, but for this sample to work I need the player to be able to click on any tile.
        // for your game you will have to decide when the best time would be to this or even which tiles would be
        // best to enable. For example, you might only want to spawn new units around some building, so only
        // enable the the tiles around the building so that the player cannot click on other tiles and disable 
        // the tiles whne yo uare done with them

        foreach (TileNode n in map.nodes)
        {
            if (n)
                n.collider.enabled = true;
        }
        map.ShowAllTileNodes(true);
    }

    void OnGUI()
    {
        hasUpdatedGui = ResourceManager.GetInstance.UpdateGUI(hasUpdatedGui);
        InitializeStats();
        GUILayout.Window(1, _containerBox, doContainerWindow, "", ColoredGUISkin.Skin.box);
        GUILayout.Window(2, rectPlay, doPlayWindow, "", GUIStyle.none);
        if (GUI.Button(new Rect(Screen.width - 150, Screen.height - 50, 150, 50), "Quitter"))
            wantToQuit = true;
        if (wantToQuit)
            GUILayout.Window(0, rectQuit, doQuitWindow, "Quitter");   // Draw the quit window
    }

    private void doContainerWindow(int windowID)
    {
        GUILayout.BeginVertical();
        showStats();
        GUILayout.EndVertical();
    }

    private void doPlayWindow(int windowID)
    {
        GUI.enabled = placed == PlayerManager._instance._chosenTeam.Count;
        if (GUILayout.Button("Démarrer"))
        {
            Object[] allObjects = FindObjectsOfType(typeof(Character));



            PlayerManager._instance.Send("ok");
            PlayerManager._instance.SendObject<List<int>>(GameManager._instance._playerPositions);
            GameManager._instance._enemyPositions = PlayerManager._instance.ReceiveObject<int>();
            GameController.unitsFabs = unitFabs;
            GameController.enemyFabs = enemyFabs;



            for (int i = 0; i < allObjects.Length; ++i)
            {
                Destroy(allObjects[i]);
            }
            Application.LoadLevel(scene);
        }
    }

    private void showStats()
    {
        //--- Name -- HP -- MP
        GUILayout.Label(charName);

        GUILayout.BeginHorizontal();
        GUILayout.Label(_healthTexture, GUILayout.Height(20), GUILayout.Width(20));
        GUILayout.Label(hpMax.ToString());
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label(_magicTexture, GUILayout.Height(20), GUILayout.Width(20));
        GUILayout.Label(mpMax.ToString());
        GUILayout.EndHorizontal();

        //--- Physical ATK -- Magic ATK -- Physical Defense -- Magic Defense
        GUILayout.BeginHorizontal();
        GUILayout.Label(_atkTexture, GUILayout.Height(20), GUILayout.Width(20));
        GUILayout.Label(patk.ToString());
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label(_matkTexture, GUILayout.Height(20), GUILayout.Width(20));
        GUILayout.Label(matk.ToString());
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label(_defTexture, GUILayout.Height(20), GUILayout.Width(20));
        GUILayout.Label(pdef.ToString());
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label(_mdefTexture, GUILayout.Height(20), GUILayout.Width(20));
        GUILayout.Label(mdef.ToString());
        GUILayout.EndHorizontal();
    }

    void InitializeStats()
    {
        if (placed < PlayerManager._instance._chosenTeam.Count && PlayerManager._instance._chosenTeam[placed] != null)
        {
            charName = PlayerManager._instance._chosenTeam[placed]._name;
            //charClass = unitFabs[placed].GetComponent<Character>()._characterClass._className;
            //lvl = unitFabs[placed].GetComponent<Character>()._characterClass._classLevel;

            hpMax = PlayerManager._instance._chosenTeam[placed]._maxHealth;
            mpMax = PlayerManager._instance._chosenTeam[placed]._maxMagic;

            patk = PlayerManager._instance._chosenTeam[placed]._physAttack;
            matk = PlayerManager._instance._chosenTeam[placed]._magicAttack;
            pdef = PlayerManager._instance._chosenTeam[placed]._physDefense;
            mdef = PlayerManager._instance._chosenTeam[placed]._magicDefense;



            //charName = unitFabs[placed].GetComponent<Character>()._name;
            ////charClass = unitFabs[placed].GetComponent<Character>()._characterClass._className;
            ////lvl = unitFabs[placed].GetComponent<Character>()._characterClass._classLevel;

            //hpMax = unitFabs[placed].GetComponent<Character>()._maxHealth;
            //mpMax = unitFabs[placed].GetComponent<Character>()._maxMagic;

            //patk = unitFabs[placed].GetComponent<Character>()._currPhysAttack;
            //matk = unitFabs[placed].GetComponent<Character>()._currMagicAttack;
            //pdef = unitFabs[placed].GetComponent<Character>()._currPhysDefense;
            //mdef = unitFabs[placed].GetComponent<Character>()._currMagicDefense;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // Place the character (left clic)
        {
            // cast a ray to check what the player "clicked" on. Only want to know 
            // about TILE clicks, so pass mask to check against layer for tiles only
            Ray ray = rayCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, tilesLayer))
            {
                // a tile gameobject was clicked on
                if (placed < PlayerManager._instance._chosenTeam.Count)
                {
                    // get the TileNode
                    TileNode node = hit.collider.GetComponent<TileNode>();
                    if (node == null) return; // sanity check

                    // dont spawn here if there is alrelady a unit on this tile
                    if (node.units.Count > 0) return;

                    // finally, spawn a unit on the tile
                    Character.SpawnUnit(unitFabs[placed], map, node);

                    placed++;
                    table.Add(unitFab);

                    string[] numbers = Regex.Split(node.name, @"\D+");
                    GameManager._instance._playerPositions.Add(int.Parse(numbers[1]));
                }
            }
            return;
        }
        else if (Input.GetMouseButtonUp(1))    // Remove the character (right clic)
        {
            // Cast a ray to check what the player "clicked" on. Only want to know 
            // about TILE clicks, so pass mask to check against layer for tiles only
            Ray ray = rayCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, tilesLayer))
            {
                if (placed > 0)
                {
                    // Get the TileNode
                    TileNode node = hit.collider.GetComponent<TileNode>();
                    if (node == null) return;   // Sanity check

                    // Don't remove if there's no unit there
                    if (node.units.Count == 0) return;

                    placed--;
                    table.Remove(unitFab);

                    string[] numbers = Regex.Split(node.name, @"\D+");
                    GameManager._instance._playerPositions.Remove(int.Parse(numbers[1]));

                    // Destroy the unit on the tile
                    Character.RemoveUnit(unitFabs[placed], node);
                }
            }
            return;
        }
    }

    private void InitializeEnemyUnits()
    {
        //BIDON, À MODIFIER AVEC LES INFOS DU SERVEUR

        CharacterInventory characterInvent = new CharacterInventory();

        GameManager._instance._enemyTeam[0] = Character.CreateCharacter("Grota", "Guerrier", 2, 3, 3, 5, 10, characterInvent, 20, 10, 0, 10);
        GameManager._instance._enemyTeam[1] = Character.CreateCharacter("Salty", "Mage", 1, 2, 1, 50, 50, characterInvent, 10, 10, 10, 10);
        GameManager._instance._enemyTeam[2] = Character.CreateCharacter("SnIP3r", "Archer", 1, 4, 4, 100, 10, characterInvent, 10, 10, 10, 10);
        GameManager._instance._enemyTeam[3] = Character.CreateCharacter("1337", "Prêtre", 1, 2, 1, 60, 40, characterInvent, 10, 10, 10, 10);

    }

    private void AddCharacterPrefab(int pos)
    {
        string classPrefab = "";

        switch (PlayerManager._instance._chosenTeam[pos]._characterClass._className)
        {
            case "Guerrier":
                classPrefab = "Prefabs/Sprites/Warrior" + PlayerManager._instance._playerSide.ToString();
                break;
            case "Prêtre":
                classPrefab = "Prefabs/Sprites/Priest" + PlayerManager._instance._playerSide.ToString();
                break;
            case "Mage":
                classPrefab = "Prefabs/Sprites/Mage" + PlayerManager._instance._playerSide.ToString();
                break;
            case "Archer":
                classPrefab = "Prefabs/Sprites/Archer" + PlayerManager._instance._playerSide.ToString();
                break;
        }
        unitFabs[pos] = Resources.Load(classPrefab, typeof(GameObject)) as GameObject;
    }
    private void AddEnemyPrefab(int pos)
    {
        string classPrefab = "";

        switch (GameManager._instance._enemyTeam[pos]._characterClass._className)
        {
            case "Guerrier":
                classPrefab = "Prefabs/Sprites/Warrior" + GameManager._instance._enemySide.ToString();
                break;
            case "Prêtre":
                classPrefab = "Prefabs/Sprites/Priest" + GameManager._instance._enemySide.ToString();
                break;
            case "Mage":
                classPrefab = "Prefabs/Sprites/Mage" + GameManager._instance._enemySide.ToString();
                break;
            case "Archer":
                classPrefab = "Prefabs/Sprites/Archer" + GameManager._instance._enemySide.ToString();
                break;
        }
        enemyFabs[pos] = Resources.Load(classPrefab, typeof(GameObject)) as GameObject;
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
            Application.LoadLevel("MainMenu");
        }
        if (GUILayout.Button("Non", GUILayout.Height(37)))
        {
            wantToQuit = false;
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(3);
    }
    // ====================================================================================================================
}
