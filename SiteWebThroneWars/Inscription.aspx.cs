using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using ControleBD;
using System.Globalization;
using Emails;
using System.Text;


namespace SiteWebThroneWars
{
    public partial class Inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void inscriptionJoueur_Click(object sender, EventArgs e)
        {
            // Variable de texte a envoyer dans les sweetalert
            string text = "";
            // Verif si all textbox sont pas vide
            bool ok = VerifChamps();
            if (ok)
            {
                // Variable des textbox
                string user = username.Text;
                string pass = password.Text;
                string courriel = email.Text;

                // Verifier si email est legit ou non vide
                bool legitEmail = IsEmail(courriel);


                // Verifier si mot de passe = confirmation && Email == confirmation && Email legit
                if (password.Text == cpassword.Text && email.Text == cemail.Text && legitEmail)
                {
                    bool InsReussi = false;
                    // Inserer dans oracle
                    InsReussi = Controle.insertPlayer(user, pass, courriel);

                    if (InsReussi)
                    {
                        // Message de confirmation
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxReussi();</script>", false);

                        // Send email de confirmation
                        Email.sendMail(courriel, Email.SujetInscription, Email.bodyConfirmation);

                        ViderTB();

                    }
                    else
                    {
                        text = "Quelque chose avec inscription à échoué";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                        ViderTB();
                    }
                }
                // Something happen
                else
                {
                    text = "Une erreur à été trouvée";
                    // Message d'erreur
                    if (password.Text != cpassword.Text)
                    {
                        text += ", vos mots de passe ne concordent pas";
                        PasswordLB.ForeColor = System.Drawing.Color.Red;
                        CPasswordLB.ForeColor = System.Drawing.Color.Red;
                    }
                    if (email.Text != cemail.Text)
                    {
                        text += " ainsi que vos courriels";
                        EmailLB.ForeColor = System.Drawing.Color.Red;
                        CEmailLB.ForeColor = System.Drawing.Color.Red;
                    }
                    if (!legitEmail)
                    {
                        text += " et le format de celui-ci n'est pas valide";
                        EmailLB.ForeColor = System.Drawing.Color.Red;
                        CEmailLB.ForeColor = System.Drawing.Color.Red;
                    }
                    text += ".";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                    ViderTB();
                }
            }
            //Message erreur si un des champs requis est vide
            text = "Vous devez remplir tout les champs requis";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
            ViderTB();
        }
        public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

        /// <summary>
        /// Checks whether the given Email-Parameter is a valid E-Mail address.
        /// </summary>
        /// <param name="email">Parameter-string that contains an E-Mail address.</param>
        /// <returns>True, when Parameter-string is not null and 
        /// contains a valid E-Mail address;
        /// otherwise false.</returns>
        public static bool IsEmail(string email)
        {
            if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
            else return false;
        }
        protected bool VerifChamps()
        {
            bool Valide = false;
            if (!string.IsNullOrWhiteSpace(username.Text) || !string.IsNullOrWhiteSpace(password.Text) || !string.IsNullOrWhiteSpace(cpassword.Text) ||
                !string.IsNullOrWhiteSpace(email.Text) || !string.IsNullOrWhiteSpace(cemail.Text))
            {
                Valide = true;
            }
            return Valide;
        }
        protected void ViderTB()
        {
            username.Text = "";
            password.Text = "";
            cpassword.Text = "";
            email.Text = "";
            cemail.Text = "";
        }
    }
}