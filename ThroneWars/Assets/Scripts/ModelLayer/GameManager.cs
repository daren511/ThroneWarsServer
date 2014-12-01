using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ControleBD;
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

    public List<Character> _enemyTeam = new List<Character>();
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
        instance = this;
    }
    public void PopulateEnemy(List<Personnages> list)
    {
        List<Character> enemyTeam = new List<Character>();
        CharacterInventory invent = new CharacterInventory();
        Personnages p;
        for (int i = 0; i < list.Count; ++i)
        {
            p = list[i];
            enemyTeam.Add(Character.CreateCharacter(p.Nom, p.ClassName, p.Level, p.Moves, p.Range, p.Health, p.Magic,
                invent, p.PhysAtk, p.PhysDef, p.MagicAtk, p.MagicDef));
        }
        _enemyTeam = enemyTeam;
    }
    public void ClearEnemy()
    {
        _playerPositions.Clear();
        _enemyPositions.Clear();
        for (int i = 0; i < _enemyTeam.Count; ++i)
        {
            Destroy(_enemyTeam[i]);
        }
        _enemyTeam.Clear();
    }
}
