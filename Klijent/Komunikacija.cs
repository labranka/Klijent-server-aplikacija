using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domen;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Klijent
{
    public class Komunikacija
    {
        TcpClient klijent;
        NetworkStream tok;
        BinaryFormatter formater;

        public bool povesiSeNaServer()
        {
            try
            {
                klijent = new TcpClient("localhost", 20000);
                tok = klijent.GetStream();
                formater = new BinaryFormatter();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Kraj()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.Kraj;
            formater.Serialize(tok, transfer);
        }


        public Advokat Login(Advokat l)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.Login;
            transfer.TransferObjekat = l;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as Advokat;
        }


        public List<Mesto> vratiSvaMesta()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.VratiMesta;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as List<Mesto>;
        }

        public bool sacuvajKlijenta(Domen.Klijent klijent)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.SacuvajKlijenta;
            transfer.TransferObjekat = klijent;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (bool)transfer.Rezultat;
        }
        public List<Domen.Klijent> vratiSveKlijente()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.VratiKlijente;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as List<Domen.Klijent>;
        }

        public List<Domen.Klijent> nadjiKlijente(string naziv)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.NadjiKlijente;
            transfer.TransferObjekat = naziv;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as List<Domen.Klijent>;
        }

        public bool azurirajKlijenta(Domen.Klijent klijent)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.AzurirajKlijenta;
            transfer.TransferObjekat = klijent;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (bool)transfer.Rezultat;
        }
        public bool obrisiKlijenta(Domen.Klijent klijent)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.ObrisiKlijenta;
            transfer.TransferObjekat = klijent;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (bool)transfer.Rezultat;
        }

        public bool sacuvajSlucaj(Slucaj s)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.Zakazi;
            transfer.TransferObjekat = s;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (bool)transfer.Rezultat;
        }
        public List<Slucaj> vratiSlucaje(Domen.Klijent k)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.VratiSlucaje;
            transfer.TransferObjekat = k;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as List<Slucaj>;
        }

        public bool izmeniSlucaj(Slucaj s)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.IzmeniSlucaj;
            transfer.TransferObjekat = s;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (bool)transfer.Rezultat;
        }
    }
}
