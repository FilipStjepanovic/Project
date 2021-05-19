using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Izdavanje : IDomenskiObjekat
    {
        public int IzdavanjeID { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        [Browsable(false)]
        public PrimerakAutomobila PrimerakAutomobila { get; set; }
        public Korisnik Korisnik { get; set; }
        public bool Aktivno { get; set; }
        // dodati za datagrid NazivAutomobila iz primerka a njega browsable false!
        public String NazivAutomobila { get { return PrimerakAutomobila.Automobil.Naziv; } }



        [Browsable(false)]
        public string Table => "Izdavanje";
        [Browsable(false)]
        public string FullTable => "Izdavanje i";
        [Browsable(false)]
        public string InsertValues => $"'{DatumIzdavanja}', '{Aktivno}', {Korisnik.KorisnikID}, {PrimerakAutomobila.PrimerakAutomobilaID}";
        [Browsable(false)]
        public string UpdateValues => $"DatumIzdavanja = '{DatumIzdavanja}', Aktivno='{Aktivno}', KorisnikID={Korisnik.KorisnikID}, PrimerakAutomobilaID={PrimerakAutomobila.PrimerakAutomobilaID}";
        [Browsable(false)]
        public string Join => $"LEFT JOIN PrimerakAutomobila pa on(i.PrimerakAutomobilaID = pa.PrimerakAutomobilaID) LEFT JOIN Automobil a on(a.AutomobilID = pa.AutomobilID) LEFT JOIN Korisnik k on(k.KorisnikID = i.KorisnikID)";

        [Browsable(false)]
        public string SearchId => $" where IzdavanjeID = {IzdavanjeID}";
        [Browsable(false)]
        public object ColumnId => throw new NotImplementedException();
        [Browsable(false)]
        public object Get => "SELECT i.IzdavanjeID as IzdavanjeID, a.Naziv as NazivAutomobila, a.AutomobilID as AutomobilID, pa.PrimerakAutomobilaID as PrimerakAutomobilaID, i.DatumIzdavanja as DatumIzdavanja, k.KorisnikID as KorisnikID, k.ImePrezime as ImePrezimeKorisnika, i.Aktivno as AktivnoIzdavanje FROM";
        [Browsable(false)]
        public string GroupBy => "";
        [Browsable(false)]
        public string Kriterijum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Browsable(false)]
        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                lista.Add(new Izdavanje()
                {
                    IzdavanjeID = (int)reader["IzdavanjeID"],
                    PrimerakAutomobila = new PrimerakAutomobila()
                    {
                        PrimerakAutomobilaID = (int)reader["PrimerakAutomobilaID"],
                        Automobil = new Automobil()
                        {
                            AutomobilID = (int)reader["AutomobilID"],
                            Naziv = (string)reader["NazivAutomobila"]
                        }
                    },
                    DatumIzdavanja = (DateTime)reader["DatumIzdavanja"],
                    Aktivno = (bool)reader["AktivnoIzdavanje"],
                    Korisnik = new Korisnik()
                    {
                        KorisnikID = (int)reader["KorisnikID"],
                        ImePrezime = (string)reader["ImePrezimeKorisnika"]
                    }
                });
            }
            reader.Close();
            return lista;
        }
        [Browsable(false)]
        public string SearchWhere(string criteria1, string criterial2 = null)
        {
            throw new NotImplementedException();
        }
        
    }
}
