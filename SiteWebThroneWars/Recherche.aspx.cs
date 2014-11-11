using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;
using System.Data;

namespace SiteWebThroneWars
{
    public partial class Stats2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Leaderboard_Croissant();
        }

        protected void Rechercher_Click(object sender, EventArgs e)
        {
            //Textbox pas null
            bool ok = VerifChamps();
            string text = "";
            DataSet DSStats = new DataSet();
            DataSet DSLeaderboard = new DataSet();
            if (ok)
            {
                
                string user = TB_UsernameSearch.Text.ToLower();
                bool UserExiste = Controle.UserExiste(user);
                //Prend le JID
                int JID = Controle.getJID(user);
                if (UserExiste)
                {

                    //Random random = new Random();
                    //int randomNumber = random.Next(1, 9);
                    //string userHash = Controle.Phrase.Chiffrer(user, randomNumber);
                    //Response.Redirect("www.thronewars.ca/Recherche?User="+userHash);

                    //Ramener la position du username dans le leaderboard
                    DSLeaderboard = Controle.ReturnLeaderboard(user,true);
                    if (DSLeaderboard != null)
                    {
                        GV_Leaderboard.DataSource = DSLeaderboard;
                        GV_Leaderboard.DataBind();
                    }


                    //Ramener stats
                    DSStats = Controle.ReturnStatsWEB(JID);
                    if (DSStats != null)
                    {
                        GV_Stats.DataSource = DSStats;
                        GV_Stats.DataBind(); 
                    }
                }
                else
                { 
                    //Message erreur user inexistant
                    text = "Usager inexistant";
                    //Textbox vide erreur
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                }
            }
            else
            { 
                // message erreur champs vide
                text = "Veuillez remplir tout les champs";
                //Textbox vide erreur
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);

            }
        }

        private void Leaderboard_Croissant()
        {

            //Pour tous les enrigistrements du leaderboard
            
        }

        protected bool VerifChamps()
        {
            bool Valide = false;
            if (!string.IsNullOrWhiteSpace(TB_UsernameSearch.Text))
            {
                Valide = true;
            }
            return Valide;
        }

        protected void GV_Leaderboard_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // do your stuffs here, for example if column risk is your third column:
                if (e.Row.Cells[1].Text == TB_UsernameSearch.Text.ToLower())
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}