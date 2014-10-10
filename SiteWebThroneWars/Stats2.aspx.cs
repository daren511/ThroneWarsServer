using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            // Chercher le username dans la bd, rammene la position leaderboard + stats joueur 
            Leaderboard_Croissant();
        }

        private void Leaderboard_Croissant()
        {

            //Pour tous les enrigistrements de la BD
            for (int i = 1; i < 100; ++i)
            {
                TableRow tr = new TableRow();
                table.Rows.Add(tr);
                // Pour tous les champs de l'enrigistrements courant
                TableCell tdPosition = new TableCell();
                TableCell tdUsername = new TableCell();
                TableCell tdXP = new TableCell();
                tr.Cells.Add(tdPosition);
                tr.Cells.Add(tdUsername);
                tr.Cells.Add(tdXP);
                tdPosition.Text = i.ToString();
                tdUsername.Text = "Hcfranck";
                tdXP.Text = "13154651531";


            }
        }
    }
}