using System.Collections.Generic;

namespace TravelNet.Verblijven
{
    internal class Appartement : IVerblijfstype
    {
        public Appartement() // initialisatie van beschikbareVerblijfsFormulesValue
        {
            BeschikbareVerblijfsFormules = new List<Formule>();
            BeschikbareVerblijfsFormules.Add(Formule.Ontbijt);
            BeschikbareVerblijfsFormules.Add(Formule.Ontbijt);
        }

        public Appartement(string naamVerblijf, decimal schoonmaakPrijs, bool lift) : this()
        {
            NaamVerblijf = naamVerblijf;
            SchoonmaakPrijs = schoonmaakPrijs;
            Lift = lift;
        }

        public decimal SchoonmaakPrijs { get; set; }
        public bool Lift { get; set; }
        public List<Formule> BeschikbareVerblijfsFormules { get; private set; }

        public bool ToeslagSingle
        {
            get { return false; }
        }

        public PrijsInfo PrijsInfo { get; set; }
        public string NaamVerblijf { get; set; }

        public decimal BerekenVerblijfsPrijs(int aantalDagen, Formule gekozenFormule)
        {
            decimal totPrijs = 0;
            if (PrijsInfo.PrijsPeriode == PrijsPeriode.Dag)
                totPrijs += aantalDagen*PrijsInfo.BasisPrijs;
            else totPrijs += aantalDagen/7*PrijsInfo.BasisPrijs;
            totPrijs += totPrijs/100*(int) gekozenFormule + SchoonmaakPrijs;

            return totPrijs;
        }
    }
}