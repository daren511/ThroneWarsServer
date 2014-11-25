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
            Joueur2 = j;
            isFull = true;
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
