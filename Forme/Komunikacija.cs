using Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Forme
{
    public class Komunikacija
    {
        Socket klijentskiSoket;
        NetworkStream stream;
        BinaryFormatter formatter = new BinaryFormatter();
        private static Komunikacija _instance;
        public static Komunikacija Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new Komunikacija();
                return _instance;
            }
        }
        private Komunikacija() { }

        public bool PoveziSe()
        {
            try
            {
                if (klijentskiSoket == null || !klijentskiSoket.Connected)
                {
                    klijentskiSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    klijentskiSoket.Connect("localhost", 1945);
                    stream = new NetworkStream(klijentskiSoket);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal List<PrimerakAutomobila> VratiSvePrimerke(Automobil automobil)
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.TransferniObjekat = automobil;
            transfer.Operacija = Operacija.VratiPrimerke;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (List<PrimerakAutomobila>)transfer.Result;
        }

        internal bool SacuvajIzdavanje(Izdavanje izdavanje)
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.TransferniObjekat = izdavanje;
            transfer.Operacija = Operacija.SacuvajIzdavanje;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (bool)transfer.Result;
        }

        internal bool DeaktivirajIzdavanje(Izdavanje izdavanje)
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.TransferniObjekat = izdavanje;
            transfer.Operacija = Operacija.DeaktivirajIzdavanje;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (bool)transfer.Result;
        }

        internal List<Izdavanje> VratiSvaIzdavanja()
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.Operacija = Operacija.VratiIzdavanja;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (List<Izdavanje>)transfer.Result;
        }

        internal bool SacuvajKorisnika(Korisnik korisnik)
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.TransferniObjekat = korisnik;
            transfer.Operacija = Operacija.SacuvajKorisnika;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (bool)transfer.Result;
        }

        internal List<Korisnik> PretraziKorisnika(string pretraga)
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.TransferniObjekat = pretraga;
            transfer.Operacija = Operacija.PretraziKorisnike;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (List<Korisnik>)transfer.Result;
        }

        internal bool IzmeniKorisnika(Korisnik korisnik)
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.TransferniObjekat = korisnik;
            transfer.Operacija = Operacija.IzmeniKorisnika;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (bool)transfer.Result;
        }

        internal List<Korisnik> VratiSveKorisnike()
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.Operacija = Operacija.VratiKorisnike;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (List<Korisnik>)transfer.Result;
        }

        internal List<TipAutomobila> VratiSveTipove()
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.Operacija = Operacija.VratiTipove;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (List<TipAutomobila>)transfer.Result;
        }

        internal List<Kompanija> vratiSveKompanije()
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.Operacija = Operacija.VratiKompanije;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (List<Kompanija>)transfer.Result;
        }

        internal bool DeaktivirajAutomobil(Automobil auto)
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.Operacija = Operacija.DeaktivirajAutomobil;
            transfer.TransferniObjekat = auto;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (bool)transfer.Result;
        }

        internal List<Automobil> PretraziAutomobil(string pretraga)
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.TransferniObjekat = pretraga;
            transfer.Operacija = Operacija.PretraziAutomobile;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (List<Automobil>)transfer.Result;
        }

        internal bool SacuvajAutomobil(Automobil a)
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.TransferniObjekat = a;
            transfer.Operacija = Operacija.SacuvajAutomobil;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (bool)transfer.Result;
        }

        internal List<Automobil> vratiSveAutomobile()
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.Operacija = Operacija.VratiAutomobile;
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (List<Automobil>)transfer.Result;
        }

        private TransfernaKlasa ProcitajOdgovor()
        {
            try
            {
                return (TransfernaKlasa)formatter.Deserialize(stream);
            }
            catch (Exception e)
            {
                Debug.WriteLine(">>>" + e.Message);
                return null;
            }
        }

        internal Radnik Login(string user, string pass)
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.Operacija = Operacija.Login;
            transfer.TransferniObjekat = new Radnik() { KorisnickoIme = user, Sifra = pass };
            formatter.Serialize(stream, transfer);

            transfer = ProcitajOdgovor();
            return (Radnik)transfer.Result;

        }

        public void Kraj()
        {
            TransfernaKlasa transfer = new TransfernaKlasa();
            transfer.Operacija = Operacija.Kraj;
            formatter.Serialize(stream, transfer);
        }



    }
}
