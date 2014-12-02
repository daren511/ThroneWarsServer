using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;
using Emails;


namespace SiteWebThroneWars
{
    public partial class MOBILESendConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SendLinkBack_Click(object sender, EventArgs e)
        {
            string text = "";
            string user = TB_Username.Text;
            bool ok = VerifChamps();
            if (ok)
            {
                bool userExiste = Controle.userExiste(user);
                if (userExiste)
                {
                    bool isConfirmed = Controle.accountIsConfirmed(user);
                    string courriel = Controle.getEmail(user);
                    if (!isConfirmed)
                    {
                        Random random = new Random();
                        int randomNumber = random.Next(1, 9);
                        Controle.Rotation rot = new Controle.Rotation(randomNumber);
                        string userHash = rot.Chiffrer(user);
                        userHash += randomNumber;
                        string link = "<a href=http://www.thronewars.ca/ConfirmAccount.aspx?User=" + userHash + ">Ici</a>";
                        // Send email de confirmation
                        Email.sendMail(courriel, Email.SujetInscription, Email.BodyConfirmation + link);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxReussi();</script>", false);
                    }
                    else
                    {
                        text = "Votre compte est déja confirmé";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                    }
                }
                else
                {
                    text = "Votre usager n'existe pas";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
                }
            }
            else
            {
                text = "Veuillez remplir tout les champs";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MessageBoxErreur(\"" + text + "\");</script>", false);
            }
        }
        protected bool VerifChamps()
        {
            bool Valide = false;
            if (!string.IsNullOrWhiteSpace(TB_Username.Text) && !string.IsNullOrWhiteSpace(TB_Username.Text))
            {
                Valide = true;
            }
            return Valide;
        }
    }
}