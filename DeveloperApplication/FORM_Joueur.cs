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
            get
            {
                if (CHECK_Confirmed.Checked)
                    return "1";
                else
                    return "0";
            }
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
        }

        private void TB_Argent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
