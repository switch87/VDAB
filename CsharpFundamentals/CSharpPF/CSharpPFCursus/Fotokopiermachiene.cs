using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Materiaal
{
    public delegate void Onderhoudsbeurt(Fotokopiemachine machine);
    public class Fotokopiemachine : IKost
    {
        //================Exeptions=====================
        public class KostPerBlzException : Exception
        {
            private decimal verkeerdeKostValue;
            public decimal VerkeerdeKost
            {
                get
                {
                    return verkeerdeKostValue;
                }
                set
                {
                    verkeerdeKostValue = value;
                }
            }

            public KostPerBlzException(string message, decimal verkeerdeKost) : base(message)
            {
                VerkeerdeKost = verkeerdeKost;
            }
        }

        public class AantalBlzException : Exception
        {
            private int verkeerdAantalBlzValue;
            public int VerkeerdAantalBlz
            {
                get
                {
                    return verkeerdAantalBlzValue;
                }
                set
                {
                    verkeerdAantalBlzValue = value;
                }
            }

            public AantalBlzException(string message, int verkeerdAantalBlz)
                : base(message)
            {
                VerkeerdAantalBlz = verkeerdAantalBlz;
            }
        }

        //========variabelen en constanten=============
        private string serieNrValue;
        private int aantalBlzValue;
        private decimal kostPerBlzValue;
        private const int AantalBlzTussen2OnderhoudsBeurten = 10;

        //===============events=========================
        public event Onderhoudsbeurt OnderhoudNodig;

        //==============methodes========================
        public void Fotokopieer(int aantalBlz)
        {
            for (int blz = 1; blz <= aantalBlz; blz++)
            {
                Console.WriteLine("FotokopieMachine {0} kopieert " +
                    "blz. {1} van {2}.", SerieNr, blz, aantalBlz);
                if (++AantalBlz % AantalBlzTussen2OnderhoudsBeurten == 0)
                    if (OnderhoudNodig != null)
                        OnderhoudNodig(this);
            }
        }

        public Fotokopiemachine(string serieNr, int aantalBlz, decimal kostPerBlz)
        {
            SerieNr = serieNr;
            AantalBlz = aantalBlz;
            KostPerBlz = kostPerBlz;
        }

        
        //===============eigenschappen======================
        public string SerieNr
        {
            get
            {
                return serieNrValue;
            }
            set
            {
                serieNrValue = value;
            }
        }

        public int AantalBlz
        {
            get
            {
                return aantalBlzValue;
            }
            set
            {
                if (value <= 0)
                    throw new AantalBlzException("Aantal blz. < 0!", value);
                aantalBlzValue = value;
            }
        }

        public decimal KostPerBlz
        {
            get
            {
                return kostPerBlzValue;
            }
            set
            {
                if (value <= 0)
                    throw new KostPerBlzException("Kost per blz. <=0!", value);
                kostPerBlzValue = value;
            }
        }

        

        public decimal Bedrag
        {
            get 
            { 
                return AantalBlz * KostPerBlz;
            }
        }

        public bool Menselijk
        {
            get 
            { 
                return false; 
            }
        }
    }
}
