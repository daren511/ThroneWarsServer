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
            // Si user est plus que 4 characteres
            bool userOK = false;
            // Si user est de format valide
            bool isValid = false;
            // Verif si all textbox sont pas vide
            bool ok = VerifChamps();
            if (ok)
            {
                // Variable des textbox
                string user = username.Text;
                string pass = password.Text;
                string courriel = email.Text;

                // Vérifie si le nombre de charactere du username est respecté 
                if (user.Length >= 4 && user.Length <= 12)
                    userOK = true;
                else
                {
                    text = "Le nombre de charactères du nom d'utilisateur minimum est de 4 et maximum 12 . Veuillez entrer un nom d'utilisateur valide";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                    ViderTB();
                }
                if (Regex.IsMatch(user, @"^[a-zA-Z0-9]+$"))
                {
                    isValid = true;
                }
                else
                {
                    text = "Le format de votre nom d'usager est invalide";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                    ViderTB();
                }
                

                // Verifier si email est legit ou non vide
                bool legitEmail = IsEmail(courriel);


                // Verifier si mot de passe = confirmation && Email == confirmation && Email legit
                if (password.Text == cpassword.Text && email.Text == cemail.Text && legitEmail && userOK && isValid)
                {
                    bool InsReussi = false;
                    // Inserer dans oracle
                    InsReussi = Controle.insertPlayer(user, courriel, pass);


                    if (InsReussi)
                    {
                        // Message de confirmation
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxReussi();</script>", false);

                        //Hash le username pour le courriel de confirmation
                        Random random = new Random();
                        int randomNumber = random.Next(1, 9);
                        Controle.Rotation rot = new Controle.Rotation(randomNumber);
                        string userHash = rot.Chiffrer(user);
                        userHash += randomNumber; 
                        string link = "<a href=http://www.thronewars.ca/ConfirmAccount.aspx?User=" + userHash + ">Ici</a>";
                        // Send email de confirmation
                        Email.sendMail(courriel, Email.SujetInscription, Email.BodyConfirmation + link);
                        // Vide les TB
                        ViderTB(); 
                        //Remet la couleur noir au label
                        PasswordLB.ForeColor = System.Drawing.Color.Black;
                        CPasswordLB.ForeColor = System.Drawing.Color.Black;
                        EmailLB.ForeColor = System.Drawing.Color.Black;
                        CEmailLB.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        text = "Votre courriel ou votre nom d'uilisateur est déja utilisé";
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
                        if (password.Text == cpassword.Text && legitEmail)
                        {
                            text += ", vos courriels ne concordent pas";
                            EmailLB.ForeColor = System.Drawing.Color.Red;
                            CEmailLB.ForeColor = System.Drawing.Color.Red;
                            PasswordLB.ForeColor = System.Drawing.Color.Black;
                            CPasswordLB.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            text += " ainsi que vos courriels";
                            EmailLB.ForeColor = System.Drawing.Color.Red;
                            CEmailLB.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    if (!legitEmail)
                    {
                        if (password.Text == cpassword.Text && email.Text == cemail.Text)
                        {
                            text += ", le format du courriel est invalide";
                            EmailLB.ForeColor = System.Drawing.Color.Red;
                            CEmailLB.ForeColor = System.Drawing.Color.Red;
                            PasswordLB.ForeColor = System.Drawing.Color.Black;
                            CPasswordLB.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            text += " et le format de celui-ci n'est pas valide";
                            EmailLB.ForeColor = System.Drawing.Color.Red;
                            CEmailLB.ForeColor = System.Drawing.Color.Red;
                        }

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
            bool Valide = true;
            if (string.IsNullOrWhiteSpace(username.Text) || string.IsNullOrEmpty(username.Text))
                Valide = false;
            if (string.IsNullOrWhiteSpace(username.Text) || string.IsNullOrEmpty(username.Text))
                Valide = false;
            if (string.IsNullOrWhiteSpace(password.Text) || string.IsNullOrEmpty(password.Text))
                Valide = false;
            if (string.IsNullOrWhiteSpace(cpassword.Text) || string.IsNullOrEmpty(cpassword.Text))
                Valide = false;
            if (string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrEmpty(email.Text))
                Valide = false;
            if (string.IsNullOrWhiteSpace(cemail.Text) || string.IsNullOrEmpty(cemail.Text))
                Valide = false;

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