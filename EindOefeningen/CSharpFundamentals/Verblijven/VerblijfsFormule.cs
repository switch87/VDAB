namespace TravelNet.Verblijven
{
    public enum Formule
    {
        // formulenaam '=' toeslagpercentage
        Ontbijt = 10,
        HalfPension = 20,
        VolPension = 50
    }

    internal class VerblijfsFormule
    {
        private int factorValue;

        public VerblijfsFormule(Formule formule)
        {
            Formule = formule;
        }

        public Formule Formule { get; set; }

        public int Factor
        {
            get
            {
                // geef de integerwaarde van de enum Formule terug
                return (int) Formule;
            }
        }
    }
}