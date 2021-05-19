using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class TipAutomobila : IDomenskiObjekat
    {

        public int TipAutomobilaID { get; set; }
        public String Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

        public string Table => "TipAutomobila";

        public string FullTable => "TipAutomobila ta";

        public string InsertValues => throw new NotImplementedException();

        public string UpdateValues => throw new NotImplementedException();

        public string Join => "";

        public string SearchId => throw new NotImplementedException();

        public object ColumnId => throw new NotImplementedException();

        public object Get => "SELECT * FROM";

        public string GroupBy => "";

        public string Kriterijum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                lista.Add(new TipAutomobila()
                {
                    TipAutomobilaID = (int)reader["TipAutomobilaID"],
                    Naziv = (string)reader["Naziv"]
                });
            }
            return lista;
        }

        public string SearchWhere(string criteria1, string criterial2 = null)
        {
            throw new NotImplementedException();
        }
    }
}
