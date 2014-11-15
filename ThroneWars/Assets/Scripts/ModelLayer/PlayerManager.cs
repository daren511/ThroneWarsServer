using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * PlayerManager
 * par Charles Hunter-Roy, 2014
 * un singleton qui s'occupe du profil du joueur, contenant ses personnages ainsi que son inventaire
 * */
public class PlayerManager : MonoBehaviour
{
    private const int MAX_TEAM_LENGTH = 4;

    public Character[] _chosenTeam { get; set; }
    public PlayerInventory _playerInventory;
    public List<Character> _characters = new List<Character>();
    public Character _selectedCharacter;
    public int _playerSide;
    public int _gold;

    //singleton
    private static PlayerManager instance = null;
    public static PlayerManager _instance
    {
        get
        {
            if (instance == null)
            {
                instance = (PlayerManager)FindObjectOfType(typeof(PlayerManager));
                if (instance == null)
                    instance = (new GameObject("PlayerManager")).AddComponent<PlayerManager>();
            }
            return instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
        _chosenTeam = new Character[MAX_TEAM_LENGTH];
    }
}
