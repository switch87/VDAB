using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voertuigen
{
    public class Stookketel : IVervuiler
    {
        private float cONormValue;
        public float CONorm
        {
            get
            {
                return cONormValue;
            }
            set
            {
                if (value >= 0)
                    cONormValue = value;
            }
        }

        public Stookketel(float cOnorm)
        {
            CONorm = cOnorm;
        }

        public double GeefVervuiling()
        {
            return CONorm * 100;
        }
    }
}
