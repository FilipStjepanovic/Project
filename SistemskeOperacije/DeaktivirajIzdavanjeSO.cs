﻿using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class DeaktivirajIzdavanjeSO : OpstaSistemskaOperacija
    {
        protected override object IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            return broker.Izmeni(objekat);
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Izdavanje))
            {
                throw new ArgumentException();
            }
        }
    }
}
