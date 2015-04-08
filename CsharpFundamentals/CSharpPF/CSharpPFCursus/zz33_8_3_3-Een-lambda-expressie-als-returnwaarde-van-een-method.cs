using System;
using Firma.Personeel;
using Firma.Materiaal;
using Firma;
using System.Collections;

namespace Program33833
{
    class Program33833
    {
        //

        // 33.8.3.3 --- Een lambda expressie als returnwaarde van een method ---
        delegate bool Filter(int getal);

        static Filter MaakLambda()
        {
            Console.Write("Geef een getal: ");
            var deelbaarDoor = int.Parse(Console.ReadLine());
            return getal => getal % deelbaarDoor == 0;
        }

        private static void ToonGetallen(Filter filter)
        {
            var getallen = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var getal in getallen)
                if (filter(getal))
                    Console.WriteLine(getal);
        }

        public static void Mainisch(string[] args)
        {
            ToonGetallen(MaakLambda());
        }
        
    }
}