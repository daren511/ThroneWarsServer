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
        public bool hasConnected = false;
        public string Username;
        public int jid;
        public List<Potions> potions;
        public bool isConnected = false;
        public List<int> positionsPersonnages = new List<int>();
        public Joueur(Socket sck)
        {
            this.Socket = sck;

        }

        public bool socketIsConnected()
        {
            return !(Socket.Poll(1000, SelectMode.SelectRead) && Socket.Available == 0);
        }
    }
}
