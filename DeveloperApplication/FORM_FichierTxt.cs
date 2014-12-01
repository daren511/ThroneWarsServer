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
        // Values
        int minWATK = 0;
        int maxWATK = 0;
        int minMATK = 0;
        int maxMATK = 0;
        int minWDEF = 0;
        int maxWDEF = 0;
        int minMDEF = 0;
        int maxMDEF = 0;
        // Array
        string[] tabItems;
        // Attributs item
        string nom = "";
        string classe = "";
        int level = 0;
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
            BTN_Supprimer.Enabled = false;
            BTN_Insert.Enabled = false;
            LBL_Total_Inserer.Text = "";
            LBL_NonInserer.Text = "";
        }

        private void BTN_OuvrirFichier_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
                TB_Path.Text = fileDialog.FileName;
        }

        private void TB_Path_TextChanged(object sender, EventArgs e)
        {
            LBL_Total_Inserer.Text = "";
            LBL_NonInserer.Text = "";
            fileDialog.FileName = TB_Path.Text;
            tabItems = File.ReadAllLines(TB_Path.Text);
            ListerItems();
        }

        private void BTN_Insert_Click(object sender, EventArgs e)
        {
            InsererItem();
        }

        private void BTN_Supprimer_Click(object sender, EventArgs e)
        {
            tabItems = tabItems.Where(val => val != LB_Noms.SelectedItem.ToString()).ToArray();
            ListerItems();
        }

        private void LB_Noms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Noms.SelectedItem != null)
                BTN_Supprimer.Enabled = true;
            if ((LB_Noms.SelectedItem.ToString().StartsWith("[") && LB_Noms.SelectedItem.ToString().EndsWith("]")) ||
                ((LB_Noms.SelectedItem.ToString().StartsWith("{") && LB_Noms.SelectedItem.ToString().EndsWith("}"))))
                BTN_Supprimer.Enabled = false;
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
                BTN_Insert.Enabled = tabItems.Length == 0 ? false : true;
                BTN_Supprimer.Enabled = tabItems.Length == 0 ? false : true;

                for (int i = 0; i < tabItems.Length; ++i)
                    LB_Noms.Items.Add(tabItems[i]);

                if (index < LB_Noms.Items.Count && index != -1)
                    LB_Noms.SelectedIndex = index;
                else
                    BTN_Supprimer.Enabled = false;
            }
            else
            {
                BTN_Insert.Enabled = false;
                BTN_Supprimer.Enabled = false;
            }
        }

        private void InsererItem()
        {
            InitialiserClasse();
            if (classe != "vide")
            {
                if (LB_Noms.Items[1].ToString() == "{ARMES}")
                    InsererArmes();
                else if (LB_Noms.Items[1].ToString() == "{ARMURES}")
                    InsererArmures();
                else if (LB_Noms.Items[1].ToString() == "{BIJOUX}")
                    InsererBijoux();
                else
                {
                    classe = "";
                    LB_Noms.SelectedIndex = 0;
                    MessageBox.Show("La deuxième ligne doit être {ARMES}, {ARMURES} OU {BIJOUX}. " + Environment.NewLine + "Pour de l'aide, référez-vous aux instructions.");
                }
            }
            else
            {
                classe = "";
                LB_Noms.SelectedIndex = 0;
                MessageBox.Show("La première ligne doit être [TOUS], [GUERRIER], [ARCHER], [MAGE] OU [PRETRE]. " +
                    Environment.NewLine + "Pour de l'aide, référez-vous aux instructions.");
            }
        }

        private void InitialiserClasse()
        {
            switch (LB_Noms.Items[0].ToString())
            {
                case "[TOUS]":
                    classe = "Tous";
                    minWATK = -6;
                    maxWATK = 12;
                    minMATK = -3;
                    maxMATK = 8;
                    minWDEF = -2;
                    maxWDEF = 9;
                    minMDEF = -1;
                    maxMDEF = 10;
                    break;
                case "[GUERRIER]":
                    classe = "Guerrier";
                    minWATK = 2;
                    maxWATK = 8;
                    minMATK = -6;
                    maxMATK = 3;
                    minWDEF = 1;
                    maxWDEF = 9;
                    minMDEF = -2;
                    maxMDEF = 6;
                    break;
                case "[ARCHER]":
                    classe = "Archer";
                    minWATK = 1;
                    maxWATK = 6;
                    minMATK = -3;
                    maxMATK = 5;
                    minWDEF = 0;
                    maxWDEF = 4;
                    minMDEF = -4;
                    maxMDEF = 5;
                    break;
                case "[MAGE]":
                    classe = "Mage";
                    minWATK = 1;
                    maxWATK = 5;
                    minMATK = 3;
                    maxMATK = 9;
                    minWDEF = -2;
                    maxWDEF = 4;
                    minMDEF = 2;
                    maxMDEF = 8;
                    break;
                case "[PRETRE]":
                    classe = "Prêtre";
                    minWATK = 1;
                    maxWATK = 4;
                    minMATK = 2;
                    maxMATK = 11;
                    minWDEF = -3;
                    maxWDEF = 6;
                    minMDEF = 2;
                    maxMDEF = 10;
                    break;
                default:
                    classe = "vide";
                    break;
            }
        }

        private void InsererArmes()
        {
            int valeurInserer = 0;
            int valeurNonInserer = 0;
            Random rand = new Random();
            for (int i = 2; i < tabItems.Length; ++i)
            {
                level = int.Parse(tabItems[i].Split('-')[0]);
                nom = tabItems[i].Split('-')[1];
                watk = rand.Next(minWATK + Convert.ToInt32(0.7 * level), maxWATK + Convert.ToInt32(1.5 * level));
                wdef = rand.Next(minWDEF + Convert.ToInt32(0.2 * level), maxWDEF + Convert.ToInt32(0.4 * level));
                matk = rand.Next(minMATK + Convert.ToInt32(0.6 * level), maxMATK + Convert.ToInt32(1.6 * level));
                mdef = rand.Next(minMDEF + Convert.ToInt32(0.2 * level), maxMDEF + Convert.ToInt32(0.3 * level));
                price = (watk * matk) + Convert.ToInt32(1.5 * level) + wdef - mdef - level;
                if (price < 0)
                    price = Convert.ToInt32(price * -1 + 2.5 * level);
                else
                    price = Convert.ToInt32(price + 2.5 * level);

                if (Controle.addItem(nom, classe, level, watk, wdef, matk, mdef, actif, price))
                    valeurInserer++;
                else
                    valeurNonInserer++; 
            }
            LBL_Total_Inserer.Text = valeurInserer.ToString() + (valeurInserer > 1 ? " lignes insérées" : " ligne insérée");
            LBL_NonInserer.Text = valeurNonInserer.ToString() + (valeurNonInserer > 1 ? " lignes non insérées" : " ligne non insérée");
        }

        private void InsererArmures()
        {
            int valeurInserer = 0;
            int valeurNonInserer = 0;
            Random rand = new Random();
            for (int i = 2; i < tabItems.Length; ++i)
            {
                level = int.Parse(tabItems[i].Split('-')[0]);
                nom = tabItems[i].Split('-')[1];
                watk = rand.Next(minWATK + Convert.ToInt32(0.2 * level), maxWATK + Convert.ToInt32(0.4 * level));
                wdef = rand.Next(minWDEF + Convert.ToInt32(0.7 * level), maxWDEF + Convert.ToInt32(1.5 * level));
                matk = rand.Next(minMATK + Convert.ToInt32(0.2 * level), maxMATK + Convert.ToInt32(0.3 * level));
                mdef = rand.Next(minMDEF + Convert.ToInt32(0.6 * level), maxMDEF + Convert.ToInt32(1.6 * level));
                price = (wdef * mdef) + Convert.ToInt32(1.5 * level) + watk - matk - level;
                if (price < 0)
                    price = Convert.ToInt32(price * -1 + 2.5 * level);
                else
                    price = Convert.ToInt32(price + 2.5 * level);

                if (Controle.addItem(nom, classe, level, watk, wdef, matk, mdef, actif, price))
                    valeurInserer++;
                else
                    valeurNonInserer++; 
            }
            LBL_Total_Inserer.Text = valeurInserer.ToString() + (valeurInserer > 1 ? " lignes insérées" : " ligne insérée");
            LBL_NonInserer.Text = valeurNonInserer.ToString() + (valeurNonInserer > 1 ? " lignes non insérées" : " ligne non insérée");
        }

        private void InsererBijoux()
        {
            int valeurInserer = 0;
            int valeurNonInserer = 0;
            Random rand = new Random();
            for (int i = 2; i < tabItems.Length; ++i)
            {
                level = int.Parse(tabItems[i].Split('-')[0]);
                nom = tabItems[i].Split('-')[1];
                watk = rand.Next(minWATK + Convert.ToInt32(0.3 * level), maxWATK + level);
                wdef = rand.Next(minWDEF + Convert.ToInt32(0.3 * level), maxWDEF + level);
                matk = rand.Next(minMATK + Convert.ToInt32(0.3 * level), maxMATK + level);
                mdef = rand.Next(minMDEF + Convert.ToInt32(0.3 * level), maxMDEF + level);
                price = watk * matk + wdef * mdef;
                if (price < 0)
                    price = Convert.ToInt32(price * -1 + 3.5 * level);
                else
                    price = Convert.ToInt32(price + 3.5 * level);

                if (Controle.addItem(nom, classe, level, watk, wdef, matk, mdef, actif, price))
                    valeurInserer++;
                else
                    valeurNonInserer++; 
            }
            LBL_Total_Inserer.Text = valeurInserer.ToString() + (valeurInserer > 1 ? " lignes insérées" : " ligne insérée");
            LBL_NonInserer.Text = valeurNonInserer.ToString() + (valeurNonInserer > 1 ? " lignes non insérées" : " ligne non insérée");
        }
    }
}