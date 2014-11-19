using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleBD;
using Emails;
using System.Net.Sockets;
using System.Net;


namespace ThroneWarsServer
{
    class Program
    {
        const int PORT = 50052;
        static List<Joueur> v = new List<Joueur>();
        static List<Instance> i = new List<Instance>();
        static Socket sckserver;
        static Socket sck1;

        public static bool SocketConnected(Socket s)
        {
            return !(s.Poll(1000, SelectMode.SelectRead) && s.Available == 0);
        }
        static void Main(string[] args)
        {
            sckserver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sckserver.Bind(new IPEndPoint(0, PORT));
            sckserver.Listen(0);
            Console.WriteLine("Serveur en attente de connexion");
            while (true)
            {
                if (sck1 == null)
                {
                    sck1 = sckserver.Accept();
                }

                if (SocketConnected(sck1))
                {
                    v.Add(new Joueur(sck1,v.Count));
                    new Instance(v[v.Count-1]).T.Start();
                    System.Threading.Thread.Sleep(100);
                    Console.WriteLine("["+ System.DateTime.Now +"] Joueur connecté : " + (sck1.RemoteEndPoint as IPEndPoint).Address + " Joueur: " + v[v.Count-1].Username) ;
                    
                }
                sck1 = null;
            }

        }
    }
}
