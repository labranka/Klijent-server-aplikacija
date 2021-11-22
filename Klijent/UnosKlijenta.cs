using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domen;

namespace Klijent
{
    public partial class UnosKlijenta : Form
    {


        Komunikacija k;
        Advokat a;
        
        Domen.Klijent klijent = new Domen.Klijent();
        

        public UnosKlijenta(Komunikacija k, Advokat a)
        {
            
            InitializeComponent();
            this.k = k;
            this.a = a;
           
        }

        private void IzmenaZahteva_Load(object sender, EventArgs e)
        {
			try
			{
                List<Mesto> listaMesta = new List<Mesto>();
                listaMesta = k.vratiSvaMesta();
                cmbMesto.DataSource = listaMesta;
                
			}
			catch (Exception)
			{

				throw;
			}


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

		private void btnSacuvaj_Click(object sender, EventArgs e)
		{
            klijent.Ime = txtImeKlijenta.Text;
            klijent.Prezime = txtPrezimeKlijenta.Text;
            klijent.Email = txtEmail.Text;
            klijent.Kontakt = txtKontakt.Text;
            klijent.Adresa = txtAdresa.Text;
            klijent.Mesto = cmbMesto.SelectedItem as Mesto;
            

            if(klijent.Ime=="" || klijent.Prezime=="" || klijent.Email == "" || klijent.Kontakt == "" || klijent.Adresa == "")
			{
                MessageBox.Show("Sva polja moraju biti popunjena!");
                return;
			}

			if (k.sacuvajKlijenta(klijent))
			{
                MessageBox.Show("Klijent je uspesno sacuvan!");
                
                this.Close();
            }
			else
			{
                MessageBox.Show("Klijent nije sacuvan!");
                return;
            }
            
		}
	}
}
