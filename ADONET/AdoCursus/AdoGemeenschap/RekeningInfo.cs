namespace AdoGemeenschap
{
    public class RekeningInfo
    {
        public RekeningInfo(decimal saldo, string klantNaam)
        {
            Saldo = saldo;
            Klantnaam = klantNaam;
        }

        public decimal Saldo { get; private set; }
        public string Klantnaam { get; private set; }
    }
}