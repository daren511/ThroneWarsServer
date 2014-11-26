using System;
using System.Collections.Generic;

namespace ControleBD
{
    [Serializable]
    public class Personnages
    {
        public string Nom { get;  set; }
        public int Level { get;  set; }
        public int Xp { get;  set; }
        public List<Items> Item = new List<Items>();

        public Personnages()
        {

        }

        public Personnages(string nom,int level,int classid)
        {
            this.Nom = nom;
            this.Level = level;
            this.ClassId = classid;
        }
        public Personnages(string nom, int level, string className, int hp, int mp, int patk, int pdef, int matk, int mdef)
        {
            Nom = nom;
            Level = level;
            ClassName = className;
            Health = hp;
            Magic = mp;
            PhysAtk = patk;
            PhysDef = pdef;
            MagicAtk = matk;
            MagicDef = mdef;
        }
        public int ClassId { get;  set; }

        public string ClassName {get; set;}

        public int Health { get;  set; }
        public int Magic { get;  set; }
        public int PhysAtk { get;  set; }
        public int PhysDef { get;  set; }
        public int MagicAtk { get;  set; }
        public int MagicDef { get;  set; }
        public int Moves { get;  set; }
        public int Range { get;  set; }


        public List<AttaqueSpeciale> Attaques = new List<AttaqueSpeciale>();
    }
}
