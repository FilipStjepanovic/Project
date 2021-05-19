using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public class KontrolerKorisnickogInterfejsa
    {
        Komunikacija k;

        public static KontrolerKorisnickogInterfejsa _instance;
        private KontrolerKorisnickogInterfejsa()
        {
            k = Komunikacija.Instance;
        }
        public static KontrolerKorisnickogInterfejsa Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KontrolerKorisnickogInterfejsa();
                }
                return _instance;
            }
        }

        internal List<Izdavanje> VratiSvaIzdavanja()
        {
            return k.VratiSvaIzdavanja();
        }

        internal List<Korisnik> VratiSveKorisnike()
        {
            return k.VratiSveKorisnike();
        }

        internal List<PrimerakAutomobila> VratiSvePrimerke(Automobil automobil)
        {
            return k.VratiSvePrimerke(automobil);
        }

        internal List<TipAutomobila> VratiSveTipove()
        {
            return k.VratiSveTipove();
        }

        internal bool SacuvajIzdavanje(Izdavanje izdavanje)
        {
            return k.SacuvajIzdavanje(izdavanje);
        }

        internal List<Kompanija> vratiSveKompanije()
        {
            return k.vratiSveKompanije();
        }

        internal bool SacuvajKorisnika(Korisnik korisnik)
        {
            return k.SacuvajKorisnika(korisnik);
        }

        internal bool DeaktivirajIzdavanje(Izdavanje izdavanje)
        {
            izdavanje.Aktivno = false;
            return k.DeaktivirajIzdavanje(izdavanje);
        }

        internal List<Korisnik> PretraziKorisnika(string pretraga)
        {
            return k.PretraziKorisnika(pretraga);
        }

        internal List<Automobil> VratiSveAutomobile()
        {
            return k.vratiSveAutomobile();
        }

        internal Radnik Login(string user, string pass)
        {
            return k.Login(user, pass);
        }

        internal bool PoveziSe()
        {
            return k.PoveziSe();
        }

        internal List<Automobil> PretraziAutomobil(string pretraga)
        {
            return k.PretraziAutomobil(pretraga);
        }

        internal bool SacuvajAutomobil(Automobil a)
        {
            return k.SacuvajAutomobil(a);
        }

        internal bool IzmeniKorisnika(Korisnik korisnik)
        {
            return k.IzmeniKorisnika(korisnik);
        }

        public void Kraj()
        {
            k.Kraj();
        }

        internal bool DeaktivirajAutomobil(Automobil auto)
        {
            auto.Aktivan = false;
            return k.DeaktivirajAutomobil(auto);
        }
    }
}
