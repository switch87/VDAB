using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    public enum Formule
    {
        // formulenaam '=' toeslagpercentage
        Ontbijt = 10,
        HalfPension = 20,
        VolPension = 50
    }

    class VerblijfsFormule
    {
        private Formule formuleValue;
        private int factorValue;

        public Formule Formule
        {
            get
            {
                return formuleValue;
            }
            set
            {
                formuleValue = value;
            }
        }
        public int Factor
        {
            get
            {
                // geef de integerwaarde van de enum Formule terug
                return (int)formuleValue;
            }
        }

        public VerblijfsFormule(Formule formule)
        {
            Formule = formule;
        }
    }
}
