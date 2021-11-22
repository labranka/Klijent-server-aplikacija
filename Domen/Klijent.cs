using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Klijent
    {
        public override string ToString()
        {
            return Ime + " " + Prezime;
        }

        int id;
        string ime;
        string prezime;
        string email;
        string kontakt;
        string adresa;
        Mesto mesto;

        [Browsable(false)]
		public int Id { get => id; set => id = value; }
		public string Ime { get => ime; set => ime = value; }
		public string Prezime { get => prezime; set => prezime = value; }
        [Browsable(false)]
        public string Email { get => email; set => email = value; }
        [Browsable(false)]
        public string Kontakt { get => kontakt; set => kontakt = value; }
        [Browsable(false)]
        public string Adresa { get => adresa; set => adresa = value; }
     
        public Mesto Mesto { get => mesto; set => mesto = value; }
	}
}
