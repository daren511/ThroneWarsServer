using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteWebThroneWars
{
    public partial class Stats2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Build_Table();
        }

        private void Build_Table()  
        {
           
            // Pour tous les enrigistrements de la BD
            for (int i = 0; i < 10; ++i)
            {
                TableRow tr = new TableRow();
                table.Rows.Add(tr);
                // POur tous les champs de lerigistrements courant

                for (int j = 0; j < 5; ++j)
                {
                    TableCell td = new TableCell();

                    tr.Cells.Add(td);

                    td.Text = i.ToString() + "Hcfranck";


                }


            }
        }
    }
}