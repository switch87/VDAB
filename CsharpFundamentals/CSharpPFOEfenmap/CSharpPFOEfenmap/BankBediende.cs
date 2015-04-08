using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankBediende
    {
        private string VoornaamValue;
        private string NaamValue;

        public string Voornaam
        {
            get
            {
                return VoornaamValue;
            }
            set
            {
                VoornaamValue = value;
            }
        }

        public string Naam
        {
            get
            {
                return NaamValue;
            }
            set
            {
                NaamValue = value;
            }
        }

        public BankBediende(string voornaam, string naam)
        {
            Voornaam = voornaam;
            Naam = naam;
        }

        public void ToonRekeningUitreksel(Rekening rekening)
        {
            rekening.Afbeelden();
            Console.WriteLine("Vorig saldo: {0} euro", rekening.VorigSaldo);
            if (rekening.VorigSaldo > rekening.Saldo)
            {
                Console.WriteLine("Afhaling van {0} euro", rekening.VorigSaldo - rekening.Saldo);   
            }
            else
            {
                Console.WriteLine("Storting van {0} euro", rekening.VorigSaldo + rekening.Saldo);
            }
            Console.WriteLine("Saldo: {0} euro", rekening.Saldo);
        }

        public void ToonSaldoInHetRood(Rekening rekening)
        {
            Console.WriteLine("Uw saldo is ontoerijkend");
            Console.WriteLine("maximum af te halen bedrag is {0} euro", rekening.Saldo);
        }
    }
}
