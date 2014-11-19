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
            Console.WriteLine(Controle.hashPassword("Warst",null,System.Security.Cryptography.SHA256.Create()).ToString());
            Console.ReadLine();
        }
    }
}
