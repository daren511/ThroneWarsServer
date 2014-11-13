using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ControleBD
{
    [Serializable]
    public class Items
    {
        public Items(string Nom, int Level, string Classe, int WAtk, int WDef, int MAtk, int MDef,int Quantite=1)
        {
            this.Nom = Nom;
            this.Level = Level;
            this.Classe = Classe;
            this.WAtk = WAtk;
            this.WDef = WDef;
            this.MAtk = MAtk;
            this.MDef = MDef;
            this.Quantite = Quantite;
        }
        public int Quantite { get; private set; }
        public string Nom {get; private set;}
        public string Description { get; private set; }
        public int Level { get; private set; }
        public string Classe { get; private set; }
        public int WAtk { get; private set; }
        public int WDef { get; private set; }
        public int MAtk { get; private set; }
        public int MDef { get; private set; }

    }
}
