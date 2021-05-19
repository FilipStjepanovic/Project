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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (KontrolerKorisnickogInterfejsa.Instance.PoveziSe()) 
            {
                Radnik radnik = KontrolerKorisnickogInterfejsa.Instance.Login(txtUsername.Text, txtPassword.Text);
                if (radnik != null)
                {
                    MessageBox.Show("Uspesno ste prijavljeni!");
                    Sesija.Instance.Radnik = radnik;
                    FrmPocetna frmPocetna = new FrmPocetna();
                    frmPocetna.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Pokusajte ponovo!");
                txtUsername.Text = "";
                txtPassword.Text = "";
                btnLogin.Focus();
            }
        }
    }
}
