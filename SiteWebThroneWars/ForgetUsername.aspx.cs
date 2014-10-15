using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteWebThroneWars
{
    public partial class ForgetUsername : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UsernameRecovery(object sender, EventArgs e)
        {
            string courriel = TB_Email.Text;
            // Valider que le email est legit
            bool legitEmail = IsEmail(courriel);

            // Si legit envoyer mess with password
            if (legitEmail)
            { 
                
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
}