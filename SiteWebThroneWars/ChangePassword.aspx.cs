using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteWebThroneWars
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button_Valider.Enabled = false;
        }


        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            
            if (apassword == npassword || npassword != ncpassword)
            {
                //OldPass.ForeColor = ; // couleur -- not sure forecolor checker
                //NewPass.ForeColor = ;
                //cNewPass.ForeColor = ;
            }
        }

    }
}