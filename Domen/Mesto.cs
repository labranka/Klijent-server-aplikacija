using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Mesto
    {
        public override string ToString()
        {
            return NazivMesta;
        }

      public Mesto()
		{
            ListaKlijenata = new BindingList<Klijent>();
		}

        int id;
        string nazivMesta;
        int ptt;
        BindingList<Domen.Klijent> listaKlijenata;

		public int Id { get => id; set => id = value; }
		public string NazivMesta { get => nazivMesta; set => nazivMesta = value; }
		public BindingList<Klijent> ListaKlijenata { get => listaKlijenata; set => listaKlijenata = value; }
		public int Ptt { get => ptt; set => ptt = value; }
	}
}
