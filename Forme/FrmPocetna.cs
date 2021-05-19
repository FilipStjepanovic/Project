using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmPocetna : Form
    {
        KontrolerKorisnickogInterfejsa kontroler = KontrolerKorisnickogInterfejsa.Instance;
        bool pritisnutaPretraga = false;
        public FrmPocetna()
        {
            InitializeComponent();
            dgvAutomobili.DataSource = kontroler.VratiSveAutomobile();
            this.Text = $"Radnik: {Sesija.Instance.Radnik.ImePrezime}";
            Timer timer = new Timer();
            timer.Interval = 6000;
            timer.Tick += prikaziAutomobile;
            timer.Start();
        }

        private void prikaziAutomobile(object sender, EventArgs e)
        {
            if(!pritisnutaPretraga)
                dgvAutomobili.DataSource = kontroler.VratiSveAutomobile();
            else
                dgvAutomobili.DataSource = kontroler.PretraziAutomobil(txtPretraga.Text);

        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            pritisnutaPretraga = true;
            dgvAutomobili.DataSource = kontroler.PretraziAutomobil(txtPretraga.Text);
            if (dgvAutomobili.Rows.Count == 0)
                MessageBox.Show("Sistem nije uspeo da pronadje nijedan automobil!");
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            FrmKreirajAutomobil frmKreirajAutomobil = new FrmKreirajAutomobil();
            frmKreirajAutomobil.ShowDialog();
        }

        private void btnDeaktiviraj_Click(object sender, EventArgs e)
        {
            try
            {
                bool uspesno = kontroler.DeaktivirajAutomobil((Automobil)dgvAutomobili.SelectedRows[0].DataBoundItem);
                if (uspesno)
                {
                    MessageBox.Show("Sistem je uspesno deaktivirao automobil.");
                    prikaziAutomobile(sender, e);
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da deaktivira automobil!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Niste odabrali nijedan automobil.");
            }
        }

        private void korisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKorisnici frm = new FrmKorisnici();
            frm.ShowDialog();
        }

        private void izdavanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmIzdavanja().ShowDialog();
        }
    }
}
