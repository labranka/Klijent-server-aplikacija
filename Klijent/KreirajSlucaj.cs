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
	public partial class IzaberiKlijenta : Form
	{
		Komunikacija k;
		Advokat a;
		Domen.Klijent klijent;
		List<Domen.Klijent> listaKlijenata;
		Slucaj slucaj = new Slucaj();
		List<Slucaj> listaSluc = new List<Slucaj>();

		public IzaberiKlijenta(Komunikacija k, Domen.Advokat a, Domen.Klijent klijent, List<Domen.Klijent> lis)
		{
			InitializeComponent();
			this.k = k;
			this.a = a;
			this.klijent = klijent;
			this.listaKlijenata = lis;
		}

		

	



		private void label11_Click(object sender, EventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		
		private void IzaberiKlijenta_Load_1(object sender, EventArgs e)
		{
			txtAdresa.Text = klijent.Adresa;
			txtEmail.Text = klijent.Email;
			txtImeKlijenta.Text = klijent.Ime;
			txtPrezimeKlijenta.Text = klijent.Prezime;
			txtKontakt.Text = klijent.Kontakt;
			txtMesto.Text = klijent.Mesto.NazivMesta;

			txtMesto.Enabled = false;
			txtKontakt.Enabled = false;
			txtImeKlijenta.Enabled = false;
			txtPrezimeKlijenta.Enabled = false;
			txtAdresa.Enabled = false;
			txtEmail.Enabled = false;


		
		}

		private void btnUnesiTermin_Click(object sender, EventArgs e)
		{
			slucaj.NazivSlucaja = txtNazivSlucaja.Text;
			try
			{
				slucaj.DatumSudjenja = DateTime.ParseExact(txtDatumSudjenja.Text, "dd.MM.yyyy HH:mm", null);
			}
			catch (Exception)
			{
				MessageBox.Show("Datum sudjenja nije u dobrom formatu!");
				return;
			}

			slucaj.Klijent = klijent;
			slucaj.Advokat = a;

			
			Termin termin = new Termin();
			termin.Napomena = txtNapomena.Text;
			try
			{
				termin.Datum = DateTime.ParseExact(txtTerminKonsultacija.Text, "dd.MM.yyyy HH:mm", null);
			}
			catch (Exception)
			{
				MessageBox.Show("Datum i vreme termina nisu u dobrom formatu!");
				return;
			}




			slucaj.ListaTermina.Add(termin);

			dataGridView1.DataSource = slucaj.ListaTermina;

			



		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			if (k.sacuvajSlucaj(slucaj))
			{
				MessageBox.Show("Sistem je zapamtio podatke o novom slučaju.");
				this.Hide();
				return;
			}
			else
			{
				MessageBox.Show("Sistem ne može da zapamti podatke o novom slučaju!");
				return;
			}
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
		}

		private void cbSlucajevi_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
