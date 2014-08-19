using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
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
            switch (myClient.connectedServer.CurrServerCommand.cmd)
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
                    MessageBox.Show(myClient.connectedServer.CurrServerCommand.ToString());
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
    

        private void server_Connected(Server sender)
        {
            tsmiDisconnect.Enabled = true;
            sblConnectionStatus.Visible = true;
            sblConnectionStatus.Text = "Connected";
            sblConnectionStatus.ForeColor = Color.LightGreen;
            tsmiQuickConnect.Enabled = false;
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
