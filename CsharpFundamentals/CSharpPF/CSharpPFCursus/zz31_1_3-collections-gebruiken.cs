using System;
using Firma.Personeel;
using Firma.Materiaal;
using Firma;
using System.Collections;

namespace Program3113
{
    class Program3113
    {
        static void Program3113a(string[] args)
        {
            // 31 ---= Collections en generics =---

            // 31.1.3 --- Collections gebruiken ---

            // Je maakt een arbeider, een bediende en een manager aan.
            Arbeider asterix = new Arbeider("Asterix", new DateTime(2014, 1, 1), Geslacht.Man, 24.79m, 3);
            Bediende obelix = new Bediende("Obelix", new DateTime(2004, 1, 1), Geslacht.Man, 2400.79m);
            Manager idefix = new Manager("Idefix", new DateTime(2004, 1, 1), Geslacht.Man, 2400.79m, 7000m);

            // Je maakt een nieuwe ArrayList personeel.
            ArrayList personeel = new ArrayList();
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
             */
            Console.WriteLine(((Werknemer)personeel[0]).Naam +
                " is de 1ste van " + personeel.Count +
                " personeelsleden.");
            // Met een foreach doorlopen we de ArrayList.
            foreach (Werknemer personeelslid in personeel)
                Console.WriteLine(personeelslid.Naam);

            /*
             * We maken een nieuwe afdeling aan en stoppen deze “per ongeluk” in de ArrayList. 
             * We proberen nadien de ArrayList te overlopen als een lijst van werknemers maar we krijgen een runtimefout.
             */
            Afdeling eenAfdeling = new Afdeling("Verzending", 0);
            personeel.Add(eenAfdeling);
            foreach (Werknemer personeelslid in personeel)
                Console.WriteLine(personeelslid.Naam);

            /*
             * Een ArrayList is een zeer flexibele array met heel veel mogelijkheden. 
             * Nadeel is dat alle elementen in de ArrayList van het type Object zijn. 
             * Haal je een element uit de ArrayList, dan moet je dit eerst casten naar 
             * zijn echte type vooraleer je er de properties en methods van kan gebruiken.
             * 
             * Je kan om het even wat in de ArrayList stoppen. De ArrayList controleert niet 
             * wat er ingestopt wordt. Dit kan fouten opleveren bij het casten, 
             * die pas optreden at runtime.
             */
        }
    }
}