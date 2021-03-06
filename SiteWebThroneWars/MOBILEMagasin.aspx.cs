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
    public partial class MOBILEMagasin : System.Web.UI.Page
    {
        // Variable pour l'ID de l'item et son prix
        int ItemID = 0;
        int Prix = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si une session existe
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
                // Si une session existe il peut visiter le magasin
                User_Set.Text = Session["username"].ToString();
                Money_Set.Text = Controle.GetJoueurMoney(User_Set.Text).ToString();
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
                string text = "Veuillez vous connecter avant d'accéder au magasin";
                //Textbox vide erreur
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxWarning(\"" + text + "\");</script>", false);
            }
        }

        protected void Acheter_Click(object sender, EventArgs e)
        {
            // Si le tb prix n'est pas vide
            if (TB_Prix.Text != "")
            {
                // Si le tb quantité n'est pas vide
                if (TB_Quantite.Text != "")
                {
                    // Si le total n'est pas plus grand que l'argent que l'usager a
                    if (Int32.Parse(TB_Total.Text) <= Int32.Parse(Money_Set.Text))
                    {
                        // Prend son JID
                        int JID = Controle.getJID(Session["username"].ToString());
                        // Prend l'ID de l'item
                        int ItemID = Int32.Parse(Session["ItemID"].ToString());
                        // Si le current GridView est items
                        if (Session["GV"].ToString() == "Items")
                            Controle.addItemInventaire(ItemID, JID, Int32.Parse(TB_Quantite.Text));
                        // Si le current Gridview est potion
                        else if (Session["GV"].ToString() == "Potions")
                            Controle.addPotionJoueurs(ItemID, JID, Int32.Parse(TB_Quantite.Text));

                        // Retire l'argent du porte feuille de l'usager
                        Controle.RetirerTotalFromMoney(Int32.Parse(TB_Total.Text), Int32.Parse(Money_Set.Text), JID);
                        Money_Set.Text = Controle.GetJoueurMoney(User_Set.Text).ToString();

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
            else
            {
                string text = "Veuillez sélectionner un item";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                ViderTB();
            }

        }
        protected void ListerItems()
        {
            DataSet DSMagasin = new DataSet();
            // Si le current Gridview est Items
            if (Session["GV"].ToString() == "Items")
                DSMagasin = Controle.listItems(false, 0, 0, 0, true);
            // Si le current Gridview est Potions
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
            // Récupère la ligne du gridview selectionné
            GridViewRow IDItem = GV_Magasin.SelectedRow;
            // ItemID = la cell 0
            ItemID = Int32.Parse(IDItem.Cells[0].Text);
            Session["ItemID"] = ItemID;
            if (Session["GV"].ToString() == "Items")
                Prix = Int32.Parse(IDItem.Cells[8].Text);
            else if (Session["GV"].ToString() == "Potions")
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
            }

        }
        protected void ViderTB()
        {
            TB_Quantite.Text = "";
            TB_Total.Text = "";
            TB_Prix.Text = "";
        }
        protected void BTN_Items_Click(object sender, EventArgs e)
        {
            Session["GV"] = "Items";
            ListerItems();
        }

        protected void BTN_Potions_Click(object sender, EventArgs e)
        {
            Session["GV"] = "Potions";
            ListerItems();
        }

        protected void GV_Magasin_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
        }

        protected void GV_Magasin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_Magasin.PageIndex = e.NewPageIndex;
            GV_Magasin.DataBind();
        }
    }

}