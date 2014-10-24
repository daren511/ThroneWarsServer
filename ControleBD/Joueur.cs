using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Net.Sockets;


namespace ControleBD
{
    [Serializable]
    public class Joueur
    {
        [NonSerialized]
        Socket Socket;
        //[Serializable]
        //List<>
        public int position { get; private set; }

        public Joueur(Socket sck, int position)
        {
            this.Socket = sck;
            this.position = position;
        }

        public bool isAlive()
        {
            return !(Socket.Poll(1000, SelectMode.SelectRead) && Socket.Available == 0);
        }
    }
}
