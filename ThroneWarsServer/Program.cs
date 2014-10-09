using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleBD;



namespace ThroneWarsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Controle.insertplayer("hcfranck2","hc_throwdown2@hotmail.com","tattoo").ToString());
            Console.ReadKey();
        }
    }

}
