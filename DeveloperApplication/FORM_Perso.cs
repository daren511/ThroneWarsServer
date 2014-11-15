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
    public partial class FORM_Perso : Form
    {
        //---------- VARIABLES ----------//
        public int GUID
        {
            get { return int.Parse(LBL_GUID.Text); }
            set { LBL_GUID.Text = value.ToString(); }
        }

        public string NOM
        {
            get { return TB_Nom.Text; }
            set { TB_Nom.Text = value; }
        }

        public int XP
        {
            get { return int.Parse(TB_XP.Text); }
            set { TB_XP.Text = value.ToString(); }
        }

        public int LEVEL
        {
            get { return int.Parse(TB_Level.Text); }
            set { TB_Level.Text = value.ToString(); }
        }

        public string CLASSE
        {
            get { return CB_Classe.Text; }
            set { CB_Classe.Text = value; }
        }

        public string ISACTIVE
        {
            get { return CHECK_IsActive.Checked ? "1" : "0"; }
            set { CHECK_IsActive.Checked = Convert.ToBoolean(int.Parse(value)); }
        }

        public int JID;


        public FORM_Perso()
        {
            InitializeComponent();
        }

        private void FORM_Perso_Load(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(TB_Nom, "Nom");
            ToolTip.SetToolTip(TB_Level, "Niveau");
            ToolTip.SetToolTip(TB_XP, "XP");
            ToolTip.SetToolTip(CB_Classe, "Classe");
            if (this.Text == "Ajout")
            {
                TB_Level.ReadOnly = false;
                CB_Classe.Enabled = true;
                LBL_GUID.Text = "";
            }
            else
                Lister_Items();
            FillComboBox();
            UpdateControls(sender, e);

            DGV_Inventaire.Columns[0].Visible = false;
            DGV_Inventaire.Columns[2].Visible = false;
            DGV_Inventaire.Columns[3].Visible = false;
            DGV_Inventaire.Columns[4].Visible = false;
            DGV_Inventaire.Columns[5].Visible = false;
            DGV_Inventaire.Columns[6].Visible = false;
            DGV_Inventaire.Columns[7].Visible = false;
        }

        private void FillComboBox()
        {
            List<string> classes = Controle.FillClasses();
            for (int i = 0; i < classes.Count; ++i)
                CB_Classe.Items.Add(classes[i]);
        }

        private void CheckKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void UpdateControls(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_Nom.Text) || string.IsNullOrWhiteSpace(TB_Level.Text) ||
                string.IsNullOrWhiteSpace(TB_XP.Text) || string.IsNullOrWhiteSpace(CB_Classe.Text))
                BTN_OK.Enabled = false;
            else
                BTN_OK.Enabled = true;
        }

        private void Lister_Items()
        {
            BindingSource maSource = new BindingSource(Controle.ListItems(CHECK_AfficherTout.Checked, JID, 2, GUID), "STATS");
            DGV_Inventaire.DataSource = maSource;

            if (DGV_Inventaire.Rows.Count > 0)
                BTN_Consulter.Enabled = true;
            else
                BTN_Consulter.Enabled = false;
        }

        private void ConsulterItem()
        {
            FORM_Item FI = new FORM_Item();
            FI.Text = DGV_Inventaire.SelectedRows[0].Cells[1].Value.ToString();
            FI.IID = int.Parse(DGV_Inventaire.SelectedRows[0].Cells[0].Value.ToString());
            FI.NOM = DGV_Inventaire.SelectedRows[0].Cells[1].Value.ToString();
            FI.CLASSE = DGV_Inventaire.SelectedRows[0].Cells[2].Value.ToString();
            FI.LEVEL = int.Parse(DGV_Inventaire.SelectedRows[0].Cells[3].Value.ToString());
            FI.WATK = int.Parse(DGV_Inventaire.SelectedRows[0].Cells[4].Value.ToString());
            FI.WDEF = int.Parse(DGV_Inventaire.SelectedRows[0].Cells[5].Value.ToString());
            FI.MATK = int.Parse(DGV_Inventaire.SelectedRows[0].Cells[6].Value.ToString());
            FI.MDEF = int.Parse(DGV_Inventaire.SelectedRows[0].Cells[7].Value.ToString());
            FI.ISACTIVE = DGV_Inventaire.SelectedRows[0].Cells[8].Value.ToString();
            FI.VISIBLE = false;
            FI.ShowDialog();
        }

        private void BTN_Consulter_Click(object sender, EventArgs e)
        {
            ConsulterItem();
        }

        private void DGV_Inventaire_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConsulterItem();
        }
    }
}
