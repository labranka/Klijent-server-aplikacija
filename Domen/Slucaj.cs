using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
	[Serializable]
	public class Slucaj
	{
		public Slucaj()
		{
			ListaTermina = new BindingList<Termin>();
		}

		public override string ToString()
		{
			return nazivSlucaja;
		}

		

		int id;
		string nazivSlucaja;
		DateTime datumSudjenja;
		Advokat advokat;
		Klijent klijent;
		BindingList<Termin> listaTermina;

		[Browsable(false)]
		public int Id { get => id; set => id = value; }
		public string NazivSlucaja { get => nazivSlucaja; set => nazivSlucaja = value; }
		public DateTime DatumSudjenja { get => datumSudjenja; set => datumSudjenja = value; }
		[Browsable(false)]
		public BindingList<Termin> ListaTermina { get => listaTermina; set => listaTermina = value; }
		public Advokat Advokat { get => advokat; set => advokat = value; }
		public Klijent Klijent { get => klijent; set => klijent = value; }

		
	}
}
