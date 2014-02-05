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
    public partial class FormNeueVerbindung : Form
    {
        public FormNeueVerbindung()
        {
            InitializeComponent();
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVerbinden_Click(object sender, EventArgs e)
        {
           if( Verbindung verbindung = new Verbindung(tbxIP.Text, Convert.ToInt32(tbxPort.Text), tbxServerPW.Text, tbxBenutzername.Text, tbxbenutzerPW.Text);
           
        }
    }
}
