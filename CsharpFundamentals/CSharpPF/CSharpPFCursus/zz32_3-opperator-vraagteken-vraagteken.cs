using System;
using Firma.Personeel;
using Firma.Materiaal;
using Firma;
using System.Collections;

namespace Program323
{
    class Program323
    {
        static void Program323a(string[] args)
        {
            // 32 ---= Nullable types =---

            /*
             * Indien je nu bijvoorbeeld het aantal kinderen van een werknemer niet kent en dit aantal 
             * dus niet expliciet invult, dan zal de membervariabele aantalKinderen van een class 
             * Werknemer toch op de defaultwaarde 0 gezet worden. Wie deze waarde leest, kan dus 
             * geen onderscheid maken of het aantal kinderen onbekend of werkelijk 0 is.
             * 
             * In de databasewereld kan men de waarde van een veld op ‘onbekend’ of ‘niet ingevuld’ zetten. 
             * Ook in .NET kunnen we een Value type de waarde ‘onbekend’ geven. 
             * Je gebruikt hiervoor een zogenaamd nullable type.
             */

            // 32.3 --- De operator ?? ---

            /*
             * Met de operator ?? kan je aangeven welke waarde aan het Value type wordt toegekend wanneer het 
             * nullable type op null staat:
             */

            byte? aantalKinderen = null;
            byte aantalKamers;
            /*
             * Het Value type aantalKamers krijgt de waarde van het nullable type aantalKinderen, 
             * tenzij deze de waarde null heeft, dan wordt de waarde van het Value type aantalKamers 0.
             */
            aantalKamers = aantalKinderen ?? 0;
            Console.WriteLine("Er zijn {0} kinderkamers nodig", aantalKamers);
        }
    }
}