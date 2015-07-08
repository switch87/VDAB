using System;
using ConsoleBierenClient.BierenServiceReference;

namespace ConsoleBierenClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var bierenServiceClient = new BierenServiceClient("httpBieren"))
            {
                Console.WriteLine("Aantal bieren: {0}",
                    bierenServiceClient.GetTotaalAantalBieren());
                Console.Write("Van alcohol:");
                var van = decimal.Parse(Console.ReadLine());
                Console.Write("Tot alcohol:");
                var tot = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Aantal bieren: {0}",
                    bierenServiceClient.GetAantalBierenTussenAlcohol(van, tot));
                Console.Write("Woord:");
                var woord = Console.ReadLine();
                var bieren = bierenServiceClient.GetBierenMetWoord(woord);
                foreach (var bier in bieren)
                {
                    Console.WriteLine("{0} {1} {2}%", bier.BierNr, bier.Naam, bier.Alcohol);
                }
                Console.WriteLine();
                foreach ( var bier in bierenServiceClient.GetStrafsteBieren() )
                {
                    Console.WriteLine( "{0} {1} {2}%", bier.BierNr, bier.Naam, bier.Alcohol );
                }
            }
        }
    }
}