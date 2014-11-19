using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using ControleBD;
using System.Runtime.Serialization.Formatters.Binary;
/*
 * PlayerManager
 * par Charles Hunter-Roy, 2014
 * un singleton qui s'occupe du profil du joueur, contenant ses personnages ainsi que son inventaire
 * */
public class PlayerManager : MonoBehaviour
{
    private const int MAX_TEAM_LENGTH = 4;
    private const char SPLITTER = '?';

    public Character[] _chosenTeam { get; set; }
    public PlayerInventory _playerInventory = new PlayerInventory();
    public List<Character> _characters = new List<Character>();
    public Character _selectedCharacter;
    public int _playerSide;
    public int _gold;

    // Connection
    public Socket sck;
    public IPEndPoint localEndPoint;
    public string ip = "bd.thronewars.ca";
    public int port = 50053;


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
        List<string> charNames = GetAllPersonnages();
        onMainMenu.tabCharac = charNames;
        Send("ok");

        List<Items> list = GetPlayerInventory();
        LoadPlayerinventory(list);
        Send("ok");

        if(onMainMenu.tabCharac.Count > 0)
        {
            Personnages p = GetPersonnage();
            LoadPersonnage(p);
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
        byte[] data = Encoding.ASCII.GetBytes(user + SPLITTER + Controle.hashPassword(pw, null, System.Security.Cryptography.SHA256.Create()));
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
        CharacterInventory invent = GetCharacterInventory(new List<Items>());

        PlayerManager._instance._selectedCharacter = Character.CreateCharacter(p.Nom, p.ClassName, p.Level, 3, 1,
            p.Health, 100, invent, p.PhysAtk, p.PhysDef, p.MagicAtk, p.MagicDef);
    }
    public void LoadPlayerinventory(List<Items> items)
    {
        EquipableItem eItem;
        for (int i = 0; i < items.Count; ++i)
        {
            Items it = items[i];
            eItem = new EquipableItem(it.Level, it.Classe, it.Nom, it.Description, it.WAtk, it.WDef, it.MAtk, it.MDef, it.Quantite);
            PlayerManager._instance._playerInventory._equips.Add(eItem);
        }

    }
    public CharacterInventory GetCharacterInventory(List<Items> items)
    {
        CharacterInventory invent = new CharacterInventory();

        for (int i = 0; i < items.Count; ++i )
        {
            Items it = items[i];
            invent._invent.Add(new EquipableItem(it.Level, it.Classe, it.Nom, it.Description, it.WAtk, it.WDef, it.MAtk, it.MDef, it.Quantite));
        }
        return invent;
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

    public CharacterInventory GetCharacterInventory(int pos)
    {
        CharacterInventory characterInvent = new CharacterInventory();

        for (int i = 0; i < PlayerManager._instance._characters[i]._characterInventory._invent.Count; ++i)
        {
            characterInvent._invent.Add(PlayerManager._instance._characters[i]._characterInventory._invent[i]);
        }
        return characterInvent;
    }
    private string GetCharacterClass(int id)
    {
        string classe = "";
        switch (id)
        {
            case 1:
                classe = "Guerrier";
                break;
            case 2:
                classe = "Archer";
                break;
            case 3:
                classe = "Mage";
                break;
            case 4:
                classe = "Prêtre";
                break;
        }
        return classe;
    }
    private int GetCharacterClassId(string classe)
    {
        int id = 0;
        switch (classe)
        {
            case "Guerrier":
                id = 1;
                break;
            case "Archer":
                id = 2;
                break;
            case "Mage":
                id = 3;
                break;
            case "Prêtre":
                id = 4;
                break;
        }
        return id;
    }
}
