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

namespace Server
{
    class NitKlijenta
    {
        private NetworkStream tok;
        BinaryFormatter formater;

        public NitKlijenta(NetworkStream tok)
        {
            this.tok = tok;
            formater = new BinaryFormatter();

            ThreadStart ts = obradiKlijenta;
            Thread nit = new Thread(ts);
            nit.Start();
        }

        void obradiKlijenta()
        {
            try
            {
                int operacija = 0;

                while (operacija != (int)Operacije.Kraj)
                {
                    TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;
                    switch (transfer.Operacija)
                    {

                        case Operacije.Login:
                            transfer.Rezultat = Broker.DajSesiju().Login(transfer.TransferObjekat as Advokat);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.VratiMesta:
                            transfer.Rezultat = Broker.DajSesiju().vratiSvaMesta();
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.SacuvajKlijenta:
                            transfer.Rezultat = Broker.DajSesiju().sacuvajKlijenta(transfer.TransferObjekat as Klijent);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.VratiKlijente:
                            transfer.Rezultat = Broker.DajSesiju().vratiSveKlijente();
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacije.NadjiKlijente:
                            transfer.Rezultat = Broker.DajSesiju().nadjiKlijente(transfer.TransferObjekat.ToString());
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.AzurirajKlijenta:
                            transfer.Rezultat = Broker.DajSesiju().azurirajKlijenta(transfer.TransferObjekat as Klijent);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacije.ObrisiKlijenta:
                            transfer.Rezultat = Broker.DajSesiju().obrisiKlijenta(transfer.TransferObjekat as Klijent);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.Zakazi:
                            transfer.Rezultat = Broker.DajSesiju().sacuvajSlucaj(transfer.TransferObjekat as Slucaj);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacije.VratiSlucaje:
                            transfer.Rezultat = Broker.DajSesiju().vratiSlucaje(transfer.TransferObjekat as Klijent);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacije.IzmeniSlucaj:
                            transfer.Rezultat = Broker.DajSesiju().izmeniSlucaj(transfer.TransferObjekat as Slucaj);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.Kraj:operacija = 1;                           
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
               
            }
        }
    }
}
