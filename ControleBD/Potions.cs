using System;
using System.Collections.Generic;
using System.Text;

namespace ControleBD
{
    [Serializable]
    public class Potions
    {
        public Potions(int pid,string name,string description,int duration,int healthRestore,int WAtk,int WDef, int MAtk, int MDef,int quantity)
        {
            this.pid = pid;
            this.name = name;
            this.description = description;
            this.duration = duration;
            this.healthRestore = healthRestore;
            this.WAtk = WAtk;
            this.WDef = WDef;
            this.MAtk = MAtk;
            this.MDef = MDef;
            this.quantity = quantity;
        }
        int pid;
        string name;
        string description;
        int quantity;
        int healthRestore;
        int duration;
        public int WAtk { get; private set; }
        public int WDef { get; private set; }
        public int MAtk { get; private set; }
        public int MDef { get; private set; }

    }
}
