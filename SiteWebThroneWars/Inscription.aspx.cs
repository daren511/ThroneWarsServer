using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleBD;

namespace SiteWebThroneWars
{
    public partial class Inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void inscriptionJoueur(object sender, EventArgs e)
        {
            Controle.insertplayer("inserer","textbox","ici");
        }
    }
}