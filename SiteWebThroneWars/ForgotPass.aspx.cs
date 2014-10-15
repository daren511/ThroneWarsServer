using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SiteWebThroneWars
{
    public partial class ForgotPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                      

        }
        protected void PasswordRecovery(object sender, EventArgs e)
        {
            string username = TB_Username.Text;

            bool ok = Controle.PasswordRecovery(username);
            if (ok)
            {

            }
            else
                Response.Redirect("Forgotpass.aspx");
             
        }
    }
}