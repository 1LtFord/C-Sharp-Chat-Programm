using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace ChatServer
{
    public class Listener
    {
        Socket s;

        public bool Listening
        {
            get;
            private set;
        }

        public int Port
        {
            get;
            private set;
        }

        public Listener(int port)
        {
            Port = port;
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            if (Listening)
                return;

            s.Bind(new IPEndPoint(0, Port));
            s.Listen(0);

            s.BeginAccept(callback, null);
            Listening = true;
        }

        public void Stop()
        {
            if (!Listening)
                return;

            s.Close();
            s.Dispose();
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        void callback(IAsyncResult ar)
        {
            try
            {
                Socket s = this.s.EndAccept(ar);

                if (SocketAccepted != null)
                {
                    SocketAccepted(this, new SocketAcceptedEventHandler(s));
                }

                this.s.BeginAccept(callback, null);
            }
            catch (Exception ex)
            {
               // Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public event EventHandler<SocketAcceptedEventHandler> SocketAccepted;
    }

    public class SocketAcceptedEventHandler : EventArgs
    {
        public Socket Accepted
        {
            get;
            private set;
        }
        public SocketAcceptedEventHandler(Socket s)
        {
            Accepted = s;
        }
    }
    

}
