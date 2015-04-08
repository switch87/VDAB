using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voertuigen
{
    class Program 
    { 
        static void Main(string[] args) 
        { 
            Vrachtwagen vw = new Vrachtwagen("Jan", 40000m, 500, 30, "1-ABC-123", 10000); 
            Personenwagen pw = new Personenwagen("Piet", 15000m, 8, 6.5f, "1-DEF-4156", 5, 5); 
            IVervuiler[] vervuilers = new IVervuiler[3]; 
            vervuilers[0] = vw; 
            vervuilers[1] = pw; 
            vervuilers[2] = new Stookketel(7.5f); 
            foreach (IVervuiler vervuiler in vervuilers) 
            { 
                Console.WriteLine("Vervuiling: {0}", vervuiler.GeefVervuiling()); 
            } 
        } 
    }
}
