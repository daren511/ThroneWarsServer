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
        }


        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            bool ChampsValide = VerifChamps();
            if (ChampsValide)
            {
                if (apassword == npassword || npassword != ncpassword)
                {
                    //Verif si forecolor is the right thing
                    OldPass.ForeColor = System.Drawing.Color.Red;
                    NewPass.ForeColor = System.Drawing.Color.Red;
                    cNewPass.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    //Chercher le username et son password correspondant 
                    // Verif si le text d'ancien mot de passe est correspondant a celui dans la BD
                    // Crypter le nouveau mot de passe et envoyer
                    // Messagebox changement réussi
                }
            }

        }
        protected bool VerifChamps()
        {
            bool Valide = false;
            if (!string.IsNullOrWhiteSpace(apassword.Text) || !string.IsNullOrWhiteSpace(npassword.Text) || !string.IsNullOrWhiteSpace(ncpassword.Text))
            {
                Valide = true;
            }
            return Valide;
        }


    }
}