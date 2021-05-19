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
    public partial class FrmKreirajIzdavanje : Form
    {
        KontrolerKorisnickogInterfejsa kontroler = KontrolerKorisnickogInterfejsa.Instance;
        public FrmKreirajIzdavanje()
        {
            InitializeComponent();
            cmbKorisnik.DataSource = kontroler.VratiSveKorisnike();
            cmbAutomobil.DataSource = kontroler.VratiSveAutomobile();
            txtDatum.Text = DateTime.Now.ToString("dd/MM/yyyy");    // OVDE GRESKA?
            checkBoxAktivno.Checked = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParseExact(txtDatum.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime datum))
            {
                MessageBox.Show("Datum nije dobro unet.");
            }
            else
            {
                if (cmbPrimerak.SelectedItem != null)
                {
                    KontrolerKorisnickogInterfejsa.Instance.SacuvajIzdavanje(new Izdavanje()
                        {
                        PrimerakAutomobila = (PrimerakAutomobila)cmbPrimerak.SelectedItem,
                        Korisnik = (Korisnik)cmbKorisnik.SelectedItem,
                        DatumIzdavanja = datum,
                        Aktivno = checkBoxAktivno.Checked
                        });
                    MessageBox.Show("Sistem je uspesno kreirao izdavanje.");
                }
                else
                {
                    MessageBox.Show("Trenutno nemamo nijedan slobodan auto izabranog modela.");
                }
            }
        }

        private void cmbAutomobil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPrimerak.DataSource = kontroler.VratiSvePrimerke((Automobil) cmbAutomobil.SelectedItem);
        }


    }
}
