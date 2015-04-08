using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    public class LijnTrekker
    {
        public void TrekLijn(int lengte)
        {
            for (int teller = 0; teller < lengte; teller++)
                Console.WriteLine();
            Console.WriteLine();
        }
    }
}
