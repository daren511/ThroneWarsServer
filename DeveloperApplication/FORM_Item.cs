using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using ControleBD;

namespace DeveloperApplication
{
    public partial class FORM_Item : Form
    {
        //---------- VARIABLES ----------//
        public int IID
        {
            get { return int.Parse(LBL_IID.Text); }
            set { LBL_IID.Text = value.ToString(); }
        }

        public string NOM
        {
            get { return TB_Nom.Text; }
            set { TB_Nom.Text = value; }
        }

        public string CLASSE
        {
            get { return CB_Classe.Text; }
            set { CB_Classe.Text = value.ToString(); }
        }

        public int LEVEL
        {
            get { return int.Parse(TB_Level.Text); }
            set { TB_Level.Text = value.ToString(); }
        }

        public int WATK
        {
            get { return int.Parse(TB_WATK.Text); }
            set { TB_WATK.Text = value.ToString(); }
        }

        public int WDEF
        {
            get { return int.Parse(TB_WDEF.Text); }
            set { TB_WDEF.Text = value.ToString(); }
        }

        public int MATK
        {
            get { return int.Parse(TB_MATK.Text); }
            set { TB_MATK.Text = value.ToString(); }
        }

        public int MDEF
        {
            get { return int.Parse(TB_MDEF.Text); }
            set { TB_MDEF.Text = value.ToString(); }
        }

        public int QUANTITE
        {
            get { return int.Parse(TB_Quantite.Text); }
            set { TB_Quantite.Text = value.ToString(); }
        }

        public string ISACTIVE
        {
            get { return CHECK_IsActive.Checked ? "1" : "0"; }
            set { CHECK_IsActive.Checked = Convert.ToBoolean(Int32.Parse(value)); }
        }

        public bool VISIBLE = true;


        public FORM_Item()
        {
            InitializeComponent();
        }

        private void FORM_Item_Load(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(TB_Nom, "Nom");
            ToolTip.SetToolTip(TB_Level, "Niveau");
            ToolTip.SetToolTip(TB_WATK, "Attaque physique");
            ToolTip.SetToolTip(TB_WDEF, "Défense physique");
            ToolTip.SetToolTip(TB_MATK, "Attaque magique");
            ToolTip.SetToolTip(TB_MDEF, "Défense magique");
            ToolTip.SetToolTip(CB_Classe, "Classe");
            ToolTip.SetToolTip(TB_Quantite, "Quantité");
            FillComboBox();

            if (!VISIBLE)
                TB_Quantite.Visible = false;
        }

        private void CheckKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void FillComboBox()
        {
            List<string> classes = Controle.FillClasses();
            for (int i = 0; i < classes.Count; ++i)
                CB_Classe.Items.Add(classes[i]);
        }
    }
}
