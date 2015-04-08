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
            Console.Write("geef een jaartal: ");
            int Jaar = int.Parse(Console.ReadLine());
            if ((Jaar%4==0) && !(Jaar%400==0))
            {
                Console.WriteLine("Het was een schrikkeljaar!");
            }
            else
            {
                Console.WriteLine("Sorry, niets schrikkeligs aan dat jaar!");
            }
        }
    }
}
