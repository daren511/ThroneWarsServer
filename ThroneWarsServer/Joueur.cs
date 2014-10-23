using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ThroneWarsServer
{
    class Joueur
    {
        Socket socket;
        public int position { get; private set; }

        public Joueur(Socket sck, int position)
        {
            this.socket = sck;
            this.position = position;
        }

        public bool isAlive()
        {
            return !(socket.Poll(1000, SelectMode.SelectRead) && socket.Available == 0);
        }
    }
}
