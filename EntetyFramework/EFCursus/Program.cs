using System;
using System.Linq;

namespace EFCursus
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            

            ////5.4 Groeperen in queries
            //using (var entities = new OpleidingenEntities())
            //{
            //    var query = from docent in entities.Docenten
            //        group docent by docent.Voornaam
            //        into VoornaamGroep
            //        select new {VoornaamGroep, Voornaam = VoornaamGroep.Key};
            //    foreach (var voornaamStatistiek in query)
            //    {
            //        Console.WriteLine(voornaamStatistiek.Voornaam);
            //        Console.WriteLine(new string('-', voornaamStatistiek.Voornaam.Length));
            //        foreach (var docent in voornaamStatistiek.VoornaamGroep)
            //        {
            //            Console.WriteLine(docent.Naam);
            //        }
            //        Console.WriteLine();
            //    }


                ////5.3 Gedeeltelijke objecten ophalen
                //using (var enteties = new OpleidingenEntities())
                //{
                //    var query = from Campus in enteties.Campussen
                //        orderby Campus.Naam
                //        select new {Campus.CampusNr, Campus.Naam};
                //    foreach (var campusDeel in query)
                //    {
                //        Console.WriteLine("{0}: {1}", campusDeel.CampusNr, campusDeel.Naam);
                //    }
                //}

                //// 5.2 Een entity zoeken op zijn primary key waarde
                //using (var enteties = new OpleidingenEntities())
                //{
                //    Console.WriteLine("DocentNr.:");
                //    int docentNr;
                //    if (int.TryParse(Console.ReadLine(), out docentNr))
                //    {
                //        var docent = enteties.Docenten.Find(docentNr);
                //        Console.WriteLine(docent==null?"Niet gevonden":docent.Naam);
                //    }
                //    else
                //    {
                //        Console.WriteLine("U tikte geen getal");
                //    }
                //}

                //// 5.1.4 LINQ queries en queries met methods vergeleken
                //Console.Write("Minimum wedde:");
                //decimal minWedde;
                //if (decimal.TryParse(Console.ReadLine(), out minWedde))
                //{
                //    Console.Write("Sorteren:1=op wedde, 2=op familienaam, 3=op voornaam:");
                //    var sorterenOp = Console.ReadLine();
                //    Func<Docent, Object> sorteerFunc;
                //    switch (sorterenOp)
                //    {
                //        case "1":
                //            sorteerFunc = (Docent) => Docent.Wedde;
                //            break;
                //        case "2":
                //            sorteerFunc = (Docent) => Docent.Familienaam;
                //            break;
                //        case "3":
                //            sorteerFunc = (Docent) => Docent.Voornaam;
                //            break;
                //        default:
                //            Console.WriteLine("Verkeerde keuze");
                //            sorteerFunc = null;
                //            break;
                //    }
                //    if (sorteerFunc!=null)
                //    {
                //        using (var enteties = new OpleidingenEntities())
                //        {
                //            var query = enteties.Docenten
                //                .Where(Docent => Docent.Wedde >= minWedde)
                //                .OrderBy(sorteerFunc);
                //            foreach (var docent in query)
                //            {
                //                Console.WriteLine("{0}: {1}", docent.Naam, docent.Wedde);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        Console.WriteLine("U tikte geen getal");
                //    }  
                //}


                //// 5.1.2 Een LINQ query
                //Console.WriteLine( "Minimum Wedde:" );
                //decimal minWedde;
                //if ( decimal.TryParse( Console.ReadLine(), out minWedde ) )
                //{
                //    using (var enteties = new OpleidingenEntities())
                //    {
                //        var query = from docent in enteties.Docenten
                //            where docent.Wedde >= minWedde
                //            orderby docent.Voornaam, docent.Familienaam
                //            select docent;
                //        foreach (var docent in query)
                //        {
                //            Console.WriteLine("{0}: {1}", docent.Naam, docent.Wedde);
                //        }
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("Tik een getal");
                //}


                //// 5.1.1 foreach iteratie
                //using (var enteties = new OpleidingenEntities())
                //{
                //    foreach (var docent in enteties.Docenten)
                //    {
                //        Console.WriteLine(docent.Naam);
                //    }
                //}
            }
        }
    }