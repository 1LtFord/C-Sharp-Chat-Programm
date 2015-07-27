namespace ChatClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;

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
                Connection.BeginReceive(new byte[] { 0 }, 0, 0, 0, this.Callback, null);
                
            
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

        private void Callback(IAsyncResult ar)
        {
            try
            {
                this.Connection.EndReceive(ar);

                byte[] buf = new byte[this.Connection.ReceiveBufferSize];
                var size = this.Connection.Receive(buf, buf.Length, 0);

                Array.Resize<byte>(ref buf, size);
                if (buf.Length == 0)
                {
                    this.Close();
                }

                var cmdString = System.Text.Encoding.UTF8.GetString(buf);
                this.CurrServerCommand.FetchCommand(cmdString);

                this.HandleCommand();

                var onReceived = this.Received;
                if (onReceived != null)
                {
                    onReceived();
                }

                this.Connection.BeginReceive(new byte[] { 0 }, 0, 0, 0, this.Callback, null);
            }
            catch (Exception)
            {
                if (this.Disconnected != null)
                {
                    this.Disconnected(this);
                }
            }
        }

        public void HandleCommand()
        {
            switch (this.CurrServerCommand.CommandList)
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
                    this.RetrieveServerInfo();
                    break;
                case ServerCommandList.SpreadMessage:
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

        private void RetrieveServerInfo()
        {
            this.SrvInfo.parseSrvInfo(this.CurrServerCommand.Args);
        }
    
        public void FetchCommand(byte[] buffer)
        {
            var CommandString = System.Text.Encoding.UTF8.GetString(buffer);
            this.CurrServerCommand.FetchCommand(CommandString);
            this.HandleCommand();
            this.Received();
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
