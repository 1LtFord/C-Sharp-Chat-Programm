using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSharp_Chatprojekt_Client
{
    public partial class FormServerListe : Form
    {
        private Form1 hauptform;

        private string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public struct Server
        {
            public string name;
            public string ip;
            public string port;
        }

        private Server[] ServerListe = new Server[25];

        public FormServerListe(Form1 hauptform)
        {
            InitializeComponent();
            this.hauptform = hauptform;
            ServerEinlesen();
            
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ServerEinlesen()
        {
            string dateipfad = dir + @"serverliste.csv";
            if (File.Exists(dateipfad))
            {
                StreamReader sr = new StreamReader(dateipfad);
                for (int i = 0; sr.Peek() != -1;i++)
                {
                    ServerEintragen(sr.ReadLine(), i);
                }
                sr.Close();
            }
            
        }

        private void ServerEintragen(string server, int index)
        {
            string[] serverInfo = server.Split(';');
            ServerListe[index].name = serverInfo[0];
            ServerListe[index].ip = serverInfo[1];
            ServerListe[index].port = serverInfo[2];
            ServerInListeEintragen(serverInfo[0]);
        }

        private void btnVerbinden_Click(object sender, EventArgs e)
        {
            int i= erkenneServer();
            FormLogin FormLogin1 = new FormLogin(hauptform, ServerListe[i].ip, ServerListe[i].port, ServerListe[i].name);
            Close();
        }

        private int erkenneServer()
        {
            for (int i = 0; i <= lbxServerliste.Items.Count - 1; i++)
            {
                if (Convert.ToString(lbxServerliste.SelectedItem) == ServerListe[i].name)
                    return i;
            }
            return -1;
        }

        private void ServerInListeEintragen(string servername)
        {
            lbxServerliste.Items.Add(servername);
        }

        private void lbxServerliste_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnVerbinden.Enabled = true;
            int i = erkenneServer();
            string data = hauptform.ServerStatusAbfragen(ServerListe[i].ip,Convert.ToInt32(ServerListe[i].port));
            string[] daten =  data.Split(';');


            lblAktuelleClientsValue.Text = daten[0];
            lblMaxClientsValue.Text = daten[1];
            lblTextPing.Text = daten[2];
            if (Convert.ToBoolean(daten[3]))
            {
                lblServerStatus.Text = "online";
                lblServerStatus.ForeColor = Color.Green;
            }
            else
            {
                lblServerStatus.Text = "offline";
                lblServerStatus.ForeColor = Color.Red;
            }
        }

        

    }
}
