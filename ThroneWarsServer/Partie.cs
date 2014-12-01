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
        private Joueur player1;
        private Joueur player2;
        public bool isFull = false;
        public bool isWon = false;

        public Partie(Joueur J)
        {
            player1 = J;
            T = new Thread(new ThreadStart(Run));
        }
        public void addJoueur(Joueur j)
        {
            if (player2 == null)
            {
                player2 = j;
            }
            else if (player1 == null)
            {
                player1 = j;
            }
            if (!dcInactivePlayer() && player1 != null && player2 != null)
            {
                isFull = true;
                this.T.Start();
            }
        }
        /// <summary>
        /// si un joueur est inactif en attendant le debut de la partie le serveur va le deconnecter 
        /// </summary>
        public bool dcInactivePlayer()
        {
            bool aPlayerIsInactive = false;
            if (player1 != null && !player1.socketIsConnected())
            {
                player1.isConnected = false;
                player1 = null;
                aPlayerIsInactive = true;
            }
            if (player2 != null && !player2.socketIsConnected())
            {
                player2.isConnected = false;
                player2 = null;
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
                prepareGame();
                bool player1PlacedOrHasQuitted = false;
                bool player2PlacedOrHasQuitted = false;
                while (!player1PlacedOrHasQuitted || !player2PlacedOrHasQuitted)
                {
                    Controle.Game Action;
                    try
                    {
                        player1.Socket.Blocking = false;
                        Action = recevoirChoix(player1);
                        player1.Socket.Blocking = true;
                    }
                    catch (Exception) { Action = Controle.Game.NOTHING; }
                    switch (Action)
                    {
                        case Controle.Game.NOTHING:
                            break;
                        case Controle.Game.SENDPOSITIONS:
                            player1.positionsPersonnages = RecevoirObjet<int>(player1);
                            player1PlacedOrHasQuitted = true;
                            break;
                        case Controle.Game.QUIT: 
                            envoyerObjet(Controle.Game.QUIT, player2);
                            updateWinner(player2);
                            player1PlacedOrHasQuitted = true;
                            player2PlacedOrHasQuitted = true;
                            Program.addGoToMenu(player2);
                            player1.isConnected = false;
                            break;

                        case Controle.Game.CANCEL:
                            envoyerObjet(Controle.Game.QUIT, player2);
                            envoyerObjet(Controle.Game.CANCEL, player1);
                            updateWinner(player2);
                            player1PlacedOrHasQuitted = true;
                            player2PlacedOrHasQuitted = true;
                            Program.addGoToMenu(player1);
                            Program.addGoToMenu(player2);                            
                            break;
                    }
                    if (Action != Controle.Game.QUIT && Action != Controle.Game.CANCEL)
                    {
                        try
                        {
                            player2.Socket.Blocking = false;
                            Action = recevoirChoix(player2);
                            player2.Socket.Blocking = true;
                        }
                        catch (Exception) { Action = Controle.Game.NOTHING; }
                        switch (Action)
                        {
                            case Controle.Game.NOTHING:
                                break;
                            case Controle.Game.SENDPOSITIONS:
                                player2.positionsPersonnages = RecevoirObjet<int>(player2);
                                player2PlacedOrHasQuitted = true;
                                break;
                            case Controle.Game.QUIT:
                                envoyerObjet(Controle.Game.QUIT, player1);
                                updateWinner(player1);
                                player1PlacedOrHasQuitted = true;
                                player2PlacedOrHasQuitted = true;
                                Program.addGoToMenu(player1);
                                player2.isConnected = false;
                                break;

                            case Controle.Game.CANCEL:
                                envoyerObjet(Controle.Game.QUIT, player1);
                                envoyerObjet(Controle.Game.CANCEL, player2);
                                updateWinner(player1);
                                player1PlacedOrHasQuitted = true;
                                player2PlacedOrHasQuitted = true;
                                Program.addGoToMenu(player2);
                                Program.addGoToMenu(player1);
                                break;
                        }
                    }
                }
                //la partie debute ou un joueur a quitter
                if (!isWon)
                {
                    initGame();
                }

            }
            catch (Exception)
            {

            }
            this.T.Abort();
        }

        private void updateWinner(Joueur j)
        {
            Controle.updateMatch(this.mId, j.jid, player1.jid,
                        player1.Persos[0].Nom, player1.Persos[0].kills, Convert.ToInt32(player1.Persos[0].idDead).ToString()[0],
                        player1.Persos[1].Nom, player1.Persos[1].kills, Convert.ToInt32(player1.Persos[1].idDead).ToString()[0],
                        player1.Persos[2].Nom, player1.Persos[2].kills, Convert.ToInt32(player1.Persos[2].idDead).ToString()[0],
                        player1.Persos[3].Nom, player1.Persos[3].kills, Convert.ToInt32(player1.Persos[3].idDead).ToString()[0],
                        player2.jid,
                        player2.Persos[0].Nom, player2.Persos[0].kills, Convert.ToInt32(player2.Persos[0].idDead).ToString()[0],
                        player2.Persos[1].Nom, player2.Persos[1].kills, Convert.ToInt32(player2.Persos[1].idDead).ToString()[0],
                        player2.Persos[2].Nom, player2.Persos[2].kills, Convert.ToInt32(player2.Persos[2].idDead).ToString()[0],
                        player2.Persos[3].Nom, player2.Persos[3].kills, Convert.ToInt32(player2.Persos[3].idDead).ToString()[0]
                        );
            isWon = true;
        }
        /// <summary>
        /// cette fonction envoie au joueurs les fonctions neccessaire pour debuter la partie apres l'ecran de placement
        /// </summary>
        private void initGame()
        {
            envoyerObjet(Controle.Game.STARTING, player1);
            envoyerObjet(Controle.Game.STARTING, player2);
            //jouation
            recevoirChoix(player1);
            recevoirChoix(player2);
            envoyerObjet(player2.Persos, player1);
            envoyerObjet(player1.Persos, player2);
            recevoirChoix(player1);
            recevoirChoix(player2);
            envoyerObjet(player2.positionsPersonnages, player1);
            envoyerObjet(player1.positionsPersonnages, player2);
            recevoirChoix(player1);
            recevoirChoix(player2);
            envoyerObjet(Controle.listPotions(player1.jid,1), player1);

        }
        private List<Controle.po> traiterDataSet(DataSet DS)
        {
            List<string> Liste = new List<string>();
            foreach (DataRow dr in DS.Tables["StatsJoueur"].Rows)
            {
                Liste.Add(dr[0].ToString());
            }
            Liste.Capacity = Liste.Count;
            return Liste;
        }
        private void prepareGame()
        {
            envoyerReponse("1", player1);
            envoyerReponse("2", player2);
            player1.Persos = RecevoirObjet<Personnages>(player1);
            player2.Persos = RecevoirObjet<Personnages>(player2);
            this.mId = Controle.createMatch(player1.jid, 1, player1.Persos[0].Nom, player1.Persos[1].Nom, player1.Persos[2].Nom, player1.Persos[3].Nom);
            Controle.addPlayerMatch(this.mId, player2.jid, player2.Persos[0].Nom, player2.Persos[1].Nom, player2.Persos[2].Nom, player2.Persos[3].Nom);
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
        private Controle.Game recevoirChoix(Joueur j)
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
                return (Controle.Game)rec.Deserialize(stream);
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
