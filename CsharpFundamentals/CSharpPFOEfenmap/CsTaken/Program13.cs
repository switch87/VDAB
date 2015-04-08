using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTaken
{
    class Program13
    {

        delegate Boolean Filter(int getal);
        static void Main13(string[] args)
        {
            Filter filterEvenGetallen = getal => getal % 2 == 0;
            Filter filterPositieveGetallen = getal => getal >= 0;
            ToonGetallen(filterEvenGetallen, "GroenRood");
            ToonGetallen(filterPositieveGetallen, "witgeel");

        }

        private static void ToonGetallen(Filter filter, string kleur)
        {
            var getallen = new[] {1,2,3,4,5,6,7,8,9,-1,-2,-3,-4,-5,-6,-7,-8,-9};
            if (kleur == "GroenRood")
                foreach (var getal in getallen)
                {
                    if (filter(getal))
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(getal);
                }
            else if (kleur == "witgeel")
                foreach (var getal in getallen)
                {
                    if (filter(getal))
                        Console.ForegroundColor = ConsoleColor.White;
                    else
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(getal);
                }



        }


    }
}
