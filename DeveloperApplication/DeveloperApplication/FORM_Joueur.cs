using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeveloperApplication
{
    public partial class FORM_Joueur : Form
    {
        public FORM_Joueur()
        {
            InitializeComponent();
        }

        private void FORM_Joueur_Load(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(TB_Username, "Nom d'usager");
            ToolTip.SetToolTip(TB_PWD, "Mot de passe");
            ToolTip.SetToolTip(TB_Email, "Email");
            ToolTip.SetToolTip(TB_Argent, "Argent");
            ToolTip.SetToolTip(DTP_JoinDate, "Date joint");
        }
    }
}
