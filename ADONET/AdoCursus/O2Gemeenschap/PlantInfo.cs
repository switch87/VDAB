namespace TuinCentrumGemeenschap
{
    public class PlantInfo
    {
        public PlantInfo(string naam, string soort, string leverancier, string kleur, decimal kostprijs)
        {
            Naam = naam;
            Soort = soort;
            Leverancier = leverancier;
            Kleur = kleur;
            Kostprijs = kostprijs;
        }

        public string Naam { get; private set; }
        public string Soort { get; private set; }
        public string Leverancier { get; private set; }
        public string Kleur { get; private set; }
        public decimal Kostprijs { get; private set; }
    }
}