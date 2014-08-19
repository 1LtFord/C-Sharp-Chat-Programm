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
        public string UserID="";
        public int indexOffset;
        
        public Socket sck;
        public Client(Socket acceptedSck)
        {
            sck = acceptedSck;
            ID = Guid.NewGuid().ToString();

            
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
                Console.WriteLine("Ich sende zurück: "+cmdString);
                //sck.Connected = true;
                //sck.SendTimeout = 10;
                sck.Send(cmdInByte);
            

        }

        void callback(IAsyncResult ar)
        {
            try
            {
                sck.EndReceive(ar);


                byte[] buf = new byte[sck.ReceiveBufferSize];
                
                int size = sck.Receive(buf, buf.Length, 0);

                Array.Resize<byte>(ref buf, size);

                if (buf.Length == 0) this.Close();

                Received(this, buf);

                sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (Disconnected != null)
                {
                    Disconnected(this);
                }
                Close();
                
            }
        }

        public void Close()
        {
            sck.Close();
            sck.Dispose();
            
        }

        public event ClientReceivedHandler Received;
        public event ClientDisconnectedHandler Disconnected;

        public delegate void ClientReceivedHandler(Client sender, byte[] data);
        public delegate void ClientDisconnectedHandler(Client sender);

    }
}
