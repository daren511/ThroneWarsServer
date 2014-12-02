using UnityEngine;
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
 * par Charles Hunter-Roy, Alexis Lalonde; 2014
 * 
 * 
 * un singleton qui s'occupe du profil du joueur, contenant ses personnages ainsi que son inventaire
 * 
 * 
 *  * IMPORTANT: Ce singleton  contient le canal de communication avec le serveur, à optimiser 
 * */
public class PlayerManager : MonoBehaviour
{
    #region Constants
    public const int MAX_TEAM_LENGTH = 4;
    public const char SPLITTER = '?';
    private const int MAX_CHARACTER_EQUIPS = 6;
    #endregion
    #region Player parameters
    public List<Character> _chosenTeam = new List<Character>();
    public PlayerInventory _playerInventory = new PlayerInventory();
    public List<Character> _characters = new List<Character>();
    public Character _selectedCharacter;
    public int _playerSide;
    public int _gold;
    #endregion

    public List<string> _characNames = new List<string>();

    #region Connection parameters
    /// Connexion
    private string checkIn = "DECDEADDEADE712A400A8889425EA4488BF3040E81FE170F2E7E3069EB11126402AF84F587E";
    public bool dev = false;
    public Socket sck;
    public IPEndPoint localEndPoint;
    public string ip = "projet.thronewars.ca";
    private int port = 50052;
    private static string nom = "";
    private static string pwd = "";
    #endregion

    #region Interface parameters
    public bool isLoading = false;
    public bool isWaitingPlayer = false;
    public bool hasWonDefault = false;
    public bool isInGame = false;

    #endregion

    /// in game
    public bool isAFK = false;

    public bool enemyAttack = false;
    public bool enemyMove = false;
    public bool enemyItem = false;
    public bool enemyDone = false;

    public string _activeEnemyName;

    //la tuile de destination, pour les mouvements
    public string _destinationNodeNumber;

    //la cible, pour le combat
    public string _activeTargetUnit;
    //les dégâts infligés, pour le combat
    public int _damageDealt;

    //le nom de l'item
    public string _itemName;

    void OnApplicationQuit()
    {
        if (sck.Connected && !isLoading && !isInGame)
            SendObject(Controle.Actions.QUIT);
        else if (sck.Connected && isInGame)
            SendObject(Controle.Game.QUIT);

        PlayerManager._instance.ClearPlayer();
    }
    void OnDestroy()
    {
        if (sck.Connected && !isLoading && !isInGame)
            SendObject(Controle.Actions.QUIT);
        else if (sck.Connected && isInGame)
            SendObject(Controle.Game.QUIT);
        PlayerManager._instance.ClearPlayer();
    }

    ///L'instance interne du singleton
    private static PlayerManager instance = null;
    /// <summary>
    /// L'instance publique du singleton, si elle n'existe pas, la crée
    /// </summary>
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

