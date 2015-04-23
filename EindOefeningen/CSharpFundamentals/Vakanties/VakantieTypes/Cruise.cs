using System;
using System.Collections.Generic;

namespace TravelNet.Vakanties
{
    internal class Cruise : Vakantie
    {
        public Cruise(int boekingNr, Bestemming bestemming, DateTime vertrekDatum, DateTime terugkeerDatum,
            int aantalPersonen, bool internetGewenst,
            Route route, List<string> aanlegPlaatsten, decimal allInPrijs)
            : base(boekingNr, bestemming, vertrekDatum, terugkeerDatum, aantalPersonen, internetGewenst)
        {
            Route = route;
            AanlegPlaatsen = aanlegPlaatsten;
            AllInPrijs = allInPrijs;
        }

        // 1 route
        // prijs = all-in

        public Route Route { get; set; }
        public List<string> AanlegPlaatsen { get; set; }
        public decimal AllInPrijs { get; set; }

        public override decimal BerekenVakantiePrijs()
        {
            return AllInPrijs;
        }
    }
}