﻿using System;
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
        private int Timer;
        private const char SPLITTER = '?';
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
                    Joueur.hasConnected = true;
                    string Login = recevoirString();
                    Joueur.Username = Login.Remove(Login.LastIndexOf(SPLITTER));
                    bool reponse = Controle.userPassCorrespondant(Joueur.Username, Login.Substring(Login.LastIndexOf(SPLITTER)+1));//verifie si les informations de login sont ok
                    if (reponse)
                    {
                        string rep = reponse.ToString() + SPLITTER + Controle.accountIsConfirmed(Joueur.Username).ToString() + SPLITTER + Program.checkAlreadyConnected(Joueur).ToString();
                        envoyerReponse(rep);
                        if(rep == "True?True?False")
                        Joueur.isConnected = true;
                    }
                    else 
                    { 
                        envoyerReponse(reponse.ToString());
                    }
                    if(Joueur.isConnected)
                    {
                        Joueur.jid = Controle.getJID(Joueur.Username); 
                    }
                }
                if (Joueur.isConnected)
                {
                    startUP(Joueur);
                    Controle.Actions Choix = 0;
                    while (Joueur.socketIsConnected() && Choix != Controle.Actions.START_GAME && Choix != Controle.Actions.QUIT && Timer < 10000)
                    {
                        Joueur.Socket.Blocking = false;
                        try
                        {
                            Choix = recevoirChoix();
                            Timer = 0;
                        }
                        catch(Exception)
                        {
                            Choix = Controle.Actions.NOTHING;
                        }
                        Joueur.Socket.Blocking = true;
                        //read le choix ici
                        switch (Choix)
                        {
                            case Controle.Actions.CLICK: 
                                envoyerObjet(getPersonnage(recevoirString()));
                                break;
                            case Controle.Actions.CREATE:
                                string Personnage = recevoirString();
                                envoyerReponse(Controle.addPerso(Joueur.jid,Personnage.Remove(Personnage.LastIndexOf(SPLITTER)),Personnage.Substring(Personnage.LastIndexOf(SPLITTER)+1)).ToString());
                                break;
                            case Controle.Actions.DELETE:
                                envoyerReponse(Controle.updateStatePerso(Controle.getGUID(recevoirString()),"0").ToString());
                                break;
                            case Controle.Actions.START_GAME:
                                Program.addToQueue(Joueur);

                                break;
                            case Controle.Actions.EQUIP:
                                string requeteEquip = recevoirString();
                                envoyerReponse(Controle.addItemPersonnages(requeteEquip.Remove(requeteEquip.LastIndexOf(SPLITTER)), Int32.Parse(requeteEquip.Substring(requeteEquip.LastIndexOf(SPLITTER) + 1)), Joueur.jid).ToString());
                                recevoirString();
                                envoyerObjet(getPersonnage(requeteEquip.Remove(requeteEquip.LastIndexOf(SPLITTER))));
                                break;
                            case Controle.Actions.UNEQUIP:
                                string requeteUnequip = recevoirString();
                                envoyerReponse(Controle.deleteItemPersonnages(requeteUnequip.Remove(requeteUnequip.LastIndexOf(SPLITTER)), Int32.Parse(requeteUnequip.Substring(requeteUnequip.LastIndexOf(SPLITTER) + 1)), Joueur.jid).ToString());
                                recevoirString();
                                envoyerObjet(getPersonnage(requeteUnequip.Remove(requeteUnequip.LastIndexOf(SPLITTER))));
                                break;   
                            case Controle.Actions.NOTHING:
                                Timer++;
                                if(Timer >= 10000) // plus de 5 minutes a avoir rien recu du client on le sort
                                {
                                    Joueur.isConnected = false;
                                }
                                break;
                            case Controle.Actions.QUIT:
                                Joueur.isConnected = false;
                                break;
                            case Controle.Actions.STATS:
                                envoyerObjet(getPersonnage(recevoirString()));
                                break;
                            case Controle.Actions.ITEMS:
                                envoyerObjet(Controle.getInventaireJoueurs(Joueur.jid));
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
            envoyerObjet(list);
            recevoirString();
            envoyerObjet(Controle.getInventaireJoueurs(j.jid));
            string test = recevoirString();
            if (list.Count > 0)
            {
                envoyerObjet(getPersonnage(list[0]));
                string allo = recevoirString();
            }            
        }

        private Personnages getPersonnage(string nom)
        {
            Personnages p = Controle.returnPersonnage(nom);
            p.Item = Controle.getInventairePersonnage(Controle.getGUID(nom));

            return p;
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
        private void envoyerObjet<T>(T ds)
        {
            BinaryFormatter b = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                b.Serialize(stream, ds);
                Joueur.Socket.Send(stream.ToArray());
            }
        }
        
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
