using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    public class Client
    {
        public string ID
        {
            get;
            private set;
        }
        public IPEndPoint EndPoint
        {
            get;
            private set;
        }
        public string UserID;
        public bool isReceiving = false;
        
        Socket sck;
        public Client(Socket accepted)
        {
            sck = accepted;
            ID = Guid.NewGuid().ToString();
            EndPoint = (IPEndPoint)sck.RemoteEndPoint;

            isReceiving = true;
            sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
        }

        public void Send(int cmdIndex, string args="")
        {
            
                string cmdString = cmdIndex.ToString();

                if (args != "")
                {
                    cmdString += args;
                }
                byte[] cmdInByte = System.Text.Encoding.UTF8.GetBytes(cmdString);
                sck.Send(cmdInByte);
            

        }

        void callback(IAsyncResult ar)
        {
            try
            {
                sck.EndReceive(ar);
                

                byte[] buf = new byte[70000];
                
                int rec = sck.Receive(buf, buf.Length, 0);
                Array.Resize<byte>(ref buf, rec);
                if (rec < buf.Length)
                {
                    Received(this, buf);
                }
                if (Received != null)
                {
                    Received(this, buf);
                }
                isReceiving = true;
                sck.BeginReceive(new byte[]{0}, 0, 0, 0, callback, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Close();
                if (Disconnected != null)
                {
                    Disconnected(this);
                }
            }
        }

        public void Close()
        {
            sck.Close();
            sck.Dispose();
        }

        public delegate void ClientReceivedHandler(Client sender, byte[] data);
        public delegate void ClientDisconnectedHandler(Client sender);

        public event ClientReceivedHandler Received;
        public event ClientDisconnectedHandler Disconnected;
    }
}
