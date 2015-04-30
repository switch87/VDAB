using System.Collections.Generic;
using System.Data;

namespace TuinCentrumGemeenschap
{
    public class Soort
    {
        public Soort(string soortNaam, int soortNr)
        {
            SoortNaam = soortNaam;
            SoortNr = soortNr;
        }

        public string SoortNaam { get; set; }
        public int SoortNr { get; set; }

        public override string ToString()
        {
            return SoortNaam;
        }

    }
}