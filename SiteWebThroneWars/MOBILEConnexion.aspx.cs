﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;
using Oracle.DataAccess.Client;
using System.Data;
using System.Text.RegularExpressions;

namespace SiteWebThroneWars
{
    public partial class MOBILEConnexion : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            isSessionOn();
        }
        protected void isSessionOn()
        {
            HttpCookie Cookie = Request.Cookies["Erreur"];
            if (Session["username"] != null)
            {
                int JID = Controle.getJID(Session["username"].ToString());
                DataSet DSLeaderboard = Controle.getLeaderboard(Session["username"].ToString());
                if (DSLeaderboard != null)
                {
                    GV_Leaderboard.DataSource = DSLeaderboard;
                    GV_Leaderboard.DataBind();
                }
                DataSet DS = Controle.getStatsWEB(JID);
                if (DS != null)
                {
                    GV_Stats.DataSource = DS;
                    GV_Stats.DataBind();
                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>changeVisibility();</script>", false);
            }
            if (Cookie != null)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + Cookie.Value + "\");</script>", false);
                Cookie.Expires = DateTime.Now.AddMilliseconds(1);
                Response.Cookies.Add(Cookie);
            }

        }
        
        
        protected void MOBILEConnexion_Click(object sender, EventArgs e)
        {
            //String pour le sweetalert
            string text = "";
            HttpCookie CookieErreur;
            DataSet DS = new DataSet();
            DataSet DSLeaderboard = new DataSet();
            // Textbox non null
            bool ok = VerifChamps();

            bool Connecter = false;
            bool siConfirmer = false;
            // if Text box pas null
            if (ok)
            {
                //Variable des textbox
                string user = username.Text;
                string pass = password.Text;

                string passHash = Controle.hashPassword(pass, null, System.Security.Cryptography.SHA256.Create());
                Connecter = Controle.userPassCorrespondant(user, passHash);
                if (Connecter)
                    siConfirmer = Controle.accountIsConfirmed(user);
                else
                {
                    text = "Compte inexistant";
                    // Pas connecté
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxWarning(\"" + text + "\");</script>", false);
                    if (Session["username"] != null)
                    {
                        CookieErreur = new HttpCookie("Erreur", text);
                        Response.Cookies.Add(CookieErreur);
                        Session.Abandon();
                        Response.Redirect("MOBILEConnexion.aspx");
                    }
                    ViderTB();
                }
                if (!siConfirmer && Connecter)
                {
                    text = "Veuillez visiter votre courriel pour confirmer votre compte";
                    // Pas connecté
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxWarning(\"" + text + "\");</script>", false);
                    CookieErreur = new HttpCookie("Erreur", text);
                    Response.Cookies.Add(CookieErreur);
                    Response.Redirect("MOBILEConnexion.aspx");
                    ViderTB();
                }
                if (Connecter)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxReussi();</script>", false);

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
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>changeVisibility();</script>", false);
                        Session["username"] = username.Text;
                        ViderTB();

                    }
                    else
                    {
                        text = "JID Invalide ";
                        //Textbox vide erreur
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                        if (Session["username"] != null)
                        {
                            CookieErreur = new HttpCookie("Erreur", text);
                            Response.Cookies.Add(CookieErreur);
                            Session.Abandon();
                            Response.Redirect("MOBILEConnexion.aspx");
                        }

                        ViderTB();
                    }
                }
                else
                {
                    text = "Le nom d'utilisateur et le mot de passe n'étaient pas correspondant";
                    // Pas connecté
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                    if (Session["username"] != null)
                    {
                        CookieErreur = new HttpCookie("Erreur", text);
                        Response.Cookies.Add(CookieErreur);
                        Session.Abandon();
                        Response.Redirect("MOBILEConnexion.aspx");
                    }
                    ViderTB();
                }
            }

            else
            {
                text = "Vous devez remplir tout les champs requis";
                //Textbox vide erreur
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                if (Session["username"] != null)
                {
                    CookieErreur = new HttpCookie("Erreur", text);
                    Response.Cookies.Add(CookieErreur);
                    Session.Abandon();
                    Response.Redirect("MOBILEConnexion.aspx");
                }

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
                    e.Row.BackColor = System.Drawing.Color.PowderBlue;
                }
            }
        }
    }
}












