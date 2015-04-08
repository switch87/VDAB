using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    class Vakantiehuis : IVerblijfstype
    {
        private decimal schoonmaakPrijsValue, linnengoedPrijsValue;
        private List<Formule> beschikbareVerblijfsFormulesValue;
        private string naamVerblijfValue;
        private PrijsInfo prijsInfoValue;

        public decimal SchoonmaakPrijs
        {
            get
            {
                return schoonmaakPrijsValue;
            }
            set
            {
                schoonmaakPrijsValue = value;
            }
        }
        public decimal LinnengoedPrijs
        {
            get
            {
                return linnengoedPrijsValue;
            }
            set
            {
                linnengoedPrijsValue = value;
            }
        }


        public Vakantiehuis()
        {
            beschikbareVerblijfsFormulesValue = new List<Formule>();
            beschikbareVerblijfsFormulesValue.Add(Formule.Ontbijt);
        }
        public Vakantiehuis(string naamVerblijf, decimal schoonmaakPrijs, decimal linnengoedPrijs):this()
        {
            NaamVerblijf = naamVerblijf;
            SchoonmaakPrijs = schoonmaakPrijs;
            LinnengoedPrijs = linnengoedPrijs;
        }

        public List<Formule> BeschikbareVerblijfsFormules
        {
            get { throw new NotImplementedException(); }
        }

        public bool ToeslagSingle
        {
            get { throw new NotImplementedException(); }
        }

        public PrijsInfo PrijsInfo
        {
            get
            {
                return prijsInfoValue;
            }
            set
            {
                prijsInfoValue = value;
            }
        }

        public string NaamVerblijf
        {
            get
            {
                return naamVerblijfValue;
            }
            set
            {
                naamVerblijfValue = value;
            }
        }

        public decimal BerekenVerblijfsPrijs(int aantalDagen, Formule gekozenFormule)
        {
            decimal totPrijs = 0;
            if (this.PrijsInfo.PrijsPeriode == PrijsPeriode.Dag)
                totPrijs += aantalDagen * PrijsInfo.BasisPrijs;
            else totPrijs += aantalDagen / 7 * PrijsInfo.BasisPrijs;
            totPrijs += totPrijs / 100 * (int)gekozenFormule + SchoonmaakPrijs +LinnengoedPrijs;

            return totPrijs;
        }
    }
}
