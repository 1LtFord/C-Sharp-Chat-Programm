namespace ChatClient
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmMainWindow : Form
    {
        public Client myClient;

        public frmMainWindow()
        {
            myClient = new Client();
            myClient.connectedServer.Disconnected += new Server.ServerDisconnectedHandler(server_Disconnected);
            myClient.connectedServer.Connected += new Server.ServerConnectedHandler(server_Connected);
            myClient.connectedServer.Received += new Server.ServerReceivedHandler(handleCommand);
            InitializeComponent();

        }


        public void handleCommand()
        {
            switch (myClient.connectedServer.CurrServerCommand.CommandList)
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
                    MessageBox.Show(myClient.connectedServer.CurrServerCommand.ToString());
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
    

        private void server_Connected(Server sender)
        {
            tsmiDisconnect.Enabled = true;
            sblConnectionStatus.Visible = true;
            sblConnectionStatus.Text = "Connected";
            sblConnectionStatus.ForeColor = Color.LightGreen;

        }

        public delegate void server_DisconnectedDlg(Server sender);

        public void server_Disconnected(Server sender)
        {
            if (InvokeRequired)
            {

                Invoke(new server_DisconnectedDlg(server_Disconnected),
                    new object[] { sender });
            }
            else
            {
            tsmiDisconnect.Enabled = false;
            sblConnectionStatus.Text = "Disconnected";
            sblConnectionStatus.ForeColor = Color.Red;
            tsmiQuickConnect.Enabled = true;
            }
        }

        private void tsmiQuickConnect_Click(object sender, EventArgs e)
        {
            if (myClient.connectedServer.Connection.Connected)
            {
                myClient.connectedServer.Disconnect();
            }
            frmQuickConnect qcWindow = new frmQuickConnect(myClient);
            qcWindow.ShowDialog();
        }

        private void tsmiDisconnect_Click(object sender, EventArgs e)
        {
            myClient.connectedServer.Disconnect();
        }

        private void tsmiShowServerlist_Click(object sender, EventArgs e)
        {

        }
    }
}
