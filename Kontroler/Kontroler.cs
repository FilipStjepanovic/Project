using Broker;
using Domen;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontroler
{
    public class Kontroler
    {
        private static Kontroler _instance;
        private Broker.Broker broker = Broker.Broker.Instance;
        public static Kontroler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Kontroler();
                }
                return _instance;
            }
        }
        private Kontroler() { }

        public Radnik Login(string korisnickoIme, string sifra)
        {
            try
            {
                broker.OtvoriKonekciju();
                Radnik r = broker.Login(new Radnik() { KorisnickoIme = korisnickoIme, Sifra = sifra })
                                                                   .OfType<Radnik>().ToList().SingleOrDefault();
                if (r != null)
                    return r;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.ZatvoriKonekciju(); }
        }

        public List<Automobil> VratiSveAutomobile()
        {
            try
            {
                //broker.OtvoriKonekciju();
                VratiAutomobileSO so = new VratiAutomobileSO();
                return so.Izvrsi(new Automobil()) as List<Automobil>;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message); 
                throw;
            }
            //finally { broker.ZatvoriKonekciju(); }
        }

        public List<Automobil> PretraziAutomobile(IDomenskiObjekat objekat)
        {
            PretraziAutomobileSO so = new PretraziAutomobileSO();
            try
            {
                return so.Izvrsi(objekat) as List<Automobil>;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SacuvajAutomobil(IDomenskiObjekat objekat)
        {
            SacuvajAutomobilSO so = new SacuvajAutomobilSO();
            try
            {
                return (bool)so.Izvrsi(objekat);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Kompanija> VratiSveKompanije()
        {
            try
            {
                broker.OtvoriKonekciju();
                return broker.VratiSve(new Kompanija()).OfType<Kompanija>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.ZatvoriKonekciju(); }
        }

        public List<TipAutomobila> VratiSveTipove()
        {
            try
            {
                broker.OtvoriKonekciju();
                return broker.VratiSve(new TipAutomobila()).OfType<TipAutomobila>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally { broker.ZatvoriKonekciju(); }
        }

        public bool DeaktivirajAutomobil(IDomenskiObjekat objekat)
        {
            DeaktivirajAutomobilSO so = new DeaktivirajAutomobilSO();
            try
            {
                return (bool)so.Izvrsi(objekat);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public List<Korisnik> VratiKorisnike()
        {

            VratiKorisnikeSO so = new VratiKorisnikeSO();
            try
            {
                //broker.OtvoriKonekciju();       // pokusavam da resim problem sa Izdavanjem
                return so.Izvrsi(new Korisnik()) as List<Korisnik>;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            //finally { broker.ZatvoriKonekciju(); }
        }

        public List<Korisnik> PretraziKorisnike(IDomenskiObjekat objekat)
        {
            PretraziKorisnikeSO so = new PretraziKorisnikeSO();
            try
            {
                return so.Izvrsi(objekat) as List<Korisnik>;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object SacuvajKorisnika(IDomenskiObjekat objekat)
        {
            SacuvajKorisnikaSO so = new SacuvajKorisnikaSO();
            try
            {
                return so.Izvrsi(objekat);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IzmeniKorisnika(Korisnik korisnik)
        {
            IzmeniKorisnikaSO so = new IzmeniKorisnikaSO();
            try
            {
                return (bool)so.Izvrsi(korisnik);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public bool IzmeniPrimerakAutomobila(Izdavanje izdavanje)
        {
            PrimerakAutomobila primerak = izdavanje.PrimerakAutomobila;
            primerak.Zauzet = true;
            try
            {
                broker.OtvoriKonekciju();
                return (bool)broker.Izmeni(primerak);
            }
            catch (Exception)
            {

                throw;
            }
            finally { broker.ZatvoriKonekciju(); }
        }

        public bool DeaktivirajIzdavanje(IDomenskiObjekat objekat)
        {
            DeaktivirajIzdavanjeSO so = new DeaktivirajIzdavanjeSO();
            try
            {
                return (bool)so.Izvrsi(objekat);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SacuvajIzdavanje(Izdavanje izdavanje)
        {
            SacuvajIzdavanjeSO so = new SacuvajIzdavanjeSO();
            try
            {
                return (bool)so.Izvrsi(izdavanje);          // KAKO BRE OVO NE RADI ?!
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PrimerakAutomobila> VratiPrimerke(Automobil automobil)
        {
            try
            {
                broker.OtvoriKonekciju();
                return broker.VratiSvePoKriterijumu(new PrimerakAutomobila(), automobil).OfType<PrimerakAutomobila>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally { broker.ZatvoriKonekciju(); }
        }

        public List<Izdavanje> VratiIzdavanja()
        {
            try
            {
                broker.OtvoriKonekciju();
                return broker.VratiSve(new Izdavanje()).OfType<Izdavanje>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally { broker.ZatvoriKonekciju(); }

        }
    }
}
