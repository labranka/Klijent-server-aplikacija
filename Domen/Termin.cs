using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Termin
    {

	
        int id;
       
        DateTime datum;
        string napomena;
     
        [Browsable(false)]
		public int Id { get => id; set => id = value; }
		public DateTime Datum { get => datum; set => datum = value; }
		public string Napomena { get => napomena; set => napomena = value; }
	}
}
