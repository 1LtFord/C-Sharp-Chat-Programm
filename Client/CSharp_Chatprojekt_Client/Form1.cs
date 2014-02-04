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
        public Form1()
        {
            InitializeComponent();

        }

        private void tsmiServerliste_Click(object sender, EventArgs e)
        {
            ServerListe ServerListe1 = new ServerListe();
            ServerListe1.Show();
        }

        private void tsmiNeueVerbindung_Click(object sender, EventArgs e)
        {
            FormNeueVerbindung FormNeueVerbindung1 = new FormNeueVerbindung();
            FormNeueVerbindung1.Show();
        }


    }
}
