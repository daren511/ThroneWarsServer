using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteWebThroneWars
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string urlHash = Request.QueryString["user"];
        }
        protected void ResetPass_Click(object sender, EventArgs e)
        { 
            
        }
    }
}