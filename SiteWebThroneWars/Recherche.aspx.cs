﻿using System;
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
            DataSet DSLeaderboardSelection = new DataSet();
            if (ok)
            {

                string user = TB_UsernameSearch.Text;
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
                    DSLeaderboard = Controle.ReturnLeaderboard(user, true);
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
                    TB_UsernameSearch.Text = "";

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
            DataSet DSLeaderboard = Controle.ReturnLeaderboard(null,false);
            if (DSLeaderboard != null)
            {
                GV_Leaderboard.DataSource = DSLeaderboard;
                GV_Leaderboard.DataBind();
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

        protected void GV_Leaderboard_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (!(e.Row.BackColor == System.Drawing.Color.Red))
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D2E6F8'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#219ac2'");
                    e.Row.Attributes["style"] = "cursor:pointer";
                    e.Row.Attributes["onclick"] = ClientScript.GetPostBackEventReference(GV_Leaderboard, "Select$" + e.Row.RowIndex.ToString());
                }
                // do your stuffs here, for example if column risk is your third column:
                if (e.Row.Cells[1].Text == TB_UsernameSearch.Text.ToLower())
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }



        protected void GV_Leaderboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow rowColor in GV_Leaderboard.Rows)
            {
                rowColor.BackColor = System.Drawing.Color.Transparent;
            }
            GridViewRow row = GV_Leaderboard.SelectedRow;
            DataSet DSLeaderboardSelection = new DataSet();
            string user = row.Cells[1].Text;
            row.BackColor = System.Drawing.Color.Red;

            int JID = Controle.getJID(user);
            DSLeaderboardSelection = Controle.ReturnStatsWEB(JID);
            if (DSLeaderboardSelection != null)
            {
                GV_Stats.DataSource = DSLeaderboardSelection;
                GV_Stats.DataBind();
            }
        }

        protected void GV_Leaderboard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_Leaderboard.PageIndex = e.NewPageIndex;
            GV_Leaderboard.DataBind();
        }
    }
}