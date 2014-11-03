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
    public partial class FORM_Perso : Form
    {
        public FORM_Perso()
        {
            InitializeComponent();
        }

        private void FORM_Perso_Load(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(TB_Nom, "Nom");
            ToolTip.SetToolTip(TB_Level, "Email");
            ToolTip.SetToolTip(TB_XP, "Email");
            ToolTip.SetToolTip(CB_Classe, "Classe");
        }
    }
}
