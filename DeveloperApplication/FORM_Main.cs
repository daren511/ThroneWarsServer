using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace DeveloperApplication
{
    public partial class FORM_Main : Form
    {
        //---------- VARIABLES ----------//
        private OracleConnection conn;


        public FORM_Main()
        {
            InitializeComponent();
        }

        private void FORM_Main_Load(object sender, EventArgs e)
        {
            Connexion();
        }

        private void Connexion()
        {
            string Dsource = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)"
                            + "(HOST=bd.thronewars.ca)(PORT=1521)))"
                            + "(CONNECT_DATA=(SERVICE_NAME=ORCL)))";

            String ChaineConnexion = "Data Source=" + Dsource + ";User Id= Throne;Password =Warst";
            conn.ConnectionString = ChaineConnexion;
            try
            {
                conn.Open();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Application.Exit();
            }
        }

        private void ListerJoueurs()
        {

        }
    }
}
