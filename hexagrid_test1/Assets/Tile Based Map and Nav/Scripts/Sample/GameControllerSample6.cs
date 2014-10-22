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

    private int placed = 0;
    List<GameObject> table = new List<GameObject>();

    private Rect _containerBox = new Rect(Screen.width / 2 - (Screen.width / 2), Screen.height / 2 + 100, Screen.width, 150);
    private Rect _buttonGO;
    IEnumerator Start()
    {
        // wait for a frame for everything else to start and then enable the colliders for the TielNodes
        yield return null;


        for (int i = 0; i < PlayerManager._instance._chosenTeam.Length; ++i)
        {
            AddCharacterPrefab(i);
        }
        InitializeEnemyUnits();
        for (int i = 0; i < GameManager._instance._enemyTeam.Length; ++i)
        {
            AddEnemyPrefab(i);
        }

        _buttonGO = new Rect(_containerBox.x + _containerBox.width - 150, _containerBox.y, 150, 150);
        // now enable the colliders of the TileNodes.
        // they are disabled by default, but for this sample to work I need the player to be able to click on any tile.
        // for your game you will have to decide when the best time would be to this or even which tiles would be
        // best to enable. For example, you might only want to spawn new units around some building, so only
        // enable the the tiles around the building so that the player cannot click on other tiles and disable 
        // the tiles whne yo uare done with them

        foreach (TileNode n in map.nodes)
        {
            n.collider.enabled = true;
        }
        map.ShowAllTileNodes(true);
    }

    void OnGUI()
    {
        GUI.enabled = placed == PlayerManager._instance._chosenTeam.Length;
        // Make a background box
        GUI.Box(_containerBox, "");
        if (GUI.Button(_buttonGO, "Démarrer la partie"))
        {
            Object[] allObjects = FindObjectsOfType(typeof(Character));

            for (int i = 0; i < allObjects.Length; ++i)
            {
                Destroy(allObjects[i]);
            }
            GameController.unitsFabs = unitFabs;
            GameController.enemyFabs = enemyFabs;
            Application.LoadLevel("test2");
        }

    }
    void Update()
    {
        // don;t do anything else if there was not a jouse click
        if (!Input.GetMouseButtonUp(0)) return;

        // cast a ray to check what the player "clicked" on. Only want to know 
        // about TILE clicks, so pass mask to check against layer for tiles only
        Ray ray = rayCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1500f, tilesLayer))
        {
            // a tile gameobject was clicked on
            if (placed < PlayerManager._instance._chosenTeam.Length)
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
    }

    private void InitializeEnemyUnits()
    {


        //BIDON, À MODIFIER AVEC LES INFOS DU SERVEUR

        CharacterInventory characterInvent = new CharacterInventory();

        GameManager._instance._enemyTeam[0] = Character.CreateCharacter("Grota", "Guerrier", 2, 3, 3, 100, 10, characterInvent, 20, 10, 0, 10);
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
    // ====================================================================================================================
}
