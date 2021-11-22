using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Domen;
using System.Data.SqlClient;
using System.ComponentModel;

namespace Server
{
    public class Broker
    {
        SqlCommand komanda;
        SqlConnection konekcija;
        SqlTransaction transakcija;

        void poveziSe()
        {
            konekcija = new SqlConnection(@"Data Source=DESKTOP-R01OBK0\SQLEXPRESS;Initial Catalog=AdvokatskaKancelarija;Integrated Security=True");
            komanda = konekcija.CreateCommand();
        }

        Broker()
        {
            poveziSe();
        }

        static Broker instanca;
        public static Broker DajSesiju()
        {
            if (instanca == null) instanca = new Broker();
            return instanca;
        }



        public Advokat Login(Advokat a)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Advokat where Username='"+a.Username+"' and Password='"+a.Password+"'";
                SqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    a.Id = citac.GetInt32(0);
                    a.Ime = citac.GetString(1);
                    a.Prezime = citac.GetString(2);
                    
                 

                    citac.Close();
                    return a;

                }
                citac.Close();
                return null;
                
            }
            catch (Exception)
            {

                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }


       public List<Mesto> vratiSvaMesta()
		{
            List<Mesto> lista = new List<Mesto>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Mesto";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                   Mesto m = new Mesto();
                    m.Id = citac.GetInt32(0);
                    m.NazivMesta = citac.GetString(1);
                    m.Ptt = citac.GetInt32(2);
                    lista.Add(m);
                }
                citac.Close();
                return lista;
            }
			catch (Exception)
			{
                return null;
			}
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public bool sacuvajKlijenta(Klijent klijent)
        {
            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija);
                                    
                komanda.CommandText = "Insert into Klijent values('" +klijent.Ime+ "','" +klijent.Prezime + "','" +klijent.Email + "','" +klijent.Kontakt + "', '" +klijent.Adresa + "'," + klijent.Mesto.Id + ")";
                komanda.ExecuteNonQuery();

  
                transakcija.Commit();
                return true;

            }
            catch (Exception)
            {
                transakcija.Rollback();
                return false;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        

        public List<Klijent> vratiSveKlijente()
        {
            List<Klijent> lista = new List<Klijent>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Klijent k inner join Mesto m on m.MestoID=k.MestoID";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Klijent k = new Klijent();
                    k.Id = citac.GetInt32(0);
                    k.Ime = citac.GetString(1);
                    k.Prezime = citac.GetString(2);
                    k.Email = citac.GetString(3);
                    k.Kontakt = citac.GetString(4);
                    k.Adresa = citac.GetString(5);
                    k.Mesto = new Mesto();
                    k.Mesto.Id = citac.GetInt32(7);
                    k.Mesto.NazivMesta = citac.GetString(8);
                    k.Mesto.Ptt = citac.GetInt32(9);

                    lista.Add(k);
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public List<Klijent> nadjiKlijente(string naziv)
		{
			try
			{
				List<Klijent> lista = new List<Klijent>();
				lista = vratiSveKlijente();
                List<Klijent> novaLista = new List<Klijent>();
				foreach (Klijent k in lista)
				{
					if (k.Mesto.NazivMesta == naziv)
					{
						novaLista.Add(k);
					}
				}
				return novaLista;
			}
			catch (Exception)
			{
                return null;
			}
		}

        public bool azurirajKlijenta(Klijent klijent)
        {
           
            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija);

                komanda.CommandText = "Update Klijent set Email='"+klijent.Email+"', Kontakt='"+klijent.Kontakt+"', Adresa='"+klijent.Adresa+"', MestoID="+klijent.Mesto.Id+" where KlijentID="+klijent.Id+"";
                komanda.ExecuteNonQuery();


                transakcija.Commit();
                return true;
               
            }
            catch (Exception)
            {
                transakcija.Rollback();
                return false;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public bool obrisiKlijenta(Klijent klijent)
        {

            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija);

                komanda.CommandText = "Delete Klijent where KlijentID=" + klijent.Id + "";
                komanda.ExecuteNonQuery();

                transakcija.Commit();
                return true;

            }
            catch (Exception)
            {
                transakcija.Rollback();
                return false;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public bool sacuvajSlucaj(Slucaj s)
        {
            
            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija);

                s.Id = vratiID();
                komanda.CommandText = "Insert into Slucaj values("+s.Id+",'"+s.NazivSlucaja+"', '"+s.DatumSudjenja.ToString("yyyy-MM-dd HH:mm") +"',"+s.Advokat.Id+", "+s.Klijent.Id+")";
                komanda.ExecuteNonQuery();
              

                foreach (Termin t in s.ListaTermina)
                {
                   
                    komanda.CommandText = "Insert into Termin values("+s.Id+",'" + t.Datum.ToString("yyyy-MM-dd HH:mm") + "', '"+t.Napomena+"')";
                    komanda.ExecuteNonQuery();
                }

                transakcija.Commit();
                return true;

            }
            catch (Exception)
            {
                transakcija.Rollback();
                return false;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

		private int vratiID()
		{
            try
            {
                komanda.CommandText = "Select max(SlucajID) from Slucaj";
                try
                {
                    int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                    return sifra + 1;
                }
                catch (Exception)
                {

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


       public List<Slucaj> vratiSlucaje(Klijent k)
		{
            List<Slucaj> lista = new List<Slucaj>();
           
			try
			{
                konekcija.Open();
                komanda.CommandText = "Select * from Slucaj where KlijentID="+k.Id+"";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Slucaj s = new Slucaj();
                    s.Id = citac.GetInt32(0);
                    s.NazivSlucaja = citac.GetString(1);
                    s.DatumSudjenja = citac.GetDateTime(2);
                    
                    s.Advokat = new Advokat();
                    s.Advokat.Id = citac.GetInt32(3);

                    s.Klijent = new Klijent();
                    s.Klijent.Id = citac.GetInt32(4); 

                    lista.Add(s);
                    
                }

                citac.Close();

                foreach(Slucaj slucaj in lista)
				{
                    vratiSveTermineZaSlucaj(slucaj);
				}
                return lista;
            }
			catch (Exception)
			{
                return null;
			}
			finally { if (konekcija != null) konekcija.Close(); }
		}

		private void vratiSveTermineZaSlucaj(Slucaj s)
		{
          
         
         
			try
			{
                komanda.CommandText = "Select * from Termin where SlucajID="+s.Id+"";
                SqlDataReader citac = komanda.ExecuteReader();
				while (citac.Read())
				{
                    Termin t = new Termin();
                    t.Id = citac.GetInt32(0);
                    t.Datum = citac.GetDateTime(2);
                    t.Napomena = citac.GetString(3);

                    s.ListaTermina.Add(t);
				}
                citac.Close();
              

			}
			catch (Exception)
			{
                throw;
			}
		}

        public bool izmeniSlucaj(Slucaj s)
        {

            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija);

                komanda.CommandText = "Delete from Termin where SlucajID=" + s.Id + "";
                komanda.ExecuteNonQuery();

                foreach (Termin t in s.ListaTermina)
                {

                    komanda.CommandText = "Insert into Termin values(" + s.Id + ",'" + t.Datum.ToString("yyyy-MM-dd HH:mm") + "', '" + t.Napomena + "')";
                    komanda.ExecuteNonQuery();
                }

                transakcija.Commit();
                return true;

            }
            catch (Exception)
            {
                transakcija.Rollback();
                return false;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
    }
}
