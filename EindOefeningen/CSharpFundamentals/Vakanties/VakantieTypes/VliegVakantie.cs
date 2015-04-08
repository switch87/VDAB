using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    class VliegVakantie : Vakantie
    {
        // 1 route
        // totPrijs = verblijfsPrijs + ticket

        private Route routeValue;
        private decimal vliegTicketPrijsValue; // prijs heen en terug

        public Route Route { get { return routeValue; } set { routeValue = value; } }
        public decimal VliegTicketPrijs { get { return vliegTicketPrijsValue; } set { vliegTicketPrijsValue = value; } }

        public VliegVakantie(int boekingNr,Bestemming bestemming, DateTime vertrekDatum, DateTime terugkeerDatum, int aantalPersonen, bool internetGewenst,
            Route route, decimal vliegTicketPrijs)
            :base(boekingNr,bestemming, vertrekDatum, terugkeerDatum, aantalPersonen, internetGewenst)
        {
            Route = route;
            VliegTicketPrijs = vliegTicketPrijs;
        }

        public override decimal BerekenVakantiePrijs()
        {
            if (!Route.GekozenVerblijfsType.BeschikbareVerblijfsFormules.Contains(Route.GekozenVerblijfsFormule))
                throw new VerblijfsFormuleException("Verblijfsformule " + Route.GekozenVerblijfsFormule + " is niet beschikbaar in een " + Route.GekozenVerblijfsType + "!", Route.GekozenVerblijfsFormule);
            decimal vakantiePrijs = (VliegTicketPrijs + Route.GekozenVerblijfsType.BerekenVerblijfsPrijs((this.TerugkeerDatum-this.VertrekDatum).Days,Route.GekozenVerblijfsFormule));
            if (Route.GekozenVerblijfsType.ToeslagSingle && AantalPersonen == 1)
            {
                vakantiePrijs += ToeslagSingel;
            }
            return vakantiePrijs;
        }

    }
}
