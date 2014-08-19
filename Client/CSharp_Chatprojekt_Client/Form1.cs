using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace CSharp_Chatprojekt_Client
{
    public partial class Form1 : Form
    {
        public Verbindung connection;

        public Form1()
        {
            InitializeComponent();

        }

        private void tsmiServerliste_Click(object sender, EventArgs e)
        {
            FormServerListe ServerListe1 = new FormServerListe(this);
            ServerListe1.Show();
        }

        private void tsmiNeueVerbindung_Click(object sender, EventArgs e)
        {
            FormNeueVerbindung FormNeueVerbindung1 = new FormNeueVerbindung(this);
            FormNeueVerbindung1.Show();
        }

        private void btnSenden_Click(object sender, EventArgs e)
        {
            connection.GeschriebeneNachrichtAuswerten(rtbSchreiben.Text);
        }

        public bool UserVerbinden(string ip, int port, string serverPW, string benutzername, string benutzerPW)
        {
            connection = new Verbindung(ip,port,serverPW,benutzername,benutzerPW, this);
            return connection.Verbunden;
        }

        public string ServerStatusAbfragen(string ip, int port)
        {
            string data = Convert.ToString(connection.CurrentClients)+ ";" +Convert.ToString(connection.MaxClients) + ";" + Convert.ToString(connection.Ping) + ";" + Convert.ToString(connection.Verbunden) + ";" + connection.ServerName;

            return data;
        }

        private void tsmiTrennen_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Logout();
            }
            catch
            {
                MessageBox.Show("Sie sind nicht Eingeloggt");
            }
        }

        public delegate void UserInListeEintragenDelegate(string user);

        public void UserInListeEintragen(string user)
        {
            if (InvokeRequired)
            {
                lbxUserliste.Invoke(new UserInListeEintragenDelegate(UserInListeEintragen),
                    new object[] { user });
            }
            else
            {
                lbxUserliste.Items.Add(user);
            }
        }

        public delegate void UserNachrichtEintragenDelegate(string text);

        public void UserNachrichtEintragen(string nachricht)
        {
            if (rtbNachrichten.InvokeRequired)
            {
                rtbNachrichten.Invoke(new UserNachrichtEintragenDelegate(UserNachrichtEintragen),
                    new object[] { nachricht });
            }
            else
            {
                rtbNachrichten.AppendText(nachricht);
                rtbSchreiben.Clear();
            }
        }

        public delegate void ServerNachrichtEintragenDelegate(string text);

        public void ServerNachrichtEintragen(string nachricht)
        {
            if (rtbNachrichten.InvokeRequired)
            {
                rtbNachrichten.Invoke(new ServerNachrichtEintragenDelegate(ServerNachrichtEintragen),
                    new object[] { nachricht });
            }
            else
            {
                rtbNachrichten.SelectionStart = rtbNachrichten.TextLength;
                rtbNachrichten.SelectionLength = 0;

                rtbNachrichten.SelectionColor = Color.Gray;
                rtbNachrichten.AppendText(nachricht);
                rtbNachrichten.SelectionColor = rtbNachrichten.ForeColor;
            }
        }

        public delegate void ChatClearDelegate();

        public void ChatClear()
        {

            if (rtbNachrichten.InvokeRequired)
            {
                rtbNachrichten.Invoke(new ChatClearDelegate(ChatClear),
                    null);
            }
            else
            {
                rtbNachrichten.Clear();
                rtbSchreiben.Clear();
                lbxUserliste.Items.Clear();
            }
        }

    }
}
