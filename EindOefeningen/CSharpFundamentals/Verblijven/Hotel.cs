using System.Collections.Generic;

namespace TravelNet.Verblijven
{
    internal class Hotel : IVerblijfstype
    {
        public Hotel()
        {
            BeschikbareVerblijfsFormules = new List<Formule>();
            BeschikbareVerblijfsFormules.Add(Formule.Ontbijt);
            BeschikbareVerblijfsFormules.Add(Formule.HalfPension);
            BeschikbareVerblijfsFormules.Add(Formule.VolPension);
        }

        public Hotel(string naamVerblijf, bool internet, bool strijkdienst, bool fitness, decimal? wellnessPrijs)
            : this()
        {
            NaamVerblijf = naamVerblijf;
            Internet = internet;
            Strijkdienst = strijkdienst;
            Fitness = fitness;
            WellnessPrijs = wellnessPrijs;
        }

        public bool Internet { get; set; }
        public bool Strijkdienst { get; set; }
        public bool Fitness { get; set; }
        public decimal? WellnessPrijs { get; set; }
        public List<Formule> BeschikbareVerblijfsFormules { get; private set; }

        public bool ToeslagSingle
        {
            get { return true; }
        }

        public PrijsInfo PrijsInfo { get; set; }
        public string NaamVerblijf { get; set; }

        public decimal BerekenVerblijfsPrijs(int aantalDagen, Formule gekozenFormule)
        {
            decimal totPrijs = 0;
            if (PrijsInfo.PrijsPeriode == PrijsPeriode.Dag)
                totPrijs += aantalDagen*PrijsInfo.BasisPrijs;
            else totPrijs += aantalDagen/7*PrijsInfo.BasisPrijs;
            totPrijs += totPrijs/100*(int) gekozenFormule;
            if (WellnessPrijs != null)
            {
                totPrijs += (decimal) WellnessPrijs;
            }

            return totPrijs;
        }
    }
}