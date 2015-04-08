using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een positief getal: ");
            int Getal =int.Parse(Console.ReadLine());
            Boolean Priem = true;
            for (int I = 2; I < Getal; I++)
            {
                if (Getal%I==0)
                {
                    Console.WriteLine("{0} is deelbaar door {1}", Getal, I);
                    Priem = false;
                } 
            }
            Console.WriteLine(Priem == true ? "{0} is een priemgetal." : "{0} is geen priemgetal.", Getal);
        }
    }
}