    #region Server communication
    /// <summary>
    /// Crée un nouveau cannal de communication avec le serveur de ThroneWars
    /// </summary>
    public void ConnectToServer()
    {
        // Connect the user to the server
        sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        localEndPoint = new IPEndPoint(Dns.GetHostAddresses(ip)[0], port);
        sck.Connect(localEndPoint);
    }
    /// <summary>
    /// Envoi un message au serveur
    /// </summary>
    /// <param name="reponse">Une chaîne de caractères à envoyer</param>
    public void Send(string reponse)
    {
        byte[] data = Encoding.UTF8.GetBytes(reponse);
        sck.Send(data);
    }
    /// <summary>
    /// Charge les paramètres du joueur, on envoi un message de confirmation entre chaque obtention
    /// </summary>
    public void LoadPlayer()
    {

        ///on reçoit les noms des personnages du joueur
        _characNames = ReceiveObject<string>();
        onMainMenu.tabCharac = _characNames;//optimiser: on affecte les noms qui seront affichés on menu principal dans une autre classe
        Send("ok");

        ///on charge l'inventaire du joueur
        LoadPlayerEquipement(ReceiveObject<Items>());
        Send("ok");

        ///charge le personnage choisi
        if (onMainMenu.tabCharac.Count > 0)//optimiser ici aussi
        {
            LoadPersonnage(GetPersonnage());
            Send("ok");
        }
    }
    /// <summary>
    /// Récupère le personnage qui est sélectionné
    /// </summary>
    /// <returns>Un personnage de contrôle</returns>
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
    /// <summary>
    /// Envoi une requête de création de personnage au serveur
    /// </summary>
    /// <param name="nom">Le nom du personnage</param>
    /// <param name="classe">La classe du personnage</param>
    /// <returns>Si le nom est valide</returns>
    public bool SendCreateCharacter(string nom, string classe)
    {
        string sender = nom + SPLITTER + classe;

        SendObject(Controle.Actions.CREATE);
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
    /// <summary>
    /// Envoi une requête de suppression de personnage au serveur
    /// </summary>
    /// <param name="nom">Le nom du personnage à supprimer</param>
    /// <returns>Si le personnage à bien été supprimé</returns>
    public bool SendDeleteCharacter(string nom)
    {
        SendObject(Controle.Actions.DELETE);
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
    /// <summary>
    /// Vérifie le joueur peut se connecter, une chaine protocolisée d'ordre (mot de passe/usager valide, compte confirmé, compte déjà connecté)
    /// Important: chacun des booléens reçus sont séparés par la constante SPLITTER
    /// 
    /// ex: True?True?False signifie que le joueur peut bien se connecter,
    ///     True?False      signifie que le compte n'est pas confirmé,
    ///     False           signifie que les informations entrées n'étaient pas valides
    /// </summary>
    /// <param name="user">L'alias du joueur</param>
    /// <param name="pw">Le mot de passe du joueur</param>
    /// <returns>Une chaîne protocole </returns>
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
    #endregion
    /// <summary>
    /// Crée un objet de type Character, qui sera utilisé pour le jeu
    /// </summary>
    /// <param name="p">Un personnage</param>
    public void LoadPersonnage(Personnages p)
    {
        CharacterInventory invent = ReturnCharacterInventory(p.Item);

        _selectedCharacter = Character.CreateCharacter(p.Nom, p.ClassName, p.Level, 3, 1,
            p.Health, 100, invent, p.PhysAtk, p.PhysDef, p.MagicAtk, p.MagicDef);
    }
    /// <summary>
    /// Équipe l'inventaire d'équipements du joueur
    /// </summary>
    /// <param name="items">Une liste d'équipements à ajouter au joueur</param>
    public void LoadPlayerEquipement(List<Items> items)
    {
        EquipableItem eItem;
        for (int i = 0; i < items.Count; ++i)
        {
            Items it = items[i];
            eItem = new EquipableItem(it.IID, it.Level, it.Classe, it.Nom, it.Description, it.WAtk, it.WDef, it.MAtk, it.MDef, it.Quantite);
            _playerInventory._equips.Add(eItem);
        }
    }
    public void LoadPlayerPotions(List<Potions> list)
    {
        Potions pot;
        Potion newPot;
        for (int i = 0; i < list.Count; ++i)
        {
            pot = list[i];
            newPot = new Potion(pot.pid, -1, 1, "Tous", pot.name, pot.description, pot.duration, pot.quantity,
                pot.WAtk, pot.WDef, pot.MAtk, pot.MDef, pot.healthRestore);
            _playerInventory._potions.Add(newPot);
        }
    }

    /// <summary>
    /// Retourne un équipement pour un objet de type Character
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public CharacterInventory ReturnCharacterInventory(List<Items> items)
    {
        CharacterInventory invent = new CharacterInventory();
        for (int i = 0; i < items.Count; ++i)
        {
            Items it = items[i];
            invent._invent.Add(new EquipableItem(it.IID, it.Level, it.Classe, it.Nom, it.Description, it.WAtk, it.WDef, it.MAtk, it.MDef, it.Quantite));
        }
        return invent;
    }
    /// <summary>
    /// Envoie une requête pour équiper un objet au personnage choisi
    /// </summary>
    /// <param name="itemId">l'id de l'item</param>
    public void SendEquipItem(int itemId)
    {
        SendObject(Controle.Actions.EQUIP);
        Send(_selectedCharacter._name + SPLITTER + itemId);

        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];

        //on lit au socket pour un vrai ou faux
        sck.Receive(buffer);

        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }
    }
    /// <summary>
    /// On vérifie si le personnage peut équiper l'item. 
    /// (Si l'ajout entre dans les limites de l'inventaire du personnage,
    /// si le personnage est de la classe ainsi que du niveau du personnage,
    /// ainsi que si l'item n'est pas déjà présent dans l'inventaire du joueur)
    /// </summary>
    /// <param name="item">l'item que l'on veut équipper</param>
    /// <returns>Si l'on peut équiper l'item</returns>
    public bool VerifyCanEquip(EquipableItem item)
    {
        return _selectedCharacter._characterInventory._invent.Count < MAX_CHARACTER_EQUIPS && item.CanEquipUse(_selectedCharacter)
            && !ItemInInventory(item._itemName);
    }
    /// <summary>
    /// On vérifie si l'item donné n'est pas déjà dans l'inventaire du personnage sélectionné
    /// </summary>
    /// <param name="itemName">Le nom de l'item</param>
    /// <returns>Si l'objet est déjà dans l'inventaire</returns>
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

