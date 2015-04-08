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
            Console.Write("Geef een aankoopbedrag: ");
            int Aankoop = Console.Read();
            if (Aankoop < 25)
            {
                Console.WriteLine("korting = 1%");
            }
            else if (Aankoop < 50)
            {
                Console.WriteLine("korting = 2%");
            }
            else if (Aankoop < 100)
            {
                Console.WriteLine("korting = 3%");
            }
            else
            {
                Console.WriteLine("korting = 5%");
            }
        }
    }
}
