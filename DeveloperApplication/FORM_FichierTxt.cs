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
        // Array
        string[] tabDefault;
        string[] tabItems;
        // List
        List<List<string>> listGlobalArmes = new List<List<string>>();
        List<string> listTousArmes = new List<string>();
        List<string> listTousArmures = new List<string>();
        List<string> listGuerrierArmes = new List<string>();
        List<string> listGuerrierArmures = new List<string>();
        List<string> listArcherArmes = new List<string>();
        List<string> listArcherArmures = new List<string>();
        List<string> listMageArmes = new List<string>();
        List<string> listMageArmures = new List<string>();
        List<string> listPretreArmes = new List<string>();
        List<string> listPretreArmures = new List<string>();
        // Infos
        string classe = "";
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
            if ((LB_Noms.SelectedItem.ToString().StartsWith("[") && LB_Noms.SelectedItem.ToString().EndsWith("]")) ||
                ((LB_Noms.SelectedItem.ToString().StartsWith("{") && LB_Noms.SelectedItem.ToString().EndsWith("}"))))
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
            SplitClasses();
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
            ClearTables();
            if (File.Exists(TB_Path.Text))
            {
                string strClasse = null;
                string strType = null;
                tabItems = tabDefault = File.ReadAllLines(TB_Path.Text);
                for (int i = 0; i < tabItems.Length; ++i)
                {
                    if (tabItems[i].ToString().StartsWith("[") && tabItems[i].ToString().EndsWith("]"))
                    {
                        strClasse = tabItems[i].ToString();
                        ++i;
                    }
                    if (tabItems[i].ToString().StartsWith("{") && tabItems[i].ToString().EndsWith("}"))
                    {
                        strType = tabItems[i].ToString();
                        ++i;
                    }
                    addItemInList(strClasse, strType, i);
                }
            }
        }

        private void addItemInList(string strClasse, string strType, int i)
        {
            switch (strClasse)
            {
                case "[TOUS]":
                    if (strType == "{ARME}")
                        listTousArmes.Add(tabItems[i].ToString());
                    else if (strType == "{ARMURE}")
                        listTousArmures.Add(tabItems[i].ToString());
                    break;
                case "[GUERRIER]":
                    if (strType == "{ARME}")
                        listGuerrierArmes.Add(tabItems[i].ToString());
                    else if (strType == "{ARMURE}")
                        listGuerrierArmes.Add(tabItems[i].ToString());
                    break;
                case "[ARCHER]":
                    if (strType == "{ARME}")
                        listArcherArmes.Add(tabItems[i].ToString());
                    else if (strType == "{ARMURE}")
                        listArcherArmes.Add(tabItems[i].ToString());
                    break;
                case "[MAGE]":
                    if (strType == "{ARME}")
                        listMageArmes.Add(tabItems[i].ToString());
                    else if (strType == "{ARMURE}")
                        listMageArmes.Add(tabItems[i].ToString());
                    break;
                case "[PRETRE]":
                    if (strType == "{ARME}")
                        listPretreArmes.Add(tabItems[i].ToString());
                    else if (strType == "{ARMURE}")
                        listPretreArmes.Add(tabItems[i].ToString());
                    break;
                default:
                    if (strType == "{ARME}")
                        listTousArmes.Add(tabItems[i].ToString());
                    else if (strType == "{ARMURE}")
                        listTousArmures.Add(tabItems[i].ToString());
                    break;
            }
        }

        private void ClearTables()
        {
            tabItems = tabDefault = null;
            // Armes
            listTousArmes.Clear();
            listGuerrierArmes.Clear();
            listArcherArmes.Clear();
            listMageArmes.Clear();
            listPretreArmes.Clear();
            // Armures
            listTousArmures.Clear();
            listGuerrierArmures.Clear();
            listArcherArmures.Clear();
            listMageArmures.Clear();
            listPretreArmures.Clear();
        }

        private void InsererArmes()
        {

        }
    }
}