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
                DGV_Joueurs.Columns[0].Visible = false;
            }
        }

        private void DGV_Joueurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ListerPerso(int.Parse(DGV_Joueurs.SelectedRows[0].Cells[0].ToString()));
            if (!BTN_CONS_Joueur.Enabled && !BTN_SUPP_Joueur.Enabled)
            {
                BTN_CONS_Joueur.Enabled = true;
                BTN_SUPP_Joueur.Enabled = true;
            }
        }

        private void ListerPerso(int jid)
        {
            if(Controle.ListCharacters(jid) != null)
            {
                BindingSource maSource = new BindingSource(Controle.ListCharacters(jid), "PERSONNAGES");
                DGV_Personnages.DataSource = maSource;
                DGV_Personnages.Columns[0].Visible = false;
            }
        }

        private void DGV_Personnages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!BTN_CONS_Perso.Enabled && !BTN_SUPP_Perso.Enabled)
            {
                BTN_CONS_Perso.Enabled = true;
                BTN_SUPP_Perso.Enabled = true;
            }
        }
    }
}
