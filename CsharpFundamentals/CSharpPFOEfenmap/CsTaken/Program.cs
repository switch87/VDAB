using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTaken
{
    public class Program
    {
        static void Main(string[] args)
        {
            var Plantjes = new List<Plant>{
                new Plant {PlantID=1,Plantennaam="Tulp", Kleur="rood",
                    Prijs=0.5m, Soort="bol"},
                new Plant {PlantID=2, Plantennaam="Krokus", Kleur="wit",
                    Prijs=0.2m, Soort="bol"},
                new Plant {PlantID=3, Plantennaam="Narcis", Kleur="geel",
                    Prijs=0.3m, Soort="bol"},
                new Plant {PlantID=4, Plantennaam="Blauw druifje", Kleur="blauw",
                    Prijs=0.2m, Soort="bol"},
                new Plant {PlantID=5, Plantennaam="Azalea",Kleur="rood",
                    Prijs=3m, Soort="heester"},
                new Plant {PlantID=6, Plantennaam="Forsythia", Kleur="geel",
                    Prijs=2m, Soort="heester"},
                new Plant {PlantID=7, Plantennaam="Magnolia", Kleur="wit",
                    Prijs=4m, Soort="heester"},
                new Plant {PlantID=8, Plantennaam="Waterlelie", Kleur="wit",
                    Prijs=2m,Soort="water"},
                new Plant {PlantID=9, Plantennaam="Lisdodde", Kleur="geel",
                    Prijs=3m,Soort="water"},
                new Plant {PlantID=10,Plantennaam="Kalmoes", Kleur="geel",
                    Prijs=2.5m, Soort="water"},
                new Plant {PlantID=11,Plantennaam="Bieslook", Kleur="paars",
                    Prijs=1.5m,Soort="kruid"},
                new Plant {PlantID=12,Plantennaam="Rozemarijn", Kleur="blauw",
                    Prijs=1.25m, Soort="kruid"},
                new Plant {PlantID=13,Plantennaam="Munt", Kleur="wit",
                    Prijs=1.1m, Soort="kruid"},
                new Plant {PlantID=14,Plantennaam="Dragon", Kleur="wit",
                    Prijs=1.3m, Soort="kruid"},
                new Plant {PlantID=15,Plantennaam="Basilicum", Kleur="wit",
                    Prijs=1.5m, Soort="kruid"}};


            var WittePlanten = 
                from plant in Plantjes
                where plant.Kleur == "wit"
                orderby plant.Prijs
                select plant;
            foreach(var plant in WittePlanten)
                Console.WriteLine(plant.Plantennaam+" "+plant.Kleur+" "+plant.Prijs);
            Console.WriteLine("Aantal witte planten: {0}", WittePlanten.Count());
            Console.WriteLine();

            var GemiddeldePrijsHeesters =
                (from plant in Plantjes
                 where plant.Soort == "heester"
                 select plant.Prijs).Average();
            Console.WriteLine("Gemiddelde prijs heesters: {0:0.00} Euro", GemiddeldePrijsHeesters);
            Console.WriteLine();

            var KruidPrijzen =
                from plant in Plantjes
                where plant.Soort == "kruid"
                select plant.Prijs;
            var MaxKruidPrijzen = KruidPrijzen.Max();
            var GemiddeldKruidPrijzen = KruidPrijzen.Average();
            Console.WriteLine("Gemiddelde prijs kruid: {0:0.00} Euro\n" +
                "Maximum prijs kruid: {1:0.00} Euro", GemiddeldKruidPrijzen, MaxKruidPrijzen);
            Console.WriteLine();

            var StartMetB =
                from plant in Plantjes
                where plant.Plantennaam.Substring(0, 1).ToUpper() == "B"
                select plant.Plantennaam;
            Console.WriteLine("Plantennamen die starten op 'B'");
            foreach (var plant in StartMetB)
                Console.WriteLine(plant);
            Console.WriteLine();

            var Kleuren =
                (from plant in Plantjes
                 select plant.Kleur).Distinct();
            foreach (var kleur in Kleuren)
                Console.WriteLine(kleur);
            Console.WriteLine();

            var GegroepeerdPerKleur =
                from plant in Plantjes
                group plant by plant.Kleur
                    into kleurgroep
                    select kleurgroep;
            foreach (var groep in GegroepeerdPerKleur)
            {
                Console.WriteLine("Kleur: {0}", groep.Key);
                foreach (var plant in groep)
                    Console.WriteLine(plant.Plantennaam);
                Console.WriteLine();
            }
            Console.WriteLine();

            var MaxPrijsPerSoort =
                from plant in Plantjes
                group plant by plant.Soort
                    into soorten
                    select new { Soort = soorten.Key, MaxPrijs = soorten.Max(plant => plant.Prijs) };
            foreach (var soort in MaxPrijsPerSoort)
                Console.WriteLine("Maximum prijs {0}: {1:0.00} Euro", soort.Soort, soort.MaxPrijs);
            Console.WriteLine();

            var AlfabetischOpSoort =
                from plant in Plantjes
                group plant by plant.Soort
                    into soorten
                    orderby soorten.Key
                    select soorten;
            foreach (var soort in AlfabetischOpSoort)
            {
                Console.WriteLine("Planten van soort {0}", soort.Key);
                foreach(var plant in soort)
                    Console.WriteLine(plant.Plantennaam);
                Console.WriteLine();
            }


        }
         
    }
}
