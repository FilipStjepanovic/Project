using Domen;
using Kontroler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    public class ObradaKlijenta
    {
        private Socket klijentskiSoket;
        NetworkStream stream;
        BinaryFormatter formatter = new BinaryFormatter();
        Kontroler.Kontroler kontroler = Kontroler.Kontroler.Instance;

        public ObradaKlijenta(Socket klijentskiSoket)
        {
            this.klijentskiSoket = klijentskiSoket;
            stream = new NetworkStream(klijentskiSoket);
        }

        internal void ObradaZahteva()
        {
            try
            {
                int choice = -1;
                while (choice != (int)Operacija.Kraj)
                {
                    TransfernaKlasa transfer = formatter.Deserialize(stream) as TransfernaKlasa;
                    switch (transfer.Operacija)
                    {
                        case Operacija.Kraj:
                            choice = 0;
                            break;

                        case Operacija.Login:
                            Radnik radnik = (Radnik)transfer.TransferniObjekat;
                            radnik = kontroler.Login(radnik.KorisnickoIme, radnik.Sifra);
                            transfer.Result = radnik;
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.VratiAutomobile:
                            List<Automobil> lista = kontroler.VratiSveAutomobile();
                            transfer.Result = lista;
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.PretraziAutomobile:
                            Automobil a = new Automobil() { Kriterijum = (string)transfer.TransferniObjekat };
                            transfer.Result = kontroler.PretraziAutomobile(a);
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.SacuvajAutomobil:
                            transfer.Result = kontroler.SacuvajAutomobil(transfer.TransferniObjekat as Automobil);
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.VratiKompanije:
                            // List<> 
                            transfer.Result = kontroler.VratiSveKompanije();
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.VratiTipove:
                            transfer.Result = kontroler.VratiSveTipove();
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.DeaktivirajAutomobil:
                            transfer.Result = kontroler.DeaktivirajAutomobil(transfer.TransferniObjekat as Automobil);
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.VratiKorisnike:
                            List<Korisnik> korisnici = kontroler.VratiKorisnike();
                            transfer.Result = korisnici;
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.PretraziKorisnike:
                            Korisnik k = new Korisnik() { Kriterijum = (string)transfer.TransferniObjekat };
                            transfer.Result = kontroler.PretraziKorisnike(k);
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.SacuvajKorisnika:
                            transfer.Result = kontroler.SacuvajKorisnika(transfer.TransferniObjekat as Korisnik);
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.IzmeniKorisnika:
                            transfer.Result = kontroler.IzmeniKorisnika(transfer.TransferniObjekat as Korisnik);
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.VratiIzdavanja:
                            transfer.Result = kontroler.VratiIzdavanja();
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.VratiPrimerke:
                            transfer.Result = kontroler.VratiPrimerke(transfer.TransferniObjekat as Automobil);
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.SacuvajIzdavanje:
                            transfer.Result = kontroler.SacuvajIzdavanje(transfer.TransferniObjekat as Izdavanje) 
                                               && kontroler.IzmeniPrimerakAutomobila(transfer.TransferniObjekat as Izdavanje);
                            formatter.Serialize(stream, transfer);
                            break;

                        case Operacija.DeaktivirajIzdavanje:
                            transfer.Result = kontroler.DeaktivirajIzdavanje(transfer.TransferniObjekat as Izdavanje)
                                                && kontroler.IzmeniPrimerakAutomobila(transfer.TransferniObjekat as Izdavanje);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }   
        }
    }
}
