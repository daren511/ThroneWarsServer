using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;
using System.Globalization;
using System.Text.RegularExpressions;
using Emails;

namespace SiteWebThroneWars
{
    public partial class ForgotPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                      

        }
        protected void PasswordRecovery(object sender, EventArgs e)
        {
            string text = "";
            string username = TB_Username.Text;
            // Verif si textbox sont pas null
            bool ok = VerifChamps();
            if (ok)
            {
                // Si recovery reussie
                bool RecoveryReussi = Controle.PasswordRecovery(username);

                // 

                //Email.sendMail()
            }
            else
            text = "Vous devez remplir tout les champs requis";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
            ViderTB();
             
        }
        protected bool VerifChamps()
        {
            bool Valide = false;
            if (!string.IsNullOrWhiteSpace(TB_Username.Text))
            {
                Valide = true;
            }
            return Valide;
        }
        protected void ViderTB()
        {
            TB_Username.Text = "";
        }

    }
}