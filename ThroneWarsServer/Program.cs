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
        static Socket sckserver;
        static Socket sck1;
        static Mutex mJoueur = new Mutex();
        static Mutex mQueue = new Mutex();
        static Mutex mGame = new Mutex();

        public static bool SocketConnected(Socket s)
        {
            return !(s.Poll(1000, SelectMode.SelectRead) && s.Available == 0);
        }

        public static void removePlayer(Joueur j)
        {
            mJoueur.WaitOne();
            v.Remove(j);
            mJoueur.ReleaseMutex();
        }
        public static bool checkConnected(Joueur j)
        {
            int count = 0;
            mJoueur.WaitOne();
            foreach(Joueur player in v)
            {
                if (player.Username == j.Username) { count++; }
            }
            mJoueur.ReleaseMutex();
            return count != 1;
        }

        public static void ajouterQueue(Joueur j)
        {
            mQueue.WaitOne();
            queue.Add(j);
            mQueue.ReleaseMutex();
        }

        static public int trouverPositionLibre()
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
            sckserver.Blocking = false;
            sckserver.Bind(new IPEndPoint(0, PORT));
            sckserver.Listen(0);
            Console.WriteLine("Serveur en attente de connexion");
            while (true)
            {
                if (sck1 == null)
                {
                    try
                    {                        
                        sck1 = sckserver.Accept();                       
                    }
                    catch(Exception)
                    {
                        sck1 = null;
                    }                    
                }

                if (sck1!=null && SocketConnected(sck1))
                {
                    sck1.Blocking = true;
                    string ip = (sck1.RemoteEndPoint as IPEndPoint).Address.ToString();
                    v.Add(new Joueur(sck1));
                    new Instance(v[v.Count-1]).T.Start();
                    System.Threading.Thread.Sleep(100);
                    Console.WriteLine("["+ System.DateTime.Now +"] Joueur connecté : " + ip + " Joueur: " + v[v.Count-1].Username) ;
                }
                sck1 = null;

                if(queue.Count != 0)
                {
                    int index = trouverPositionLibre();
                    if(games.Count > 0 && index != -1)
                    {
                        games[index].addJoueur(queue[0]);
                        queue.RemoveAt(0);
                    }
                    else
                    {
                        games.Add(new Partie(queue[0]));
                        queue.RemoveAt(0);
                    }
                }
                if (games.Count > 0 && trouverPositionLibre() != -1)
                {
                    games[trouverPositionLibre()].deconnecterJoueurInactif();
                }
                if(v.Count != 0)
                {
                    for (int i = 0; i < v.Count;++i)
                    {
                        if (!v[i].isConnected && v[i].hasConnected)
                        {
                            Console.WriteLine("[" + System.DateTime.Now + "] Joueur déconnecté : " + v[i].Username);
                            v.Remove(v[i]);
                        }
                    }
                }
            }
        }
    }
}
