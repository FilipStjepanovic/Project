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
    public partial class FrmKreirajKorisnika : Form
    {
        private Korisnik Korisnik { get; set; }
        KontrolerKorisnickogInterfejsa kontroler = KontrolerKorisnickogInterfejsa.Instance;
        public FrmKreirajKorisnika()
        {
            InitializeComponent();
            cmbPol.DataSource = new List<String>() { "muski", "zenski" };
        }

        public FrmKreirajKorisnika(Korisnik korisnik)
        {
            InitializeComponent();
            Korisnik = korisnik;
            txtDatum.Text = korisnik.DatumRodjenja.ToString("dd/MM/yyyy");
            txtImePrezime.Text = korisnik.ImePrezime;
            cmbPol.Text = korisnik.Pol;
            checkBoxAktivan.Checked = korisnik.Aktivan;
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParseExact(txtDatum.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime datumRodjenja))
            {
                if (cmbPol.Text.Length > 0 && txtImePrezime.Text.Length > 0)
                {
                    if (Korisnik == null)
                    {
                        kontroler.SacuvajKorisnika(new Korisnik()
                        {
                            ImePrezime = txtImePrezime.Text,
                            DatumRodjenja = datumRodjenja,
                            Pol = cmbPol.Text,
                            Aktivan = checkBoxAktivan.Checked
                        });
                        this.Hide();
                        MessageBox.Show("Sistem je uspesno kreirao korisnika.");
                    }
                    else
                    {
                        kontroler.IzmeniKorisnika(new Korisnik()
                        {
                            KorisnikID = Korisnik.KorisnikID,
                            ImePrezime = txtImePrezime.Text,
                            DatumRodjenja = datumRodjenja,
                            Pol = cmbPol.Text,
                            Aktivan = checkBoxAktivan.Checked
                        });
                        this.Hide();
                        MessageBox.Show("Sistem je zapamtio korisnika.");
                    }
                }
                else
                {
                    MessageBox.Show("Molimo Vas da popunite sva polja!");
                }
            }
            else
            {
                MessageBox.Show("Neispravno unet datum!");
            }
        }
    }
}
