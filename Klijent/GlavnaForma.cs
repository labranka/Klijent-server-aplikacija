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
    public partial class GlavnaForma : Form
    {
        Komunikacija k;
        Advokat a;      
        List<Domen.Klijent> lis = new List<Domen.Klijent>();
        Domen.Klijent klijent = new Domen.Klijent();
        List<Slucaj> listaSlucajeva = new List<Slucaj>();
        public GlavnaForma(Komunikacija k, Advokat a)
        {
         
            InitializeComponent();
            this.a = a;
            this.k = k;
        }

        private void GlavnaForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            k.Kraj();
        }

      

        private void GlavnaForma_Load(object sender, EventArgs e)
        {
            this.Text = a.ToString();
			try
			{
               
                lis = k.vratiSveKlijente();
             
                dataGridView1.DataSource = lis;
                cbMesto.DataSource = k.vratiSvaMesta();
                cbMesto.Text = "Izaberi mesto";
			}
			catch (Exception)
			{

				throw;
			}
        }

		private void btnUnos_Click(object sender, EventArgs e)
		{
            new UnosKlijenta(k, a).ShowDialog();
            GlavnaForma_Load(sender, e);
          
		}

        
		private void btnPretrazi_Click(object sender, EventArgs e)
		{
            string naziv="";
            naziv = cbMesto.SelectedItem.ToString();
            List<Domen.Klijent> lista = new List<Domen.Klijent>();
            lista = k.nadjiKlijente(naziv);
            if (lista.Count == 0)
			{
                MessageBox.Show("Klijenti za izabrano mesto nisu pronadjeni");
                GlavnaForma_Load(sender, e);
                return;
			}
            if(cbMesto.Text =="Izaberi mesto")
			{
                dataGridView1.DataSource = k.vratiSveKlijente();
                return;
            }
            dataGridView1.DataSource = lista;
            
		}

		private void btnIzaberi_Click(object sender, EventArgs e)
		{
			try
			{
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Klijent nije pronadjen!");
                }
                else
                {
                    klijent = dataGridView1.CurrentRow.DataBoundItem as Domen.Klijent;

                    new IzaberiKlijenta(k, a, klijent, lis).Show();
                    GlavnaForma_Load(sender, e);

                }
            }
			catch (NullReferenceException)
			{
                MessageBox.Show("Klijent nije pronadjen!");
            }
            
            
        }

		

		private void btnObrisiKlijenta_Click(object sender, EventArgs e)
		{
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Klijent nije pronadjen!");
                }
                else
                {
                    klijent = dataGridView1.CurrentRow.DataBoundItem as Domen.Klijent;
                    if (k.obrisiKlijenta(klijent))
                    {
                        MessageBox.Show("Klijent je obrisan!");
                        dataGridView1.Refresh();
                       
                    }
                    else
                    {
                        MessageBox.Show("Klijent nije obrisan!");
                        return;
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Klijent nije pronadjen!");
            }
           
        }

		private void btnIzmeni_Click(object sender, EventArgs e)
		{
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Klijent nije pronadjen!");
                }
                else
                {
                    klijent = dataGridView1.CurrentRow.DataBoundItem as Domen.Klijent;

                    new AzurirajKlijenta(k, a, klijent, lis).Show();

                    dataGridView1.Refresh();

                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Klijent nije pronadjen!");
            }
			
           
        }

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
           

            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Klijent nije pronadjen!");
                    return;
                }
                else
                {
                    klijent = dataGridView1.CurrentRow.DataBoundItem as Domen.Klijent;
                    if(k.vratiSlucaje(klijent).Count == 0)
					{
                        MessageBox.Show("Ne postoje slucajevi za izabranog klijenta, definisi nov slucaj!");
                        return;
                    }
                    new PromeniTermine(k, a, klijent, lis).Show();

                   

                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Klijent nije pronadjen!");
            }
        }
	}
}
