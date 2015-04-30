using System;

namespace TuinCentrumGemeenschap
{
    public class plant
    {
        public plant(string naam, Int32 plantNr, Int32 levNr, decimal prijs, string kleur)
        {
            Naam = naam;
            PlantNr = plantNr;
            LevNr = levNr;
            Prijs = prijs;
            Kleur = kleur;
        }

        public plant()
        {
        }

        public string Naam { get; set; }
        public Int32 PlantNr { get; set; }
        public Int32 LevNr { get; set; }
        public decimal Prijs { get; set; }
        public string Kleur { get; set; }

        public override string ToString()
        {
            return Naam;
        }
    }
}