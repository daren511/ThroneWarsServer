using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;



namespace ThroneWarsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Controle.updatePlayer(5,"hcfranck","hc_throwdown2@hotmail.com","tattoo").ToString());
            Console.ReadKey();
        }
    }

}
