using System;
using System.Collections.Generic;

namespace TravelNet.Vakanties
{
    public enum WagenType
    {
        EigenWagen,
        HuurAuto,
        Camper
    }

    internal class Autovakantie : Vakantie
    {
        // 1 dag per route
        // totPrijs = som(verblijfPrijzen)+huurptijsWagen


        private static readonly decimal VasteHuurPrijs = 20.00m;
        private decimal huurPrijsValue;

        public Autovakantie(int boekingNr, Bestemming bestemming, DateTime vertrekDatum, DateTime terugkeerDatum,
            int aantalPersonen, bool internetGewenst,
            List<Route> routes, WagenType wagenType)
            : base(boekingNr, bestemming, vertrekDatum, terugkeerDatum, aantalPersonen, internetGewenst)
        {
            Routes = routes;
            WagenType = wagenType;
        }

        public List<Route> Routes { get; set; }
        public WagenType WagenType { get; set; }

        public decimal Huurprijs
        {
            get
            {
                if (WagenType == WagenType.EigenWagen)
                    return 0m;
                return VasteHuurPrijs;
            }
        }

        public override decimal BerekenVakantiePrijs()
        {
            var VakantiePrijs = Huurprijs;
            foreach (var route in Routes)
            {
                if (!route.GekozenVerblijfsType.BeschikbareVerblijfsFormules.Contains(route.GekozenVerblijfsFormule))
                    throw new VerblijfsFormuleException(
                        "Verblijfsformule " + route.GekozenVerblijfsFormule + " is niet beschikbaar in een " +
                        route.GekozenVerblijfsType + "!", route.GekozenVerblijfsFormule);
                VakantiePrijs += route.GekozenVerblijfsType.BerekenVerblijfsPrijs(1, route.GekozenVerblijfsFormule);
                if (route.GekozenVerblijfsType.ToeslagSingle && AantalPersonen == 1)
                {
                    VakantiePrijs += ToeslagSingel;
                }
            }
            return VakantiePrijs;
        }
    }
}