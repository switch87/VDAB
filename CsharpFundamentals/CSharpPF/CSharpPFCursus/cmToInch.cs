using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    class Program
    {
        const ulong BtwNummer = 213252520UL;
        static void Main(string[] args)
        {
            ulong deeltal = BtwNummer / 100UL;
            int rest = (int)(deeltal % 97UL);
            int controle = (int)(BtwNummer % 100);
            Console.WriteLine("97 - de rest van de deling " +
                " van de eerste 7 cijfers door 97: {0}", 97 - rest);
            Console.WriteLine("Twee laatste cijfers: {0}", controle);
        }
    }
}
