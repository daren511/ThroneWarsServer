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
            // Verif si textbox sont pas null
            bool ok = VerifChamps();

            //Verif si username existe dans la BD
            bool UserExiste = Controle.UsernameExiste(username);
            if (UserExiste)
            {
                // Si recovery reussie
                bool RecoveryReussi = Controle.PasswordRecovery(username);

                // what to do after ?
            }
             
        }
        protected bool VerifChamps()
        {
            bool Valide = false;
            if (!string.IsNullOrWhiteSpace(TB_Username.Text))
            {
                Valide = true;
            }
            return Valide;
        }

    }
}