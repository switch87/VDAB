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
            Console.Write("Tik een lengte in cm:");
            float cm = float.Parse(Console.ReadLine());
            Console.WriteLine("lengte in inch: {0}", cm / CmInch);
        }
    }
}
