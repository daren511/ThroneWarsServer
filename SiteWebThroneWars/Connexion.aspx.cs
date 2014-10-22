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
            // Textbox non null
            bool ok = VerifChamps();
            
            // bool si User existe && si le user et le password sont correspondant dans la bd
            bool userexiste = false;
            bool userPassCorrespondant = false;
            
            // if Text box pas null
            if (ok)
            {
                //Variable des textbox
                string user = username.Text;
                string pass = password.Text;

                //Vérif si Username existe dans la BD
                userexiste = Controle.UsernameExiste(user);
                if (userexiste)
                {

                    //Vérif si Username et Password sont correspondant
                    userPassCorrespondant = Controle.UserPassCorrespondant(user,pass);
                    if(userPassCorrespondant)
                    {
                        //Si oui > Ramener la position du leaderboard

                        // XP and Perso and Niveau
                    }
                    else
                    {
                      //Si non -> Erreur

                    }
                }
                else
                {
                    // Erreur le username n'existe pas LB + Messagebox
                }
            }
            else
            {
                // Mettre en rouge les LB plus message d'erreur que something goes wrong
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