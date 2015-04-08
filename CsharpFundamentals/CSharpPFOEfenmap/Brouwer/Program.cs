using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brouwers_linq
{
    class Program
    {
        public static void Main(string[] args)
        {
            var brouwers = new Brouwers().GetBrouwers();

            // -- LINQ met een sortering --
            var brouwersGesorteerdAsc =
                from brouwer in brouwers
                orderby brouwer.Brouwernaam
                select brouwer;
            foreach (var brouwer in brouwersGesorteerdAsc)
                Console.WriteLine(brouwer.ToString());

            Console.WriteLine();
            var brouwersGesorteerdDesc =
                from brouwer in brouwers
                orderby brouwer.Brouwernaam descending
                select brouwer;
            foreach (var brouwer in brouwersGesorteerdDesc)
                Console.WriteLine(brouwer.ToString());


            // -- LINQ query met een anonymous type --
            Console.WriteLine();
            var brouwersGegevens =
                from brouwer in brouwers
                select new { brouwer.Brouwernaam, brouwer.Bieren.Count };
            // of
            //  select new {
            //      Brouwernaam = brouwer.Brouwernaam,
            //      AantalBieren = brouwen.Bieren.Count};
            foreach (var brouwer in brouwersGegevens)
            {
                Console.WriteLine("{0}: {1} bier(en)",
                    brouwer.Brouwernaam, brouwer.Count);
            }


            // -- LINQ met voorwaarden -where --
            Console.WriteLine();
            Console.WriteLine("Belgische brouwerijen:");
            var belgischeBrouwerijen =
                from brouwer in brouwers
                where brouwer.Belgisch
                select brouwer;
            foreach (var brouwer in belgischeBrouwerijen)
                Console.WriteLine(brouwer.ToString());

            Console.WriteLine();
            Console.WriteLine("Niet-Belgische brouwerijen:");
            var nietBelgischeBrouwerijen = 
                from brouwer in brouwers
                where !brouwer.Belgisch
                select brouwer;
            foreach (var brouwer in nietBelgischeBrouwerijen)
                Console.WriteLine(brouwer.ToString());

            Console.WriteLine();
            Console.WriteLine("Brouwers met 2 bieren:");
            var brouwersMet2Bieren = 
                from brouwer in brouwers
                where brouwer.Bieren.Count == 2
                select brouwer;
            foreach (var brouwer in brouwersMet2Bieren)
                Console.WriteLine(brouwer.Brouwernaam);

            Console.WriteLine();
            Console.WriteLine("Brouwers met een ingegeven aantal bieren: ");
            Console.Write("Geef een aantal: ");
            var aantal = int.Parse(Console.ReadLine());
            var brouwersMetXAantalBieren =
                from brouwer in brouwers
                where brouwer.Bieren.Count == aantal
                select brouwer;
            foreach (var brouwer in brouwersMetXAantalBieren)
                Console.WriteLine(brouwer.Brouwernaam);

            Console.WriteLine();
            Console.WriteLine("Belgische brouwerijen met 3 bieren: ");
            var belgischeBrouwerijenMet3Bieren =
                from brouwer in brouwers
                where brouwer.Belgisch && brouwer.Bieren.Count == 3
                select brouwer;
            foreach (var brouwer in belgischeBrouwerijenMet3Bieren)
                Console.WriteLine(brouwer.Brouwernaam);

            // -- Van een hierarchische structuur naar een platte structuur --
            Console.WriteLine();
            var bieren =
                from brouwer in brouwers
                from bier in brouwer.Bieren
                select bier;
            foreach (var bier in bieren)
                Console.WriteLine(bier.ToString());

            Console.WriteLine();
            var alcoholarmeBieren =
                from brouwer in brouwers
                from bier in brouwer.Bieren
                where bier.Alcohol < 2.0F
                select bier;
            foreach (var bier in alcoholarmeBieren)
                Console.WriteLine(bier.ToString());

            // -- LINQ query met een groepering --
            Console.WriteLine();
            var opBelgisch =
                from brouwer in brouwers
                group brouwer by brouwer.Belgisch;
            foreach (var welNietBelgisch in opBelgisch)
            {
                Console.WriteLine(welNietBelgisch.Key ? "Belgisch" : "Niet-Belgisch");
                foreach (var brouwer in welNietBelgisch)
                    Console.WriteLine(brouwer.Brouwernaam);
            }

            // groeperen op aantal bieren zonder sorteren
            Console.WriteLine();
            var opAantalBieren =
                from brouwer in brouwers
                group brouwer by brouwer.Bieren.Count;
            foreach (var aantalBieren in opAantalBieren)
            {
                Console.WriteLine(aantalBieren.Key);
                foreach (var brouwer in aantalBieren)
                    Console.WriteLine(brouwer.Brouwernaam);
            }

            // groeperen op aantal en sorteren
            Console.WriteLine();
            var opAantalBieren2 =
                from brouwer in brouwers
                group brouwer by brouwer.Bieren.Count
                into mijnGroep
                orderby mijnGroep.Key
                select mijnGroep;
            foreach (var aantalBieren in opAantalBieren2)
            {
                Console.WriteLine(aantalBieren.Key);
                foreach (var brouwer in aantalBieren)
                    Console.WriteLine(brouwer.Brouwernaam);
            }


        }
    }
}
