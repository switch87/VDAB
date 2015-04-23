using System;

namespace AdoGemeenschap
{
    public class Brouwer
    {
        private short PostcodeValue;

        public Brouwer(int brouwerNr, string brNaam, string adres, short postcode, string gemeente, int? omzet)
        {
            BrouwerNr = brouwerNr;
            BrNaam = brNaam;
            Adres = adres;
            Postcode = postcode;
            Gemeente = gemeente;
            Omzet = omzet;
        }

        public int BrouwerNr { get; private set; }
        public string BrNaam { get; set; }
        public string Adres { get; set; }

        public short Postcode
        {
            get { return PostcodeValue; }
            set
            {
                if (value < 1000 || value > 9999)
                {
                    throw new Exception("Postcode moet tussen 1000 en 9999 liggen");
                }
                PostcodeValue = value;
            }
        }

        public string Gemeente { get; set; }
        public int? Omzet { get; set; }
    }
}