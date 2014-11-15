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
    public partial class FORM_Joueur : Form
    {
        //---------- VARIABLES ----------//
        public int JID
        {
            get { return Int32.Parse(LBL_JID.Text); }
            set { LBL_JID.Text = value.ToString(); }
        }

        public string USERNAME
        {
            get { return TB_Username.Text; }
            set { TB_Username.Text = value; }
        }

        public string PASSWORD
        {
            get { return TB_PWD.Text; }
            set { TB_PWD.Text = value; }
        }

        public string EMAIL
        {
            get { return TB_Email.Text; }
            set { TB_Email.Text = value; }
        }

        public int MONEY
        {
            get { return Int32.Parse(TB_Argent.Text); }
            set { TB_Argent.Text = value.ToString(); ; }
        }

        public DateTime JOINDATE
        {
            get { return DTP_JoinDate.Value; }
            set { DTP_JoinDate.Value = value; }
        }

        public string CONFIRMED
        {
            get { return CHECK_Confirmed.Checked ? "1" : "0"; }
            set { CHECK_Confirmed.Checked = Convert.ToBoolean(Int32.Parse(value)); }
        }


        public FORM_Joueur()
        {
            InitializeComponent();
        }

        private void FORM_Joueur_Load(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(TB_Username, "Nom d'usager");
            ToolTip.SetToolTip(TB_PWD, "Mot de passe");
            ToolTip.SetToolTip(TB_Email, "Email");
            ToolTip.SetToolTip(TB_Argent, "Argent");
            ToolTip.SetToolTip(DTP_JoinDate, "Date rejoint");

            Lister_Items();
            DGV_Inventaire.Columns[0].Visible = false;
            DGV_Inventaire.Columns[2].Visible = false;
            DGV_Inventaire.Columns[3].Visible = false;
            DGV_Inventaire.Columns[4].Visible = false;
            DGV_Inventaire.Columns[5].Visible = false;
            DGV_Inventaire.Columns[6].Visible = false;
            DGV_Inventaire.Columns[7].Visible = false;

            ListerPotions();
            DGV_Potions.Columns[0].Visible = false;
            DGV_Potions.Columns[2].Visible = false;
            DGV_Potions.Columns[3].Visible = false;
            DGV_Potions.Columns[4].Visible = false;
            DGV_Potions.Columns[5].Visible = false;
            DGV_Potions.Columns[6].Visible = false;
            DGV_Potions.Columns[7].Visible = false;

            FillComboBox();
            if (CB_Perso.Items.Count == 0 || DGV_Inventaire.Rows.Count == 0)
                BTN_Ajouter.Enabled = false;
        }

        private void TB_Argent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void Lister_Items()
        {
            BindingSource maSource = new BindingSource(Controle.listItems(CHECK_SHOW_Activated.Checked, JID, 1), "STATS");
            DGV_Inventaire.DataSource = maSource;

            if (TAB_Control.SelectedTab == PAGE_Inventaire)
            {
                if (DGV_Inventaire.Rows.Count > 0)
                {
                    BTN_Consulter.Enabled = true;
                    BTN_Ajouter.Enabled = true;
                }
                else
                    BTN_Consulter.Enabled = false;
            }
        }

        private void BTN_Consulter_Click(object sender, EventArgs e)
        {
            if (TAB_Control.SelectedTab == PAGE_Inventaire)
                Consulter_Item();
            else
                ConsulterPotion();
        }

        private void DGV_Inventaire_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Consulter_Item();
        }

        private void Consulter_Item()
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
            FI.QUANTITE = int.Parse(DGV_Inventaire.SelectedRows[0].Cells[8].Value.ToString());
            FI.ISACTIVE = DGV_Inventaire.SelectedRows[0].Cells[9].Value.ToString();

            if (FI.ShowDialog() == DialogResult.OK)
            {
                if (Controle.updateQuantityItem(JID, FI.IID, FI.QUANTITE))
                    Lister_Items();
            }
        }

        private void ListerPotions()
        {
            BindingSource maSource = new BindingSource(Controle.listPotions(JID, 1), "POTIONS");
            DGV_Potions.DataSource = maSource;

            if (TAB_Control.SelectedTab == PAGE_Potions)
            {
                if (DGV_Potions.Rows.Count > 0)
                    BTN_Consulter.Enabled = true;
                else
                    BTN_Consulter.Enabled = false;
            }
        }

        private void ConsulterPotion()
        {
            FORM_Potion FP = new FORM_Potion();
            FP.Text = DGV_Potions.SelectedRows[0].Cells[1].Value.ToString();
            FP.PID = int.Parse(DGV_Potions.SelectedRows[0].Cells[0].Value.ToString());
            FP.NOM = DGV_Potions.SelectedRows[0].Cells[1].Value.ToString();
            FP.DESCRIPTION = DGV_Potions.SelectedRows[0].Cells[2].Value.ToString();
            FP.DURATION = int.Parse(DGV_Potions.SelectedRows[0].Cells[3].Value.ToString());
            FP.WATK = int.Parse(DGV_Potions.SelectedRows[0].Cells[4].Value.ToString());
            FP.WDEF = int.Parse(DGV_Potions.SelectedRows[0].Cells[5].Value.ToString());
            FP.MATK = int.Parse(DGV_Potions.SelectedRows[0].Cells[6].Value.ToString());
            FP.MDEF = int.Parse(DGV_Potions.SelectedRows[0].Cells[7].Value.ToString());
            FP.QUANTITE = int.Parse(DGV_Potions.SelectedRows[0].Cells[8].Value.ToString());

            if (FP.ShowDialog() == DialogResult.OK)
            {
                if (Controle.updateQuantityPotion(JID, FP.PID, FP.QUANTITE))
                    ListerPotions();
            }
        }

        private void TAB_Control_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (TAB_Control.SelectedTab == PAGE_Inventaire)
            {
                if (DGV_Inventaire.Rows.Count > 0)
                    BTN_Consulter.Enabled = true;
                else
                    BTN_Consulter.Enabled = false;
            }
            else
            {
                if (DGV_Potions.Rows.Count > 0)
                    BTN_Consulter.Enabled = true;
                else
                    BTN_Consulter.Enabled = false;
            }
        }

        private void DGV_Potions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConsulterPotion();
        }

        private void CHECK_SHOW_Activated_CheckedChanged(object sender, EventArgs e)
        {
            Lister_Items();
        }

        private void FillComboBox()
        {
            List<string> perso = Controle.fillPerso(JID);
            for (int i = 0; i < perso.Count; ++i)
                CB_Perso.Items.Add(perso[i]);
            CB_Perso.SelectedIndex = 0;
        }

        private void BTN_Ajouter_Click(object sender, EventArgs e)
        {
            string nom = CB_Perso.SelectedItem.ToString();
            int IID = int.Parse(DGV_Inventaire.SelectedRows[0].Cells[0].Value.ToString());
            if (Controle.addItemPersonnages(nom, IID, JID))
                Lister_Items();
            else
                MessageBox.Show("Ce personnage possède déjà cet item");
        }
    }
}
