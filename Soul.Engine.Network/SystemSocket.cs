using System;
using System.Net.Sockets;

namespace Soul.Engine.Network
{
    public class SystemSocket
    {
        public byte[] Buffer;
        public bool Connected;
        public object Owner = null;
        public ServerSocket Server = null;
        public Socket Socket = null;
        public uint UID = 0;

        public string RemoteAddress
        {
            get
            {
                try
                {
                    return Socket.RemoteEndPoint.ToString().Split(':')[0];
                }
                catch (Exception)
                {
                    if (Server != null)
                        Server.InvokeDisconect(this);
                    return "";
                }
            }
        }

        public SystemSocket(uint size)
        {
            Buffer = new byte[size];
        }

        public void Disconnect()
        {
            Connected = false;
            Server.InvokeDisconect(this);
            Socket.Disconnect(false);
        }
    }
}