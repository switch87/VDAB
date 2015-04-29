namespace AdoGemeenschap
{
    public class Figuur
    {
        public Figuur(int id, string naam, object versie)
        {
            ID = id;
            Naam = naam;
            Versie = versie;
        }

        public Figuur()
        {
        }

        public int ID { get; set; }
        public string Naam { get; set; }
        public object Versie { get; set; }
    }
}