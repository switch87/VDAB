using System.Collections.Generic;
using System.Linq;

namespace BierenServiceLibrary
{
    public class BierenService : IBierenService
    {
        private static readonly Bier[] Bieren =
        {
            new Bier {BierNr = 11, Naam = "Adler", Alcohol = 6.75M},
            new Bier {BierNr = 41, Naam = "Anglo pils", Alcohol = 4.8M},
            new Bier {BierNr = 166, Naam = "Boeg pils", Alcohol = 5M}
        };

        public int GetTotaalAantalBieren()
        {
            return Bieren.Count();
        }

        public int GetAantalBierenTussenAlcohol(decimal van, decimal tot)
        {
            return (from bier in Bieren
                where bier.Alcohol >= van && bier.Alcohol <= tot
                select bier).Count();
        }

        public List<Bier> GetBierenMetWoord(string woord)
        {
            var woordInKleineLetters = woord.ToLower();
            return (from bier in Bieren
                where bier.Naam.ToLower().Contains(woordInKleineLetters)
                select bier).ToList();
        }
    }
}