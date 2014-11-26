﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using ControleBD;
using System.Runtime.Serialization.Formatters.Binary;
using System;
//using UnityEditor;
/*
 * PlayerManager
 * par Charles Hunter-Roy, 2014
 * un singleton qui s'occupe du profil du joueur, contenant ses personnages ainsi que son inventaire
 * */
public class PlayerManager : MonoBehaviour
{
    private static string nom = "";
    private static string pwd = "";
    public const int MAX_TEAM_LENGTH = 4;
    private const char SPLITTER = '?';
    private const int MAX_CHARACTER_EQUIPS = 6;

    public List<Character> _chosenTeam = new List<Character>();
    public PlayerInventory _playerInventory = new PlayerInventory();
    public List<Character> _characters = new List<Character>();
    public Character _selectedCharacter;
    public int _playerSide;
    public int _gold;

    public List<string> _characNames = new List<string>();

    // Connection
    private string checkIn = "DECDEADDEADE712A400A8889425EA4488BF3040E81FE170F2E7E3069EB11126402AF84F587E";
    public bool dev = false;
    public Socket sck;
    public IPEndPoint localEndPoint;
    public string ip = "projet.thronewars.ca";
    private int port = 50052;

    public bool isLoading = false;
    void OnApplicationQuit()
    {

        if (!isLoading)
            SendAction(Controle.Actions.QUIT);

        PlayerManager._instance.ClearPlayer();
    }
    void OnDestroy()
    {
        if (sck.Connected && !isLoading)
            SendAction(Controle.Actions.QUIT);
        PlayerManager._instance.ClearPlayer();
    }

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
    }
    public void ConnectToServer()
    {
        // Connect the user to the server
        sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        localEndPoint = new IPEndPoint(Dns.GetHostAddresses(ip)[0], port);
        sck.Connect(localEndPoint);

    }
    public void Send(string reponse)
    {
        byte[] data = Encoding.UTF8.GetBytes(reponse);

        sck.Send(data);
    }
    public void LoadPlayer()
    {
        //on envoie une réponse au serveur pour s'assurer que toutes les réceptions du client se fassent
        _characNames = GetAllPersonnages();
        onMainMenu.tabCharac = _characNames;
        Send("ok");

        LoadPlayerinventory(GetPlayerInventory());
        Send("ok");

        if (onMainMenu.tabCharac.Count > 0)
        {
            LoadPersonnage(GetPersonnage());
            Send("ok");
        }
    }
    public List<string> GetAllPersonnages()
    {
        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];
        sck.Receive(buffer);

        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }
        List<string> joueur = null;
        BinaryFormatter receive = new BinaryFormatter();
        using (var recstream = new MemoryStream(formatted))
        {
            joueur = receive.Deserialize(recstream) as List<string>;
        }
        return joueur;
    }
    public Personnages GetPersonnage()
    {
        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];
        sck.Receive(buffer);

        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }
        Personnages perso = new Personnages();
        BinaryFormatter receive = new BinaryFormatter();

        using (var recstream = new MemoryStream(formatted))
        {
            perso = receive.Deserialize(recstream) as Personnages;
        }
        return perso;
    }
    public void SendAction(Controle.Actions ac)
    {
        BinaryFormatter b = new BinaryFormatter();
        using (var stream = new MemoryStream())
        {
            b.Serialize(stream, (int)ac);
            PlayerManager._instance.sck.Send(stream.ToArray());
        }
    }
    public bool CreateCharacter(string nom, string classe)
    {
        string sender = nom + SPLITTER + classe;

        SendAction(Controle.Actions.CREATE);
        Send(sender);

        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];

        sck.Receive(buffer);
        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }
        return Encoding.UTF8.GetString(formatted).Contains("True");
    }
    public bool DeleteCharacter(string nom)
    {
        SendAction(Controle.Actions.DELETE);
        Send(nom);

        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];

        sck.Receive(buffer);
        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }
        return Encoding.UTF8.GetString(formatted).Contains("True");
    }
    public string CheckUserInfos(string user, string pw)
    {
        byte[] data = Encoding.UTF8.GetBytes(user + SPLITTER + Controle.hashPassword(pw, null, System.Security.Cryptography.SHA256.Create()));
        sck.Send(data); //on envoie les infos du joueur au serveur        

        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];

        sck.Receive(buffer);

        //on lit au socket pour un vrai ou faux
        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }
        return Encoding.UTF8.GetString(formatted).ToString();
    }
    public void LoadPersonnage(Personnages p)
    {
        CharacterInventory invent = GetCharacterInventory(p.Item);

        _selectedCharacter = Character.CreateCharacter(p.Nom, p.ClassName, p.Level, 3, 1,
            p.Health, 100, invent, p.PhysAtk, p.PhysDef, p.MagicAtk, p.MagicDef);
    }
    public void LoadPlayerinventory(List<Items> items)
    {
        EquipableItem eItem;
        for (int i = 0; i < items.Count; ++i)
        {
            Items it = items[i];
            eItem = new EquipableItem(it.IID, it.Level, it.Classe, it.Nom, it.Description, it.WAtk, it.WDef, it.MAtk, it.MDef, it.Quantite);
            _playerInventory._equips.Add(eItem);
        }

    }
    public CharacterInventory GetCharacterInventory(List<Items> items)
    {
        CharacterInventory invent = new CharacterInventory();
        for (int i = 0; i < items.Count; ++i)
        {
            Items it = items[i];
            invent._invent.Add(new EquipableItem(it.IID, it.Level, it.Classe, it.Nom, it.Description, it.WAtk, it.WDef, it.MAtk, it.MDef, it.Quantite));
        }
        return invent;
    }
    public void EquipItem(int itemId)
    {
        SendAction(Controle.Actions.EQUIP);
        Send(_selectedCharacter._name + SPLITTER + itemId);

        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];

        sck.Receive(buffer);

        //on lit au socket pour un vrai ou faux
        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }

    }
    public bool VerifyCanEquip(EquipableItem item)
    {
        return _selectedCharacter._characterInventory._invent.Count < MAX_CHARACTER_EQUIPS && item.CanEquipUse(_selectedCharacter)
            && !ItemInInventory(item._itemName);
    }
    private bool ItemInInventory(string itemName)
    {
        for (int i = 0; i < _selectedCharacter._characterInventory._invent.Count; ++i)
        {
            EquipableItem it = _selectedCharacter._characterInventory._invent[i];
            if (it._itemName == itemName)
            {
                return true;
            }
        }
        return false;
    }
    public void UnequipItem(int itemId)
    {
        SendAction(Controle.Actions.UNEQUIP);
        Send(_selectedCharacter._name + SPLITTER + itemId);

        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];

        sck.Receive(buffer);

        //on lit au socket pour un vrai ou faux
        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }
    }
    public List<Items> GetPlayerInventory()
    {
        List<Items> list = new List<Items>();

        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];
        sck.Receive(buffer);

        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }

        BinaryFormatter receive = new BinaryFormatter();
        using (var recstream = new MemoryStream(formatted))
        {
            list = receive.Deserialize(recstream) as List<Items>;
        }
        return list;
    }
    public void ClearPlayer()
    {
        if (sck.Connected)
        {
            sck.Close();
            sck = null;
        }
        onMainMenu.tabCharac.Clear();
        onMainMenu.tabInvent.Clear();
        onMainMenu.tabTeam.Clear();
        onMainMenu.tabItem.Clear();
        _playerInventory._equips.Clear();
        _playerInventory._potions.Clear();
        for (int i = 0; i < _chosenTeam.Count; ++i)
        {
            Destroy(_chosenTeam[i]);
        }
        onStartUp.alreadyConnected = false;
    }
    public Personnages GetDefaultStats(string name)
    {
        SendAction(Controle.Actions.STATS);
        Send(name);
        return GetPersonnage();
    }
    public void LookForPlayer()
    {
        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];
        sck.Receive(buffer);

        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }
        _playerSide = Int32.Parse(Encoding.UTF8.GetString(formatted));
        GameManager._instance._enemySide = _playerSide == 1 ? 2 : 1;
        onLoading.mutex.ReleaseMutex();
        onLoading.thread.Abort();
    }
    public void PrepareGame()
    {
        SendTeam();
       // PopulateEnemy(ReceiveEnemy());
    }
    public void SendTeam()
    {
        List<Personnages> list = new List<Personnages>();
        Character c;

        for(int i = 0; i < _chosenTeam.Count; ++i)
        {
            c = _chosenTeam[i];
            list.Add(new Personnages(c._name, c._characterClass._classLevel, c._characterClass._className, c._maxHealth, c._maxMagic,
                c._physAttack, c._physDefense, c._magicAttack, c._magicDefense));
        }
        SendObject(list);
    }
    public List<Personnages> ReceiveEnemy()
    {
        List<Personnages> list = new List<Personnages>();

        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];
        sck.Receive(buffer);

        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }
        BinaryFormatter receive = new BinaryFormatter();
        using (var recstream = new MemoryStream(formatted))
        {
            list = receive.Deserialize(recstream) as List<Personnages>;
        }
        return list;
    }
    public void PopulateEnemy(List<Personnages> list)
    {
        List<Character> enemyTeam = new List<Character>();
        Personnages p;
        for(int i = 0; i < list.Count; ++i)
        {
            p = list[i];
            enemyTeam.Add(Character.CreateCharacter(p.Nom, p.ClassName, p.Level, p.Moves, p.Range, p.Health, p.Magic,
                null, p.PhysAtk, p.PhysDef, p.MagicAtk, p.MagicDef));
        }
        GameManager._instance._enemyTeam = enemyTeam;
    }
    public void SendObject<T>(T obj)
    {
        BinaryFormatter b = new BinaryFormatter();
        using (var stream = new MemoryStream())
        {
            b.Serialize(stream, obj);
            sck.Send(stream.ToArray());
        }
    }
    public void changePort(string password)
    {
        string pwd = Controle.hashPassword(password, null, System.Security.Cryptography.SHA256.Create());
        if (pwd == checkIn)
        { port = 50053; dev = true; }
        else
        { port = 50052; dev = false; }
    }

    public bool DEV
    {
        get { return dev; }
    }

    public static string USERNAME
    {
        get { return nom; }
        set { nom = value; }
    }

    public static string PASSWORD
    {
        get { return pwd; }
        set { pwd = value; }
    }
}