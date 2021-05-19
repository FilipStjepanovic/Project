using Broker;
using Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public abstract class OpstaSistemskaOperacija
    {
        protected Broker.Broker broker = Broker.Broker.Instance;
        protected abstract object IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat);
        protected abstract void Validacija(IDomenskiObjekat objekat);

        public object Izvrsi(IDomenskiObjekat objekat)
        {
            try
            {
                Validacija(objekat);
                broker.OtvoriKonekciju();
                broker.PokreniTransakciju();
                object rezultat = IzvrsiKonkretnuOperaciju(objekat);
                broker.Commit();
                return rezultat;
            }
            catch (Exception e)
            {
                broker.Rollback();
                Debug.WriteLine(e.Message);
                return null;
                throw;  
            }
            finally { broker.ZatvoriKonekciju(); }
        }
    }
}
