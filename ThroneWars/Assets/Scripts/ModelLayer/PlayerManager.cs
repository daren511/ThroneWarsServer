using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ControleBD;
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
    public int port = 50052;


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
        byte[] data = Encoding.ASCII.GetBytes(reponse);

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

        Personnages p = GetPersonnage();
        LoadPersonnage(p);
        Send("ok");
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
    public string CheckPasswordUser(string user, string pw)
    {
        byte[] data = Encoding.ASCII.GetBytes(user + SPLITTER + Controle.HashPassword(pw, null, System.Security.Cryptography.SHA256.Create()));
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
        return Encoding.ASCII.GetString(formatted).ToString();
    }


    public void LoadPersonnage(Personnages p)
    {
        PlayerManager._instance._selectedCharacter = Character.CreateCharacter(p.Nom, p.ClassName, p.Level, 3, 1,
            p.Health, 100, null, p.PhysAtk, p.PhysDef, p.MagicAtk, p.MagicDef);
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
}
