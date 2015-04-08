using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    class Appartement : IVerblijfstype
    {
        private decimal schoonmaakPrijsValue;
        private bool liftValue;
        private List<Formule> beschikbareVerblijfsFormulesValue;
        private PrijsInfo prijsInfoValue;
        private string naamVerblijfValue;

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
        public bool Lift
        {
            get
            {
                return liftValue;
            }
            set
            {
                liftValue = value;
            }
        }

        public Appartement() // initialisatie van beschikbareVerblijfsFormulesValue
        {
            beschikbareVerblijfsFormulesValue = new List<Formule>();
            beschikbareVerblijfsFormulesValue.Add(Formule.Ontbijt);
            beschikbareVerblijfsFormulesValue.Add(Formule.Ontbijt);
        }

        public Appartement(string naamVerblijf, decimal schoonmaakPrijs, bool lift) : this()
        {
            NaamVerblijf = naamVerblijf;
            SchoonmaakPrijs = schoonmaakPrijs;
            Lift = lift;
        }

        public List<Formule> BeschikbareVerblijfsFormules
        {
            get 
            {
                return beschikbareVerblijfsFormulesValue;
            }
        }

        public bool ToeslagSingle
        {
            get { return false; }
        }

        public PrijsInfo PrijsInfo
        {
            get { return prijsInfoValue; }
            set { prijsInfoValue = value; }
        }

        public string NaamVerblijf
        {
            get { return naamVerblijfValue; }
            set { naamVerblijfValue = value; }
        }

        public decimal BerekenVerblijfsPrijs(int aantalDagen, Formule gekozenFormule)
        {
            decimal totPrijs = 0;
            if (this.PrijsInfo.PrijsPeriode == PrijsPeriode.Dag)
                totPrijs += aantalDagen * PrijsInfo.BasisPrijs;
            else totPrijs += aantalDagen / 7 * PrijsInfo.BasisPrijs;
            totPrijs += totPrijs / 100 * (int)gekozenFormule + SchoonmaakPrijs;

            return totPrijs;
        }
    }
}