    /// <summary>
    /// Envoi une requête de retrait d'item de l'inventaire du personnage choisi au serveur
    /// </summary>
    /// <param name="itemId">l'id de l'item</param>
    public void SendUnequipItem(int itemId)
    {
        SendObject(Controle.Actions.UNEQUIP);
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
    /// <summary>
    /// On nettoie l'interface, les paramètres du joueur et on détruit ses personnages.
    /// </summary>
    /// <param name="closeSocket">Si on veut fermer le canal de communication</param>
    public void ClearPlayer(bool closeSocket = true)
    {
        ///fermeture du canal de communication
        if (closeSocket && sck.Connected)
        {
            sck.Close();
            sck = null;
        }
        ///nettoyage des tableaux liés à l'interface
        onMainMenu.tabCharac.Clear();
        onMainMenu.tabInvent.Clear();
        onMainMenu.tabTeam.Clear();
        onMainMenu.tabItem.Clear();

        ///nettoyage de l'inventaire du joueur
        _playerInventory._equips.Clear();
        _playerInventory._potions.Clear();

        isLoading = false;
        isWaitingPlayer = false;
        hasWonDefault = false;
        isInGame = false;

        ///destruction des instances des objets de type Character
        for (int i = 0; i < _chosenTeam.Count; ++i)
        {
            Destroy(_chosenTeam[i]);
        }
        _chosenTeam.Clear();
        ///
        onStartUp.alreadyConnected = false;
    }
    /// <summary>
    /// Récupère les statistiques de départ pour un personnage donné.
    /// </summary>
    /// <param name="name">Le nom de la classe</param>
    /// <returns>Un personnage initialisé seulement qu'avec les caractéristiques: (Health, PhysAtk, PhysDef, MagAtk, MagDef)</returns>
    public Personnages GetDefaultStats(string name)
    {
        SendObject(Controle.Actions.STATS);
        Send(name);
        return GetPersonnage();
    }

    #region Scenes methods
    /// <summary>
    /// Cette méthode est appellée par un thread lorsque l'on attend un autre joueur pour commencer la partie.
    /// </summary>
    public void WaitingForPlayerScreen()
    {
        int count = sck.ReceiveBufferSize;
        byte[] buffer = new byte[count];
        sck.Receive(buffer);

        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }

        _playerSide = Int32.Parse(Encoding.UTF8.GetString(formatted));
        isLoading = false;
        isInGame = true;
        onLoading.thread.Abort();
    }
    /// <summary>
    /// Cette méthode est appellée par un thread lors de l'écran de placement des personnages.
    /// </summary>
    public void PlacementScreen()
    {
        int count = sck.ReceiveBufferSize;
        byte[] buffer = new byte[count];
        sck.Receive(buffer);

        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }

        Controle.Game action;

