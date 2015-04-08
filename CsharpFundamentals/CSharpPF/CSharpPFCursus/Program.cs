using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> som = (getal1, getal2) => getal1 + getal2;
            Console.WriteLine(som(10, 5));

            Func<string, int, string> tekstDeel = (tekst, vanaf) =>
                tekst.Substring(vanaf);
            Console.WriteLine(tekstDeel("VDAB", 2));
        }
    }
}
