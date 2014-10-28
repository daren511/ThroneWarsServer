using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ControleBD;
using Oracle.DataAccess.Client;

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

        public void Run()
        {
            try
            {
                if (!Joueur.isConnected && Joueur.isAlive())
                {
                    string Login = recevoirLogin();
                    Joueur.
                    bool reponse = Controle.UserPassCorrespondant(Login.Split(Splitter)[0], Login.Split(Splitter)[1]);
                    if (reponse) 
                    {
                        envoyerReponse(reponse.ToString());
                        Joueur.isConnected = true; 
                    }
                    else
                    {
          
                        envoyerReponse(reponse.ToString());
                    }
                }
                if(Joueur.isConnected)
                {

                }
            }
            catch (OracleException e)
            {

            }
            this.T.Abort();
        }

        private void envoyerReponse(string reponse)
        {
            byte[] data = Encoding.ASCII.GetBytes(reponse);

            Joueur.Socket.Send(data);
        }
        private string recevoirLogin()
        {
            string login;
            byte[] buffer = new byte[Joueur.Socket.SendBufferSize];
            int bytesRead = Joueur.Socket.Receive(buffer);
            byte[] formatted = new byte[bytesRead];
            for (int i = 0; i < bytesRead; ++i)
            {
                formatted[i] = buffer[i];
            }

            login = Encoding.ASCII.GetString(formatted);

            return login;
        }
    }
}
