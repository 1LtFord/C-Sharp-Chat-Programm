using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ChatClient
{
    public class Server
    {
        public Socket Connection;
        public List<string> UserList;
        public List<Message> MsgLog;
        public ServerInfo SrvInfo;
        public ServerCommand CurrServerCommand;
        public ClientCommand CurrClientCommand;


        public Server(string ip,string port)
        {
            Init();
            Connect(ip, port);
        }

        public Server()
        {
            Init();
        }

        public void Init()
        {
            Connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SrvInfo = new ServerInfo();
            CurrClientCommand = new ClientCommand();
            CurrServerCommand = new ServerCommand();
        }

        public void Connect(string ip,string port)
        {
            
            try
            {
                Connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Connection.Connect(ip, Convert.ToInt16(port));

                SrvInfo.IP = ip;
                SrvInfo.Port = port;

                Connected(this);
                Connection.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
                
            
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void getServerInfo()
        {
            CurrClientCommand = new ClientCommand(16);
            ExecuteCmd(CurrClientCommand);
        }

        public void ExecuteCmd(ClientCommand _cmd)
        {

            Connection.Send(System.Text.Encoding.UTF8.GetBytes(_cmd.ToString()));

        }

        private void callback(IAsyncResult ar)
        {
            try
            {
                Connection.EndReceive(ar);

                byte[] buf = new byte[Connection.ReceiveBufferSize];

                int size=Connection.Receive(buf, buf.Length, 0);
                Array.Resize<byte>(ref buf, size);
                if (buf.Length == 0) this.Close();

                string cmdString=System.Text.Encoding.UTF8.GetString(buf);
                CurrServerCommand.fetchCmd(cmdString);

                handleCommand();

                Received();

                Connection.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);

            }
            catch (Exception)
            {
                if (Disconnected != null)
                {
                    Disconnected(this);
                }
            }
        }

        public void handleCommand()
        {
            switch (CurrServerCommand.cmd)
            {
                case ServerCmd.isLogged:
                    break;
                case ServerCmd.WrongPwd:
                    break;
                case ServerCmd.NewUserRegistered:
                    break;
                case ServerCmd.ServerIsFull:
                    break;
                case ServerCmd.ServerIsPrivate:
                    break;
                case ServerCmd.UserIsBanned:
                    break;
                case ServerCmd.LoggedUserList:
                    break;
                case ServerCmd.sendLatestMsgLog:
                    break;
                case ServerCmd.MsgLogRestricted:
                    break;
                case ServerCmd.MsgAccepted:
                    break;
                case ServerCmd.DisconnectReceived:
                    break;
                case ServerCmd.SendServerInfo:
                    retrieveServerInfo();
                    break;
                case ServerCmd.spreadMsg:
                    break;
                case ServerCmd.ServerIsClosing:
                    break;
                case ServerCmd.WrongArgs:
                    break;
                case ServerCmd.AlreadyLogged:
                    break;
                case ServerCmd.NotLoggedIn:
                    break;
                case ServerCmd.ChangeOfLoggedUserList:
                    break;
                case ServerCmd.ChangeOfServerInfo:
                    break;
                default:
                    break;
            }
            
        }

        private void retrieveServerInfo()
        {
            SrvInfo.parseSrvInfo(CurrServerCommand.Args);

        }
    
        public void fetchCommand(byte[] _buf)
        {

            string CommandString = System.Text.Encoding.UTF8.GetString(_buf);
            CurrServerCommand.fetchCmd(CommandString);
            handleCommand();
            Received();

        }

        public void Disconnect()
        {
            Connection.Close();
            Connection.Dispose();
            Disconnected(this);
        }

        private void Close()
        {
            Connection.Close();
            Connection.Dispose();
        }

        public event ServerReceivedHandler Received;
        public event ServerDisconnectedHandler Disconnected;
        public event ServerConnectedHandler Connected;

        public delegate void ServerReceivedHandler();
        public delegate void ServerDisconnectedHandler(Server sender);
        public delegate void ServerConnectedHandler(Server sender);

        



    }
}
