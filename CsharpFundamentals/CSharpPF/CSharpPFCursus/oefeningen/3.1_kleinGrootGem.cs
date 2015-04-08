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
            int[] Waarden = new int[100];
            int Aantal = 0;
            int Som = 0;
            int Kleinste = 0;
            int Grootste = 0;

            for(int I = 0; I < 100; I++)
            {
                Console.Write("Geef een getal, \"-1\" om te stoppen: ");
                Waarden[I] = int.Parse(Console.ReadLine());
                if (Waarden[I] == -1) break;
                Aantal += 1;
            }
            for (int I = 0; I < Aantal && (Waarden[I] != -1); I++)
            {
                Som += Waarden[I];
                if (Waarden[I] < Waarden[Kleinste]) Kleinste = I;
                if (Waarden[I] > Waarden[Grootste]) Grootste = I;
            }
            Console.WriteLine("De kleinste waarde is {0}\n" +
                "De grootste waarde is {1}\n" +
                "Het gemiddelde is {2}\n",
                Waarden[Kleinste], Waarden[Grootste], (Som / Aantal));

        }
    }
}
