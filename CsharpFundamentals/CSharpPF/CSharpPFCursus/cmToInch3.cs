using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    class Program
    {
        const float GemLichTempCelcius = 37f;
        const float Cel2Far = 9 / 5;
        static void Main(string[] args)
        {
            Console.Write("De gemiddelde lichaamstemperatuur in Fahrenheit is {0}", GemLichTempCelcius * Cel2Far);
        }
    }
}
