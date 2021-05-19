using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Korisnik : IDomenskiObjekat
    {
        public int KorisnikID { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public String ImePrezime { get; set; }
        public String Pol { get; set; }
        public bool Aktivan { get; set; }

        [Browsable(false)]
        public string Table => "Korisnik";
        [Browsable(false)]
        public string FullTable => "Korisnik k";
        [Browsable(false)]
        public string InsertValues => $"'{ImePrezime}','{DatumRodjenja}','{Pol}','{Aktivan}'";
        [Browsable(false)]
        public string UpdateValues => $"ImePrezime= '{ImePrezime}', DatumRodjenja='{DatumRodjenja}', Pol='{Pol}', Aktivan='{Aktivan}'";
        [Browsable(false)]
        public string Join => "";
        [Browsable(false)]
        public string SearchId => $"WHERE KorisnikID = {KorisnikID}";
        [Browsable(false)]
        public object ColumnId => throw new NotImplementedException();
        [Browsable(false)]
        public object Get => "SELECT * FROM";
        [Browsable(false)]
        public string GroupBy => "";
        [Browsable(false)]
        public string Kriterijum { get; set; }
        [Browsable(false)]
        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {

                lista.Add(new Korisnik()
                {
                    KorisnikID = (int)reader["KorisnikID"],
                    DatumRodjenja = (DateTime)reader["DatumRodjenja"],
                    ImePrezime = (string)reader["ImePrezime"],
                    Pol = (string)reader["Pol"],
                    Aktivan = (bool)reader["Aktivan"]
                });
            }
            reader.Close();
            return lista;
        }
        [Browsable(false)]
        public string SearchWhere(string kriterijum, string criterial2 = null)
        {
            return $"WHERE ImePrezime like '%{kriterijum}%' or Pol like '%{kriterijum}%'";
        }

        public override string ToString()
        {
            return $"{ImePrezime}";
        }
    }

    public enum Pol
    {
        Muski, 
        Zenski
    }
}
