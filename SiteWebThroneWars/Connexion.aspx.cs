using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;
using Oracle.DataAccess.Client;
using System.Data;


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
            DataSet DS = new DataSet();
            DataSet DSLeaderboard = new DataSet();
            // Textbox non null
            bool ok = VerifChamps();
            bool Connecter = false;
            // if Text box pas null
            if (ok)
            {
                //Variable des textbox
                string user = username.Text;
                string pass = password.Text;

                string passHash = Controle.hashPassword(pass, null, System.Security.Cryptography.SHA256.Create());
                Connecter = Controle.userPassCorrespondant(user, passHash);

                if (Connecter)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxReussi();</script>", false);

                    //Prend le JID
                    int JID = Controle.getJID(user);
                    

                    if (JID != 0)
                    {
                        //Si oui > Ramener la position du leaderboard
                        
                        DSLeaderboard = Controle.getLeaderboard(user);
                        if (DSLeaderboard != null)
                        {
                            GV_Leaderboard.DataSource = DSLeaderboard;
                            GV_Leaderboard.DataBind();
                        }
                         
                        // Return stats des persos dans un DataSet
                        DS = Controle.getStatsWEB(JID);
                        if (DS != null)
                        {
                            GV_Stats.DataSource = DS;
                            GV_Stats.DataBind();
                        }
                        
                    }


                    else
                    {
                        text = "JID Invalide ";
                        //Textbox vide erreur
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                    }
                }
                else
                {
                    text = "Le nom d'utilisateur et le mot de passe n'étaient pas correspondant";
                    // Pas connecté
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                }
            }
            else
            {
                text = "Vous devez remplir tout les champs requis";
                //Textbox vide erreur
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                ViderTB();
            }

        }
        protected bool VerifChamps()
        {
            bool Valide = true;
            if (string.IsNullOrWhiteSpace(username.Text))
                Valide = false;
            if (string.IsNullOrWhiteSpace(password.Text))
                Valide = false;

            return Valide;
        }
        protected void ViderTB()
        {
            username.Text = "";
            password.Text = "";
        }

        protected void GV_Leaderboard_OnRowDataBound(object sender, GridViewRowEventArgs e)
        { 
            if (e.Row.RowType == DataControlRowType.DataRow)
             {
        // do your stuffs here, for example if column risk is your third column:
                if (e.Row.Cells[1].Text == username.Text.ToLower())
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}




    



        


        
