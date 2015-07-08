using System.Collections.Generic;
using System.Linq;

namespace PlantenServiceLibrary
{
    public class PlantenService : IPlantenService
    {
        private static readonly Plant[] PlantList =
        {
            new Plant {Naam = "Margerietje", Nummer = 0, Prijs = 88.55},
            new Plant {Naam = "ziet", Nummer = 1, Prijs = 45.54},
            new Plant {Naam = "me", Nummer = 2, Prijs = 74.74},
            new Plant {Naam = "nietje", Nummer = 3, Prijs = 5555555.22}
        };

        public List<Plant> PlantenMinimumprice(double minPrijsDecimal)
        {
            return (from plant in PlantList
                where plant.Prijs >= minPrijsDecimal
                select plant).ToList();
        }

        public List<Plant> PlantenNameContains(string subString)
        {
            return (from plant in PlantList
                where plant.Naam.Contains(subString)
                select plant).ToList();
        }
    }
}