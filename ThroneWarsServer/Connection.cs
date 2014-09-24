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
        public OracleConnection conn { get; private set; }
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
                + ";User Id=THRONE; Password =Warst";
                conn = new OracleConnection(ChaineConnexion);

                conn.Open();

                if (conn.State.ToString() != "Open")
                {

                }

            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
            }
        }
    }
}
