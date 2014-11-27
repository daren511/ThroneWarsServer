﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;
using System.Data;
using System.Text;

namespace SiteWebThroneWars
{
    public partial class Magasin : System.Web.UI.Page
    {
        int ItemID = 0;
        int Prix = 0;
        string GVCurrent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            isSessionOn();
        }
        protected void isSessionOn()
        {
            if (!IsPostBack)
            {
                Session["GV"] = "NotPostBack";
            }
            if (Session["username"] != null)
            {
                string test = Session["GV"].ToString();
                username.Text = Session["username"].ToString();
                TB_Monnaie.Text = Controle.GetJoueurMoney(username.Text).ToString();
                if (Session["GV"].ToString() == "Items")
                {
                    ListerItems();
                }
                else if (Session["GV"].ToString() == "Potions")
                {
                    ListerItems();
                }
            }

            else
            {
                string text = "Veuillez vous connecter";
                //Textbox vide erreur
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxWarning(\"" + text + "\");</script>", false);
                Response.Redirect("Connexion.aspx");
            }
        }

        protected void Acheter_Click(object sender, EventArgs e)
        {
            if (TB_Quantite != null)
            {
                if (Int32.Parse(TB_Total.Text) <= Int32.Parse(TB_Monnaie.Text))
                {
                    int JID = Controle.getJID(Session["username"].ToString());
                    int ItemID = Int32.Parse(Session["ItemID"].ToString());
                    if (GVCurrent == "Items")
                        Controle.addItemInventaire(ItemID, JID, Int32.Parse(TB_Quantite.Text));
                    else if (GVCurrent == "Potions")
                        Controle.addPotionJoueurs(ItemID, JID, Int32.Parse(TB_Quantite.Text));

                    Controle.RetirerTotalFromMoney(Int32.Parse(TB_Total.Text), Int32.Parse(TB_Monnaie.Text), JID);
                    TB_Monnaie.Text = Controle.GetJoueurMoney(username.Text).ToString();

                    ViderTB();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxReussi();</script>", false);
                }
                else
                {
                    string text = "Vous n'avez pas assez de monnaie";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                    ViderTB();
                }

            }
            else
            {
                string text = "Veuillez indiquer une quantité";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);

            }

        }
        protected void ListerItems()
        {
            DataSet DSMagasin = new DataSet();

            if (Session["GV"].ToString() == "Items")
                DSMagasin = Controle.listItems(false);
            else if (Session["GV"].ToString() == "Potions")
                DSMagasin = Controle.listPotions(0, 0);
            if (DSMagasin != null)
            {
                GV_Magasin.DataSource = DSMagasin;
                GV_Magasin.DataBind();
            }
        }


        protected void GV_Magasin_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViderTB();
            GridViewRow IDItem = GV_Magasin.SelectedRow;
            ItemID = Int32.Parse(IDItem.Cells[0].Text);
            Session["ItemID"] = ItemID;
            Prix = Int32.Parse(IDItem.Cells[9].Text);
            TB_Prix.Text = Prix.ToString();
        }
        protected void GV_Magasin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D2E6F8'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#219ac2'");
                e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackEventReference(GV_Magasin, "Select$" + e.Row.RowIndex.ToString());
                //if(GV_Magasin.Rows.Count > 8)
                  // this.GV_Magasin.Columns[8].Visible = false;               
            }
            //string count = GV_Magasin.Rows.Count.ToString();

        }
        protected void ViderTB()
        {
            TB_Quantite.Text = "";
            TB_Total.Text = "";
            TB_Prix.Text = "";
        }

        protected void GV_Magasin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_Magasin.PageIndex = e.NewPageIndex;
            GV_Magasin.DataBind();
        }
        protected void BTN_Items_Click(object sender, EventArgs e)
        {
            Session["GV"] = "Items";
            GVCurrent = "Items";
            ListerItems();
        }

        protected void BTN_Potions_Click(object sender, EventArgs e)
        {
            Session["GV"] = "Potions";
            GVCurrent = "Potions";
            ListerItems();
        }
        
    }
    
}