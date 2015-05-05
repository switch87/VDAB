namespace VideoGemeenschap
{
    public class Film
    {
        public Film(int bandNr, string titel, int inVoorraad, int uitVoorraad, decimal prijs, int totaalVerhuurd,
            int genre)
        {
            BandNr = bandNr;
            Titel = titel;
            InVoorraad = inVoorraad;
            UitVoorraad = uitVoorraad;
            Prijs = prijs;
            TotaalVerhuurd = totaalVerhuurd;
            Genre = genre;
        }

        public Film()
        {
        }

        public string Titel { get; set; }
        public int BandNr { get; set; }
        public int InVoorraad { get; set; }
        public int UitVoorraad { get; set; }
        public decimal Prijs { get; set; }
        public int TotaalVerhuurd { get; set; }
        public int Genre { get; set; }
    }
}