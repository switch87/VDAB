using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    public enum WagenType
    {
        EigenWagen,
        HuurAuto,
        Camper
    }
    class Autovakantie : Vakantie
    {
        // 1 dag per route
        // totPrijs = som(verblijfPrijzen)+huurptijsWagen


        private static decimal VasteHuurPrijs = 20.00m; 
        private List<Route> routesValue;
        private WagenType wagenTypeValue;
        private decimal huurPrijsValue;

        public List<Route> Routes 
        {
            get { return routesValue; } 
            set 
            {
                routesValue = value; 
            } 
        }
        public WagenType WagenType { get { return wagenTypeValue; } set { wagenTypeValue = value; } }
        public decimal Huurprijs
        {
            get
            {
                if (WagenType == WagenType.EigenWagen)
                    return 0m;
                else
                    return VasteHuurPrijs;
            }
        }

        public Autovakantie(int boekingNr,Bestemming bestemming, DateTime vertrekDatum, DateTime terugkeerDatum, int aantalPersonen, bool internetGewenst, 
            List<Route> routes,WagenType wagenType)
            : base (boekingNr,bestemming,vertrekDatum, terugkeerDatum, aantalPersonen, internetGewenst)
        {
            Routes = routes;
            WagenType = wagenType;
        }

        public override decimal BerekenVakantiePrijs()
        {
            decimal VakantiePrijs = Huurprijs;
            foreach (Route route in Routes)
            {
                if (!route.GekozenVerblijfsType.BeschikbareVerblijfsFormules.Contains(route.GekozenVerblijfsFormule))
                    throw new VerblijfsFormuleException("Verblijfsformule "+route.GekozenVerblijfsFormule+" is niet beschikbaar in een "+route.GekozenVerblijfsType+"!", route.GekozenVerblijfsFormule);
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
