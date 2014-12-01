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
    public partial class FORM_Instructions : Form
    {
        public FORM_Instructions()
        {
            InitializeComponent();
        }

        private void FORM_Instructions_Load(object sender, EventArgs e)
        {
            string text = "Dans votre fichier texte, débutez par le nom de la classe avec une des balises suivantes: " + 
                "@[TOUS]" + 
                "@[GUERRIER]" + 
                "@[ARCHER]" + 
                "@[MAGE]" + 
                "@[PRÊTRE]" + 
                "@La deuxième ligne doit être le type de l'item choisit avec l'une des balises suivantes: " + 
                "@{ARMES}" + 
                "@{ARMURES}" + 
                "@{BIJOUX}" + 
                "@Il est obligatoire de mettre une balise pour la classe et le type." + 
                "Précédez vos noms d'items par le niveau et \"-\" (ex.: 3-Item).";
            TB_Instructions.Text = text.Replace("@", System.Environment.NewLine);
        }
    }
}
