using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleBD;

namespace ConsoleTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Controle.insertPlayer("TEST3", "TEST3", "TESTTEST").ToString());
            Console.ReadLine();
        }
    }
}
