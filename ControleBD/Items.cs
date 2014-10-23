﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ControleBD
{
    [Serializable]
    public class Items
    {
        public string Nom {get; private set;}
        public string Description { get; private set; }
        public int Level { get; private set; }
        public int Classe { get; private set; }
        public int WAtk { get; private set; }
        public int WDef { get; private set; }
        public int MAtk { get; private set; }
        public int MDef { get; private set; }

    }
}
