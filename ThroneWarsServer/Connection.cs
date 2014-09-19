using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace ThroneWarsServer
{

    class Connection
    {
        private OracleConnection conn = null;
        private static Connection instance;
        public static Connection GetInstance()
        {
            if (instance == null)
            {
                instance = new Connection();
            }
            return instance;
        }

        private Connection()
        {
            try
            {
                string Dsource = "(DESCRIPTION="
               + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)"
               + "(HOST=205.237.244.251)(PORT=1521)))"
               + "(CONNECT_DATA=(SERVICE_NAME=ORCL)))";

                String ChaineConnexion = "Data Source=" + Dsource
                + ";User Id='Throne'; Password ='Warst'";
                conn = new OracleConnection();
                conn.ConnectionString = ChaineConnexion;

                conn.Open();

                if (conn.State.ToString() != "Open")
                {

                }

            }
            catch (OracleException ex)
            {
                ErrorMessage(ex);
            }
        }

        

        private void ErrorMessage(OracleException Ex)
        {
            switch (Ex.Number)
            {
                case 1017:
                    Console.WriteLine("*Erreur Usager/Mot de passe");
                    break;
                case 12170:
                    Console.WriteLine("Erreur 12170:La base de données est indisponible,réessayer plus tard");
                    break;
                case 12543:
                    Console.WriteLine("Erreur 12543:Connexion impossible,Vérifiez votre connection internet");
                    break;
                default: Console.WriteLine(Ex.Message.ToString());
                    break;
            }
        }
    }
}
