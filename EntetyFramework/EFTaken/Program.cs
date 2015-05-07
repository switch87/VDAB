using System;
using System.Linq;

namespace EFTaken
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GeldStorten();
        }

        private static void GeldStorten() // 1.4 Storten
        {
            using (var entetie = new BankEntities())
            {
                var query = (from rekening in entetie.Rekeningen
                    orderby rekening.RekeningNr
                    select rekening).ToList();
                foreach (var rekening in query)
                {
                    Console.WriteLine(rekening.RekeningNr);
                }
                Console.Write("Geef rekeningnr:");
                var rekeningNr = Console.ReadLine();
                try
                {
                    Console.Write("Te storten bedrag:");
                    var rekening = entetie.Rekeningen.Find(rekeningNr);
                    try
                    {
                        rekening.Storten(decimal.Parse(Console.ReadLine()));
                        entetie.SaveChanges();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine( "Het opgegeven bedrag is niet geldig" );
                    }
                }
                catch (Exception)
                {
                    
                    Console.WriteLine("Het opgegeven rekening nummer bestaat niet");
                }

            }
        }

        private static void ZichtrekeningToevoegen() // 1.3 Zichtrekening toevoegen
        {
            using (var entities = new BankEntities())
            {
                var query = from klant in entities.Klanten orderby klant.Voornaam select klant;
                foreach (var klant in query)
                {
                    Console.WriteLine("{0}: {1}", klant.KlantNr, klant.Voornaam);
                }
                try
                {
                    Console.Write("KlantNr:");
                    var klantNr = int.Parse(Console.ReadLine());
                    var klant = entities.Klanten.Find(klantNr);
                    if (klant == null)
                    {
                        Console.WriteLine("Klant niet gevonden");
                    }
                    else
                    {
                        Console.Write("RekeningNr:");
                        var rekeningNr = Console.ReadLine();
                        var rekening = new Rekening {RekeningNr = rekeningNr, Soort = "Z"};
                        klant.Rekeningen.Add(rekening);
                        entities.SaveChanges();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Tik een getal");
                }
            }
        }

        private static void KlantenEnHunRekeningen() // 1.2 Klanten en hun rekeningen
        {
            using (var enteties = new BankEntities())
            {
                var query = from klant in enteties.Klanten.Include("Rekeningen")
                    orderby klant.Voornaam
                    select klant;
                foreach (var klant in query)
                {
                    Console.WriteLine(klant.Voornaam);
                    var totaalSaldo = decimal.Zero;
                    foreach (var rekening in klant.Rekeningen)
                    {
                        Console.WriteLine("{0}: {1}", rekening.RekeningNr, rekening.Saldo);
                        totaalSaldo += rekening.Saldo;
                    }
                    Console.WriteLine("Totaal: {0}\n", totaalSaldo);
                }
            }
        }
    }
}