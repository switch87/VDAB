using System;
namespace Firma.Personeel
{
    /* 
     * public abstract class Werknemer
     * Werknemer.cs
     * WerkRegime.cs
     */
    public abstract partial class Werknemer:IKost
    {
        private Afdeling afdelingValue;
        public Afdeling Afdeling
        {
            get
            {
                return afdelingValue;
            }

            set
            {
                afdelingValue = value;
            }
        }
        
        private string naamValue;
        private Geslacht geslachtValue;
        private DateTime inDienstValue;
        private decimal salarisValue;
        private static DateTime personeelsfeestValue;

        public abstract decimal Premie
        {
            get;
        }

        public string Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (value != string.Empty)
                    naamValue = value;
            }
        }

        public DateTime InDienst
        {
            get
            {
                return inDienstValue;
            }
            set
            {
                inDienstValue = value;
            }
        }

        public Geslacht Geslacht
        {
            get
            {
                return geslachtValue;
            }
            set
            {
                geslachtValue = value;
            }
        }

        public decimal Salaris
        {
            get
            {
                return salarisValue;
            }
            private set
            {
                if (value >= 0m)
                    salarisValue = value;
            }
        }

        public bool VerjaarAncien
        {
            get
            {
                return inDienstValue.Month == DateTime.Today.Month &&
                    inDienstValue.Day == DateTime.Today.Day;
            }
        }

        public static DateTime Personeelsfeest
        {
            set
            {
                personeelsfeestValue = value;
            }

            get
            {
                return personeelsfeestValue;
            }
        }

        static Werknemer()
        {
            Personeelsfeest = new DateTime(DateTime.Today.Year, 2, 1);
            while (Personeelsfeest.DayOfWeek != DayOfWeek.Friday)
                Personeelsfeest = Personeelsfeest.AddDays(1);
        }
        
        public Werknemer(): this("Onbekend", DateTime.Today, Geslacht.Man) { }

        public Werknemer(string Naam, DateTime InDienst, Geslacht Geslacht)
        {
            this.Naam = Naam;
            this.InDienst = InDienst;
            this.Geslacht = Geslacht;
        }

        public virtual void Afbeelden()
        {
            Console.WriteLine("Naam: {0}", Naam);
            Console.WriteLine("Geslacht: {0}", Geslacht);
            Console.WriteLine("In dienst: {0}", InDienst);
            Console.WriteLine("Personeelsfeest: {0}", Personeelsfeest);
            if (Afdeling != null)
                Console.WriteLine(Afdeling);
        }

        public override string ToString()
        {
            return base.ToString() + ' ' + Geslacht;
        }

        public abstract decimal Bedrag
        {
            get;
        }

        public bool Menselijk
        {
            get 
            {
                return true;
            }
        }
    }
}
