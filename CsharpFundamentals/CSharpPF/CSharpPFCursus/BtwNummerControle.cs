using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    class Program
    {
        const float CmInch = 2.54f;
        static void Main(string[] args)
        {
            float afstand = 100000.0f;
            afstand /= CmInch;
            Console.WriteLine(afstand);
        }
    }
}
