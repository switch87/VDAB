using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voertuigen
{
    public class Personenwagen : Voertuig, IVervuiler
    {
        private int aantalDeurenValue;
        public int AantalDeuren
        {
            get
            {
                return aantalDeurenValue;
            }

            set
            {
                if (value > 0)
                    aantalDeurenValue = value;
            }
        }

        private int aantalPassagiersValue;
        public int AantalPassagiers
        {
            get
            {
                return aantalPassagiersValue;
            }

            set
            {
                if (value >= 0)
                    aantalPassagiersValue = value;
            }
        }

        public override double GetKyotoScore()
        {
            return (this.GemiddeldVerbruik*this.Pk)/this.AantalPassagiers;
        }

        public override void Afbeelden()
        {
            Console.WriteLine("Personenwagen");
            base.Afbeelden();
            Console.WriteLine("Aantal Deuren: {0}", AantalDeuren);
            Console.WriteLine("Aantal Passagiers: {0}", AantalPassagiers);
        }

        public Personenwagen() : base()
        {
            AantalDeuren = 4;
            AantalPassagiers = 5;
        }

        public Personenwagen(string polishouder, decimal kostprijs, int pk, float gemiddeldeVerbruik, string nummerplaat, int aantalDeuren, int aantalPassagiers)
            : base(polishouder, kostprijs, pk, gemiddeldeVerbruik, nummerplaat)
        {
            AantalDeuren = aantalDeuren;
            AantalPassagiers = aantalPassagiers;
        }


        public double GeefVervuiling()
        {
            return GetKyotoScore() * 5;
        }
    }
}
