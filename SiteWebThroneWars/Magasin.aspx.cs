using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;
using System.Data;

namespace SiteWebThroneWars
{
    public partial class Magasin : System.Web.UI.Page
    {
        int ItemID = 0;
        int Prix = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                username.Text = Session["username"].ToString();
                ListerItems();
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
            int JID = Controle.getJID(Session["username"].ToString());
            //Fonction dans controle qui ajouter au compte l'item ID dans ItemID
            Controle.addItemInventaire(ItemID,JID,Int32.Parse(TB_Quantite.Text));
        }
        protected void ListerItems()
        {
            DataSet DSMagasin = new DataSet();

            DSMagasin = Controle.listItems(false);
            if (DSMagasin != null)
            {
                GV_Magasin.DataSource = DSMagasin;
                GV_Magasin.DataBind();
            }
        }

        protected void GV_Magasin_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow IDItem = GV_Magasin.SelectedRow;
            ItemID = Int32.Parse(IDItem.Cells[0].ToString());
            Prix = Int32.Parse(IDItem.Cells[9].ToString());

        }
        protected void GV_Magasin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[8].Visible = false;
        }

        protected void TB_Quantite_TextChanged(object sender, EventArgs e)
        {
            int total = (Prix * (Int32.Parse(TB_Quantite.Text)));
            TB_Total.Text = total.ToString();
        }
    }
}