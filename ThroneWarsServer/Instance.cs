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
                if (!Joueur.isConnected && Joueur.socketIsConnected())
                {
                    string Login = recevoirString();
                    Joueur.Username = Login.Remove(Login.LastIndexOf(Splitter));
                    bool reponse = Controle.userPassCorrespondant(Joueur.Username, Login.Substring(Login.LastIndexOf(Splitter)+1));//verifie si les informations de login sont ok
                    if (reponse)
                    {
                        envoyerReponse(reponse.ToString() + Splitter + Controle.accountIsConfirmed(Joueur.Username).ToString());
                        Joueur.isConnected = true;
                    }
                    else { envoyerReponse(reponse.ToString()); }
                }
                if (Joueur.isConnected)
                {
                    Joueur.jid = Controle.getJID(Joueur.Username);
                    startUP(Joueur);
                    Controle.Actions Choix = 0;
                    while (Joueur.socketIsConnected() && Choix != Controle.Actions.START_GAME)
                    {
                        Choix = recevoirChoix();
                        //read le choix ici
                        switch (Choix)
                        {
                            case Controle.Actions.CLICK: 
                                envoyerListe(Controle.returnPersonnage(recevoirString()));
                                break;

                            case Controle.Actions.CREATE:
                                string Personnage = recevoirString();
                                envoyerReponse(Controle.addPerso(Joueur.jid,Personnage.Remove(Personnage.LastIndexOf(Splitter)),Personnage.Substring(Personnage.LastIndexOf(Splitter)+1)).ToString());
                                break;
                            case Controle.Actions.DELETE:
                                envoyerReponse(Controle.updateStatePerso(Controle.getGUID(recevoirString()),"0").ToString());
                                break;
                            case Controle.Actions.START_GAME:

                                break;
                            case Controle.Actions.EQUIP:
                                string requete = recevoirString();
                                envoyerReponse(Controle.addItemPersonnages(requete.Remove(requete.LastIndexOf(Splitter)), Int32.Parse(requete.Substring(requete.LastIndexOf(Splitter) + 1)), Joueur.jid).ToString());
                                break;
                            case Controle.Actions.UNEQUIP:

                                break;                          
                        }
                    }

                }
            }
            catch (Exception e)
            {
                if (Joueur.socketIsConnected())
                    Console.WriteLine(e.Message);
            }
            this.T.Abort();//arret du thread
        }
        /// <summary>
        /// Execute les actions neccesaires au demmarage de Unity
        /// </summary>
        /// <param name="j">Le Joueur</param>
        private void startUP(Joueur j)
        {
            List<string> list = traiterDataSet(Controle.returnStats(j.jid));
            envoyerListe(list);
            recevoirString();
            envoyerListe(Controle.getInventaireJoueurs(j.jid));
            recevoirString();
            if (list.Count > 0)
            {
                envoyerListe(Controle.returnPersonnage(list[0]));
                recevoirString();
            }            
        }

        private Controle.Actions recevoirChoix()
        {
            int first = Joueur.Socket.ReceiveBufferSize;
            byte[] array = new byte[first];
            Joueur.Socket.Receive(array);
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

        private List<string> traiterDataSet(DataSet DS)
        {
            List<string> Liste = new List<string>();
            foreach (DataRow dr in DS.Tables["StatsJoueur"].Rows)
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

            S = Encoding.UTF8.GetString(formatted);

            return S;
        }
    }
}
