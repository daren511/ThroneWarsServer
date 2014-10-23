using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBD
{
    public class Personnages
    {
        public string Nom { get; private set; }
        public int Level { get; private set; }
        public int Xp { get; private set; }
        List<Items> Item = new List<Items>();

        public int ClassId { get; private set; }
        public int Health { get; private set; }
        public int Magic { get; private set; }
        public int PhysAtk { get; private set; }
        public int PhysDef { get; private set; }
        public int MagicAtk { get; private set; }
        public int MagicDef { get; private set; }
        public int Moves { get; private set; }
        public int Range { get; private set; }
        //public AttaqueSpeciale[] { get; private set; }
    }
}
