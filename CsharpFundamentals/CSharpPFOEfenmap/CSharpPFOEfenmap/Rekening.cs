using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public abstract class Rekening : ISpaarmiddel
    {
        //============exceptions=======================

        public class OngeldigRekeningNrException : Exception
        {
            private ulong OngeldigRekeningNrValue;
            public ulong OngeldigRekeningNr
            {
                get
                {
                    return OngeldigRekeningNrValue;
                }
                set
                {
                    OngeldigRekeningNrValue = value;
                }
            }

            public OngeldigRekeningNrException(string message, ulong value)
                : base(message)
            {
                OngeldigRekeningNr = value;
            }
        }

        public class OngeldigeCreatieDatumException : Exception
        {
            private DateTime OngeldigeCreatieDatumValue;
            public DateTime OngeldigeCreatieDatum
            {
                get
                {
                    return OngeldigeCreatieDatumValue;
                }
                set
                {
                    OngeldigeCreatieDatumValue = value;
                }
            }

            public OngeldigeCreatieDatumException(String message, DateTime creatieDatum) 
                : base(message)
            {
                OngeldigeCreatieDatum = creatieDatum;
            }
            
        }

        //============end exceptions===================

        public delegate void Transactie(Rekening rekening);

        private Klant eigenaarValue;
        private ulong RekeningnummerValue;
        private decimal SaldoValue;
        private decimal vorigSaldoValue;
        private DateTime CreatiedatumValue;
        private readonly DateTime EersteCreatiedatum = new DateTime(1900, 1, 1);

        public Transactie RekeningUitreksel;
        public Transactie SaldoInHetRood;

        public void Storten(decimal bedrag) 
        {
            if (bedrag >= 0)
            {
                VorigSaldo = Saldo;
                Saldo += bedrag;
                RekeningUitreksel(this);
            }
        }

        public void Afhalen(decimal bedrag)
        {
            if (bedrag <= Saldo)
            {
                VorigSaldo = Saldo;
                Saldo -= bedrag;
                RekeningUitreksel(this);
            }
            else
            {
                SaldoInHetRood(this);
            }

        }

        

        public Rekening(ulong nummer, Klant eigenaar, decimal saldo, DateTime datum)
        {
            this.Rekeningnummer = nummer;
            this.Saldo = saldo;
            this.Creatiedatum = datum;
            this.Eigenaar = eigenaar;
        }

        public Rekening()
        {
            this.Rekeningnummer = 0;
            this.Saldo = 0;
            this.Creatiedatum = DateTime.Today;
        }

        public virtual void Afbeelden()
        {
            Console.WriteLine("Rekeningnummer: {0:000-0000000-00}", Rekeningnummer);
            Console.WriteLine("Eigenaar:");
            Eigenaar.Afbeelden();
            Console.WriteLine("Saldo: {0}", Saldo);
            Console.WriteLine("Creatiedatum: {0:dd-MM-yyyy}", Creatiedatum);
        }

        public decimal VorigSaldo
        {
            get
            {
                return vorigSaldoValue;
            }
            set
            {
                if (value >= 0)
                    vorigSaldoValue = value;
            }
        }

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



        public ulong Rekeningnummer
        {
            get
            {
                return RekeningnummerValue;
            }

            set
            {
                ulong eerste10 = value / 10ul;
                int laatste2 = (int)(value % 100ul);
                if ((int)(eerste10 % 97ul) != laatste2)
                    throw new OngeldigRekeningNrException("Ongeldig rekeningnummer!", value);
                RekeningnummerValue = value;
                
            }
        }

        public decimal Saldo
        {
            get
            {
                return SaldoValue;
            }

            set
            {
                SaldoValue = value;
            }
        }

        public DateTime Creatiedatum
        {
            get
            {
                return CreatiedatumValue;
            }

            set
            {
                if (value <= EersteCreatiedatum)
                    throw new OngeldigeCreatieDatumException("Ongeldige creatiedatum!", value);
                CreatiedatumValue = value;
            }
        }

    }
}
