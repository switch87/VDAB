namespace TuinCentrumGemeenschap
{
    public class Leverancier
    {
        public Leverancier(int levNr, string naam, string adres, string postcode, string woonplaats)
        {
            LevNr = levNr;
            Naam = naam;
            Adres = adres;
            Postcode = postcode;
            Woonplaats = woonplaats;
        }

        public int LevNr { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
    }
}