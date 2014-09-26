using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace ControleBD
{
    class Erreur
    {
        public static void ErrorMessage(OracleException Ex)
        {
            switch (Ex.Number)
            {
                case 1017:
                    Console.WriteLine("*Erreur Usager/Mot de passe");
                    break;
                case 12170:
                    Console.WriteLine("Erreur 12170:La base de données est indisponible,réessayer plus tard");
                    break;
                case 12543:
                    Console.WriteLine("Erreur 12543:Connexion impossible,Vérifiez votre connection internet");
                    break;
                default: Console.WriteLine(Ex.Message.ToString());
                    break;
            }
        }

    }
}
