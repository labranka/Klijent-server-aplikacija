using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Advokat
    {
        public override string ToString()
        {
            return Ime+" "+Prezime;
        }

        int id;
        string ime;
        string prezime;
        string username;
        string password;

		public int Id { get => id; set => id = value; }
		public string Ime { get => ime; set => ime = value; }
		public string Prezime { get => prezime; set => prezime = value; }
		public string Username { get => username; set => username = value; }
		public string Password { get => password; set => password = value; }
	}
}
