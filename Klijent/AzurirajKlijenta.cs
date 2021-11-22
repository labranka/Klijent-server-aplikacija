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
	public partial class AzurirajKlijenta : Form
	{
		Komunikacija k;
		Domen.Advokat a;
		Domen.Klijent klijent;
		List<Domen.Klijent> lis;
		public AzurirajKlijenta(Komunikacija k, Domen.Advokat a, Domen.Klijent klijent, List<Domen.Klijent> lis)
		{
			InitializeComponent();
			this.k = k;
			this.a = a;
			this.klijent = klijent;
			this.lis = lis;
		}

		private void AzurirajKlijenta_Load(object sender, EventArgs e)
		{
			txtAdresa.Text = klijent.Adresa;
			txtEmail.Text = klijent.Email;
			txtImeKlijenta.Text = klijent.Ime;
			txtPrezimeKlijenta.Text = klijent.Prezime;
			txtKontakt.Text = klijent.Kontakt;
			cmbMesto.DataSource = k.vratiSvaMesta();
			cmbMesto.Text = klijent.Mesto.NazivMesta.ToString();
			txtImeKlijenta.Enabled = false;
			txtPrezimeKlijenta.Enabled = false;
		}

		private void btnSacuvaj_Click(object sender, EventArgs e)
		{
			klijent.Adresa = txtAdresa.Text;
			klijent.Email = txtEmail.Text;
			klijent.Kontakt = txtKontakt.Text;
			klijent.Mesto = cmbMesto.SelectedItem as Domen.Mesto;
			klijent.Ime = txtImeKlijenta.Text;
			klijent.Prezime = txtPrezimeKlijenta.Text;
			
			if (k.azurirajKlijenta(klijent))
			{
				MessageBox.Show("Klijent je uspesno azuriran!");

				this.Close();
				
			}
			else
			{
				MessageBox.Show("Neuspesna izmena podataka o klijentu!");
				return;
			}
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}
	}
}
