using Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker
{
    public class Broker
    {
        private static Broker _instance;
        private SqlConnection connection;
        private SqlTransaction transaction;

        public List<IDomenskiObjekat> VratiSve(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"{objekat.Get} {objekat.FullTable} {objekat.Join} {objekat.GroupBy}";
            SqlDataReader reader = command.ExecuteReader();
            return objekat.GetReaderResult(reader);
        }

        public bool Izmeni(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"UPDATE {objekat.Table} SET {objekat.UpdateValues} {objekat.SearchId}";
            return command.ExecuteNonQuery() == 1;
        }

        public bool Sacuvaj(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"INSERT INTO {objekat.Table} OUTPUT INSERTED.{objekat.Table}ID VALUES( {objekat.InsertValues})"; //ID ?
            return command.ExecuteNonQuery() == 1;
        }

        public List<IDomenskiObjekat> Pretrazi(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"{objekat.Get} {objekat.FullTable} {objekat.Join} {objekat.SearchWhere(objekat.Kriterijum)} {objekat.GroupBy}";
            SqlDataReader reader = command.ExecuteReader();
            return objekat.GetReaderResult(reader);
        }

        public static Broker Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Broker();
                }
                return _instance;
            }
        }

        private Broker()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RentacarDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public List<IDomenskiObjekat> Login(IDomenskiObjekat objekat)
        {
            Radnik radnik = (Radnik)objekat;
            SqlCommand command = new SqlCommand("", connection);
            command.CommandText = $"{objekat.Get} {objekat.Table} " +
                                    $"{objekat.SearchWhere(radnik.KorisnickoIme, radnik.Sifra)} ";
            SqlDataReader reader = command.ExecuteReader();
            return objekat.GetReaderResult(reader);
        }

        public void OtvoriKonekciju()
        {
            connection.Open();
        }

        public void ZatvoriKonekciju()
        {
            connection.Close();
        }

        public void PokreniTransakciju()
        {
            transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public List<IDomenskiObjekat> VratiSvePoKriterijumu(IDomenskiObjekat objekat, Automobil automobil)
        {
            SqlCommand command = new SqlCommand("", connection);
            command.CommandText = $"{objekat.Get} {objekat.FullTable} {objekat.SearchWhere(automobil.AutomobilID.ToString())}";
            SqlDataReader reader = command.ExecuteReader();
            return objekat.GetReaderResult(reader);
        }
    }
}
