using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;

namespace SiteWebThroneWars
{
    public partial class MOBILEChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            // Variable des champs textbox
            string text = "";
            bool ok = VerifChamps();
            string user = username.Text;
            string oldpass = apassword.Text;
            string newPass = npassword.Text;
            string confirmNewPass = ncpassword.Text;

            // Si tout les champs sont remplis
            if (ok)
            {
                //Si le l'ancien mot de passe == le nouveau ou que le nouveau ne correspond pas à la confirmation
                if (oldpass == newPass || newPass != confirmNewPass)
                {
                    text = "L'ancien mot de pass et le nouveau sont les mêmes ou le nouveau et la confirmation ne correspondent pas";
                    OldPass.ForeColor = System.Drawing.Color.Red;
                    NewPass.ForeColor = System.Drawing.Color.Red;
                    cNewPass.ForeColor = System.Drawing.Color.Red;
                    //Messagebox erreur?
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                }
                else
                {
                    // Hash l'ancien password
                    string oldpassHash = Controle.hashPassword(oldpass, null, System.Security.Cryptography.SHA256.Create());
                    // Verifie si c'est correspondant
                    bool Correspondant = Controle.userPassCorrespondant(user, oldpassHash);
                    if (Correspondant)
                    {
                        // Crypter le nouveau mot de passe et envoyer
                        string newpassHash = Controle.hashPassword(newPass, null, System.Security.Cryptography.SHA256.Create());

                        //Changer le password du user avec le nouveau password hashé
                        bool ChangeOk = Controle.updatePassword(user, newpassHash);
                        if (ChangeOk)
                        {
                            // Messagebox changement réussi
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxReussi();</script>", false);
                            usernameLB.ForeColor = System.Drawing.Color.Black;
                            OldPass.ForeColor = System.Drawing.Color.Black;
                            NewPass.ForeColor = System.Drawing.Color.Black;
                            cNewPass.ForeColor = System.Drawing.Color.Black;
                        }

                    }
                    else
                    {
                        text = "Le nom  d'utilisateur et l'ancien mot de passe ne correspondent pas";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                        usernameLB.ForeColor = System.Drawing.Color.Red;
                        OldPass.ForeColor = System.Drawing.Color.Red;

                    }

                }
            }
            else
            {
                text = "Vous devez remplir tout les champs requis";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                usernameLB.ForeColor = System.Drawing.Color.Red;
                OldPass.ForeColor = System.Drawing.Color.Red;
                NewPass.ForeColor = System.Drawing.Color.Red;
                cNewPass.ForeColor = System.Drawing.Color.Red;
                ViderTB();
            }
        }
        protected bool VerifChamps()
        {
            bool Valide = true;
            if (string.IsNullOrWhiteSpace(username.Text) || string.IsNullOrEmpty(username.Text))
                Valide = false;
            if (string.IsNullOrWhiteSpace(apassword.Text) || string.IsNullOrEmpty(apassword.Text))
                Valide = false;
            if (string.IsNullOrWhiteSpace(npassword.Text) || string.IsNullOrEmpty(npassword.Text))
                Valide = false;
            if (string.IsNullOrWhiteSpace(ncpassword.Text) || string.IsNullOrEmpty(ncpassword.Text))
                Valide = false;

            return Valide;
        }
        protected void ViderTB()
        {
            username.Text = "";
            apassword.Text = "";
            npassword.Text = "";
            ncpassword.Text = "";
        }
    }
}