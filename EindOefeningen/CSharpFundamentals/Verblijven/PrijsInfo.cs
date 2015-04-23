namespace TravelNet.Verblijven
{
    public enum PrijsPeriode
    {
        Dag,
        Week
    }

    internal class PrijsInfo
    {
        public PrijsInfo(decimal basisPrijs, PrijsPeriode prijsPeriode)
        {
            BasisPrijs = basisPrijs;
            PrijsPeriode = prijsPeriode;
        }

        public decimal BasisPrijs { get; set; }
        public PrijsPeriode PrijsPeriode { get; set; }
    }
}