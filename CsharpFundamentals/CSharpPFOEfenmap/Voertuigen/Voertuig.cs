using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voertuigen
{
    public abstract class Voertuig: IPrivaat, IMilieu
    {
        public abstract double GetKyotoScore();

        private string PolishouderValue;
        private decimal KostprijsValue;
        private int PkValue;
        private float GemiddeldVerbruikValue;
        private string NummerplaatValue;

        public string Polishouder
        {
            get
            {
                return PolishouderValue;
            }

            set
            {
                PolishouderValue = value;
            }
        }
        
        public decimal Kostprijs
        {
            get
            {
                return KostprijsValue;
            }

            set
            {
                KostprijsValue = value >= 0 ? value : 0;
            }
        }

        public int Pk
        {
            get
            {
                return PkValue;
            }

            set
            {
                PkValue = value >= 0 ? value : 0;
            }
        }

        public float GemiddeldVerbruik
        {
            get
            {
                return GemiddeldVerbruikValue;
            }

            set
            {
                GemiddeldVerbruikValue = value >= 0 ? value : 0;
            }
        }

        public string Nummerplaat
        {
            get
            {
                return NummerplaatValue;
            }

            set
            {
                NummerplaatValue = value;
            }
        }

        public Voertuig()
        {
            PolishouderValue = "onbekend";
            NummerplaatValue = "onbekend";
            KostprijsValue = 0;
            PkValue = 0; 
            GemiddeldVerbruikValue = 0;
        }

        public Voertuig(string polishouder, decimal kostprijs, int pk, float gemiddeldverbruik, string nummerplaat)
        {
            this.Polishouder = polishouder;
            this.Kostprijs = kostprijs;
            this.Pk = pk;
            this.GemiddeldVerbruik = gemiddeldverbruik;
            this.Nummerplaat = nummerplaat;
        }

        public virtual void Afbeelden()
        {
            Console.WriteLine("polishouder : {0}", Polishouder);
            Console.WriteLine("kostprijs: {0}", Kostprijs);
            Console.WriteLine("PK: {0}", Pk);
            Console.WriteLine("gemiddelde verbruik: {0}", GemiddeldVerbruik);
            Console.WriteLine("nummerplaat: {0}", Nummerplaat);
        }

        public string GeefMilieuData()
        {
            return string.Format("Polishouder: {0} - Nummerplaat: {1}",Polishouder, Nummerplaat);
        }

        public string GeefPrivateData()
        {
            return string.Format("PK: {0} - Kostprijs: {1} - Verbruik {2}", Pk, Kostprijs,GemiddeldVerbruik);
        }
    }
}
