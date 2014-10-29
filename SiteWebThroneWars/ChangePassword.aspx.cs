using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;

namespace SiteWebThroneWars
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            string text = "";
            bool ok = VerifChamps();
            string user = username.Text;
            string oldpass = apassword.Text;
            string newPass = npassword.Text;
            string confirmNewPass = ncpassword.Text;
            if (ok)
            {
                if (apassword == npassword || npassword != ncpassword)
                {
                    // Redirect avant ??
                    text = "L'ancien mot de pass et le nouveau sont les mêmes ou le nouveau et la confirmation ne correspondent pas";
                    //Verif si forecolor is the right thing
                    OldPass.ForeColor = System.Drawing.Color.Red;
                    NewPass.ForeColor = System.Drawing.Color.Red;
                    cNewPass.ForeColor = System.Drawing.Color.Red;
                    //Messagebox erreur?
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                }
                else
                {
                    // Crypter le nouveau mot de passe et envoyer
                    string passHash = Controle.HashPassword(newPass, null, System.Security.Cryptography.SHA256.Create());

                    //Changer le password du user avec le nouveau password hashé
                    bool ChangeOk = Controle.UpdatePassword(user, passHash);
                    if (ChangeOk)
                        // Messagebox changement réussi
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxReussi();</script>", false);
                    else
                    {
                        text = "Le changement à échoué";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                    }
                }
            }
        }
        protected bool VerifChamps()
        {
            bool Valide = false;
            if (!string.IsNullOrWhiteSpace(apassword.Text) || !string.IsNullOrWhiteSpace(npassword.Text) || !string.IsNullOrWhiteSpace(ncpassword.Text))
            {
                Valide = true;
            }
            return Valide;
        }
    }
}