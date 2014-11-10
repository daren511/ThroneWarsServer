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
        }

        private void TB_Argent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void Lister_Items()
        {
            BindingSource maSource = new BindingSource(Controle.ListItems(CHECK_SHOW_Activated.Checked, int.Parse(LBL_JID.Text)), "ITEMS");
            DGV_Inventaire.DataSource = maSource;

            if (DGV_Inventaire.Rows.Count > 0)
                BTN_Consulter.Enabled = true;
            else
                BTN_Consulter.Enabled = false;
        }

        private void BTN_Consulter_Click(object sender, EventArgs e)
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

            if(FI.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
