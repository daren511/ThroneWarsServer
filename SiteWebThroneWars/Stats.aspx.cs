using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteWebThroneWars
{
    public partial class Stats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // afficher le leaderboard normal la
        }
        protected void Rechercher_Click(object sender, EventArgs e)
        {
            // Passer le click en post et recevoir en get ***

            // Acces à la bd pour rechercher le joueur demandé
            string user = TB_UsernameSearch.Text;


            // Afficher la positon du joueur dans le leaderboard + highlight + 1 joueur au dessus et dessous si non premier


            // Afficher stats des character

            //TB_UsernameStats.Text = ;
            //TB_XPStats.Text = ;
            //TB_Player1.Text ; 
            //TB_LVP1.Text = ;
            //TB_Player2.Text ; 
            //TB_LVP2.Text = ;
            //TB_Player3.Text ; 
            //TB_LVP3.Text = ;
            //TB_Player4.Text ; 
            //TB_LVP4.Text = ;
            
        }
    }
}