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
        public FORM_Main()
        {
            InitializeComponent();
        }

        private void FORM_Main_Load(object sender, EventArgs e)
        {
            ListerJoueurs();
            DGV_Joueurs.Columns[0].Visible = false;
            DGV_Joueurs.Columns[2].Visible = false;
            DGV_Joueurs.Columns[3].Visible = false;
            DGV_Joueurs.Columns[4].Visible = false;
            DGV_Joueurs.Columns[5].Visible = false;

            DGV_Personnages.Columns[0].Visible = false;
            DGV_Personnages.Columns[3].Visible = false;
            DGV_Personnages.Columns[4].Visible = false;
        }

        private void TSMI_Quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TSMI_Items_Click(object sender, EventArgs e)
        {
            FORM_Lister FLI = new FORM_Lister();
            FLI.Text = "Lister tous les items";
            FLI.ShowDialog();
        }

        private void TSMI_Potions_Click(object sender, EventArgs e)
        {
            FORM_Lister FLI = new FORM_Lister();
            FLI.Text = "Lister toutes les potions";
            FLI.estItem = false;
            FLI.ShowDialog();
        }

        //---------- JOUEURS ----------//
        private void ListerJoueurs()
        {
            int index = -1;
            if (DGV_Joueurs.Rows.Count > 0) { index = DGV_Joueurs.SelectedRows[0].Index; }
            BindingSource maSource = new BindingSource(Controle.listPlayers(CHECK_CFM_Joueur.Checked), "JOUEURS");
            DGV_Joueurs.DataSource = maSource;

            if (index != -1 && index < DGV_Joueurs.Rows.Count)
            {
                DGV_Joueurs.Rows[0].Selected = false;
                DGV_Joueurs.Rows[index].Selected = true;
            }
            ChangeBTNTextJ();

            ListerPerso();
        }

        private void DGV_Joueurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChangeBTNTextJ();
            ListerPerso();
        }

        private void BTN_CONS_Joueur_Click(object sender, EventArgs e)
        {
            ConsulterJoueur();
        }

        private void BTN_DESAC_Joueur_Click(object sender, EventArgs e)
        {
            string confirmer = "";
            if (DGV_Joueurs.SelectedRows[0].Cells[6].Value.ToString() == "1")
                confirmer = "0";
            else
                confirmer = "1";
            if (Controle.updateStateJoueur(Int32.Parse(DGV_Joueurs.SelectedRows[0].Cells[0].Value.ToString()), confirmer))
                ListerJoueurs();
        }

        private void CHECK_CFM_Joueur_CheckedChanged(object sender, EventArgs e)
        {
            ListerJoueurs();
        }

        private void DGV_Joueurs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConsulterJoueur();
        }

        private void ChangeBTNTextJ()
        {
            if (DGV_Joueurs.SelectedRows[0].Cells[6].Value.ToString() == "1")
                BTN_DESAC_Joueur.Text = "Désactiver";
            else
                BTN_DESAC_Joueur.Text = "Activer";
        }

        private void ConsulterJoueur()
        {
            FORM_Joueur FJ = new FORM_Joueur();
            FJ.Text = DGV_Joueurs.SelectedRows[0].Cells[1].Value.ToString(); ;  // Titre
            FJ.JID = Int32.Parse(DGV_Joueurs.SelectedRows[0].Cells[0].Value.ToString()); ;
            FJ.USERNAME = DGV_Joueurs.SelectedRows[0].Cells[1].Value.ToString(); ;
            FJ.EMAIL = DGV_Joueurs.SelectedRows[0].Cells[2].Value.ToString(); ;
            FJ.PASSWORD = DGV_Joueurs.SelectedRows[0].Cells[3].Value.ToString(); ;
            FJ.JOINDATE = DateTime.Parse(DGV_Joueurs.SelectedRows[0].Cells[4].Value.ToString()); ;
            FJ.MONEY = Int32.Parse(DGV_Joueurs.SelectedRows[0].Cells[5].Value.ToString()); ;
            FJ.CONFIRMED = DGV_Joueurs.SelectedRows[0].Cells[6].Value.ToString();

            if (FJ.ShowDialog() == DialogResult.OK)
            {
                if (Controle.updateJoueur(FJ.JID, FJ.USERNAME, FJ.EMAIL, FJ.PASSWORD, FJ.JOINDATE, FJ.MONEY, FJ.CONFIRMED))
                    ListerJoueurs();
            }
        }

        //---------- PERSONNAGES ----------//
        private void ListerPerso()
        {
            int index = -1;
            BindingSource maSource = new BindingSource(
                Controle.returnStats(
                    Int32.Parse(DGV_Joueurs.SelectedRows[0].Cells[0].Value.ToString()), true, CHECK_CFM_Perso.Checked), "StatsJoueur");
            DGV_Personnages.DataSource = maSource;
            if (DGV_Personnages.Rows.Count > 0)
            {
                index = DGV_Personnages.SelectedRows[0].Index;
                BTN_CONS_Perso.Enabled = true;
                BTN_DESAC_Perso.Enabled = true;
            }
            else
            {
                BTN_CONS_Perso.Enabled = false;
                BTN_DESAC_Perso.Enabled = false;
            }
            if (index != -1 && index < DGV_Personnages.Rows.Count)
            {
                DGV_Personnages.Rows[0].Selected = false;
                DGV_Personnages.Rows[index].Selected = true;
            }
            ChangeBTNTextP();
        }

        private void DGV_Personnages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChangeBTNTextP();
        }

        private void BTN_AJT_Perso_Click(object sender, EventArgs e)
        {
            FORM_Perso FP = new FORM_Perso();
            FP.Text = "Ajout";
            if (FP.ShowDialog() == DialogResult.OK)
            {
                int JID = Int32.Parse(DGV_Joueurs.SelectedRows[0].Cells[0].Value.ToString());
                if (Controle.addPerso(JID, FP.NOM, FP.XP, FP.LEVEL, FP.CLASSE, FP.ISACTIVE))
                    ListerPerso();
            }
        }

        private void BTN_CONS_Perso_Click(object sender, EventArgs e)
        {
            ConsulterPerso();
        }

        private void BTN_DESAC_Perso_Click(object sender, EventArgs e)
        {
            string confirmer = "";
            if (DGV_Personnages.SelectedRows[0].Cells[5].Value.ToString() == "1")
                confirmer = "0";
            else
                confirmer = "1";
            if (Controle.updateStatePerso(Int32.Parse(DGV_Personnages.SelectedRows[0].Cells[0].Value.ToString()), confirmer))
                ListerPerso();
        }

        private void CHECK_CFM_Perso_CheckedChanged(object sender, EventArgs e)
        {
            ListerPerso();
        }

        private void DGV_Personnages_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConsulterPerso();
        }

        private void ChangeBTNTextP()
        {
            if (DGV_Personnages.Rows.Count > 0)
            {
                if (DGV_Personnages.SelectedRows[0].Cells[5].Value.ToString() == "1")
                    BTN_DESAC_Perso.Text = "Désactiver";
                else
                    BTN_DESAC_Perso.Text = "Activer";
            }
        }

        private void ConsulterPerso()
        {
            int JID = Int32.Parse(DGV_Joueurs.SelectedRows[0].Cells[0].Value.ToString());

            FORM_Perso FP = new FORM_Perso();
            FP.Text = DGV_Personnages.SelectedRows[0].Cells[1].Value.ToString();
            FP.GUID = int.Parse(DGV_Personnages.SelectedRows[0].Cells[0].Value.ToString());
            FP.NOM = DGV_Personnages.SelectedRows[0].Cells[1].Value.ToString();
            FP.CLASSE = DGV_Personnages.SelectedRows[0].Cells[2].Value.ToString();
            FP.XP = int.Parse(DGV_Personnages.SelectedRows[0].Cells[3].Value.ToString());
            FP.LEVEL = int.Parse(DGV_Personnages.SelectedRows[0].Cells[4].Value.ToString());
            FP.ISACTIVE = DGV_Personnages.SelectedRows[0].Cells[5].Value.ToString();
            FP.JID = JID;

            if (FP.ShowDialog() == DialogResult.OK)
            {
                if (Controle.updatePerso(FP.GUID, JID, FP.NOM, FP.XP, FP.LEVEL, FP.CLASSE, FP.ISACTIVE))
                    ListerPerso();
            }
        }
    }
}
