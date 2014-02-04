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
    public partial class ServerListe : Form
    {
        public ServerListe()
        {
            InitializeComponent();
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
