using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;

namespace SiteWebThroneWars
{
    public partial class MOBILEResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void ResetPass_Click(object sender, EventArgs e)
        {
            string text = "";
            bool ok = VerifChamps();
            if (ok)
            {
                // Get le URL
                string URL = HttpContext.Current.Request.Url.AbsoluteUri;
                Uri myUri = new Uri(URL);
                // Get la param User
                string userHash = HttpUtility.ParseQueryString(myUri.Query).Get("User");

                if (TB_NewPassord.Text == TB_ConfirmPass.Text)
                {
                    bool ResetOK = false;
                    // Hash le password
                    string passHash = Controle.hashPassword(TB_NewPassord.Text, null, System.Security.Cryptography.SHA256.Create());
                    // Fonction qui confirme que le mot de passe est changé
                    ResetOK = Controle.resetPassword(userHash, passHash);
                    if (ResetOK)
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxReussi();</script>", false);
                    
                }
                else
                {
                    text = "Le nouveau mot de passe et la confirmation ne correspondent pas";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                }
            }
            else
            {
                text = "Vos champs ne doivent pas être vide";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
            }
        }
        protected bool VerifChamps()
        {
            bool Valide = false;
            if (!string.IsNullOrWhiteSpace(TB_NewPassord.Text) && !string.IsNullOrWhiteSpace(TB_ConfirmPass.Text))
            {
                Valide = true;
            }
            return Valide;
        }
    }
}