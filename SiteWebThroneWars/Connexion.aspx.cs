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
            bool Connecter = false;
            // if Text box pas null
            if (ok)
            {

                //Variable des textbox
                string user = username.Text;
                string pass = password.Text;

                Connecter = Controle.UserPassCorrespondant(user, pass);

                if (Connecter)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxReussi();</script>", false);
                }
                else
                {
                    text = "Shit happens";
                    //Textbox vide erreur
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                }

                //Vérif si Username et Password sont correspondant
                //Si oui > Ramener la position du leaderboard

                // XP and Perso and Niveau
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



    



        


        
