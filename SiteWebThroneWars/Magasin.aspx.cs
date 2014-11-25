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
    }
}