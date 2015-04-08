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
        static readonly double GuldenSnede = (Math.Sqrt(5.0) + 1.0) / 2.0;
        static void Main(string[] args)
        {
            float cm = 100.0f;
            float inch = cm / CmInch;
            Console.WriteLine(cm);
            Console.WriteLine(inch);
            Console.WriteLine(GuldenSnede);
        }
    }
}
