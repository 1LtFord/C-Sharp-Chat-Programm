using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace CSharp_Chatprojekt_Client
{
    class Verbindung
    {
        private string ip;
        public string IP
        {
            
            get 
            { return ip; }
        }

        private int port;
        public int Port
        {
            set 
            {
                if (value > 0)
                {
                    port = value;
                }
            }
            get { return port; }
        }

        private string username;
        public string Username
        {
            get { return username; }
        }

        private string userpasswort;

        private string serverpasswort;

        private string servername;
        public string ServerName
        {
            get { return servername; }
        }

        private int maxClients;
        public int MaxClients
        {
            get { return maxClients; }
        }

        private int currentClients;
        public int CurrentClients
        {
            get { return currentClients; }
        }

        private enum befehlslisteServer
        {
            
        }

        private enum befehlslisteClient
        {
            connect,
        	sendMsg,
        	disconnect,
        	changeName,
        	login,
        	getLatestMsgLog,
        	getLoggedUserList,
        	getAllUserList,
        	setMyStatus,
        	getMyStatus,
        	kickUser,
        	banUser,
        	setUserRole,
        	UnbanUser,
        	sendPrivateMsg,
        	changePwd,
        	getServerInfo,
        	getServerReadme,
        }

        Socket sock;

        public Verbindung(string ip,int port,string serverpasswort, string username, string userpasswort)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            if (IpUeberpruefen(ip))
            {
                this.ip = ip;
                if (PortUeberpruefen(port))
                {
                    if(
                }
            }


            if (ZuServerVerbinden())
            {
                //Login();
            }
            else
            {
 
            }

            sock.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
            
        }

        private void callback(IAsyncResult ar)
        {
            try
            {
                sock.EndReceive(ar);

                byte[] buf = new byte[70000];
                int rec = sock.Receive(buf, buf.Length, 0);
                Array.Resize<byte>(ref buf, rec);
            }

            catch(Exception ex)
            {
                throw ex;
            }
        }

        ~Verbindung()
        {
            if (sock.Connected)
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
        }

        private bool IpUeberpruefen(string ip)
        {
            try
            {
                IPAddress.Parse(ip);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ServerAnpingen()
        {
            Ping Sender = new Ping();
            PingReply Result = Sender.Send(ip);
            if (Result.Status == IPStatus.Success)
            {
                return true;
            }

            else
            {
                MessageBox.Show("Server ist nicht erreichbar");
                return false;
            }

        }

        private void FreieServerPlätzePrüfen()
        {
            if (maxClients > currentClients)
            {
                ZuServerVerbinden();
            }
            else
            {
 
            }
        }

        private bool ZuServerVerbinden()
        {
            if (ServerAnpingen())
            {
                try
                {
                    IPAddress ipo = IPAddress.Parse(ip);
                    IPEndPoint ipEo = new IPEndPoint(ipo, port);
                    sock.Connect(ipEo);
                    return true;
                }
                catch
                {
                    MessageBox.Show("Konnte nicht zum Server Verbinden");
                    return false;
                }

            }
            else
            {
                MessageBox.Show("Konnte nicht zum Server Verbinden");
                return false;
            }
            
        }

        private bool PortUeberpruefen(int port)
        {
            if (port.ToString().Length <= 10)
            {
                this.port = port;
                return true;
            }
            else
            {
                MessageBox.Show("Der Username ist zu lang");
                return false;
            }
        }

        private bool UsernameUeberpruefen(string username)
        {
            if(username.Length <= 16)
        }

        //private bool Login()
        //{
 
        //}

    }
}
