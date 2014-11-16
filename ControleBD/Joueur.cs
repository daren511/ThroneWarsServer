using System;
using System.Collections.Generic;
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
        public Socket Socket;

        public List<Personnages> Persos = new List<Personnages>();
        public string Username;
        public int jid;
        public int Position { get; private set; }
        public bool isConnected = false;
        public Joueur(Socket sck, int position)
        {
            this.Socket = sck;
            this.Position = position;
        }

        public bool socketIsConnected()
        {
            return !(Socket.Poll(1000, SelectMode.SelectRead) && Socket.Available == 0);
        }
    }
}
