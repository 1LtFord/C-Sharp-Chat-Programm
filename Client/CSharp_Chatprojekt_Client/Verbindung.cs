using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Web;

namespace CSharp_Chatprojekt_Client
{
    class Verbindung
    {
        private bool verbunden = false;
        public bool Verbunden
        {
            get { return verbunden; }
        }

        private ListBox lbxUserListe;

        private RichTextBox rtbChat;

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

        private int ping;
        public int Ping
        {
            get { return ping; }
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

        private enum befehlslisteClient
        {
            connect,
        	sendMsg,//(1,Nachricht)
        	disconnect,//(2)
        	changeName,
        	login, // (4;Benutzername;BenutzerPW[;ServerPW])
        	getLatestMsgLog,//(5)
        	getLoggedUserList,//(6)
        	getAllUserList,
        	setMyStatus,
        	getMyStatus,
        	kickUser,
        	banUser,
        	setUserRole,
        	UnbanUser,
        	sendPrivateMsg,
        	changePwd,
        	getServerInfo,//(16)
        	getServerReadme
        }

        private enum befehlslisteServer
        {
            //Responses of cmd Login(4;Benutzername;BenutzerPW[;ServerPW])
            isLogged,//(0)
            WrongPwd,//(1)
            NewUserRegistered,//(2)
            ServerIsFull,//(3)
            ServerIsPrivate,//(4)
            UserIsBanned,//(5)
            //Response of Cmd getLoggedUserList(6)
            LoggedUserList, // (6;User;User;User...)
            //Response of Cmd getLatestMsgLog(5)
            sendLatestMsgLog,//(7; Nachricht(User,Time,Msg);....;..;...)
            MsgLogRestricted, //(8)
            //Response of Cmd sendMsg(1;msg)
            MsgAccepted, // (9) 
            //Response of Cmd Disconnect(2)
            DisconnectReceived, //(10)
            //Response of Cmd getServerInfo(16)
            SendServerInfo,//(11,serverName,serverMaxUserCount,currentUserCount,)
            spreadMsg, //(12,User,Time,Msg)
            ServerIsClosing //(13[,ServerMsg])
        }

        Socket sock;

        public Verbindung(string ip,int port,string serverpasswort, string username, string userpasswort, ListBox lbxUserListe, RichTextBox rtbChat)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            if (IpUeberpruefen(ip))
            {
                this.ip = ip;
                if (PortUeberpruefen(port))
                {
                    this.port = port;
                    if (UsernameUeberpruefen(username))
                    {
                        this.username = username;
                        this.userpasswort = userpasswort;
                        this.serverpasswort = serverpasswort;
                        this.rtbChat = rtbChat;
                        this.lbxUserListe = lbxUserListe;
                        if (ZuServerVerbinden())
                        {
                            if (Username == "GetServerInfo")
                            {
                               GetServerInfo();
                                CloseSocket();
                            }
                            else
                            {
                                GetServerInfo();
                                Login();
                                sock.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
                            }
                            
                        }
                    }
                }
            }
            
        }

