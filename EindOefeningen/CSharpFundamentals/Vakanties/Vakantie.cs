using System;
using TravelNet.Verblijven;

namespace TravelNet.Vakanties
{
    public enum Bestemming
    {
        Italië,
        Griekenland,
        Noorwegen,
        Finland
    }

    internal class Vakantie
    {
        public static decimal ToeslagSingel = 5m;
        private DateTime terugkeerDatumValue;

        public Vakantie(int boekingNr, Bestemming bestemming, DateTime vertrekDatum, DateTime terugkeerDatum,
            int aantalPersonen, bool internetGewenst)
        {
            BoekingNr = BoekingNr;
            Bestemming = bestemming;
            VertrekDatum = vertrekDatum;
            TerugkeerDatum = terugkeerDatum;
            AantalPersonen = aantalPersonen;
            InternetGewenst = internetGewenst;
        }

        public int BoekingNr { get; set; }
        public Bestemming Bestemming { get; set; }
        public DateTime VertrekDatum { get; set; }

        public DateTime TerugkeerDatum
        {
            get { return terugkeerDatumValue; }
            set
            {
                if (value < VertrekDatum)
                    throw new TerugkeerDatumException(
                        "Reis met boekingnr " + BoekingNr + ": terugkeerdatum (" + value +
                        ") moet later zijn dan vertrekdatum (" + VertrekDatum + ")!", value);
                terugkeerDatumValue = value;
            }
        }

        public int AantalPersonen { get; set; }
        public bool InternetGewenst { get; set; }
        public virtual decimal BerekenVakantiePrijs();

        public class TerugkeerDatumException : Exception
        {
            public TerugkeerDatumException(string message, DateTime verkeerdeTerugkeerDatum) : base(message)
            {
                VerkeerdeTerugkeerDatum = verkeerdeTerugkeerDatum;
            }

            public DateTime VerkeerdeTerugkeerDatum { get; set; }
        }

        public class VerblijfsFormuleException : Exception
        {
            public VerblijfsFormuleException(string message, Formule verkeerdeVerblijfsFormule)
                : base(message)
            {
                VerkeerdeVerblijfsFormule = verkeerdeVerblijfsFormule;
            }

            public VerblijfsFormuleException()
            {
                // TODO: Complete member initialization
            }

            public Formule VerkeerdeVerblijfsFormule { get; set; }
        }
    }
}