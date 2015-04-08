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
            string Alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Console.Write("Geef een IBAN nummer: ");
            string Iban = Console.ReadLine().Replace(" ", @"");
            Iban = Iban.Substring(4) + Iban.Substring(0, 4);
            for (int I = 12; I < 15; I +=2) 
            {
                for (int J=0; J < 26;J++)
                {
                    if (Iban[I] == Alfabet[J])
                    {
                        string x = (J+10).ToString();
                        Iban = Iban.Substring(0,I)+x+Iban.Substring(I+1);
                    }
                }
            }
            Console.WriteLine(long.Parse(Iban)%97 == 1? "Dit is een geldig IBAN rekeningnummer": "Dit rekeningnummer is niet geldig");

        }
    }
}
