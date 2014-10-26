using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;

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
            if(ok)
            { 
            string user = TB_UsernameSearch.Text;
            //Ramener la position du username dans le leaderboard


            //Ramener stats
        }
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
                TableCell tdVictoires = new TableCell();
                TableCell tdDefaites = new TableCell();
                tr.Cells.Add(tdPosition);
                tr.Cells.Add(tdUsername);
                tr.Cells.Add(tdVictoires);
                tr.Cells.Add(tdDefaites);
                tdPosition.Text = i.ToString();
                tdUsername.Text = "Hcfranck";
                tdVictoires.Text = "9001";
                tdDefaites.Text = "1";
            }
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
    }
}