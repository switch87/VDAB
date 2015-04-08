using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class SpaarRekening : Rekening
    {
        private static decimal intrestValue;
        public static decimal Intrest
        {
            get
            {
                return intrestValue;
            }

            set
            {
                if (value >= 0)
                    intrestValue = value;
            }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Intrest: {0}", Intrest);
        }

        public SpaarRekening(ulong nummer, Klant eigenaar, decimal saldo, DateTime datum) : base(nummer, eigenaar, saldo, datum) {}
    }
}
