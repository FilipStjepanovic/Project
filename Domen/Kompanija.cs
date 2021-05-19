using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Kompanija : IDomenskiObjekat
    {

        public int KompanijaID { get; set; }
        public String Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

        public string Table => "Kompanija";

        public string FullTable => "Kompanija k";

        public string InsertValues => throw new System.NotImplementedException();

        public string UpdateValues => throw new System.NotImplementedException();

        public string Join => "";

        public string SearchId => throw new System.NotImplementedException();

        public object ColumnId => throw new System.NotImplementedException();

        public object Get => "SELECT * FROM";

        public string GroupBy => "";

        public string Kriterijum { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                lista.Add(new Kompanija()
                {
                    KompanijaID = (int)reader["KompanijaID"],
                    Naziv = (string)reader["Naziv"]
                });
            }
            return lista;
        }

        public string SearchWhere(string criteria1, string criterial2 = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
