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
using ControleBD;

namespace DeveloperApplication
{
    public partial class FORM_Main : Form
    {
        //---------- VARIABLES ----------//


        public FORM_Main()
        {
            InitializeComponent();
        }

        private void FORM_Main_Load(object sender, EventArgs e)
        {
            ListerJoueurs();
        }

        private void ListerJoueurs()
        {
            if (Controle.ListPlayers() != null)
            {
                BindingSource maSource = new BindingSource(Controle.ListPlayers(), "JOUEURS");
                DGV_Joueurs.DataSource = maSource;
            }
        }
    }
}
