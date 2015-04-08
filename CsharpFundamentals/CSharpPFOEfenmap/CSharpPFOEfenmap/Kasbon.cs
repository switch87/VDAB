using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Kasbon : ISpaarmiddel
    {
        private DateTime aankoopDatumValue;
        public DateTime AankoopDatum
        {
            get
            {
                return aankoopDatumValue;
            }
            set
            {
                if (value.Year >= 1900)
                    aankoopDatumValue = value;
            }
        }

        private decimal bedragValue;
        public decimal Bedrag
        {
            get
            {
                return bedragValue;
            }
            set
            {
                if (value >= 0)
                    bedragValue = value;
            }
        }

        private int looptijdValue;
        public int Looptijd
        {
            get
            {
                return looptijdValue;
            }
            set
            {
                if (value >= 0)
                    looptijdValue = value;
            }
        }

        private decimal intrestValue;
        public decimal Intrest
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

        private Klant eigenaarValue;
        public Klant Eigenaar
        {
            get
            {
                return eigenaarValue;
            }
            set
            {
                eigenaarValue = value;
            }
        }

        public Kasbon(DateTime aankoopDatum, decimal bedrag, int looptijd, decimal intrest, Klant eigenaar)
        {
            AankoopDatum = aankoopDatum;
            Bedrag = bedrag;
            Looptijd = looptijd;
            Intrest = intrest;
            Eigenaar = eigenaar;
        }
        public void Afbeelden()
        {
            if (Eigenaar != null)
            {
                Console.WriteLine("Eigenaar");
                Eigenaar.Afbeelden();
            }
            Console.WriteLine("Aankoopdatum: {0:dd-MM-yyyy}", AankoopDatum);
            Console.WriteLine("Bedrag: {0}", Bedrag);
            Console.WriteLine("Looptijd: {0}", Looptijd);
            Console.WriteLine("Intrest: {0}", Intrest);
        }
    }
}
