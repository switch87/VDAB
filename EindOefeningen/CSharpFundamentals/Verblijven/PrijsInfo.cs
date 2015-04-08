using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    public enum PrijsPeriode
    {
        Dag,
        Week
    }
    class PrijsInfo
    {
        private decimal basisPrijsValue;
        private PrijsPeriode prijsPeriodeValue;

        public decimal BasisPrijs
        {
            get
            {
                return basisPrijsValue;
            }
            set
            {
                basisPrijsValue = value;
            }
        }
        public PrijsPeriode PrijsPeriode
        {
            get
            {
                return prijsPeriodeValue;
            }
            set
            {
                prijsPeriodeValue = value;
            }
        }

        public PrijsInfo(decimal basisPrijs, PrijsPeriode prijsPeriode)
        {
            BasisPrijs = basisPrijs;
            PrijsPeriode = prijsPeriode;
        }
    }
}
