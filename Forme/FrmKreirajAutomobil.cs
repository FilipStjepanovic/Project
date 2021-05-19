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
    public partial class FrmKreirajAutomobil : Form
    {
        KontrolerKorisnickogInterfejsa kontroler = KontrolerKorisnickogInterfejsa.Instance;
        public FrmKreirajAutomobil()
        {
            InitializeComponent();
            cmbProizvodjac.DataSource = kontroler.vratiSveKompanije();
            cmbTip.DataSource = kontroler.VratiSveTipove();
            checkBoxAktivan.Checked = true;
            txtNaziv.Focus();
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            Automobil a = new Automobil()
            {
                Naziv = txtNaziv.Text,
                Kompanija = (Kompanija)cmbProizvodjac.SelectedItem,
                TipAutomobila = (TipAutomobila)cmbTip.SelectedItem,
                Aktivan = checkBoxAktivan.Checked
            };

            if (txtNaziv.Text.Length > 0)
            {
                bool uspesno = kontroler.SacuvajAutomobil(a);
                if (uspesno)
                {
                    this.Hide();
                    MessageBox.Show("Sistem je uspesno kreirao automobil.");
                }
                else
                {
                    MessageBox.Show("Greska prilikom kreiranja automobila!");
                }
            }
            else MessageBox.Show("Morate uneti naziv automobila!");
                
        }
    }
}
