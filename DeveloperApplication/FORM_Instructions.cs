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
            string text = "Dans votre fichier texte, mettez un nom par ligne et vous devez ajouter des balises avant " + 
                "le nom de vos items pour permettre à l'application d'insérer les items selon la classe. Les balises sont: " + 
                "@[TOUS]" + 
                "@[GUERRIER]" + 
                "@[ARCHER]" + 
                "@[MAGE]" + 
                "@[PRÊTRE]" + 
                "@Si vous ne mettez aucune balise, l'application va mettre ces items dans la catégorie [TOUS]. " + 
                "Vous n'avez qu'à choisir le type d'item que vous ajoutez et le niveau pour influencer les statistiques " + 
                "et le prix de l'item en conséquence.";
            TB_Instructions.Text = text.Replace("@", System.Environment.NewLine);
        }
    }
}
