using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    class Hotel : IVerblijfstype
    {
        private bool internetValue, strijkdienstValue, fitnessValue;
        private decimal ? welnessPrijsValue; // null = niet aanwezig, 0 = inbegrepen in prijs
        private List<Formule> beschikbareVerblijfsFormulesValue;
        private string naamVerblijfValue;
        private PrijsInfo prijsInfoValue;

        public bool Internet
        {
            get
            {
                return internetValue;
            }
            set
            {
                internetValue = value;
            }
        }
        public bool Strijkdienst
        {
            get
            {
                return strijkdienstValue;
            }
            set
            {
                strijkdienstValue = value;
            }
        }
        public bool Fitness
        {
            get
            {
                return fitnessValue;
            }
            set
            {
                fitnessValue = value;
            }
        }
        public decimal? WellnessPrijs
        {
            get
            {
                return welnessPrijsValue;
            }
            set
            {
                welnessPrijsValue = value;
            }
        }

        public Hotel()
        {
            beschikbareVerblijfsFormulesValue = new List<Formule>();
            beschikbareVerblijfsFormulesValue.Add(Formule.Ontbijt);
            beschikbareVerblijfsFormulesValue.Add(Formule.HalfPension);
            beschikbareVerblijfsFormulesValue.Add(Formule.VolPension);
        }
        public Hotel(string naamVerblijf, bool internet,bool strijkdienst,bool fitness, decimal ? wellnessPrijs):this()
        {
            NaamVerblijf = naamVerblijf;
            Internet = internet;
            Strijkdienst = strijkdienst;
            Fitness = fitness;
            WellnessPrijs = wellnessPrijs;
        }

        public List<Formule> BeschikbareVerblijfsFormules
        {
            get { return beschikbareVerblijfsFormulesValue; }
        }

        public bool ToeslagSingle
        {
            get { return true; }
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
                naamVerblijfValue=value;
            }
        }

        public decimal BerekenVerblijfsPrijs(int aantalDagen, Formule gekozenFormule)
        {
            decimal totPrijs = 0;
            if (this.PrijsInfo.PrijsPeriode == PrijsPeriode.Dag)
                totPrijs += aantalDagen * PrijsInfo.BasisPrijs;
            else totPrijs += aantalDagen / 7 * PrijsInfo.BasisPrijs;
            totPrijs += totPrijs / 100 * (int)gekozenFormule;
            if (this.WellnessPrijs != null)
            {
                totPrijs += (decimal)WellnessPrijs;
            }

            return totPrijs;
        }
    }
}
