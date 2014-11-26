using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ControleBD;

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
            else
            {
                Joueur1.isConnected = false;
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

        }
    }
}
