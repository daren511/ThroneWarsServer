using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ControleBD;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ThroneWarsServer
{
    class Partie
    {
        private const char SPLITTER = '?';
        public Thread T;
        private Joueur Joueur1;
        private Joueur Joueur2;
        public bool isFull = false;
        public Partie(Joueur J)
        {
            Joueur1 = J;
            T = new Thread(new ThreadStart(Run));
        }
        public void addJoueur(Joueur j)
        {
            if (Joueur2 == null)
            {
                Joueur2 = j;
            }
            else if ( Joueur1 == null)
            {
                 Joueur1 = j;
            }
            bool test = Joueur1.socketIsConnected();
            bool test2 = Joueur2.socketIsConnected();
            if (test && test2 )
            {
                isFull = true;
                this.T.Start();
            }
            else if (!Joueur1.socketIsConnected())
            {
                Joueur1.isConnected = false;
                Joueur1 = null;
            }
            else
            {
                Joueur2.isConnected = false;
                Joueur2 = null;
            }
        }
        /// <summary>
        /// Cette fonction est la fonction principale de la class instance c'est la fonction qui est appelée au moment ou 
        /// le thread demmare.
        /// </summary>
        public void Run()
        {
            envoyerReponse("1", Joueur1);
            envoyerReponse("2", Joueur2);

        }
        private Controle.Actions recevoirChoix(Joueur j)
        {
            int first = j.Socket.ReceiveBufferSize;
            byte[] array = new byte[first];
            j.Socket.Receive(array);
            byte[] format = new byte[first];
            for (int i = 0; i < first; i++)
            {
                format[i] = array[i];
            }

            BinaryFormatter rec = new BinaryFormatter();
            using (var stream = new MemoryStream(format))
            {
                return (Controle.Actions)rec.Deserialize(stream);
            }

        }
        private void envoyerObjet<T>(T ds,Joueur j)
        {
            BinaryFormatter b = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                b.Serialize(stream, ds);
                j.Socket.Send(stream.ToArray());
            }
        }

        private void envoyerReponse(string reponse,Joueur j)
        {
            byte[] data = Encoding.ASCII.GetBytes(reponse);

            j.Socket.Send(data);
        }
        private string recevoirString(Joueur j)
        {
            string S;
            byte[] buffer = new byte[j.Socket.SendBufferSize];
            int bytesRead = j.Socket.Receive(buffer);
            byte[] formatted = new byte[bytesRead];
            for (int i = 0; i < bytesRead; ++i)
            {
                formatted[i] = buffer[i];
            }

            S = Encoding.UTF8.GetString(formatted);

            return S;
        }
    }
}
