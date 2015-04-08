using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelNet.Verblijven

namespace TravelNet.Vakanties
{
    public enum Bestemming
    {
        Italië,
        Griekenland,
        Noorwegen,
        Finland
    }
    class Vakantie
    {
        public class TerugkeerDatumException : Exception
        {
            private DateTime verkeerdeTerugkeerDatumValue;
            public DateTime VerkeerdeTerugkeerDatum
            {
                get
                {
                    return verkeerdeTerugkeerDatumValue;
                }
                set
                {
                    verkeerdeTerugkeerDatumValue = value;
                }
            }

            public TerugkeerDatumException(string message, DateTime verkeerdeTerugkeerDatum) : base(message)
            {
                VerkeerdeTerugkeerDatum = verkeerdeTerugkeerDatum;
            }
        }

        public class VerblijfsFormuleException : Exception
        {
            private Formule verkeerdeVerblijfsFormuleValue;
            public Formule VerkeerdeVerblijfsFormule
            {
                get
                {
                    return verkeerdeVerblijfsFormuleValue;
                }
                set
                {
                    verkeerdeVerblijfsFormuleValue = value;
                }
            }

            public VerblijfsFormuleException(string message, Formule verkeerdeVerblijfsFormule)
                : base(message)
            {
                VerkeerdeVerblijfsFormule = verkeerdeVerblijfsFormule;
            }

public    VerblijfsFormuleException()
    {
        // TODO: Complete member initialization
    }
        }


        private int boekingNrValue, aantalPersonenValue;
        private Bestemming bestemmingValue;
        private DateTime vertrekDatumValue, terugkeerDatumValue;
        private bool internetGewenstValue;

        public static decimal ToeslagSingel = 5m;
        public int BoekingNr
        {
            get
            {
                return boekingNrValue;
            }
            set
            {
                boekingNrValue = value;
            }
        }
        public Bestemming Bestemming
        {
            get
            {
                return bestemmingValue;
            }
            set
            {
                bestemmingValue = value;
            }
        }
        public DateTime VertrekDatum
        {
            get
            {
                return vertrekDatumValue;
            }
            set
            {
                vertrekDatumValue = value;
            }
        }
        public DateTime TerugkeerDatum
        {
            get
            {
                return terugkeerDatumValue;
            }
            set
            {
                if (value < VertrekDatum)
                    throw new TerugkeerDatumException("Reis met boekingnr "+BoekingNr+": terugkeerdatum ("+value+") moet later zijn dan vertrekdatum ("+VertrekDatum+")!", value);
                terugkeerDatumValue = value;
            }
        }
        public int AantalPersonen
        {
            get
            {
                return aantalPersonenValue;
            }
            set
            {
                aantalPersonenValue = value;
            }
        }
        public bool InternetGewenst
        {
            get
            {
                return internetGewenstValue;
            }
            set
            {
                internetGewenstValue = value;
            }
        }

        public Vakantie (int boekingNr,Bestemming bestemming, DateTime vertrekDatum, DateTime terugkeerDatum, int aantalPersonen, bool internetGewenst)
        {
            BoekingNr = BoekingNr;
            Bestemming = bestemming;
            VertrekDatum = vertrekDatum;
            TerugkeerDatum = terugkeerDatum;
            AantalPersonen = aantalPersonen;
            InternetGewenst = internetGewenst;
        }

        public virtual decimal BerekenVakantiePrijs();
    }
}
