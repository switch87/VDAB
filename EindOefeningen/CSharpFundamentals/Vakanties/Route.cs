using TravelNet.Verblijven;

namespace TravelNet.Vakanties
{
    internal class Route
    {
        public Route(string vertrekPunt, string eindPunt, Formule gekozenVerblijfsFormule)
        {
            VertrekPunt = vertrekPunt;
            EindPunt = eindPunt;
            GekozenVerblijfsFormule = gekozenVerblijfsFormule;
        }

        public string VertrekPunt { get; set; }
        public string EindPunt { get; set; }
        public IVerblijfstype GekozenVerblijfsType { get; private set; }
        public Formule GekozenVerblijfsFormule { get; set; }
    }
}