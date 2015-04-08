using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    class Cruise : Vakantie
    {
        // 1 route
        // prijs = all-in

        private Route routeValue;
        private List<string> aanlegPlaatsenValue;
        private decimal allInPrijsValue;

        public Route Route { get { return routeValue; } set { routeValue = value; } }
        public List<string> AanlegPlaatsen { get { return aanlegPlaatsenValue; } set { aanlegPlaatsenValue = value; } }
        public decimal AllInPrijs { get { return allInPrijsValue; } set { allInPrijsValue = value; } }

        public Cruise(int boekingNr,Bestemming bestemming, DateTime vertrekDatum, DateTime terugkeerDatum, int aantalPersonen, bool internetGewenst,
            Route route, List<string> aanlegPlaatsten, decimal allInPrijs)
            :base(boekingNr,bestemming, vertrekDatum, terugkeerDatum, aantalPersonen, internetGewenst)
        {
            Route = route;
            AanlegPlaatsen = aanlegPlaatsten;
            AllInPrijs = allInPrijs;
        }

        public override decimal BerekenVakantiePrijs()
        {
            return AllInPrijs;
        }
    }
}
