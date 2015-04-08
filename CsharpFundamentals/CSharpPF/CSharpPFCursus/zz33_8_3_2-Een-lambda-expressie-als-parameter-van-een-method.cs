using System;
using Firma.Personeel;
using Firma.Materiaal;
using Firma;
using System.Collections;

namespace Program33832
{
    class Program33832
    {
        delegate bool Filter(int getal);
        static void Program33832a(string[] args)
        {
            Filter filterEvenGetallen = getal => getal % 2 == 0;
            Console.WriteLine("Even getallen:");
            ToonGetallen(filterEvenGetallen);

            Console.WriteLine("Oneven getallen:");
            ToonGetallen(getal => getal % 2 == 1);

            Console.WriteLine("Getallen deelbaar door 5:");
            ToonGetallen(getal => getal % 5 == 0);
        }

        private static void ToonGetallen(Filter filter)
        {
            var getallen = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var getal in getallen)
                if (filter(getal))
                    Console.WriteLine(getal);
        }
    }
}