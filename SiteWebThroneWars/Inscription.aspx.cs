using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using ControleBD;
using System.Globalization;

namespace SiteWebThroneWars
{
    public partial class Inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void inscriptionJoueur_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;
            string courriel = email.Text;

            // Verifier si username est dispo
            // Si le nom est legit avec le server aka pas deja pris

            // Verifier si email est legit ou non vide
            // a verifier si marche
            bool legitEmail = IsEmail(courriel);

            // Verifier si mot de passe = confirmation && Email == confirmation && Email legit
            if (password.Text == cpassword.Text && email.Text == cemail.Text && legitEmail)
            {
                // Inserer dans oracle
                Controle.insertplayer(user, pass, courriel);

                // Message de confirmation

                // Message d'erreur

                // Send email de confirmation
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
    }
}