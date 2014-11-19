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
    public partial class FORM_Login : Form
    {
        private string checkIn = "DECDEADDEADE712A400A8889425EA4488BF3040E81FE170F2E7E3069EB11126402AF84F587E";

        public FORM_Login()
        {
            InitializeComponent();
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string pwd = Controle.hashPassword(TB_MDP.Text, null, System.Security.Cryptography.SHA256.Create());
            if (pwd == checkIn)
            {
                FORM_Main FM = new FORM_Main();
                FM.ShowDialog();
            }
            else
            {
                LBL_Erreur.Visible = true;
                TB_MDP.Focus();
            }
        }

        private void TB_MDP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                Login();
        }
    }
}
