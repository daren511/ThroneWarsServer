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
    public partial class FORM_Classe : Form
    {
        public FORM_Classe()
        {
            InitializeComponent();
        }

        private void FORM_Classe_Load(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(TB_Nom, "Nom");
            ToolTip.SetToolTip(TB_Level, "Niveau");
            ToolTip.SetToolTip(TB_Life, "Points de vie");
            ToolTip.SetToolTip(TB_WATK, "Attaque physique");
            ToolTip.SetToolTip(TB_WDEF, "Défense physique");
            ToolTip.SetToolTip(TB_MATK, "Attaque magique");
            ToolTip.SetToolTip(TB_MDEF, "Défense magique");
        }
    }
}
