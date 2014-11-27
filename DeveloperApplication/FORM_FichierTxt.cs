using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleBD;
using System.IO;

namespace DeveloperApplication
{
    public partial class FORM_FichierTxt : Form
    {
        //---------- VARIABLES ----------//
        string[] tabItems;

        public FORM_FichierTxt()
        {
            InitializeComponent();
        }

        private void FORM_FichierTxt_Load(object sender, EventArgs e)
        {
            CB_Type.SelectedIndex = 0;
            CB_Niveau.SelectedIndex = 0;
        }

        private void BTN_OuvrirFichier_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fileDialog.FileName))
                TB_Path.Text = fileDialog.FileName;
        }

        private void TB_Path_TextChanged(object sender, EventArgs e)
        {
            fileDialog.FileName = TB_Path.Text;
            LB_Noms.Items.Clear();
            if (fileDialog.CheckPathExists && fileDialog.CheckFileExists)
            {
                tabItems = File.ReadAllLines(TB_Path.Text);
                for (int i = 0; i < tabItems.Length; ++i)
                    LB_Noms.Items.Add(tabItems[i]);
            }
        }

        private void BTN_Insert_Click(object sender, EventArgs e)
        {

        }

        private void LB_Noms_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_Nom.Text = LB_Noms.SelectedItem.ToString();
        }

        private void TB_Nom_TextChanged(object sender, EventArgs e)
        {
            int index = LB_Noms.SelectedIndex;
            LB_Noms.Items[index] = TB_Nom.Text;
        }
    }
}
