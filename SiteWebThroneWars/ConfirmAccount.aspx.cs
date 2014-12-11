using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;

namespace SiteWebThroneWars
{
    public partial class ConfirmAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool RecoveryOK = false;
            string text = "";
            // Prend le URL du browser
            string URL = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(URL);
            // Split sur la partie apres le User ( .ca?User=__)
            string userSplit = HttpUtility.ParseQueryString(myUri.Query).Get("User");
            // Confirme l'account 
            RecoveryOK = Controle.confirmAccount(userSplit);

            if (RecoveryOK)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxReussi();</script>", false);
            }
            else
            {
                text = "Quelque chose s'est passé , votre confirmation à échoué";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
            }
        }        
    }
}