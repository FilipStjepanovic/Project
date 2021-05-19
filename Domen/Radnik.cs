using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Radnik : IDomenskiObjekat
    {
        public int RadnikID { get; set; }
        public String ImePrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public String KorisnickoIme { get; set; }
        public String Sifra { get; set; }

        public string Table => $"Radnik";

        public string FullTable => $"Radnik r";

        public string InsertValues => throw new NotImplementedException();

        public string UpdateValues => throw new NotImplementedException();

        public string Join => throw new NotImplementedException();

        public string SearchId => throw new NotImplementedException();

        public object ColumnId => throw new NotImplementedException();

        public object Get => $"SELECT * FROM";

        public string GroupBy => throw new NotImplementedException();

        public string Kriterijum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                lista.Add(new Radnik()
                {
                    RadnikID = (int)reader["RadnikID"],
                    ImePrezime = (string)reader["ImePrezime"],
                    KorisnickoIme = (string)reader["KorisnickoIme"],
                    Sifra= (string)reader["Sifra"],
                }); 
            }
            reader.Close();
            return lista;
        }

        public string SearchWhere(string user, string pass)
        {
            return $"WHERE KorisnickoIme = '{user}' AND Sifra = '{pass}'";
        }
    }
}
