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
        string[] tabDefault;
        string[] tabItems;
        List<string> listTous = new List<string>();
        List<string> listGuerrier = new List<string>();
        List<string> listArcher = new List<string>();
        List<string> listMage = new List<string>();
        List<string> listPretre = new List<string>();
        string classe = null;
        int watk = 0;
        int wdef = 0;
        int matk = 0;
        int mdef = 0;
        string actif = "1";
        int price = 0;

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
            if (fileDialog.ShowDialog() == DialogResult.OK)
                TB_Path.Text = fileDialog.FileName;
        }

        private void TB_Path_TextChanged(object sender, EventArgs e)
        {
            fileDialog.FileName = TB_Path.Text;
            SplitClasses();
            ListerItems();
        }

        private void BTN_Insert_Click(object sender, EventArgs e)
        {

        }

        private void BTN_Supprimer_Click(object sender, EventArgs e)
        {
            tabItems = tabItems.Where(val => val != LB_Noms.SelectedItem.ToString()).ToArray();
            ListerItems();
        }

        private void LB_Noms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Noms.SelectedItem != null)
                TB_Nom.Text = LB_Noms.SelectedItem.ToString();
            if (LB_Noms.SelectedItem.ToString().StartsWith("[") && LB_Noms.SelectedItem.ToString().EndsWith("]"))
            {
                TB_Nom.Text = "";
                BTN_Modifier.Enabled = false;
            }
        }

        private void BTN_Modifier_Click(object sender, EventArgs e)
        {
            tabItems[LB_Noms.SelectedIndex] = TB_Nom.Text;
            ListerItems();
        }

        private void BTN_Instructions_Click(object sender, EventArgs e)
        {
            FORM_Instructions FI = new FORM_Instructions();
            FI.ShowDialog();
        }

        private void ListerItems()
        {
            int index = LB_Noms.SelectedIndex;
            LB_Noms.Items.Clear();
            if (tabItems != null)
            {
                for (int i = 0; i < tabItems.Length; ++i)
                    LB_Noms.Items.Add(tabItems[i]);
                LBL_Total.Text = LB_Noms.Items.Count.ToString() + "/" + tabDefault.Length.ToString();

                if (LB_Noms.Items.Count > 1) 
                    LBL_Total.Text += " lignes";
                else 
                    LBL_Total.Text += " ligne";
                if (index < LB_Noms.Items.Count) 
                    LB_Noms.SelectedIndex = index;
            }
            else
            {
                LBL_Total.Text = "";
                BTN_Insert.Enabled = false;
                BTN_Modifier.Enabled = false;
                BTN_Supprimer.Enabled = false;
                TB_Nom.Enabled = false;
            }
        }

        private void SplitClasses()
        {
            if (File.Exists(TB_Path.Text))
            {
                string str = null;
                tabItems = tabDefault = File.ReadAllLines(TB_Path.Text);
                for (int i = 0; i < tabItems.Length; ++i)
                {
                    if (tabItems[i].ToString().StartsWith("[") && tabItems[i].ToString().EndsWith("]"))
                    {
                        str = tabItems[i].ToString();
                        ++i;
                    }
                    switch (str)
                    {
                        case "[TOUS]":
                            listTous.Add(tabItems[i].ToString());
                            break;
                        case "[GUERRIER]":
                            listGuerrier.Add(tabItems[i].ToString());
                            break;
                        case "[ARCHER]":
                            listArcher.Add(tabItems[i].ToString());
                            break;
                        case "[MAGE]":
                            listMage.Add(tabItems[i].ToString());
                            break;
                        case "[PRETRE]":
                            listPretre.Add(tabItems[i].ToString());
                            break;
                        default:
                            listTous.Add(tabItems[i].ToString());
                            break;
                    }
                }
            }
            else
            {
                tabItems = tabDefault = null;
                listTous.Clear();
                listGuerrier.Clear();
                listArcher.Clear();
                listMage.Clear();
                listPretre.Clear();
            }
        }
    }
}