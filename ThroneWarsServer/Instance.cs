using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ControleBD;
using Oracle.DataAccess.Client;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ThroneWarsServer
{
    class Instance
    {
        private const char Splitter = '?';
        public Thread T;
        private Joueur Joueur;
        public Instance(Joueur J)
        {
            Joueur = J;
            T = new Thread(new ThreadStart(Run));
        }
        /// <summary>
        /// Cette fonction est la fonction principale de la class instance c'est la fonction qui est appelée au moment ou 
        /// le thread demmare.
        /// </summary>
        public void Run()
        {
            try
            {
                if (!Joueur.isConnected && Joueur.isAlive())
                {
                    string Login = recevoirString();
                    Joueur.Username = Login.Split(Splitter)[0];
                    bool reponse = Controle.UserPassCorrespondant(Joueur.Username, Login.Split(Splitter)[1]);//verifie si les informations de login sont ok
                    if (reponse) 
                    {
                        envoyerReponse(reponse.ToString() + Splitter + Controle.accountIsConfirmed(Joueur.Username).ToString());
                        Joueur.isConnected = true; 
                    }
                    else{ envoyerReponse(reponse.ToString()); }
                }
                if(Joueur.isConnected)
                {
                    Joueur.jid = Controle.getJID(Joueur.Username);

                    DataSet ds = Controle.ReturnStats(Joueur.jid);

                    List<string> list = traiterDataSet(ds);
                    envoyerListe(list);
                    recevoirString();
                    envoyerListe(Controle.ReturnPersonnage(list[0]));
                    recevoirString();
                    envoyerListe(Controle.getInventaireJoueurs(list[0]));

                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            this.T.Abort();//arret du thread
        }
        private List<string> traiterDataSet(DataSet DS)
        {
            List<string> Liste = new List<string>();
            foreach(DataRow dr in DS.Tables["StatsJoueur"].Rows)
            {
                Liste.Add(dr[0].ToString());
            }
            Liste.Capacity = Liste.Count;
            return Liste;
        }
        private void envoyerListe<T>(T ds)
        {
            BinaryFormatter b = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                b.Serialize(stream, ds);
                Joueur.Socket.Send(stream.ToArray());
            }
        }
        //private void envoyerPersonnage(string nom)
        //{
            
        //    BinaryFormatter b = new BinaryFormatter();
        //    using (var stream = new MemoryStream())
        //    {
        //        b.Serialize(stream, p);
        //        Joueur.Socket.Send(stream.ToArray());
        //    }
        //} 
        private void envoyerReponse(string reponse)
        {
            byte[] data = Encoding.ASCII.GetBytes(reponse);

            Joueur.Socket.Send(data);
        }
        private string recevoirString()
        {
            string S;
            byte[] buffer = new byte[Joueur.Socket.SendBufferSize];
            int bytesRead = Joueur.Socket.Receive(buffer);
            byte[] formatted = new byte[bytesRead];
            for (int i = 0; i < bytesRead; ++i)
            {
                formatted[i] = buffer[i];
            }

            S = Encoding.ASCII.GetString(formatted);

            return S;
        }
    }
}
