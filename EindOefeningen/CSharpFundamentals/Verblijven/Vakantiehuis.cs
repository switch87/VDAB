using System;
using System.Collections.Generic;

namespace TravelNet.Verblijven
{
    internal class Vakantiehuis : IVerblijfstype
    {
        private readonly List<Formule> beschikbareVerblijfsFormulesValue;

        public Vakantiehuis()
        {
            beschikbareVerblijfsFormulesValue = new List<Formule>();
            beschikbareVerblijfsFormulesValue.Add(Formule.Ontbijt);
        }

        public Vakantiehuis(string naamVerblijf, decimal schoonmaakPrijs, decimal linnengoedPrijs) : this()
        {
            NaamVerblijf = naamVerblijf;
            SchoonmaakPrijs = schoonmaakPrijs;
            LinnengoedPrijs = linnengoedPrijs;
        }

        public decimal SchoonmaakPrijs { get; set; }
        public decimal LinnengoedPrijs { get; set; }

        public List<Formule> BeschikbareVerblijfsFormules
        {
            get { throw new NotImplementedException(); }
        }

        public bool ToeslagSingle
        {
            get { throw new NotImplementedException(); }
        }

        public PrijsInfo PrijsInfo { get; set; }
        public string NaamVerblijf { get; set; }

        public decimal BerekenVerblijfsPrijs(int aantalDagen, Formule gekozenFormule)
        {
            decimal totPrijs = 0;
            if (PrijsInfo.PrijsPeriode == PrijsPeriode.Dag)
                totPrijs += aantalDagen*PrijsInfo.BasisPrijs;
            else totPrijs += aantalDagen/7*PrijsInfo.BasisPrijs;
            totPrijs += totPrijs/100*(int) gekozenFormule + SchoonmaakPrijs + LinnengoedPrijs;

            return totPrijs;
        }
    }
}