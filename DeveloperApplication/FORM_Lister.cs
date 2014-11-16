﻿using System;
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
    public partial class FORM_Lister : Form
    {
        //---------- VARIABLES ----------//
        public bool estItem = true;     // estItem == true -> utiliser fonctions d'items, sinon, celles de potions
        private const int newY = 27;

        public FORM_Lister()
        {
            InitializeComponent();
        }

        private void FORM_Lister_Load(object sender, EventArgs e)
        {
            if (estItem)
            {
                Lister_Items();
                PotionPourJoueur(false);
            }
            else
            {
                BTN_Ajouter.Text = "Ajouter une potion";
                BTN_Etat.Visible = false;
                CHECK_AfficherTout.Visible = false;
                PotionPourJoueur(true);
                FillComboBox();
                UpdateControls(sender, e);
                Lister_Potions();
            }
            DGV_Liste.Columns[0].Visible = false;
        }

        private void Check_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void PotionPourJoueur(bool estVisible)
        {
            LBL_Ajouter.Visible = estVisible;
            CB_Joueurs.Visible = estVisible;
            BTN_Ajouter_Potion.Visible = estVisible;
            LBL_Qte.Visible = estVisible;
            TB_Qte.Visible = estVisible;
            LBL_Envoyer.Visible = false;

            if(estVisible)
            {
                LBL_Ajouter.Location = new Point(LBL_Ajouter.Location.X, LBL_Ajouter.Location.Y - newY);
                CB_Joueurs.Location = new Point(CB_Joueurs.Location.X, CB_Joueurs.Location.Y - newY);
                BTN_Ajouter_Potion.Location = new Point(BTN_Ajouter_Potion.Location.X, BTN_Ajouter_Potion.Location.Y - newY);
                LBL_Qte.Location = new Point(LBL_Qte.Location.X, LBL_Qte.Location.Y - newY);
                TB_Qte.Location = new Point(TB_Qte.Location.X, TB_Qte.Location.Y - newY);
                LBL_Envoyer.Location = new Point(LBL_Envoyer.Location.X, LBL_Envoyer.Location.Y - newY);
            }
        }

        private void FillComboBox()
        {
            List<string> joueurs = Controle.fillJoueurs();
            for (int i = 0; i < joueurs.Count; ++i)
                CB_Joueurs.Items.Add(joueurs[i]);
            CB_Joueurs.SelectedIndex = 0;
        }

        private void UpdateControls(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_Qte.Text) || string.IsNullOrWhiteSpace(CB_Joueurs.Text))
                BTN_Ajouter_Potion.Enabled = false;
            else
                BTN_Ajouter_Potion.Enabled = true;
        }

        private void Lister_Items()
        {
            BindingSource maSource = new BindingSource(Controle.listItems(CHECK_AfficherTout.Checked), "STATS");
            DGV_Liste.DataSource = maSource;
            ChangeBTNText();

            if (DGV_Liste.Rows.Count > 0)
                BTN_Modifier.Enabled = true;
            else
                BTN_Modifier.Enabled = false;
        }

        private void Lister_Potions()
        {
            BindingSource maSource = new BindingSource(Controle.listPotions(), "POTIONS");
            DGV_Liste.DataSource = maSource;

            if (DGV_Liste.Rows.Count > 0)
                BTN_Modifier.Enabled = true;
            else
                BTN_Modifier.Enabled = false;
        }

        private void ModifierItem()
        {
            FORM_Item FI = new FORM_Item();
            FI.VISIBLE = false;
            FI.CANMODIFY = true;
            FI.Text = DGV_Liste.SelectedRows[0].Cells[1].Value.ToString();
            FI.IID = int.Parse(DGV_Liste.SelectedRows[0].Cells[0].Value.ToString());
            FI.NOM = DGV_Liste.SelectedRows[0].Cells[1].Value.ToString();
            FI.CLASSE = DGV_Liste.SelectedRows[0].Cells[2].Value.ToString();
            FI.LEVEL = int.Parse(DGV_Liste.SelectedRows[0].Cells[3].Value.ToString());
            FI.WATK = int.Parse(DGV_Liste.SelectedRows[0].Cells[4].Value.ToString());
            FI.WDEF = int.Parse(DGV_Liste.SelectedRows[0].Cells[5].Value.ToString());
            FI.MATK = int.Parse(DGV_Liste.SelectedRows[0].Cells[6].Value.ToString());
            FI.MDEF = int.Parse(DGV_Liste.SelectedRows[0].Cells[7].Value.ToString());
            FI.ISACTIVE = DGV_Liste.SelectedRows[0].Cells[8].Value.ToString();

            if (FI.ShowDialog() == DialogResult.OK)
            {
                if (Controle.updateItem(FI.IID, FI.NOM, FI.LEVEL, FI.WATK, FI.WDEF, FI.MATK, FI.MDEF, FI.ISACTIVE))
                    Lister_Items();
            }
        }

        private void ModifierPotion()
        {
            FORM_Potion FP = new FORM_Potion();
            FP.VISIBLE = false;
            FP.Text = DGV_Liste.SelectedRows[0].Cells[1].Value.ToString();
            FP.PID = int.Parse(DGV_Liste.SelectedRows[0].Cells[0].Value.ToString());
            FP.NOM = DGV_Liste.SelectedRows[0].Cells[1].Value.ToString();
            FP.DESCRIPTION = DGV_Liste.SelectedRows[0].Cells[2].Value.ToString();
            FP.DURATION = int.Parse(DGV_Liste.SelectedRows[0].Cells[3].Value.ToString());
            FP.WATK = int.Parse(DGV_Liste.SelectedRows[0].Cells[4].Value.ToString());
            FP.WDEF = int.Parse(DGV_Liste.SelectedRows[0].Cells[5].Value.ToString());
            FP.MATK = int.Parse(DGV_Liste.SelectedRows[0].Cells[6].Value.ToString());
            FP.MDEF = int.Parse(DGV_Liste.SelectedRows[0].Cells[7].Value.ToString());

            if (FP.ShowDialog() == DialogResult.OK)
            {
                if (Controle.updatePotion(FP.PID, FP.NOM, FP.DESCRIPTION, FP.DURATION, FP.WATK, FP.WDEF, FP.MATK, FP.MDEF))
                    Lister_Potions();
            }
        }

        private void BTN_Modifier_Click(object sender, EventArgs e)
        {
            if (estItem)
                ModifierItem();
            else
                ModifierPotion();
        }

        private void DGV_Liste_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (estItem)
                ModifierItem();
            else
                ModifierPotion();
        }

        private void BTN_Etat_Click(object sender, EventArgs e)
        {
            ChangerEtatItem();
        }

        private void ChangerEtatItem()
        {
            int IID = int.Parse(DGV_Liste.SelectedRows[0].Cells[0].Value.ToString());
            string actif = "";
            if (DGV_Liste.SelectedRows[0].Cells[8].Value.ToString() == "1")
                actif = "0";
            else
                actif = "1";
            if (Controle.updateStateItem(IID, actif))
                Lister_Items();
        }

        private void DGV_Liste_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (estItem)
                ChangeBTNText();
        }

        private void ChangeBTNText()
        {
            if (DGV_Liste.SelectedRows[0].Cells[8].Value.ToString() == "1")
                BTN_Etat.Text = "Désactiver";
            else
                BTN_Etat.Text = "Activer";
        }

        private void BTN_Ajouter_Click(object sender, EventArgs e)
        {
            if (estItem)
                Ajouter_Item();
            else
                Ajouter_Potion();
        }

        private void Ajouter_Item()
        {
            FORM_Item FI = new FORM_Item();
            FI.VISIBLE = false;
            FI.Text = "Ajout";

            if (FI.ShowDialog() == DialogResult.OK)
            {
                if (Controle.addItem(FI.NOM, FI.CLASSE, FI.LEVEL, FI.WATK, FI.WDEF, FI.MATK, FI.MDEF, FI.ISACTIVE))
                    Lister_Items();
            }
        }

        private void Ajouter_Potion()
        {
            FORM_Potion FP = new FORM_Potion();
            FP.VISIBLE = false;
            FP.Text = "Ajout";

            if(FP.ShowDialog() == DialogResult.OK)
            {
                if (Controle.addPotion(FP.NOM, FP.DESCRIPTION, FP.DURATION, FP.WATK, FP.WDEF, FP.MATK, FP.MDEF))
                    Lister_Potions();
            }
        }

        private void CHECK_AfficherTout_CheckedChanged(object sender, EventArgs e)
        {
            Lister_Items();
        }

        private void BTN_Ajouter_Potion_Click(object sender, EventArgs e)
        {
            int PID = int.Parse(DGV_Liste.SelectedRows[0].Cells[0].Value.ToString());
            int JID = Controle.getJID(CB_Joueurs.SelectedItem.ToString());
            int QTE = int.Parse(TB_Qte.Text);
            if (Controle.addPotionJoueurs(PID, JID, QTE))
            {
                Lister_Potions();
                TB_Qte.Text = "";
                LBL_Envoyer.Text = "Envoie effectué";
                LBL_Envoyer.Visible = true;
            }
            else
            {
                LBL_Envoyer.ForeColor = Color.Red;
                LBL_Envoyer.Text = "Envoie impossible";
            }
        }
    }
}
