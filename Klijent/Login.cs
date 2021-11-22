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

namespace Klijent
{
    public partial class Login : Form
    {
        Komunikacija k;
        public Login()
        {
            InitializeComponent();
        }

        private void FormKlijent_Load(object sender, EventArgs e)
        {
           
        }

        private void FormKlijent_FormClosed(object sender, FormClosedEventArgs e)
        {
            k.Kraj();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            k = new Komunikacija();
            if (k.povesiSeNaServer())
            {
                Advokat a = new Advokat() { Username = txtKorIme.Text, Password = txtLozinka.Text };
                a = k.Login(a);

                if (a != null)
                {
                    MessageBox.Show("Prijavljivanje uspesno!");
                    this.Hide();
                    new GlavnaForma(k, a).ShowDialog();
                   
                }
                else
                {
                    MessageBox.Show("Prijavljivanje neuspesno!");
                }
            }
            else
            {
                MessageBox.Show("Neuspelo povezivanje na server!");
            }
        }

		private void txtLozinka_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
