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
    public MapNav map;			// the mapnav
    public LayerMask tilesLayer;// layer the tiles are on

    private int placed = 0;
    List<GameObject> table = new List<GameObject>();

    private Rect _containerBox = new Rect(Screen.width / 2 - (Screen.width / 2), Screen.height / 2 + 100, Screen.width, 150);
    private Rect _buttonGO = new Rect(Screen.width / 2 + 100, Screen.height / 2 + 100, 150, 50);
    IEnumerator Start()
    {
        // wait for a frame for everything else to start and then enable the colliders for the TielNodes
        yield return null;

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
    }

    void OnGUI()
    {
        GUI.enabled = placed == PlayerManager._instance._characters.Length;
        // Make a background box
        GUI.Box(_containerBox, "");
        if (GUI.Button(_buttonGO, "D�marrer la partie"))
        {
            Object[] allObjects = FindObjectsOfType(typeof(Character));

            for (int i = 0; i < allObjects.Length; ++i )
            {
                Destroy(allObjects[i]);
            }
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
            if (placed < PlayerManager._instance._characters.Length)
            {
                // get the TileNode
                TileNode node = hit.collider.GetComponent<TileNode>();
                if (node == null) return; // sanity check

                // dont spawn here if there is alrelady a unit on this tile
                if (node.units.Count > 0) return;

                // finally, spawn a unit on the tile
                Character.SpawnUnit(unitFab, map, node);
                placed++;
                table.Add(unitFab);

                string[] numbers = Regex.Split(node.name, @"\D+");
                GameManager._instance._playerPositions.Add(int.Parse(numbers[1]));
            }
        }
    }

    // ====================================================================================================================
}
