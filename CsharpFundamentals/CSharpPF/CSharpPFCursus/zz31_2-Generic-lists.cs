using System;
using Firma.Personeel;
using Firma.Materiaal;
using Firma;
/*
 * Het .NET Framework biedt (vanaf versie 2.0) een oplossing voor het probleem uit de vorige paragraaf, 
 * in de vorm van generic lists. De namespace System.Collections.Generic bevat een aantal classes zoals 
 * List, Queue, SortedList en Stack. In tegenstelling tot de gelijknamige classes in de 
 * namespace System.Collections bevatten deze collections elementen van een welbepaald type en niet 
 * van het algemene type Object.
 */
using System.Collections.Generic;

namespace Program312
{
    class Program312
    {
        static void Program312a(string[] args)
        {
            // 31 ---= Collections en generics =---

            // 31.2 --- Generic lists ---

            // Je maakt een arbeider, een bediende en een manager aan.
            Arbeider asterix = new Arbeider("Asterix", new DateTime(2014, 1, 1), Geslacht.Man, 24.79m, 3);
            Bediende obelix = new Bediende("Obelix", new DateTime(2004, 1, 1), Geslacht.Man, 2400.79m);
            Manager idefix = new Manager("Idefix", new DateTime(2004, 1, 1), Geslacht.Man, 2400.79m, 7000m);

            // Je maakt een nieuwe List personeel.
            List<Werknemer> personeel = new List<Werknemer>();
            // Je voegt de arbeider en de bediende toe aan de arraylist.
            personeel.Add(asterix);
            personeel.Add(obelix);
            // Je voegt een manager in op positie 1 (Asterix blijft op positie 0, 
            // Idefix komt op positie 1 en Obelix schuift door naar positie 2).
            personeel.Insert(1, idefix);

            /*
             * We beelden Asterix af die op positie 0 staat. ArrayList ondersteunt 
             * directe toegang via een volgnummer. We moeten het object wel casten naar een Werknemer. 
             * Elementen van een ArrayList worden altijd opgeslagen als gewone 
             * objecten (van het type Object). Via de property Count tonen we het aantal elementen.
             *
             * Cast (Werknemer) is niet meer nodig!!
             * Console.WriteLine(((Werknemer)personeel[0]).Naam + " is de 1ste van " + personeel.Count + " personeelsleden.");
             */
            Console.WriteLine(personeel[0].Naam +
                " is de 1ste van " + personeel.Count +
                " personeelsleden.");
            // Met een foreach doorlopen we de ArrayList.
            foreach (Werknemer personeelslid in personeel)
                Console.WriteLine(personeelslid.Naam);

            // We maken een nieuwe afdeling aan en stoppen deze “per ongeluk” in de ArrayList. 
            Afdeling eenAfdeling = new Afdeling("Verzending", 0);
            // personeel.Add(eenAfdeling); werkt niet meer!

        }
    }
}