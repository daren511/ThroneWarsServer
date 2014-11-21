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
        //static List<Instance> i = new List<Instance>();
        static Socket sckserver;
        static Socket sck1;
        static Mutex m = new Mutex();

        public static bool SocketConnected(Socket s)
        {
            return !(s.Poll(1000, SelectMode.SelectRead) && s.Available == 0);
        }

        public static void removePlayer(Joueur j)
        {
            m.WaitOne();
            v.Remove(j);
            m.ReleaseMutex();
        }
        public static bool checkConnected(Joueur j)
        {
            int count = 0;
            m.WaitOne();
            foreach(Joueur player in v)
            {
                if (player.Username == j.Username) { count++; }
            }
            m.ReleaseMutex();
            return count != 1;
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
            }

        }
    }
}
