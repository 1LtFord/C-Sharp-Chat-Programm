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
    class TCPSenden
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

        Socket sockSenden;

        public TCPSenden(string ip, int port, string username, string userpasswort, string serverpasswort)
        {
            sockSenden = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IpUeberpruefen(ip);
            this.username = username;
            this.userpasswort = userpasswort;
            this.serverpasswort = serverpasswort;

            ServerAnpingen();
        }

        ~TCPSenden()
        {
            sockSenden.Shutdown(SocketShutdown.Both);
            sockSenden.Close();
        }

        private void IpUeberpruefen(string ip)
        {
            string[] ipspl = ip.Split('.');
            bool istIP = true;
            //Prüft ob der gesplittete String aus 4 Teilen besteht
            if (ipspl.Length == 4)
            {
                for (int i = 0; i < ipspl.Length; i++)
                {
                    //Prüft ob jeder Teil aus maximal 3 und minimal 1 Zeichen besteht
                    if (ipspl[i].Length <= 3 && ipspl[i].Length > 0)
                    {
                        char[] a = ipspl[i].ToCharArray();
                        for (int z = 0; z < a.Length; z++)
                        {
                            //Prüft ob die einzelnen Zeichen der Teile des Strings Ziffern sind
                            if (Char.IsDigit(a[z])) { }
                            else
                            {
                                istIP = false;
                            }
                        }
                    }
                    else
                    {
                        istIP = false;
                    }
                }
            }
            else { istIP = false; }

            if (istIP)
            {
                IpZuweisen(ip);
            }
            else { }
        }

        private void IpZuweisen(string ip)
        {
            this.ip = ip;
        }

        private void ServerAnpingen()
        {
            Ping Sender = new Ping();
            PingReply Result = Sender.Send(ip);
            if (Result.Status == IPStatus.Success)
            {
                FreieServerPlätzePrüfen();
            }

            else
            {
                MessageBox.Show("Server ist nicht erreichbar");
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

        private void ZuServerVerbinden()
        {
            IPAddress ipo = IPAddress.Parse(ip);
            IPEndPoint ipEo = new IPEndPoint(ipo, port);
            sockSenden.Connect(ipEo);
        }
    }
}
