using System;

namespace TravelNet.Vakanties
{
    internal class VliegVakantie : Vakantie
    {
        public VliegVakantie(int boekingNr, Bestemming bestemming, DateTime vertrekDatum, DateTime terugkeerDatum,
            int aantalPersonen, bool internetGewenst,
            Route route, decimal vliegTicketPrijs)
            : base(boekingNr, bestemming, vertrekDatum, terugkeerDatum, aantalPersonen, internetGewenst)
        {
            Route = route;
            VliegTicketPrijs = vliegTicketPrijs;
        }

        // 1 route
        // totPrijs = verblijfsPrijs + ticket

        public Route Route { get; set; }
        public decimal VliegTicketPrijs { get; set; }

        public override decimal BerekenVakantiePrijs()
        {
            if (!Route.GekozenVerblijfsType.BeschikbareVerblijfsFormules.Contains(Route.GekozenVerblijfsFormule))
                throw new VerblijfsFormuleException(
                    "Verblijfsformule " + Route.GekozenVerblijfsFormule + " is niet beschikbaar in een " +
                    Route.GekozenVerblijfsType + "!", Route.GekozenVerblijfsFormule);
            var vakantiePrijs = (VliegTicketPrijs +
                                 Route.GekozenVerblijfsType.BerekenVerblijfsPrijs((TerugkeerDatum - VertrekDatum).Days,
                                     Route.GekozenVerblijfsFormule));
            if (Route.GekozenVerblijfsType.ToeslagSingle && AantalPersonen == 1)
            {
                vakantiePrijs += ToeslagSingel;
            }
            return vakantiePrijs;
        }
    }
}