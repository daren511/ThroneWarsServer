using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleBD;
using Emails;
using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace ThroneWarsServer
{
    class Program
    {
        const int PORT = 50053;
        static List<Joueur> v = new List<Joueur>();
        static List<Joueur> queue = new List<Joueur>();
        static List<Partie> games = new List<Partie>();
        static List<Joueur> playersWantingMainMenu = new List<Joueur>();
        static Socket sckserver;
        static Socket sck1;
        static Mutex mJoueur = new Mutex();
        static Mutex mQueue = new Mutex();
        static Mutex mGame = new Mutex();
        static Mutex mMainMenu = new Mutex();
        /// <summary>
        /// Verifie si le socket est connecte
        /// </summary>
        /// <param name="s">Socket a verifier</param>
        /// <returns>true si il est connecter false dans le cas contraire</returns>
        public static bool SocketConnected(Socket s)
        {
            return !(s.Poll(1000, SelectMode.SelectRead) && s.Available == 0);
        }
        /// <summary>
        /// Ajoute un joueur pour recreer un thread de Instance ( le menu principale)
        /// </summary>
        /// <param name="j">Joueur a etre ajouter dans la liste</param>
        public static void addGoToMenu(Joueur j)
        {
            mMainMenu.WaitOne();
            playersWantingMainMenu.Add(j);
            mMainMenu.ReleaseMutex();
        }

        /// <summary>
        /// Verifie si le joueur passer en parametre est deja connecter
        /// </summary>
        /// <param name="j">Joueur a verifier</param>
        /// <returns>true si le joueur n'est pas deja connecter false dans le cas contraire</returns>
        public static bool checkAlreadyConnected(Joueur j)
        {
            int count = 0;
            mJoueur.WaitOne();
            foreach(Joueur player in v)
            {//si le nom d'usager correspont a celui du joueur qui essaie de se connecter 
                if (player.Username == j.Username) { count++; }
            }
            mJoueur.ReleaseMutex();
            //si le chiffre retourne est autre que 1 alors le joueur est deja connecter (1 represente le joueur (lui meme) qui tente la connection) 
            return count != 1;
        }
        /// <summary>
        /// Ajoute un joueur dans la queue pour les parties
        /// </summary>
        /// <param name="j"></param>
        public static void addToQueue(Joueur j)
        {
            mQueue.WaitOne();
            queue.Add(j);
            mQueue.ReleaseMutex();
        }
        /// <summary>
        /// cette fonction verifie si une partie est libre 
        /// </summary>
        /// <returns>retourne l'index de la partie libre dans le vecteur de parties si aucune partie n'est libre on retourne -1</returns>
        static public int findFreeGame()
        {
            int index = -1;
            foreach(Partie p in games)
            {
                if(!p.isFull)
                {
                    index = games.IndexOf(p);
                    break;
                }
            }
            return index;
        }

        static void Main(string[] args)
        {
            sckserver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sckserver.Blocking = false;// verifie a chaque tour de boucle si un joueur attend pour se connecter
            sckserver.Bind(new IPEndPoint(0, PORT));
            sckserver.Listen(0);
            Console.WriteLine("Serveur en attente de connexion");
            while (true)
            {
                if (sck1 == null)
                {
                    try
                    {                        
                        sck1 = sckserver.Accept();   //si il y a quelque chose qui essaie de se connecter on accepter sinon on leve une exception                 
                    }
                    catch(Exception)
                    {
                        sck1 = null; //personne essait de se connecter
                    }                    
                }

                if (sck1!=null && SocketConnected(sck1))
                {
                    sck1.Blocking = true;
                    string ip = (sck1.RemoteEndPoint as IPEndPoint).Address.ToString(); // on prend l'adresse ip du joueur pour affichage
                    v.Add(new Joueur(sck1));// ajoute le nouveau joueur dans la liste des joueurs
                    new Instance(v[v.Count-1]).T.Start(); //demarre le thread
                    System.Threading.Thread.Sleep(100); // pour que le thread ai le temps de recevoir le nom du joueur qui se connecte
                    Console.WriteLine("["+ System.DateTime.Now +"] Joueur connecté : " + ip + " Joueur: " + v[v.Count-1].Username) ; // affiche a la console lheure l'adresse ip et le nom d'usager du joueur qui a tenter de se connecter
                }
                sck1 = null;

                if(queue.Count != 0) // si quelquun dans la queue
                {
                    int index = findFreeGame(); // on regarde si une partie est libre
                    if(games.Count > 0 && index != -1)
                    {
                        games[index].addJoueur(queue[0]); // on ajoute le joueur a la partie
                        queue.RemoveAt(0);// on retire le joueur de la queue 
                    }
                    else
                    {
                        games.Add(new Partie(queue[0])); // aucune partie n'est pas plein alors on creer une nouvelle
                        queue.RemoveAt(0);// retire le joueur de la queue
                    }
                }
                if (games.Count > 0 && findFreeGame() != -1)// on verifie si une partie est libre pour verfier si le joueur dedans est toujours connecter
                {
                    games[findFreeGame()].dcInactivePlayer(); // on deconnecte les joueur inactif de la partie
                }

                if(playersWantingMainMenu.Count > 1)// si des joueur veulent retourne au menu principale
                {
                    mMainMenu.WaitOne();
                    foreach(Joueur j in playersWantingMainMenu)
                    {
                        new Instance(j).T.Start(); // on recreer une instance et on la demarre
                    }
                    playersWantingMainMenu.Clear(); // on vide la liste
                    mMainMenu.ReleaseMutex();
                }
                
                if(v.Count != 0) // si il y a des joueurs
                {
                    for (int i = 0; i < v.Count;++i)
                    {
                        if (!v[i].isConnected && v[i].hasConnected) // si il n'est plus connecter mais qui c'est deja aumoin connecter (pour eviter que si soit deconnecter alors qu'il ne se soit pas brancher une fois)
                        {
                            Console.WriteLine("[" + System.DateTime.Now + "] Joueur déconnecté : " + v[i].Username);// on deconnecte le joueur (trace a l'ecran)
                            v.Remove(v[i]);// on retire le joueur de la liste des joueurs
                        }
                    }
                }
            }
        }
    }
}
