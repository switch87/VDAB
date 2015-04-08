using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class ZichtRekening : Rekening
    {
        //================exceptions=================
        public class OngeldigMaxKredietException : Exception
        {
            private decimal ongeldigMaxKredietValue;
            public decimal OngeldigMaxKrediet
            {
                get
                {
                    return ongeldigMaxKredietValue;
                }
                set
                {
                    ongeldigMaxKredietValue = value;
                }
            }

            public OngeldigMaxKredietException(string message, decimal maxKrediet)
                : base(message)
            {
                OngeldigMaxKrediet = maxKrediet;
            }
        }
        //===============end exceptions==============

        private decimal maxKredietValue;
        public decimal MaxKrediet
        {
            get
            {
                return maxKredietValue;
            }

            set
            {
                if (value > 0)
                    throw new OngeldigMaxKredietException("Max crediet moet kleiner of gelijk aan nul zijn!", value);    
                maxKredietValue = value;
            }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Maximum crediet: {0}", MaxKrediet);
        }

        public ZichtRekening(ulong nummer, Klant eigenaar, decimal saldo, DateTime datum, decimal maxkrediet) : base(nummer,eigenaar, saldo,datum)
        {
            this.MaxKrediet = maxkrediet;
        }

  
        
    }
}
