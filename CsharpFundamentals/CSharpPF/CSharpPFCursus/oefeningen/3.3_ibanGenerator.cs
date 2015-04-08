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
            //landcode BE
            string LandCode = "111500";

            string BelRekening ="";
            Console.Write("Geef een belgisch rekeningnummer (xxx-xxxxxxx-xx): ");
            string BelRekRaw = Console.ReadLine();

            for (int I=0; I < BelRekRaw.Length;I++)
            {
                if (BelRekRaw[I] != '-') BelRekening += BelRekRaw[I];
            }

            long ControleGetalInt = 98 - long.Parse(BelRekening + LandCode) % 97;
            string ControleGetal = (ControleGetalInt < 10? "0"+ControleGetalInt.ToString() : ControleGetalInt.ToString());
            string Iban = "BE"+ControleGetal+" "+BelRekening.Substring(0,4)+" "+BelRekening.Substring(4,4)+" "+BelRekening.Substring(8,4);
            Console.WriteLine("Het IBAN nummer is {0}",Iban);

        }
    }
}
