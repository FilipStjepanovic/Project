using System;

namespace Domen
{
    [Serializable]
    public class TransfernaKlasa
    {
        public Operacija Operacija { get; set; }
        public Object TransferniObjekat { get; set; }
        public Object Result { get; set; }
    }

    public enum Operacija
    {
        Kraj,
        Login,
        VratiAutomobile,
        VratiKompanije,
        VratiTipove,
        SacuvajAutomobil,
        PretraziAutomobile,
        DeaktivirajAutomobil,
        VratiKorisnike,
        SacuvajKorisnika,
        IzmeniKorisnika,
        PretraziKorisnike,
        VratiPrimerke,
        SacuvajIzdavanje,
        VratiIzdavanja,
        DeaktivirajIzdavanje
    }
}
