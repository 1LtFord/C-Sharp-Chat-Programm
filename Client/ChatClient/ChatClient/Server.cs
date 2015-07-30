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

        public delegate void ServerReceivedHandler();
        public delegate void ServerDisconnectedHandler(Server sender);
        public delegate void ServerConnectedHandler(Server sender);

        public event ServerReceivedHandler Received;

        public event ServerDisconnectedHandler Disconnected;

        public event ServerConnectedHandler Connected;

        public Server(string ip,string port)
        {
            this.Init();
            this.Connect(ip, port);
        }

        public Server()
        {
            this.Init();
        }

        public void Init()
        {
            this.Connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.SrvInfo = new ServerInfo();
            this.CurrClientCommand = new ClientCommand();
            this.CurrServerCommand = new ServerCommand();
        }

        public void Connect(string ip,string port)
        {
            try
            {
                this.Connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.Connection.Connect(ip, Convert.ToInt16(port));

                this.SrvInfo.IP = ip;
                this.SrvInfo.Port = port;

                this.Connected(this);
                this.Connection.BeginReceive(new byte[] { 0 }, 0, 0, 0, this.Callback, null);
            }
            catch (Exception ex) // TODO here is cannot Exception
            {
                throw;
            }
        }

        public void GetServerInfo()
        {
            this.CurrClientCommand = new ClientCommand(16);
            this.ExecuteCmd(this.CurrClientCommand);
        }

        public void ExecuteCmd(ClientCommand command)
        {
            this.Connection.Send(System.Text.Encoding.UTF8.GetBytes(command.ToString()));
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

        public void FetchCommand(byte[] buffer)
        {
            var commandString = System.Text.Encoding.UTF8.GetString(buffer);
            this.CurrServerCommand.FetchCommand(commandString);
            this.HandleCommand();
            this.Received();
        }

        public void Disconnect()
        {
            this.Connection.Close();
            this.Connection.Dispose();
            this.Disconnected(this);
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
        
        private void RetrieveServerInfo()
        {
            this.SrvInfo.ParseServerInfo(this.CurrServerCommand.Args);
        }
    
        private void Close()
        {
            this.Connection.Close();
            this.Connection.Dispose();
        }
    }
}
