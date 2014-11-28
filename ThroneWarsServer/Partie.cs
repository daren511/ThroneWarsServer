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
        private int mId;
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
            else if (Joueur1 == null)
            {
                Joueur1 = j;
            }
            if (!deconnecterJoueurInactif() && Joueur1 != null && Joueur2 != null)
            {
                isFull = true;
                this.T.Start();
            }
        }
        /// <summary>
        /// si un joueur est inactif en attendant le debut de la partie le serveur va le deconnecter 
        /// </summary>
        public bool deconnecterJoueurInactif()
        {
            bool aPlayerIsInactive = false;
            if (Joueur1 != null && !Joueur1.socketIsConnected())
            {
                Joueur1.isConnected = false;
                Joueur1 = null;
                aPlayerIsInactive = true;
            }
            if (Joueur2 != null && !Joueur2.socketIsConnected())
            {
                Joueur2.isConnected = false;
                Joueur2 = null;
                aPlayerIsInactive = true;
            }

            return aPlayerIsInactive;
        }

        /// <summary>
        /// Cette fonction est la fonction principale de la class instance c'est la fonction qui est appelée au moment ou 
        /// le thread demmare.
        /// </summary>
        public void Run()
        {
            try
            {
                envoyerReponse("1", Joueur1);
                envoyerReponse("2", Joueur2);
                Joueur1.Persos = RecevoirObjet<Personnages>(Joueur1);
                Joueur2.Persos = RecevoirObjet<Personnages>(Joueur2);
                this.mId = Controle.createMatch(Joueur1.jid, 1, Joueur1.Persos[0].Nom, Joueur1.Persos[1].Nom, Joueur1.Persos[2].Nom, Joueur1.Persos[3].Nom);
                Controle.addPlayerMatch(this.mId, Joueur2.jid, Joueur2.Persos[0].Nom, Joueur2.Persos[1].Nom, Joueur2.Persos[2].Nom, Joueur2.Persos[3].Nom);
                envoyerObjet(Joueur1.Persos, Joueur2);
                envoyerObjet(Joueur2.Persos, Joueur1);
                Joueur1.positionsPersonnages = RecevoirObjet<int>(Joueur1);
                Joueur1.positionsPersonnages = RecevoirObjet<int>(Joueur2);
                envoyerObjet(Joueur2.positionsPersonnages, Joueur1);
                envoyerObjet(Joueur1.positionsPersonnages, Joueur2);

            }
            catch(Exception)
            {

            }
            this.T.Abort();
        }
        private List<T> RecevoirObjet<T>(Joueur j)
        {

            List<T> list = new List<T>();

            int count = j.Socket.ReceiveBufferSize;
            byte[] buffer;
            buffer = new byte[count];
            j.Socket.Receive(buffer);

            byte[] formatted = new byte[count];
            for (int i = 0; i < count; i++)
            {
                formatted[i] = buffer[i];
            }

            BinaryFormatter receive = new BinaryFormatter();
            using (var recstream = new MemoryStream(formatted))
            {
                list = receive.Deserialize(recstream) as List<T>;
            }
            return list;
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



        private void envoyerObjet<T>(T ds, Joueur j)
        {
            BinaryFormatter b = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                b.Serialize(stream, ds);
                j.Socket.Send(stream.ToArray());
            }
        }

        private void envoyerReponse(string reponse, Joueur j)
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
