using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ControleBD;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;

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
                placementScreen();
                //la partie debute ou un joueur a quitter
                if (!isWon)
                {
                    initGame();
                    Controle.Game action1 = Controle.Game.NOTHING;
                    Controle.Game action2 = Controle.Game.NOTHING;
                    int timer = 0;
                    while (!isWon)
                    {
                        timer = 0;
                        do
                        {
                            action1 = Controle.Game.NOTHING;
                            try
                            {
                                player1.Socket.Blocking = false;
                                action1 = recevoirChoix(player1);
                                player1.Socket.Blocking = true;

                                timer = 0;
                            }
                            catch (Exception) { action1 = Controle.Game.NOTHING; }
                            switch (action1)
                            {
                                case Controle.Game.ENDTURN:
                                    envoyerObjet(Controle.Game.ENDTURN, player2);
                                    break;
                                case Controle.Game.NOTHING:
                                    timer++;
                                    if (timer == 2500)
                                    {
                                        envoyerObjet(Controle.Game.HALFAFK, player1);
                                    }
                                    if (timer == 5000)
                                    {
                                        envoyerObjet(Controle.Game.AFK, player1);
                                    }
                                    break;
                                case Controle.Game.MOVE:
                                    envoyerObjet(Controle.Game.MOVE, player2);
                                    envoyerReponse(recevoirString(player1), player2);
                                    break;
                                case Controle.Game.USEITEM:
                                    envoyerObjet(Controle.Game.USEITEM, player2);
                                    envoyerReponse(recevoirString(player1), player2);
                                    break;
                                case Controle.Game.DEFEND:
                                    envoyerObjet(Controle.Game.DEFEND, player2);
                                    envoyerReponse(recevoirString(player1), player2);
                                    break;
                                case Controle.Game.ATTACK:
                                    envoyerObjet(Controle.Game.ATTACK, player2);
                                    System.Threading.Thread.Sleep(500);
                                    envoyerReponse(recevoirString(player1), player2);
                                    break;
                                case Controle.Game.QUIT:
                                    envoyerObjet(Controle.Game.QUIT, player2);
                                    updateWinner(player2);//+traitement exp
                                    Program.addGoToMenu(player2);
                                    player1.isConnected = false;
                                    isWon = true;
                                    break;

                                case Controle.Game.CANCEL:
                                    envoyerObjet(Controle.Game.QUIT, player2);
                                    updateWinner(player2);//+traitement exp
                                    Program.addGoToMenu(player1);
                                    Program.addGoToMenu(player2);
                                    isWon = true;
                                    break;
                                case Controle.Game.WIN:
                                    envoyerObjet(Controle.Game.WIN, player2);
                                    player1.Persos = RecevoirObjet<Personnages>(player1);
                                    player2.Persos = RecevoirObjet<Personnages>(player2);
                                    updateExp(Int32.Parse(recevoirString(player1)), Int32.Parse(recevoirString(player2)));
                                    updateWinner(player1);
                                    Program.addGoToMenu(player1);
                                    Program.addGoToMenu(player2);
                                    isWon = true;
                                    break;
                            }
                        }
                        while (action1 != Controle.Game.ENDTURN && timer < 5000 && !isWon && action1 != Controle.Game.WIN);

                        if (!isWon)
                        {
                            timer = 0;
                            do
                            {
                                action2 = Controle.Game.NOTHING;
                                try
                                {
                                    player2.Socket.Blocking = false;
                                    action2 = recevoirChoix(player2);
                                    player2.Socket.Blocking = true;
                                    timer = 0;
                                }
                                catch (Exception) { action2 = Controle.Game.NOTHING; }
                                switch (action2)
                                {
                                    case Controle.Game.ENDTURN:
                                        envoyerObjet(Controle.Game.ENDTURN, player1);
                                        break;
                                    case Controle.Game.NOTHING:
                                        timer++;
                                        if (timer == 2500)
                                        {
                                            envoyerObjet(Controle.Game.HALFAFK, player2);
                                        }
                                        if (timer == 5000)
                                        {
                                            envoyerObjet(Controle.Game.AFK, player2);
                                        }
                                        break;
                                    case Controle.Game.MOVE:
                                        envoyerObjet(Controle.Game.MOVE, player1);
                                        System.Threading.Thread.Sleep(500);
                                        envoyerReponse(recevoirString(player2), player1);
                                        break;
                                    case Controle.Game.USEITEM:
                                        envoyerObjet(Controle.Game.USEITEM, player1);
                                        envoyerReponse(recevoirString(player2), player1);
                                        break;
                                    case Controle.Game.DEFEND:
                                        envoyerObjet(Controle.Game.DEFEND, player1);
                                        envoyerReponse(recevoirString(player2), player1);
                                        break;
                                    case Controle.Game.ATTACK:
                                        envoyerObjet(Controle.Game.ATTACK, player1);
                                        System.Threading.Thread.Sleep(500);
                                        envoyerReponse(recevoirString(player2), player1);
                                        break;
                                    case Controle.Game.QUIT:
                                        envoyerObjet(Controle.Game.QUIT, player1);
                                        updateWinner(player1);
                                        Program.addGoToMenu(player1);
                                        isWon = true;
                                        player2.isConnected = false;
                                        break;
                                    case Controle.Game.CANCEL:
                                        envoyerObjet(Controle.Game.QUIT, player2);
                                        updateWinner(player2);
                                        Program.addGoToMenu(player1);
                                        Program.addGoToMenu(player2);
                                        isWon = true;
                                        break;
                                    case Controle.Game.WIN:
                                        envoyerObjet(Controle.Game.WIN, player1);
                                        player2.Persos = RecevoirObjet<Personnages>(player2);
                                        player1.Persos = RecevoirObjet<Personnages>(player1);
                                        updateExp(Int32.Parse(recevoirString(player1)), Int32.Parse(recevoirString(player2)));
                                        updateWinner(player2);
                                        Program.addGoToMenu(player1);
                                        Program.addGoToMenu(player2);
                                        isWon = true;
                                        break;
                                }
                            }
                            while (action2 != Controle.Game.ENDTURN && timer < 5000 && !isWon && action2 != Controle.Game.WIN);
                        }
                    }
                }

            }
            catch (Exception)
            {

            }
            this.T.Abort();
        }
        private void updateExp(int money1, int money2)
        {
            Controle.ajoutMoneyJoueur(player1.jid, money1);
            Controle.ajoutMoneyJoueur(player2.jid, money2);
            Controle.ajoutXPPersonnage(player1.Persos[0].Nom, player1.Persos[0].xpGained);
            Controle.ajoutXPPersonnage(player1.Persos[1].Nom, player1.Persos[1].xpGained);
            Controle.ajoutXPPersonnage(player1.Persos[2].Nom, player1.Persos[2].xpGained);
            Controle.ajoutXPPersonnage(player1.Persos[3].Nom, player1.Persos[3].xpGained);
            Controle.ajoutXPPersonnage(player2.Persos[0].Nom, player1.Persos[0].xpGained);
            Controle.ajoutXPPersonnage(player2.Persos[1].Nom, player1.Persos[1].xpGained);
            Controle.ajoutXPPersonnage(player2.Persos[2].Nom, player1.Persos[2].xpGained);
            Controle.ajoutXPPersonnage(player2.Persos[3].Nom, player1.Persos[3].xpGained);
        }
        /// <summary>
        /// met a jour le gagant de la partie ainsi que la base de donnees pour la partie en cours
        /// </summary>
        /// <param name="j">le joueur gagnant</param>
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
        private void placementScreen()
        {
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
        }
        /// <summary>
        /// cette fonction envoie au joueurs les fonctions neccessaire pour debuter la partie apres l'ecran de placement
        /// </summary>
        private void initGame()
        {
            envoyerObjet(Controle.Game.STARTING, player1);
            envoyerObjet(Controle.Game.STARTING, player2);//jouation

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

            envoyerObjet(player1.potions = traiterDataSet(Controle.listPotions(player1.jid, 1)), player1);
            envoyerObjet(player2.potions = traiterDataSet(Controle.listPotions(player2.jid, 1)), player2);

            recevoirChoix(player1);
            recevoirChoix(player2);
        }
        /// <summary>
        /// Fonction traite le dataset pour creer les objets potions pour le joueur
        /// </summary>
        /// <param name="DS">DataSet a traiter</param>
        /// <returns>une liste contenant les potions du joueur</returns>
        private List<Potions> traiterDataSet(DataSet DS)
        {
            List<Potions> Liste = new List<Potions>();
            foreach (DataRow dr in DS.Tables["POTIONS"].Rows)
            {
                Liste.Add(new Potions(
                    Int32.Parse(dr[0].ToString()),
                    dr[1].ToString(),
                    dr[2].ToString(),
                    Int32.Parse(dr[3].ToString()),
                    Int32.Parse(dr[4].ToString()),
                    Int32.Parse(dr[5].ToString()),
                    Int32.Parse(dr[6].ToString()),
                    Int32.Parse(dr[7].ToString()),
                    Int32.Parse(dr[8].ToString()),
                    Int32.Parse(dr[9].ToString())));
            }
            Liste.Capacity = Liste.Count;
            return Liste;
        }
        /// <summary>
        /// Execute les fonctione neccesaire pour creer la partie et recevoir les donnees basique usager
        /// </summary>
        private void prepareGame()
        {
            envoyerReponse("1", player1);
            envoyerReponse("2", player2);
            player1.Persos = RecevoirObjet<Personnages>(player1);
            player2.Persos = RecevoirObjet<Personnages>(player2);
            this.mId = Controle.createMatch(player1.jid, 1, player1.Persos[0].Nom, player1.Persos[1].Nom, player1.Persos[2].Nom, player1.Persos[3].Nom);
            Controle.addPlayerMatch(this.mId, player2.jid, player2.Persos[0].Nom, player2.Persos[1].Nom, player2.Persos[2].Nom, player2.Persos[3].Nom);
        }
        /// <summary>
        /// CETTE FONCTION EST UN TEMPLATE:
        /// elle retourne n'importe quel type de liste d'un joueur
        /// </summary>
        /// <typeparam name="T">Type de la liste attendu</typeparam>
        /// <param name="j">Joueur sur lequel on lis cette liste</param>
        /// <returns></returns>
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
        /// <summary>
        /// recoit un choix de l'enum 
        /// </summary>
        /// <param name="j">joueur a qui l'on souhaite demande l'action</param>
        /// <returns>un choix dans Controle.Game</returns>
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
        /// <summary>
        /// cette fonction envoie un objet de n'importe quel type serializable
        /// </summary>
        /// <typeparam name="T">Type serializable</typeparam>
        /// <param name="ds">Objet a envoyer</param>
        /// <param name="j">Joueur a qui envoyer l'objet</param>
        private void envoyerObjet<T>(T ds, Joueur j)
        {
            BinaryFormatter b = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                b.Serialize(stream, ds);
                j.Socket.Send(stream.ToArray());
                System.Threading.Thread.Sleep(500);// le sleep assure que les informations dans la memoire tempon on ete envoyer au client
            }
        }
        /// <summary>
        /// envoie une chaine de charactere au client
        /// </summary>
        /// <param name="reponse">String a envoyer</param>
        /// <param name="j">joueur a qui envoyer le string</param>
        private void envoyerReponse(string reponse, Joueur j)
        {
            byte[] data = Encoding.UTF8.GetBytes(reponse);

            j.Socket.Send(data);
            System.Threading.Thread.Sleep(500);
        }
        /// <summary>
        /// recoit un string provenant du client
        /// </summary>
        /// <param name="j">joueur que l'on veut ecouter</param>
        /// <returns>le string en question</returns>
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
