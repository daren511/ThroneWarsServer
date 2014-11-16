using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeveloperApplication
{
    public partial class FORM_Potion : Form
    {
        //---------- VARIABLES ----------//
        public bool VISIBLE = true;
        public bool CANMODIFY = true;

        public int PID
        {
            get { return int.Parse(LBL_PID.Text); }
            set { LBL_PID.Text = value.ToString(); }
        }

        public string NOM
        {
            get { return TB_Nom.Text; }
            set { TB_Nom.Text = value; }
        }

        public string DESCRIPTION
        {
            get { return TB_Desc.Text; }
            set { TB_Desc.Text = value; }
        }

        public int DURATION
        {
            get { return int.Parse(TB_Duration.Text); }
            set { TB_Duration.Text = value.ToString(); }
        }

        public int WATK
        {
            get { return int.Parse(TB_WATK.Text); }
            set { TB_WATK.Text = value.ToString(); }
        }

        public int WDEF
        {
            get { return int.Parse(TB_WDEF.Text); }
            set { TB_WDEF.Text = value.ToString(); }
        }

        public int MATK
        {
            get { return int.Parse(TB_MATK.Text); }
            set { TB_MATK.Text = value.ToString(); }
        }
        public int MDEF
        {
            get { return int.Parse(TB_MDEF.Text); }
            set { TB_MDEF.Text = value.ToString(); }
        }

        public int QUANTITE
        {
            get { return int.Parse(TB_Quantite.Text); }
            set { TB_Quantite.Text = value.ToString(); }
        }


        public FORM_Potion()
        {
            InitializeComponent();
        }

        private void FORM_Potion_Load(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(TB_Nom, "Nom");
            ToolTip.SetToolTip(TB_Desc, "Description");
            ToolTip.SetToolTip(TB_Duration, "Durée");
            ToolTip.SetToolTip(TB_Quantite, "Quantité");
            ToolTip.SetToolTip(TB_WATK, "Attaque physique");
            ToolTip.SetToolTip(TB_WDEF, "Défense physique");
            ToolTip.SetToolTip(TB_MATK, "Attaque magique");
            ToolTip.SetToolTip(TB_MDEF, "Défense magique");

            if (!VISIBLE)
                TB_Quantite.Visible = false;

            if(CANMODIFY || this.Text == "Ajout")
            {
                TB_Nom.ReadOnly = false;
                TB_Desc.ReadOnly = false;
                TB_Duration.ReadOnly = false;
                TB_WATK.ReadOnly = false;
                TB_WDEF.ReadOnly = false;
                TB_MATK.ReadOnly = false;
                TB_MDEF.ReadOnly = false;
            }
            if (this.Text == "Ajout")
                LBL_PID.Text = "";
            UpdateControls(sender, e);
        }

        private void CheckKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void UpdateControls(object sender, EventArgs e)
        {
            if (this.Text == "Ajout" || CANMODIFY)
            {
                if (string.IsNullOrWhiteSpace(TB_Nom.Text) || string.IsNullOrWhiteSpace(TB_Desc.Text) ||
                    string.IsNullOrWhiteSpace(TB_Duration.Text) ||string.IsNullOrWhiteSpace(TB_WATK.Text) || 
                    string.IsNullOrWhiteSpace(TB_WDEF.Text) || string.IsNullOrWhiteSpace(TB_MATK.Text) || 
                    string.IsNullOrWhiteSpace(TB_MDEF.Text))
                    BTN_OK.Enabled = false;
                else
                    BTN_OK.Enabled = true;
            }
            else if (VISIBLE)
            {
                if (string.IsNullOrWhiteSpace(TB_Quantite.Text))
                    BTN_OK.Enabled = false;
                else
                    BTN_OK.Enabled = true;
            }
        }
    }
}
