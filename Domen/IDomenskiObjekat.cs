using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IDomenskiObjekat
    {
        string Table { get; }
        string FullTable { get; }
        string InsertValues { get; }
        string UpdateValues { get; }
        string Join { get; }
        string SearchWhere(string criteria1, string criterial2 = null);
        // resi posle!
        string SearchId { get; }
        object ColumnId { get; }
        object Get { get; }
        string GroupBy { get; }
        string Kriterijum { get; set; }
        List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader);
    }
}
