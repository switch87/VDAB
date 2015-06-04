using System;
using System.Collections.Specialized;
using System.Linq;

namespace EFTaken
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Opgave1_2();
            //Opgave1_3();
            //Opgave1_4();
            //Opgave1_5();
            //Opgave1_6();
            //Opgave1_7();
            Opgave1_10();

            Console.ReadLine();
        }

        private static void Opgave1_10()
        {
        
            using (var enteties = new BankEntities())
            {
                var query = enteties.TotaleSaldoPerKlant.Select(tspk => tspk);
                Console.WriteLine(query.Count());
            }
        }


        private static void Opgave1_9()
        {
            using (var enteties = new BankEntities())
            {
                var zichtrekeningenQuery =
                    enteties.Rekeningen.Select(rekening => rekening).Where(rekening => rekening is Zichtrekening);
                foreach (var rekening in zichtrekeningenQuery)
                {
                    Console.WriteLine("{0} - {1}",rekening.RekeningNr, rekening.Saldo);
                }
            }
        }

        //private static void Opgave1_8()
        //{
        //    using (var enteties = new BankEntities())
        //    {
        //        var hoogsteQuery =
        //            enteties.Personeel.Select(persoon => persoon).Where(persoon => persoon.ManagerNr == null);
        //        foreach (var persoon in hoogsteQuery)
        //        {
        //            Console.WriteLine(persoon.Voornaam);
        //            persoon.GeefOndergeschiktenBoom(enteties, 1);
        //        }
        //    }
        //}


        //// Opgave 1.7 Klant wijzigen
        //private static void Opgave1_7()
        //{
        //    using (var enteties = new BankEntities())
        //    {
        //        try
        //        {
        //            Klanten.KlantenList(enteties);
        //            var Klant = Klanten.GiveKlant(enteties, "Geef klantenNr:");
        //            if ( Klant == null ) Console.ReadLine();


        //            try
        //            {
        //                Console.WriteLine("Geef nieuwe voornaam: ");
        //                var nieuweNaam = Console.ReadLine();
        //                if (nieuweNaam == "")
        //                {
        //                    Console.WriteLine("Lege naam gaat niet");
        //                    return;
        //                }
        //                Klant.Voornaam=nieuweNaam;
        //                enteties.SaveChanges();
        //            }
        //            catch ( Exception )
        //            {
                        
        //                throw;
        //            }
        //        }
        //        catch (Exception)
        //        {

        //            Console.WriteLine( "Geef een geldig klantenNr" );
        //        }
        //    }
        //}

        //// Opgave 1.6 Overschrijven
        //private static void Opgave1_6()
        //{
        //    using ( var enteties = new BankEntities() )
        //    {
        //        try
        //        {
        //            var rekeningOpdrachtgever = Rekeningen.GeefRekening( enteties, "Geef rekeningNr Opdrachtgever" );
        //            if ( rekeningOpdrachtgever == null )
        //            {
                        
        //                return;
        //            }

        //            var rekeningOntvanger = Rekeningen.GeefRekening( enteties, "Geef rekeningNr ontvanger:" );

        //            if ( rekeningOntvanger == null )
        //            {
                        
        //                return;
        //            }

        //            try
        //            {
        //                Console.WriteLine( "Te storten bedrag:" );
        //                var bedrag = decimal.Parse( Console.ReadLine() );
        //                rekeningOpdrachtgever.Afhalen( bedrag );
        //                rekeningOntvanger.Storten( bedrag );
        //                enteties.SaveChanges();
        //            }
        //            catch ( Exception )
        //            {
        //                Console.WriteLine( "Geef een geldig bedrag" );
        //            }
        //        }
        //        catch ( Exception )
        //        {
        //            Console.WriteLine( "Geef een geldig rekeningNr" );
        //        }
        //    }
        //    Console.ReadLine();
        //}

        //// Opgave 1.5 Klant verwijderen
        //private static void Opgave1_5()
        //{
        //    using (var enteties = new BankEntities())
        //    {
        //        var klantenQuery = enteties.Klanten.OrderBy(Klant => Klant.Voornaam).Select(Klant => Klant);
        //        foreach (var klant in klantenQuery)
        //        {
        //            Console.WriteLine("{0}:{1}", klant.KlantNr, klant.Voornaam);
        //        }
        //        try
        //        {
        //            Console.Write("Geef je klantNr: ");
        //            var klantNr = int.Parse(Console.ReadLine());
        //            var klant = enteties.Klanten.Find(klantNr);
        //            if (klant == null)
        //            {
        //                Console.WriteLine("Klant niet gevonden");
        //            }
        //            else
        //            {
        //                var rekeninQuery =
        //                    enteties.Rekeningen.Select(rekening => rekening)
        //                        .Where(rekening => rekening.KlantNr == klantNr);
        //                foreach (var rekening in rekeninQuery)
        //                {
        //                    enteties.Rekeningen.Remove(rekening);
        //                }
        //                enteties.Klanten.Remove(klant);
        //                enteties.SaveChanges();
        //                Console.WriteLine("klant {0} is verwijderd", klant.Voornaam);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("Tik een getal");
        //        }
        //    }
        //    Console.ReadLine();
        //}

        //// Opgave 1.4 Storten
        //private static void Opgave1_4()
        //{
        //    using (var enteties = new BankEntities())
        //    {
        //        try
        //        {
        //            Console.Write("RekeningNr:");
        //            var rekeningNr = Console.ReadLine();
        //            var rekening = enteties.Rekeningen.Find(rekeningNr);
        //            if (rekening == null)
        //            {
        //                Console.WriteLine("Rekening niet gevonden");
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    Console.WriteLine("Te storten bedrag:");
        //                    var bedrag = decimal.Parse(Console.ReadLine());
        //                    rekening.Storten(bedrag);
        //                    enteties.SaveChanges();
        //                }
        //                catch (Exception)
        //                {
        //                    Console.WriteLine("Geef een geldig bedrag");
        //                }
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("Geef een geldig rekeningNr");
        //        }
        //    }
        //    Console.ReadLine();
        //}

        //// Opgave 1.3 Zichtrekening Toevoegen
        //private static void Opgave1_3()
        //{
        //    using (var enteties = new BankEntities())
        //    {
        //        var klantenQuery = enteties.Klanten.OrderBy(Klant => Klant.Voornaam).Select(Klant => Klant);
        //        foreach (var klant in klantenQuery)
        //        {
        //            Console.WriteLine("{0}:{1}", klant.KlantNr, klant.Voornaam);
        //        }
        //        try
        //        {
        //            Console.Write("Geef je klantNr: ");
        //            var klantNr = int.Parse(Console.ReadLine());
        //            var klant = enteties.Klanten.Find(klantNr);
        //            if (klant == null)
        //            {
        //                Console.WriteLine("Klant niet gevonden");
        //            }
        //            else
        //            {
        //                Console.Write("RekeningNr:");
        //                var rekeningNr = Console.ReadLine();
        //                var rekening = new Rekeningen {RekeningNr = rekeningNr, Soort = "Z"};
        //                klant.Rekeningen.Add(rekening);
        //                enteties.SaveChanges();
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("Tik een getal");
        //        }
        //    }
        //    Console.ReadLine();
        //}

        //// Klanten en hun rekeningen
        //private static void Opgave1_2()
        //{
        //    using (var enteties = new BankEntities())
        //    {
        //        foreach (var klant in enteties.Klanten)
        //        {
        //            decimal totaalSaldo = 0;
        //            Console.WriteLine(klant.Voornaam);
        //            foreach (var rekening in klant.Rekeningen)
        //            {
        //                Console.WriteLine(rekening.RekeningNr);
        //                totaalSaldo += rekening.Saldo;
        //            }
        //            Console.WriteLine("Totoaal: {0}", totaalSaldo);
        //            Console.WriteLine();
        //        }
        //    }
        //}
    }
}