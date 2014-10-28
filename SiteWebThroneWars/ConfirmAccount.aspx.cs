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
        {/*
            string text = "";
            bool RecoveryOK = false;
            string URL = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(URL);
            string userHash = HttpUtility.ParseQueryString(myUri.Query).Get("User");
            RecoveryOK = Controle.confirmAccount(userHash);
            if(RecoveryOK)
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxReussi();</script>", false);
            else
            {
                text = "Quelque chose s'est passé , votre confirmation à échoué";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
            }
          * */
        }
    }
}