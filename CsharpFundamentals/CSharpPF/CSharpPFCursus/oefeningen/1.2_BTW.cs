using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    class Program
    {
        const ulong BtwNr = 213252520UL;
        static void Main(string[] args)
        {
            int FirstCont = (int)(97-((BtwNr/100UL) % 97UL));
            int SecCont = (int)(BtwNr % 100);
            Console.WriteLine(FirstCont == SecCont ? "Het BTW-nummer is geldig" : "Het BTW-nummer is niet geldig");
        }
    }
}
