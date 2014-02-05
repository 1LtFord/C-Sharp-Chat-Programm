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
        private Verbindung connection;

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
            connection = new Verbindung(ip,port,serverPW,benutzername,benutzerPW, lbxUserliste, rtbNachrichten);
            return connection.Verbunden;
        }

        public string ServerStatusAbfragen(string ip, int port)
        {
            string serverPW = null;
            string benutzername = "GetServerInfo";
            string benutzerPW = null;
            string data;
            connection = new Verbindung(ip, port, serverPW, benutzername, benutzerPW, lbxUserliste, rtbNachrichten);

            data = Convert.ToString(connection.CurrentClients)+ ";" +Convert.ToString(connection.MaxClients) + ";" + Convert.ToString(connection.Ping) + ";" + Convert.ToString(connection.Verbunden) + ";" + connection.ServerName;

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
                MessageBox.Show("Sie sind nicht Eingelogt");
            }
        }
    }
}
