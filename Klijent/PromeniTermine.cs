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
	public partial class PromeniTermine : Form
	{
		Komunikacija k;
		Advokat a;
		Domen.Klijent klijent;
		Slucaj slucaj;
		List<Domen.Klijent> lis;
		public PromeniTermine(Komunikacija k, Domen.Advokat a, Domen.Klijent klijent, List<Domen.Klijent> lis)
		{
			InitializeComponent();
			this.k = k;
			this.a = a;
			this.klijent = klijent;
			this.lis =lis;
		}

		private void PromeniTermine_Load(object sender, EventArgs e)
		{
			try
			{
				cmbSlucaj.DataSource = k.vratiSlucaje(klijent);
				
				cmbSlucaj.Text = "Izaberi slucaj";

				
				

				
				lbl1.Text = klijent.ToString();
				
				

			}
			catch (Exception)
			{

				throw;
			}
		}

		

		private void btnIzmeni_Click(object sender, EventArgs e)
		{
			slucaj = cmbSlucaj.SelectedItem as Slucaj;
			if (slucaj == null)
			{
				MessageBox.Show("Niste odabrali slucaj za koji zelite da izmenite termine");
				return;
			}
			dataGridView1.DataSource = slucaj.ListaTermina;
			dataGridView1.Refresh();

			if (slucaj.ListaTermina.Count == 0)
			{
				MessageBox.Show("Termini koji odgovaraju zadatoj vrednosti nisu pronađeni!");
				return;
			}
			
			
		}

		private void btnSacuvajIzmene_Click(object sender, EventArgs e)
		{
			if (k.izmeniSlucaj(slucaj))
			{
				MessageBox.Show("Termini uspešno ažurirani!");
				this.Hide();
			}
			else
			{
				MessageBox.Show("Termini za odabrani slucaj nisu azurirani! ");
				return;
			}
		}

		private void btnObrisi_Click(object sender, EventArgs e)
		{
			if (dataGridView1.CurrentRow == null)
			{
				MessageBox.Show("Niste odabrali ni jedan termin!");
				return;
			}
			else
			{
				try
				{
					Termin t = dataGridView1.CurrentRow.DataBoundItem as Termin;
					slucaj.ListaTermina.Remove(t);
				}
				catch (Exception)
				{

					MessageBox.Show("Niste odabrali ni jedan termin!");
				}
			}
		}
	}
}