        private void callback(IAsyncResult ar)
        {
            try
            {
                sock.EndReceive(ar);

                byte[] buf = new byte[70000];
                int rec = sock.Receive(buf, buf.Length, 0);
                Array.Resize<byte>(ref buf, rec);
                string recievedUTF8 = Encoding.UTF8.GetString(buf);
                EmpfangenenBefehlSuchen(recievedUTF8);
                sock.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
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
            PingReply Result = Sender.Send(ip,5000);
            if (Result.Status == IPStatus.Success)
            {
                ping = Convert.ToInt32(Result.RoundtripTime);
                return true;
            }

            else
            {
                MessageBox.Show("Server ist nicht erreichbar");
                return false;
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
                    verbunden = true;
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
            if (port.ToString().Length <= 10 && port >= 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Der Port ist ungültig");
                return false;
            }
        }

        private bool UsernameUeberpruefen(string username)
        {
            if (username.Length <= 16)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Der Benutzername ist zu lang");
                return false;
            }
        }

        private void Login()
        {
            string stringnachricht;
            if (serverpasswort.Length > 0)
            {
                stringnachricht = ("4;" + EscapeString(username) + ";" + EscapeString(userpasswort) + ";" + EscapeString(serverpasswort));
            }
            else
            {
                stringnachricht = ("4;" + EscapeString(username) + ";" + EscapeString(userpasswort));
            }
            byte[] bytenachricht = Encoding.UTF8.GetBytes(stringnachricht);
            try
            {
                sock.Send(bytenachricht);
            }
            catch
            {
                MessageBox.Show("Der Login konnte nicht gesendet werden");
            }
        }

        private void GetServerInfo()
        {
            sock.Send(Encoding.UTF8.GetBytes("16"));
        }

        private void EmpfangenenBefehlSuchen(string recievedUTF8)
        {
            string[] nachricht = recievedUTF8.Split(';');

            switch (nachricht[0])
            {
                case "0":
                    {
                        GetUserliste();
                        break;
                    }
                case "1":
                    {
                        WrongPW();
                        CloseSocket();
                        break;
                    }
                case "2":
                    {
                        NewUserRegistered();
                        GetUserliste();
                        break;
                    }
                case "3":
                    {
                        ServerIsFull();
                        CloseSocket();
                        break;
                    }
                case "4":
                    {
                        ServerIsPrivate();
                        CloseSocket();
                        break;
                    }
                case "5":
                    {
                        UserIsBanned();
                        CloseSocket();
                        break;
                    }
                case "6":
                    {
                        UserListeAnwenden(nachricht);
                        GetLatestMsgLog();
                        break;
                    }
                case "7":
                    {
                        LetzteNachrichtenSpeichern(nachricht);
                        break;
                    }
                case "8":
                    {
                        break;
                    }
                case "9":
                    {
                        break;
                    }
                case "10":
                    {
                        CloseSocket();
                        break;
                    }
                case "11":
                    {
                        ServerInfoSpeichern(nachricht);
                        break;
                    }
                case "12":
                    {
                        NachrichtEintragen(nachricht);
                        break;
                    }
                case "13":
                    {
                        ServerIsClosingNachricht(nachricht);
                        CloseSocket();
                        break;
                    }
            }
        }

        private void CloseSocket()
        {
            if (sock.Connected)
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
        }

        private void GetUserliste()
        {
            sock.Send(Encoding.UTF8.GetBytes("6"));
        }

        private void GetLatestMsgLog()
        {
            sock.Send(Encoding.UTF8.GetBytes("5"));
        }

        private void WrongPW()
        {
            MessageBox.Show("Das Eingegebene Passwort ist Falsch");
        }

        private void NewUserRegistered()
        {
            MessageBox.Show("Du wurdest als neuer Benutzer eingetragen");
        }

        private void ServerIsFull()
        {
            MessageBox.Show("Der Server ist voll");
        }

        private void ServerIsPrivate()
        {
            MessageBox.Show("Der Server ist auf Privat gestellt");
        }

        private void UserIsBanned()
        {
            MessageBox.Show("Du bist von diesem Server gebannt");
        }

        private void UserListeAnwenden(string[] text)
        {
            for (int i = 1; i < text.Length-1; i++)
            {
               lbxUserListe.Items.Add(UnEscapeString(text[i]));
            }
        }

        private void LetzteNachrichtenSpeichern(string[] text)
        {
            for (int i = 1; i < text.Length - 1; i++)
            {
                NachrichtenLogNachrichtEintragen(UnEscapeString(text[i]));
            }
        }

        private void NachrichtenLogNachrichtEintragen(string nachricht)
        {
            string[] text = nachricht.Split(',');
            string user, zeit, userNachricht;

            user = UnEscapeString(text[1]);
            zeit = UnEscapeString(text[2]);
            userNachricht = UnEscapeString(text[3]);

            rtbChat.AppendText(zeit + " " + user + ": " + userNachricht + "\n");
        }

        private void ServerInfoSpeichern(string[] text)
        {
            servername = UnEscapeString(text[1]);
            maxClients = Convert.ToInt32(UnEscapeString(text[2]));
            currentClients = Convert.ToInt32(UnEscapeString(text[3]));
            MessageBox.Show(servername + maxClients + currentClients);
        }

        private void NachrichtEintragen(string[] text)
        {
            string user, zeit, nachricht;

            user = UnEscapeString(text[1]);
            zeit = UnEscapeString(text[2]);
            nachricht = UnEscapeString(text[3]);

            rtbChat.AppendText(zeit + " " + user + ": " + nachricht + "\n");
        }

        private void ServerIsClosingNachricht(string[] text)
        {
            rtbChat.AppendText("Server: Server is closing(" + UnEscapeString(text[1]) + ") Connection shutdown...");
        }

        private string EscapeString(string text)
        {
           return System.Uri.EscapeDataString(text);
        }

        private string UnEscapeString(string text)
        {
            return System.Uri.UnescapeDataString(text);
        }

        private void NachrichtSenden(string text)
        {
            sock.Send(Encoding.UTF8.GetBytes("1;" + EscapeString(text)));
        }

        public void GeschriebeneNachrichtAuswerten(string text)
        {
            switch (text)
            {
                default:
                    {
                        NachrichtSenden(text);
                        break;
                    }
            }
        }

        public void VerbindungTrennen()
        {
            CloseSocket();
        }

        public void Logout()
        {
            sock.Send(Encoding.UTF8.GetBytes("2"));
            CloseSocket();
        }
    }
}
