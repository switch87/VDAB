namespace AdoGemeenschap
{
    public class Brouwer
    {
        public Brouwer(int brouwerNr, string brNaam, string adres, short postcode, string gemeente, int? omzet)
        {
            BrouwerNr = brouwerNr;
            BrNaam = brNaam;
            Adres = adres;
            Postcode = postcode;
            Gemeente = gemeente;
            Omzet = omzet;
        }

        public Brouwer()
        {
        }

        public int BrouwerNr { get; private set; }
        public string BrNaam { get; set; }
        public string Adres { get; set; }
        public short Postcode { get; set; }
        public string Gemeente { get; set; }
        public int? Omzet { get; set; }
    }
}