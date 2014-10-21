using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using ControleBD;
using System.Globalization;
using Emails;


namespace SiteWebThroneWars
{
    public partial class Inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void inscriptionJoueur_Click(object sender, EventArgs e)
        {
            //Variable string text pour les different string du messagebox Erreur / Success
            string message = "";
            // Verif si all textbox sont pas vide
            bool ok = VerifChamps();
            if (ok)
            {
                string user = username.Text;
                string pass = password.Text;
                string courriel = email.Text;

                // Verifier si username est dispo

                // Verifier si email est legit ou non vide
                // a verifier si marche
                bool legitEmail = IsEmail(courriel);
                // Verifier si Courriel est dispo


                // Verifier si mot de passe = confirmation && Email == confirmation && Email legit
                if (password.Text == cpassword.Text && email.Text == cemail.Text && legitEmail)
                {

                    // Inserer dans oracle
                    Controle.insertplayer(user, pass, courriel);

                    // Message de confirmation
                    message = "L'inscription à reussie, veuillez visiter votre courriel pour confirmer votre compte";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);

                    // Send email de confirmation
                    Email.sendMail(courriel, Email.SujetInscription, Email.bodyConfirmation);
                }
                else
                {
                    // Message d'erreur
                    if (password.Text != cpassword.Text)
                    {
                        message = "Les mots de passe ne sont pas compatibles";
                        PasswordLB.ForeColor = System.Drawing.Color.Red;
                        CPasswordLB.ForeColor = System.Drawing.Color.Red;

                    }

                    if (email.Text != cemail.Text)
                    {
                        message = "Les courriels ne sont pas compatibles";
                        EmailLB.ForeColor = System.Drawing.Color.Red;
                        CEmailLB.ForeColor = System.Drawing.Color.Red;
                    }
                    if (!legitEmail)
                    {
                        message = "Le format du courriel n'est pas valide";
                        EmailLB.ForeColor = System.Drawing.Color.Red;
                    }

                    // À vérifier si sa marche
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
                }
            }




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
    }
}