using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleBD;
using Emails;


namespace ThroneWarsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Email.sendMail("charles@thronewars.ca","TESTING LE CHARLES","CECI EST UN TEST").ToString());
            Console.WriteLine(Controle.insertplayer("TEST", "TEST", "TEST"));
            Console.ReadKey();
        }
    }

}
