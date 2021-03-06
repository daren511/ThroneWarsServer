// ====================================================================================================================
//
// Created by Leslie Young
// http://www.plyoung.com/ or http://plyoung.wordpress.com/
// ====================================================================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ControleBD;
using System.Threading;

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

    public static Thread thread;
    private bool doneWaiting = false;
    private bool isLoading = false;
    private bool hasWon = false;

    ///statistiques pour une instanciation des GameObject de type Character
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
    // Loading window
    private static float wL = 275.0f;
    private static float hL = 115.0f;
    private static Rect rectLoading = new Rect((Screen.width - wL) / 2, (Screen.height - hL) / 2, wL, hL);
    // Winning window
    private static float wW = 275.0f;
    private static float hW = 115.0f;
    private static Rect rectWinning = new Rect((Screen.width - wW) / 2, (Screen.height - hW) / 2, wW, hW);

    private Rect _containerBox = new Rect(Screen.width - 150, 0, 150, Screen.height - 50);
    private Rect rectPlay = new Rect(Screen.width / 3, Screen.height - 50, Screen.width / 3, 50);

    IEnumerator Start()
    {
        /// wait for a frame for everything else to start and then enable the colliders for the TileNodes
        yield return null;

        ///d�marrer le thread qui �coutera au serveur si l'autre joueur � fini de placer/ � quitter la partie
        ListenServer();
        for (int i = 0; i < PlayerManager._instance._chosenTeam.Count; ++i)
        {
            AddCharacterPrefab(i);
        }

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
        if (!isLoading && !hasWon)
            GUILayout.Window(2, rectPlay, doPlayWindow, "", GUIStyle.none);

        if (!isLoading && !hasWon)
        {
            if (GUI.Button(new Rect(Screen.width - 150, Screen.height - 50, 150, 50), "Quitter"))
                wantToQuit = true;
        }
        if (wantToQuit)
            GUILayout.Window(0, rectQuit, doQuitWindow, "Quitter");
        if (isLoading)
            GUILayout.Window(-1, rectLoading, doLoadingWindow, "En attente");
        if (hasWon)
            GUILayout.Window(-10, rectWinning, doWinningWindow, "Victoire!");

        //flag thread
        if (!PlayerManager._instance.isWaitingPlayer && !doneWaiting && !wantToQuit && !hasWon)
        {
            doneWaiting = true;

            ///si l'adversaire a termin�, on commence la partie
            if (!PlayerManager._instance.hasWonDefault)
            {
                StartGame();
            }
            else
            {
                ///l'adversaire a abandonn� la partie, le joueur a gagn�
                hasWon = true;
            }
        }
    }
    private void StartGame()
    {
        ///les personnages de l'adversaire pour la partie
        GameManager._instance.PopulateEnemy(PlayerManager._instance.ReceiveObject<Personnages>());
        PlayerManager._instance.SendObject(Controle.Game.OK);

        ///les positions des personnages de l'adversaire
        GameManager._instance._enemyPositions = PlayerManager._instance.ReceiveObject<int>();
        PlayerManager._instance.SendObject(Controle.Game.OK);

        ///les potions du joueur
        PlayerManager._instance.LoadPlayerPotions(PlayerManager._instance.ReceiveObject<Potions>());
        PlayerManager._instance.SendObject(Controle.Game.OK);

        for (int i = 0; i < GameManager._instance._enemyTeam.Count; ++i)
        {
            AddEnemyPrefab(i);
        }
        ///on affecte les unit�s aux �quipes respectives
        GameController.unitsFabs = unitFabs;
        GameController.enemyFabs = enemyFabs;
        ///destruction des instanciations de type Character de la sc�ne de placement

        StartCoroutine(DestroyPrefabs());
        ///on charge la sc�ne de jeu
        Application.LoadLevel(scene);
    }
    IEnumerator DestroyPrefabs()
    {
        yield return new WaitForSeconds(0.5f);
        Object[] allObjects = FindObjectsOfType(typeof(Character));
        for (int i = 0; i < allObjects.Length; ++i)
        {
            Destroy(allObjects[i], 0);
        }
        yield return new WaitForSeconds(0.5f);
    }
    private void CleanScene()
    {
        doneWaiting = false;
        isLoading = false;
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

        if (GUILayout.Button("D�marrer"))
        {
            PlayerManager._instance.SendObject(Controle.Game.SENDPOSITIONS);
            //envoi des positions de l'�quipe choisie par le joueur
            PlayerManager._instance.SendObject<List<int>>(GameManager._instance._playerPositions);

            //splash screen en attente de l'autre joueur 
            isLoading = true;
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
            hpMax = PlayerManager._instance._chosenTeam[placed]._maxHealth;
            mpMax = PlayerManager._instance._chosenTeam[placed]._maxMagic;
            patk = PlayerManager._instance._chosenTeam[placed]._physAttack;
            matk = PlayerManager._instance._chosenTeam[placed]._magicAttack;
            pdef = PlayerManager._instance._chosenTeam[placed]._physDefense;
            mdef = PlayerManager._instance._chosenTeam[placed]._magicDefense;
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

    private void ListenServer()
    {
        thread = new Thread(new ThreadStart(PlayerManager._instance.PlacementScreen));
        thread.Start();
    }

    private void AddCharacterPrefab(int pos)
    {
        string classPrefab = "";

        switch (PlayerManager._instance._chosenTeam[pos]._characterClass._className)
        {
            case "Guerrier":
                classPrefab = "Prefabs/Sprites/Warrior" + PlayerManager._instance._playerSide.ToString();
                break;
            case "Pr�tre":
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
            case "Pr�tre":
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
        GUILayout.Label("�tes-vous certain de vouloir quitter?");
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Vous allez perdre la partie.");
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUILayout.Space(7);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Oui", GUILayout.Height(37)))
        {
            DestroyUnits();
            PlayerManager._instance.ClearPlayer(false);
            CleanScene();
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

    private void doLoadingWindow(int windowID)
    {
        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.Label("En attente du joueur adverse...");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Quitter", GUILayout.Height(37)))
            wantToQuit = true;
        GUILayout.EndHorizontal();
        GUILayout.Space(3);
    }

    private void doWinningWindow(int windowID)
    {
        GUI.BringWindowToFront(windowID);
        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Votre adversaire a quitt� la partie, vous avez gagn�!");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Retour au menu principal", GUILayout.Height(37)))
        {
            DestroyUnits();
            CleanScene();
            PlayerManager._instance.ClearPlayer(false);
            PlayerManager._instance.LoadPlayer();
            Application.LoadLevel("MainMenu");
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(3);
    }

    /// <summary>
    /// Destroy the remaining units
    /// </summary>
    private void DestroyUnits()
    {
        int index = 0;
        foreach (TileNode n in map.nodes)
        {
            if (n != null)
            {
                if (n.units.Count > 0 && index >= 0)
                {
                    Character.RemoveUnit(unitFabs[index], n);
                    index++;
                }
            }
        }
    }
    // ====================================================================================================================
}
