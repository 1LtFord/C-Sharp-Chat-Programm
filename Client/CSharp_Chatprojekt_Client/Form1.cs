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
using System.Timers;
using System.IO;


namespace CSharp_Chatprojekt_Client
{
    public partial class Form1 : Form
    {
        private Verbindung connection;

        private bool warte;

        private string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

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
            rtbSchreiben.Clear();
        }

        public bool UserVerbinden(string ip, int port, string serverPW, string benutzername, string benutzerPW)
        {
            connection = new Verbindung(ip,port,serverPW,benutzername,benutzerPW, this);
            return connection.Verbunden;
        }

        public string ServerStatusAbfragen(string ip, int port)
        {
            string serverPW = null;
            string benutzername = "GetServerInfo";
            string benutzerPW = null;
            string data;
            connection = new Verbindung(ip, port, serverPW, benutzername, benutzerPW, this);

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
                MessageBox.Show(nachricht);
                rtbNachrichten.AppendText(nachricht);
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
                ServerInfoInDateiSchreiben();
            }
        }

        public delegate void UserInListeEintragenDelegate(string user);

        public void UserInListeEintragen(string user)
        {
            if (lbxUserliste.InvokeRequired)
            {
                lbxUserliste.Invoke(new UserInListeEintragenDelegate(UserInListeEintragen),
                    new object[] { user });
            }
            else
            {
                lbxUserliste.Items.Add(user);
            }
        }

        private void ServerInfoInDateiSchreiben()
        {
            string dateipfad = dir + @"ServerListe.csv";
            
            if (File.Exists(dateipfad))
            {
                StreamReader sr = new StreamReader(dateipfad);
                if (sr.Peek() != -1)
                {
                    for (int i = 0; sr.Peek() != -1; i++)
                    {
                        string text = sr.ReadLine();
                        string[] serverinfo = text.Split(';');

                        if (serverinfo[1] != connection.IP)
                        {
                            ServerdatenSpeichern(connection.ServerName + ";" + connection.IP + ";" + Convert.ToString(connection.Port));
                        }
                    }
                }
                else
                {
                    ServerdatenSpeichern(connection.ServerName + ";" + connection.IP + ";" + Convert.ToString(connection.Port));
                }

                sr.Close();
            }
            else
            {
                ServerdatenSpeichern(connection.ServerName + ";" + connection.IP + ";" + Convert.ToString(connection.Port));
            }
        }

        private void ServerdatenSpeichern(string serverdaten)
        {
            string dateipfad = dir + @"ServerListe.csv";
            StreamWriter sw = new StreamWriter(dateipfad);
            sw.WriteLine(serverdaten);
            sw.Close();
        }

        public void Ausloggen()
        {
            try
            {
                connection.Logout();
            }
            catch
            {
            }
        }
    }
}