        BinaryFormatter receive = new BinaryFormatter();
        using (var recstream = new MemoryStream(formatted))
        {
            action = (Controle.Game)receive.Deserialize(recstream);
        }
        if (action == Controle.Game.QUIT)
        {
            hasWonDefault = true;
            isWaitingPlayer = false;
            isInGame = false;
        }
        else if (action == Controle.Game.STARTING)
        {
            SendObject(Controle.Game.OK);
            isWaitingPlayer = false;
        }
        GameControllerSample6.thread.Abort();
    }
    public void InGameManager()
    {
        Controle.Game action = 0;
        string[] vals;

        do
        {
            int count = sck.ReceiveBufferSize;
            byte[] buffer = new byte[count];
            sck.Receive(buffer);

            byte[] formatted = new byte[count];
            for (int i = 0; i < count; i++)
            {
                formatted[i] = buffer[i];
            }


            BinaryFormatter receive = new BinaryFormatter();
            using (var recstream = new MemoryStream(formatted))
            {
                action = (Controle.Game)receive.Deserialize(recstream);
            }
            switch (action)
            {
                case Controle.Game.ENDTURN:                    
                    GameController.InactivityAndQuitCheck();
                    enemyDone = true;
                    GameController.threadTurn.Abort();
                    break;

                case Controle.Game.ATTACK:
                    vals = ReceiveString().Split(SPLITTER);
                    _activeEnemyName = vals[0];
                    _activeTargetUnit = vals[1];
                    _damageDealt = Int32.Parse(vals[2]);
                    enemyAttack = true;
                    break;

                case Controle.Game.MOVE:
                    vals = ReceiveString().Split(SPLITTER);
                    _activeEnemyName = vals[0];
                    _destinationNodeNumber = vals[1];
                    enemyMove = true;
                    break;

                case Controle.Game.USEITEM:
                    vals = ReceiveString().Split(SPLITTER);
                    _activeEnemyName = vals[0];

                    enemyItem = true;
                    break;

                case Controle.Game.DEFEND:
                    break;

                case Controle.Game.WIN:
                    break;

                case Controle.Game.QUIT:
                    break;

            }
        } while (action != Controle.Game.ENDTURN);
        
    }
    public string ReceiveString()
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
        return Encoding.UTF8.GetString(formatted);
    }

    public void CheckForInactivity()
    {
        int count = sck.ReceiveBufferSize;
        byte[] buffer = new byte[count];
        sck.Receive(buffer);

        byte[] formatted = new byte[count];
        for (int i = 0; i < count; i++)
        {
            formatted[i] = buffer[i];
        }

        Controle.Game action;

        BinaryFormatter receive = new BinaryFormatter();
        using (var recstream = new MemoryStream(formatted))
        {
            action = (Controle.Game)receive.Deserialize(recstream);
        }

        if (action == Controle.Game.HALFAFK)
        {

        }
        else if (action == Controle.Game.QUIT)
        {

        }
        else if (action == Controle.Game.AFK)
        {

        }
    }
    #endregion
    /// <summary>
    /// Envoi les personnages choisis par le joueur au serveur, fait appelle à la méthode SendObject(T obj).
    /// </summary>
    public void SendTeam()
    {
        List<Personnages> list = new List<Personnages>();
        Character c;

        for (int i = 0; i < _chosenTeam.Count; ++i)
        {
            c = _chosenTeam[i];
            list.Add(new Personnages(c._name, c._characterClass._classLevel, c._characterClass._className, c._maxHealth, c._maxMagic,
                c._physAttack, c._physDefense, c._magicAttack, c._magicDefense));
        }
        SendObject(list);
    }

    /// <summary>
    /// Template qui prend un objet de type générique, le sérialise, et l'envoi au serveur
    /// </summary>
    /// <typeparam name="T">Type générique</typeparam>
    /// <param name="obj">objet à envoyer</param>
    public void SendObject<T>(T obj)
    {
        BinaryFormatter b = new BinaryFormatter();
        using (var stream = new MemoryStream())
        {
            b.Serialize(stream, obj);
            sck.Send(stream.ToArray());
        }
    }
    /// <summary>
    /// Retourne une liste d'objets génériques déserialisés venant du serveur
    /// </summary>
    /// <typeparam name="T">Type générique</typeparam>
    /// <returns>Une liste de type générique</returns>
    public List<T> ReceiveObject<T>()
    {
        List<T> list = new List<T>();
        int count = sck.ReceiveBufferSize;
        byte[] buffer;
        buffer = new byte[count];

        ///écoute au serveur
        sck.Receive(buffer);

        ///on formatte les informations reçues
        byte[] formatted = new byte[count];
        for (int i = 0; i < count; ++i)
        {
            formatted[i] = buffer[i];
        }
        //on déserialise les informations
        BinaryFormatter receive = new BinaryFormatter();
        using (var recstream = new MemoryStream(formatted))
        {
            list = receive.Deserialize(recstream) as List<T>;
        }
        return list;
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