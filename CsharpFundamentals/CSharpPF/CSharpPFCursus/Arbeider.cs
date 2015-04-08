using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Personeel
{
    public class Arbeider : Werknemer
    {
        public override decimal Premie
        {
            get 
            {
                return Uurloon * 150m;
            }
        }

        private decimal uurloonValue;
        public decimal Uurloon
        {
            get
            {
                return uurloonValue;
            }

            set
            {
                if (value >= 0m)
                    uurloonValue = value;
            }
        }

        private byte ploegenstelselValue;
        public byte Ploegenstelsel
        {
            get
            {
                return ploegenstelselValue;
            }

            set
            {
                if (value >= 1 && value <= 3)
                    ploegenstelselValue = value;
            }
        }

        public override void Afbeelden()
        {
            base.Afbeelden();
            Console.WriteLine("Uurloon: {0}", Uurloon);
            Console.WriteLine("Ploegenstelsel: {0}", Ploegenstelsel);
        }

        public override string ToString()
        {
            return base.ToString() + ' ' + Uurloon + " euro/uur";
        }

        public Arbeider(string naam, DateTime inDienst, Geslacht geslacht, decimal uurloon, byte ploegenstelsel) : base(naam, inDienst, geslacht)
        {
            this.Uurloon = uurloon;
            this.Ploegenstelsel = ploegenstelsel;
        }

        public override decimal Bedrag
        {
            get { return Uurloon * 2000m; }
        }
    }
}
