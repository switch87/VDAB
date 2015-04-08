using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelNet.Verblijven;

namespace TravelNet.Vakanties
{
    class Route
    {
        private string vertrekPuntValue, eindPuntValue;
        private IVerblijfstype gekozenVerblijfsTypeValue;
        private Formule gekozenVerblijfsFormuleValue;

        public string VertrekPunt { get { return vertrekPuntValue; } set { vertrekPuntValue = value; } }
        public string EindPunt { get { return eindPuntValue; } set { eindPuntValue = value; } }
        public IVerblijfstype GekozenVerblijfsType { get { return gekozenVerblijfsTypeValue; } }
        public Formule GekozenVerblijfsFormule { get { return gekozenVerblijfsFormuleValue; } set { gekozenVerblijfsFormuleValue = value; } }

        public Route(string vertrekPunt, string eindPunt, Formule gekozenVerblijfsFormule)
        {
            VertrekPunt = vertrekPunt;
            EindPunt = eindPunt;
            GekozenVerblijfsFormule = gekozenVerblijfsFormule;
        }
    }
}
