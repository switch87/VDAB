namespace VideoGemeenschap
{
    public class Genre
    {
        public Genre(int genreNr, string genreNaam)
        {
            GenreNr = genreNr;
            GenreNaam = genreNaam;
        }

        public int GenreNr { get; set; }
        public string GenreNaam { get; set; }
    }
}