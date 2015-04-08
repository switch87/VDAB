using System;
using Firma.Personeel;
using Firma.Materiaal;
using Firma;
using System.Collections;

namespace Program3391
{
    class Program3391
    {
        static void Main3391(string[] args)
        {
            Action<int> kwadraat = getal => Console.WriteLine(getal * getal);
            kwadraat(10);

            Action<string, int> tekstDeel = (tekst, vanaf) =>
                Console.WriteLine(tekst.Substring(vanaf));
            tekstDeel("VDAB", 2);
        }
    }
}