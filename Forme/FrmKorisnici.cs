using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmKorisnici : Form
    {
        KontrolerKorisnickogInterfejsa kontroler = KontrolerKorisnickogInterfejsa.Instance;
        bool pretragaClick = false;
        public FrmKorisnici()
        {
            InitializeComponent();
            dgvKorisnici.DataSource = kontroler.VratiSveKorisnike();
            Timer t;
            t = new Timer();
            t.Interval = 5000;
            t.Tick += prikaziKorisnike;
            t.Start();
        }

        private void prikaziKorisnike(object sender, EventArgs e)
        {
            if (!pretragaClick)
                dgvKorisnici.DataSource = kontroler.VratiSveKorisnike();
            else
                dgvKorisnici.DataSource = kontroler.PretraziKorisnika(txtPretraga.Text);
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            pretragaClick = true;
            dgvKorisnici.DataSource = kontroler.PretraziKorisnika(txtPretraga.Text);

            if (dgvKorisnici.Rows.Count == 0)
                MessageBox.Show("Sistem nije uspeo da pronadje nijedan automobil!");
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            FrmKreirajKorisnika frm = new FrmKreirajKorisnika();
            frm.ShowDialog();
        }

        private void btnPromeni_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmKreirajKorisnika((Korisnik)dgvKorisnici.SelectedRows[0].DataBoundItem).ShowDialog();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Niste odabrali nijednog korisnika!");
            }
        }
    }
}
