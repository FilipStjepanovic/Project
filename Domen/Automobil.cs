using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Automobil : IDomenskiObjekat
    {
        [Browsable(false)]
        public int AutomobilID { get; set; }
        public String Naziv { get; set; }
        public Kompanija Kompanija { get; set; }
        public TipAutomobila TipAutomobila { get; set; }
        public bool Aktivan { get; set; }
        public int BrojPrimeraka { get; set; }
        public override string ToString()
        {
            return Naziv;
        }
        [Browsable(false)]
        public string Table => "Automobil";
        [Browsable(false)]
        public string FullTable => "Automobil a";
        [Browsable(false)]
        public string InsertValues => $"'{Naziv}', '{Aktivan}', {Kompanija.KompanijaID}, {TipAutomobila.TipAutomobilaID}";
        [Browsable(false)]
        public string UpdateValues => $"Naziv = '{Naziv}', Aktivan='{Aktivan}', KompanijaID={Kompanija.KompanijaID}, TipAutomobilaID={TipAutomobila.TipAutomobilaID}";
        [Browsable(false)]
        public string Join => $"JOIN Kompanija k on(k.KompanijaID = a.KompanijaID) JOIN TipAutomobila ta on(ta.TipAutomobilaID = a.TipAutomobilaID)" +
                                                    $" LEFT JOIN PrimerakAutomobila pa on(pa.AutomobilID = a.AutomobilID)";
        [Browsable(false)]
        public string SearchId => $"where AutomobilID = {AutomobilID}";
        [Browsable(false)]
        public object ColumnId => throw new NotImplementedException();
        [Browsable(false)]
        public object Get => "SELECT a.AutomobilID, a.Naziv, a.Aktivan, k.KompanijaID, k.Naziv," +
                                                     "ta.TipAutomobilaID, ta.Naziv, count(pa.AutomobilID) FROM";
        [Browsable(false)]
        public string GroupBy => "GROUP BY a.AutomobilID, a.Naziv, a.Aktivan, ta.Naziv, k.Naziv, ta.TipAutomobilaID, k.KompanijaID";
        [Browsable(false)]
        public string Kriterijum { get; set; }
        [Browsable(false)]
        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                lista.Add(new Automobil()
                {
                    AutomobilID = reader.GetInt32(0),
                    Naziv = reader.GetString(1),
                    Aktivan = reader.GetBoolean(2),
                    Kompanija = new Kompanija()
                    {
                        KompanijaID = reader.GetInt32(3),
                        Naziv = reader.GetString(4),

                    },
                    TipAutomobila = new TipAutomobila()
                    {
                        TipAutomobilaID = reader.GetInt32(5),
                        Naziv = reader.GetString(6)
                    },
                    BrojPrimeraka = reader.GetInt32(7)
                });
            }
            reader.Close();
            return lista;
        }
        [Browsable(false)]
        public string SearchWhere(string criteria, string criterial2 = null)
        {
            return $"WHERE a.Naziv like '%{criteria}%' or k.Naziv like '%{criteria}%' or ta.Naziv like '%{criteria}%'";
        }
    }
}
