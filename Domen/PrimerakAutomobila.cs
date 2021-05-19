using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class PrimerakAutomobila : IDomenskiObjekat
    {
        public int PrimerakAutomobilaID { get; set; }
        public Automobil Automobil { get; set; }
        public DateTime DatumProizvodnje { get; set; }
        public bool Zauzet { get; set; }

        public override string ToString()
        {
            return DatumProizvodnje.ToString("dd/MM/yyyy");
        }
        [Browsable(false)]
        public string Table => "PrimerakAutomobila";
        [Browsable(false)]
        public string FullTable => "PrimerakAutomobila pa";
        [Browsable(false)]
        public string InsertValues => throw new NotImplementedException();
        [Browsable(false)]
        public string UpdateValues => $"AutomobilID = {Automobil.AutomobilID}, DatumProizvodnje='{DatumProizvodnje}', Zauzet='{Zauzet}'";
        [Browsable(false)]
        public string Join => "";
        [Browsable(false)]
        public string SearchId => $"WHERE PrimerakAutomobilaID = {PrimerakAutomobilaID}";
        [Browsable(false)]
        public object ColumnId => throw new NotImplementedException();
        [Browsable(false)]
        public object Get => "SELECT * FROM";
        [Browsable(false)]
        public string GroupBy => throw new NotImplementedException();
        [Browsable(false)]
        public string Kriterijum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Browsable(false)]
        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                lista.Add(new PrimerakAutomobila()
                {
                    PrimerakAutomobilaID = (int)reader["PrimerakAutomobilaID"],
                    Automobil = new Automobil()
                    {
                        AutomobilID = (int)reader["AutomobilID"]
                    },
                    DatumProizvodnje = (DateTime)reader["DatumProizvodnje"],
                    Zauzet = (bool)reader["Zauzet"]
                });
            }
            reader.Close();
            return lista;
        }
        [Browsable(false)]
        public string SearchWhere(string criteria, string criterial2 = null)
        {
            return $"WHERE AutomobilID={criteria} AND Zauzet='False'";
        }

    }
}
