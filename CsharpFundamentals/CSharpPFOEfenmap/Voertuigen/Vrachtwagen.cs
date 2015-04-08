using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voertuigen
{
    public class Vrachtwagen : Voertuig , IVervuiler
    {
        private float maximumLadingValue;
        public float MaximumLading
        {
            get
            {
                return maximumLadingValue;
            }

            set
            {
                if (value >= 0f)
                    maximumLadingValue = value;
            }
        }

        public override double GetKyotoScore()
        {
            return (this.GemiddeldVerbruik*this.Pk)/(this.MaximumLading/1000);
        }

        public override void Afbeelden()
        {
            Console.WriteLine("Vrachtwagen");
            base.Afbeelden();
            Console.WriteLine("Maximum lading: {0}", MaximumLading);
        }

        public Vrachtwagen() : base()
        {
            MaximumLading = 1000f;
        }

        public Vrachtwagen(string polishouder, decimal kostprijs, int pk, float gemiddeldeVerbruik, string nummerplaat, float maximumLading) 
            : base(polishouder, kostprijs,pk,gemiddeldeVerbruik,nummerplaat)
        {
            MaximumLading = maximumLading;
        }

        public double GeefVervuiling()
        {
            return GetKyotoScore() * 20;
        }
    }
}
