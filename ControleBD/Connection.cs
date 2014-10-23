using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace ControleBD
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
               + "(HOST=172.17.104.127)(PORT=1521)))"
               + "(CONNECT_DATA=(SERVICE_NAME=ORCL)))";

                String ChaineConnexion = "Data Source=" + Dsource
                + ";User Id=THRONE; Password =Warst";
                conn = new OracleConnection(ChaineConnexion);

                conn.Open();

                if (conn.State.ToString() != "Open")
                {
                    // to do
                }

            }
            catch (OracleException ex)
            {
                Erreur.ErrorMessage(ex);
            }
        }
    }
}
