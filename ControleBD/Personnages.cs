using System;
using System.Collections.Generic;

namespace ControleBD
{
    public class Personnages
    {
        public string Nom { get; private set; }
        public int Level { get; private set; }
        public int Xp { get; private set; }
        List<Items> Item = new List<Items>();

        public Personnages(string nom,int level,int classid)
        {
            this.Nom = nom;
            this.Level = level;
            this.ClassId = classid;
        }
        public int ClassId { get; private set; }
        public int Health { get; private set; }
        public int Magic { get; private set; }
        public int PhysAtk { get; private set; }
        public int PhysDef { get; private set; }
        public int MagicAtk { get; private set; }
        public int MagicDef { get; private set; }
        public int Moves { get; private set; }
        public int Range { get; private set; }

        public List<AttaqueSpeciale> Attaques = new List<AttaqueSpeciale>();
    }
}
