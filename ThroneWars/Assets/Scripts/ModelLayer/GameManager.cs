using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * PlayerManager
 * par Charles Hunter-Roy, 2014
 * un singleton qui s'occupe du profil du joueur, contenant ses personnages ainsi que son inventaire
 * */
public class GameManager : MonoBehaviour
{
    const int MAX_TEAM_LENGTH = 4;

    public List<int> _playerPositions = new List<int>();
    public List<int> _enemyPositions = new List<int>();

    public Character[] _enemyTeam { get; set; }
    public int _enemySide;
    private static GameManager instance = null;
    public static GameManager _instance
    {
        get
        {
            if (instance == null)
            {
                instance = (GameManager)FindObjectOfType(typeof(GameManager));
                if (instance == null)
                    instance = (new GameObject("GameManager")).AddComponent<GameManager>();
            }
            return instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
        _enemyTeam = new Character[MAX_TEAM_LENGTH];
        instance = this;
    }
}
