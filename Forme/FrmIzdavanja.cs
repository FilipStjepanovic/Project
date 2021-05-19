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
    public partial class FrmIzdavanja : Form
    {
        KontrolerKorisnickogInterfejsa kontroler = KontrolerKorisnickogInterfejsa.Instance;
        public FrmIzdavanja()
        {
            InitializeComponent();
            btnKreiraj.FlatStyle = FlatStyle.Flat;
            btnKreiraj.FlatAppearance.BorderColor = Color.ForestGreen;
            btnKreiraj.FlatAppearance.BorderSize = 1;

            btnDeaktiviraj.FlatStyle = FlatStyle.Flat;
            btnDeaktiviraj.FlatAppearance.BorderColor = Color.Red;
            btnDeaktiviraj.FlatAppearance.BorderSize = 1;
            dgvIzdavanja.DataSource = kontroler.VratiSvaIzdavanja();

            Timer timer = new Timer();
            timer.Interval = 6000;
            timer.Tick += prikaziIzdavanja;
            timer.Start();
        }

        private void prikaziIzdavanja(object sender, EventArgs e)
        {
            dgvIzdavanja.DataSource = kontroler.VratiSvaIzdavanja();
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            FrmKreirajIzdavanje frm = new FrmKreirajIzdavanje();
            frm.ShowDialog();
        }

        private void btnDeaktiviraj_Click(object sender, EventArgs e)
        {
            try
            {
                if (kontroler.DeaktivirajIzdavanje((Izdavanje)dgvIzdavanja.SelectedRows[0].DataBoundItem))
                    MessageBox.Show("Sistem je uspesno deaktivirao izdavanje.");
                else
                    MessageBox.Show("Sistem ne moze da deaktivira izdavanje.");
            }
            catch (Exception)
            {
                MessageBox.Show("Niste izabrali nijedno izdavanje!");
            }
        }
    }
}
