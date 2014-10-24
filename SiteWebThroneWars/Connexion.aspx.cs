using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;

namespace SiteWebThroneWars
{
    public partial class Connexion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Connexion_Click(object sender, EventArgs e)
        {
            //String pour le sweetalert
            string text = "";
            // Textbox non null
            bool ok = VerifChamps();

            // Si le user et le password sont correspondant dans la bd
            bool userPassCorrespondant = false;

            // if Text box pas null
            if (ok)
            {
                //Variable des textbox
                string user = username.Text;
                string pass = password.Text;

                //Vérif si Username et Password sont correspondant
                userPassCorrespondant = Controle.UserPassCorrespondant(user, pass);
                if (userPassCorrespondant)
                {
                    //Si oui > Ramener la position du leaderboard

                    // XP and Perso and Niveau
                }
                else
                {
                    //Si non -> Erreur
                    text = "Le nom d'utilisateur et le mot de passe ne correspond pas";
                    //Textbox vide erreur
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);

                }
            }
            else
            {
                text = "Vous devez remplir tout les champs requis";
                //Textbox vide erreur
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
            }
        }

        protected bool VerifChamps()
        {
            bool Valide = false;
            if (!string.IsNullOrWhiteSpace(username.Text) || !string.IsNullOrWhiteSpace(password.Text))
            {
                Valide = true;
            }
            return Valide;
        }
    }
}