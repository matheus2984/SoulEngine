using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Soul.Engine.Extentions;

namespace Soul.Engine.Network
{
    public delegate void SocketEvent<in T, in T2>(T sender, T2 arg);

    public class ServerSocket
    {
        public ushort Backlog;
        public Dictionary<uint, SystemSocket> Connections = new Dictionary<uint, SystemSocket>();
        public uint MaxPacketSize;
        public ushort Port;
        public Socket Socket;
        public uint UID;
        public event SocketEvent<SystemSocket, object> OnConnect;
        public event SocketEvent<SystemSocket, object> OnDisconnect;
        public event SocketEvent<SystemSocket, byte[]> OnReceive;

        public void Enable(ushort port, ushort backlog, uint buffer)
        {
            Port = port;
            Backlog = backlog;
            MaxPacketSize = buffer;

            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket.Bind(new IPEndPoint(IPAddress.Any, Port));
            Socket.Listen(Backlog);
            Socket.BeginAccept(Accept, new SystemSocket(MaxPacketSize));
        }

        public void Accept(IAsyncResult result)
        {
            try
            {
                UID++;
                var sSocket = (SystemSocket) result.AsyncState;
                sSocket.Socket = Socket.EndAccept(result);

                sSocket.UID = UID;
                sSocket.Owner = this;
                sSocket.Connected = true;
                sSocket.Server = this;

                Connections.ThreadSafeAdd(sSocket.UID, sSocket);

                if (OnConnect != null) OnConnect.Invoke(sSocket, this);

                Socket.BeginAccept(Accept, new SystemSocket(MaxPacketSize));

                //SSocket.Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                //SSocket.Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);

                sSocket.Socket.BeginReceive(sSocket.Buffer, 0, (int) MaxPacketSize, SocketFlags.None, Receive, sSocket);
            }
            catch
            {
                Socket.BeginAccept(Accept, new SystemSocket(MaxPacketSize));
            }
        }

        public void Receive(IAsyncResult result)
        {
            var sSocket = (SystemSocket) result.AsyncState;
            try
            {
                SocketError error;
                if (!sSocket.Connected || !sSocket.Socket.Connected) return;
                int size = sSocket.Socket.EndReceive(result, out error);
                if (size != 0 && error == SocketError.Success)
                {
                    var Return = new byte[size];
                    Array.Copy(sSocket.Buffer, Return, size);
                    if (OnReceive != null) OnReceive.Invoke(sSocket, Return);
                    sSocket.Socket.BeginReceive(sSocket.Buffer, 0, (int) MaxPacketSize, SocketFlags.None,
                        Receive, sSocket);
                }
                else
                {
                    sSocket.Connected = false;
                    InvokeDisconect(sSocket);
                    Connections.Remove(sSocket.UID);
                }
            }
            catch (Exception)
            {
                sSocket.Connected = false;
                InvokeDisconect(sSocket);
                Connections.Remove(sSocket.UID);
            }
        }

        public void InvokeDisconect(SystemSocket client)
        {
            if (client.Connected)
            {
                client.Socket.Shutdown(SocketShutdown.Both);
                client.Socket.Close();
            }
            else
            {
                if (OnDisconnect != null) OnDisconnect.Invoke(client, null);
                client.Owner = null;
                //  client = null;
            }
        }
    }
}