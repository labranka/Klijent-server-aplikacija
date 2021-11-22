using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public enum Operacije { Kraj=1,
		Login = 2,
		VratiMesta = 3,
		SacuvajKlijenta = 4,
		VratiKlijente = 5,
		NadjiKlijente = 6,
		AzurirajKlijenta = 7,
		ObrisiKlijenta = 8,
		Zakazi = 9,
		VratiSlucaje = 10,
		IzmeniSlucaj = 11,
	}
    [Serializable]
    public class TransferKlasa
    {
        public Operacije Operacija;
        public Object TransferObjekat;
        public Object Rezultat;
    }
}
