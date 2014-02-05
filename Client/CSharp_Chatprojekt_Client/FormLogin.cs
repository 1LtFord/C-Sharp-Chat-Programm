using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Chatprojekt_Client
{
    public partial class FormLogin : Form
    {
        private Form1 hauptform;

        private string ip, port;

        public FormLogin(Form1 hauptform, string ip, string port, string servername)
        {
            InitializeComponent();
            this.hauptform = hauptform;
            this.ip = ip;
            this.port = port;
            ServerNameAnzeigen(servername);
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVerbinden_Click(object sender, EventArgs e)
        {
            if (tbxBenutzername.Text == "GetServerInfo")
            {
                MessageBox.Show("Der Benutzername ist ungültig. Er entspricht einem Programmwert");
            }
            else
            {
                if (hauptform.UserVerbinden(ip, Convert.ToInt32(port), tbxServerPW.Text, tbxBenutzername.Text, tbxBenutzerPW.Text))
                {
                    Close();
                }
            }
        }

        private void ServerNameAnzeigen(string servername)
        {
            lblvalueServerName.Text = servername;
        }




    }
}
