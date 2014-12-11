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
            // Regarde une session existe
            isSessionOn();
        }
        protected void isSessionOn()
        {
            // Cherche si le cookie erreur est présent
            HttpCookie Cookie = Request.Cookies["Erreur"];
            // Si la variable de session username n'est pas null
            if (Session["username"] != null)
            {
                username.Enabled = false;
                username.Text = Session["username"].ToString();
                password.Enabled = false;
                BTN_Connecter.Text = "Se déconnecter";
                // Get le JID
                int JID = Controle.getJID(Session["username"].ToString());
                //Rempli le leaderbord
                DataSet DSLeaderboard = Controle.getLeaderboard(Session["username"].ToString());
                if (DSLeaderboard != null)
                {
                    GV_Leaderboard.DataSource = DSLeaderboard;
                    GV_Leaderboard.DataBind();
                }
                // Rempli les stats
                DataSet DS = Controle.getStatsWEB(JID);
                if (DS != null)
                {
                    GV_Stats.DataSource = DS;
                    GV_Stats.DataBind();
                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>changeVisibility();</script>", false);
            }
            if(Cookie != null)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + Cookie.Value + "\");</script>", false);
                Cookie.Expires = DateTime.Now.AddMilliseconds(1);
                Response.Cookies.Add(Cookie);
            }

        }
        protected void Connexion_Click(object sender, EventArgs e)
        {
            // Si la session n'est pas null on abandonne la session
            if(Session["username"] != null)
            {
                Session.Abandon();
                Response.Redirect("Connexion.aspx");
            }
            
            //String pour le sweetalert
            string text = "";
            HttpCookie CookieErreur;
            DataSet DS = new DataSet();
            DataSet DSLeaderboard = new DataSet();
            // Textbox non null
            bool ok = VerifChamps();

            bool Connecter = false;
            bool siConfirmer = false;
            bool siExiste = false;
            // if Text box pas null
            if (ok)
            {
                //Variable des textbox
                string user = username.Text;
                string pass = password.Text;

                // Encrypte le password
                string passHash = Controle.hashPassword(pass, null, System.Security.Cryptography.SHA256.Create());
                // Si c'est correspondante
                Connecter = Controle.userPassCorrespondant(user, passHash);
                // si le username existe
                siExiste = Controle.userExiste(user);
                
                if (!siExiste)
                {
                    text = "Compte inexistant";
                    // Pas connecté
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxWarning(\"" + text + "\");</script>", false);
                    if (Session["username"] != null)
                    {
                        CookieErreur = new HttpCookie("Erreur", text);
                        Response.Cookies.Add(CookieErreur);
                        Session.Abandon();
                        Response.Redirect("Connexion.aspx");
                    }
                    ViderTB();
                }
                else
                    // Si l'account est confirmé
                    siConfirmer = Controle.accountIsConfirmed(user);
                    
                if (!siConfirmer && Connecter)
                {
                    text = "Veuillez visiter votre courriel pour confirmer votre compte";
                    // Pas connecté
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxWarning(\"" + text + "\");</script>", false);
                    CookieErreur = new HttpCookie("Erreur", text);
                    Response.Cookies.Add(CookieErreur);
                    Response.Redirect("Connexion.aspx");
                    ViderTB();
                }
                if (Connecter && siConfirmer)
                {
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
                        Response.Redirect("Connexion.aspx");

                    }
                    else
                    {
                        text = "JID Invalide ";
             
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                        if (Session["username"] != null)
                        {
                            CookieErreur = new HttpCookie("Erreur", text);
                            Response.Cookies.Add(CookieErreur);
                            Session.Abandon();
                            Response.Redirect("Connexion.aspx");
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
                        Response.Redirect("Connexion.aspx");
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
                    Response.Redirect("Connexion.aspx");
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




    



        


        
