﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * PlayerManager
 * par Charles Hunter-Roy, 2014
 * un singleton qui s'occupe du profil du joueur, contenant ses personnages ainsi que son inventaire
 * */
public class GameManager : MonoBehaviour
{
    public List<int> _playerPositions = new List<int>();
    public List<int> _enemyPositions = new List<int>();


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
}
