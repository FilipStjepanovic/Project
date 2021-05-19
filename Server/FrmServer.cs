using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        Server s;
        public FrmServer()
        {
            InitializeComponent();
            btnZaustavi.Enabled = false;
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            s = new Server();
            if (s.PokreniServer())
            {
                textBox1.Text = "Server je pokrenut!";
                textBox1.Select(0,0);
                btnPokreni.Enabled = false;
                btnZaustavi.Enabled = true;
                this.Hide();
            }
            else {
                MessageBox.Show("Greska prilikom pokretanja servera!");
            }
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            s.ZaustaviServer();
            textBox1.Text = "Server nije pokrenut!";
            textBox1.Select(0, 0);
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
        }
    }
}
