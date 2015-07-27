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
            switch (CurrServerCommand.CommandList)
            {
                case ServerCommandList.IsLogged:
                    break;
                case ServerCommandList.WrongPwd:
                    break;
                case ServerCommandList.NewUserRegistered:
                    break;
                case ServerCommandList.ServerIsFull:
                    break;
                case ServerCommandList.ServerIsPrivate:
                    break;
                case ServerCommandList.UserIsBanned:
                    break;
                case ServerCommandList.LoggedUserList:
                    break;
                case ServerCommandList.SendLatestMsgLog:
                    break;
                case ServerCommandList.MsgLogRestricted:
                    break;
                case ServerCommandList.MsgAccepted:
                    break;
                case ServerCommandList.DisconnectReceived:
                    break;
                case ServerCommandList.SendServerInfo:
                    retrieveServerInfo();
                    break;
                case ServerCommandList.SpreadMsg:
                    break;
                case ServerCommandList.ServerIsClosing:
                    break;
                case ServerCommandList.WrongArgs:
                    break;
                case ServerCommandList.AlreadyLogged:
                    break;
                case ServerCommandList.NotLoggedIn:
                    break;
                case ServerCommandList.ChangeOfLoggedUserList:
                    break;
                case ServerCommandList.ChangeOfServerInfo:
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
