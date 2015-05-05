using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace VideoGemeenschap
{
    public class VideoDbManager
    {
        private static readonly ConnectionStringSettings ConVideoSetting =
            ConfigurationManager.ConnectionStrings["video"];

        private static readonly DbProviderFactory Factory = DbProviderFactories.GetFactory(ConVideoSetting.ProviderName);

        public DbConnection GetConnection()
        {
            var conVideo = Factory.CreateConnection();
            conVideo.ConnectionString = ConVideoSetting.ConnectionString;
            return conVideo;
        }

        public List<Genre> GetGenres()
        {
            var genres = new List<Genre>();
            var manager = new VideoDbManager();
            using (var conVideo = manager.GetConnection())
            {
                using (var comGenre = conVideo.CreateCommand())
                {
                    comGenre.CommandType = CommandType.Text;
                    comGenre.CommandText =
                        "select genreNr, Genre " +
                        "from Genres " +
                        "order by GenreNr";
                    conVideo.Open();
                    using (var readerGenres = comGenre.ExecuteReader())
                    {
                        var genreNrPos = readerGenres.GetOrdinal("genreNr");
                        var genrePos = readerGenres.GetOrdinal("Genre");

                        while (readerGenres.Read())
                        {
                            genres.Add(new Genre(readerGenres.GetInt32(genreNrPos), readerGenres.GetString(genrePos)));
                        }
                    }
                }
            }
            return genres;
        }

        public Genre GetGenre(int genreNr)
        {
            var manager = new VideoDbManager();
            using (var conVideo = manager.GetConnection())
            {
                using (var comGenre = conVideo.CreateCommand())
                {
                    comGenre.CommandType = CommandType.Text;
                    comGenre.CommandText =
                        "select Genre " +
                        "from Genres " +
                        "where GenreNr = @GenreNr";
                    var parGenreNr = comGenre.CreateParameter();
                    parGenreNr.ParameterName = "@GenreNr";
                    parGenreNr.Value = genreNr;
                    comGenre.Parameters.Add(parGenreNr);

                    conVideo.Open();
                    using (var readerGenres = comGenre.ExecuteReader())
                    {
                        var genrePos = readerGenres.GetOrdinal("Genre");

                        return new Genre(genreNr, readerGenres.GetString(genrePos));
                    }
                }
            }
        }

        public List<Film> GetFilms()
        {
            var films = new List<Film>();
            var manager = new VideoDbManager();
            using (var conVideo = manager.GetConnection())
            {
                using (var comFilms = conVideo.CreateCommand())
                {
                    comFilms.CommandType = CommandType.Text;
                    comFilms.CommandText =
                        "select BandNr, Titel, InVoorraad, UitVoorraad, Prijs, TotaalVerhuurd, genreNr from Films order by Titel";
                    conVideo.Open();
                    using (var readerFilms = comFilms.ExecuteReader())
                    {
                        var titelPos = readerFilms.GetOrdinal("Titel");
                        var bandNrPos = readerFilms.GetOrdinal("Bandnr");
                        var inVoorraadPos = readerFilms.GetOrdinal("InVoorraad");
                        var uitVoorraadPos = readerFilms.GetOrdinal("UitVoorraad");
                        var prijsPos = readerFilms.GetOrdinal("Prijs");
                        var totaalVerhuurdPos = readerFilms.GetOrdinal("TotaalVerhuurd");
                        var genrePos = readerFilms.GetOrdinal("genreNr");


                        while (readerFilms.Read())
                        {
                            var film = new Film(readerFilms.GetInt32(bandNrPos), readerFilms.GetString(titelPos),
                                readerFilms.GetInt32(inVoorraadPos),
                                readerFilms.GetInt32(uitVoorraadPos), readerFilms.GetDecimal(prijsPos),
                                readerFilms.GetInt32(totaalVerhuurdPos), readerFilms.GetInt32(genrePos));

                            films.Add(film);
                        }
                    }
                }
            }
            return films;
        }

        public void GewijzigdeFilmOpslaan(Film film)
        {
            var manager = new VideoDbManager();
            using (var conVideo = manager.GetConnection())
            {
                using (var comOpslaan = conVideo.CreateCommand())
                {
                    comOpslaan.CommandType = CommandType.Text;
                    comOpslaan.CommandText =
                        "update Films set Titel=@Titel, GenreNr=@GenreNr, InVoorraad=@InVoorraad, UitVoorraad=@UitVoorraad, Prijs=@Prijs, TotaalVerhuurd=@TotaalVerhuurd where BandNr=@BandNr";
                    var parTitel = comOpslaan.CreateParameter();
                    var parGenre = comOpslaan.CreateParameter();
                    var parInVoorraad = comOpslaan.CreateParameter();
                    var parUitVoorraad = comOpslaan.CreateParameter();
                    var parPrijs = comOpslaan.CreateParameter();
                    var parTotaalVerhuurd = comOpslaan.CreateParameter();
                    var parBandNr = comOpslaan.CreateParameter();

                    parTitel.ParameterName = "@Titel";
                    parGenre.ParameterName = "@genreNr";
                    parInVoorraad.ParameterName = "@InVoorraad";
                    parUitVoorraad.ParameterName = "@UitVoorraad";
                    parPrijs.ParameterName = "@Prijs";
                    parTotaalVerhuurd.ParameterName = "@TotaalVerhuurd";
                    parBandNr.ParameterName = "@BandNr";

                    parTitel.Value = film.Titel;
                    parGenre.Value = film.Genre;
                    parInVoorraad.Value = film.InVoorraad;
                    parUitVoorraad.Value = film.UitVoorraad;
                    parPrijs.Value = film.Prijs;
                    parTotaalVerhuurd.Value = film.TotaalVerhuurd;
                    parBandNr.Value = film.BandNr;


                    comOpslaan.Parameters.Add(parTitel);
                    comOpslaan.Parameters.Add(parGenre);
                    comOpslaan.Parameters.Add(parInVoorraad);
                    comOpslaan.Parameters.Add(parUitVoorraad);
                    comOpslaan.Parameters.Add(parPrijs);
                    comOpslaan.Parameters.Add(parTotaalVerhuurd);
                    comOpslaan.Parameters.Add(parBandNr);

                    conVideo.Open();
                    if (comOpslaan.ExecuteNonQuery() == 0)
                        throw new Exception("Opslaan mislukt");
                }
            }
        }

        public void FilmVerwijderen(Film film)
        {
            if (film.TotaalVerhuurd != 0)
            {
                VerhuurVerwijderen(film.BandNr);
            }

            var manager = new VideoDbManager();
            using (var conVideo = manager.GetConnection())
            {
                using (var comVerwijder = conVideo.CreateCommand())
                {
                    comVerwijder.CommandType = CommandType.Text;
                    comVerwijder.CommandText =
                        "delete from Films where BandNr=@BandNr";

                    var parBandNr = comVerwijder.CreateParameter();
                    parBandNr.ParameterName = "@BandNr";
                    parBandNr.Value = film.BandNr;
                    comVerwijder.Parameters.Add(parBandNr);

                    conVideo.Open();
                    if (comVerwijder.ExecuteNonQuery() == 0)
                        throw new Exception("Verwijderen mislukt");
                }
            }
        }

        private void VerhuurVerwijderen(int bandNr)
        {
            var manager = new VideoDbManager();
            using (var conVideo = manager.GetConnection())
            {
                using (var comVerwijder = conVideo.CreateCommand())
                {
                    comVerwijder.CommandType = CommandType.Text;
                    comVerwijder.CommandText =
                        "delete from Verhuur where BandNr=@BandNr";

                    var parBandNr = comVerwijder.CreateParameter();
                    parBandNr.ParameterName = "@BandNr";
                    parBandNr.Value = bandNr;
                    comVerwijder.Parameters.Add(parBandNr);

                    conVideo.Open();
                    if (comVerwijder.ExecuteNonQuery() == 0)
                        throw new Exception("Verwijderen mislukt");
                }
            }
        }

        public void FilmToevoegen(Film film)
        {
            var dbManager = new VideoDbManager();

            using (var conVideo = dbManager.GetConnection())
            {
                using (var comNieuweFilm = conVideo.CreateCommand())
                {
                    comNieuweFilm.CommandType = CommandType.Text;
                    comNieuweFilm.CommandText =
                        "insert into Films " +
                        "(Titel,genreNr,InVoorraad,UitVoorraad,Prijs,TotaalVerhuurd)" +
                        "VALUES (@Titel, @genreNr, @InVoorraad, @UitVoorraad, @Prijs, @TotaalVerhuurd)";

                    var parTitel = comNieuweFilm.CreateParameter();
                    var parGenre = comNieuweFilm.CreateParameter();
                    var parInVoorraad = comNieuweFilm.CreateParameter();
                    var parUitVoorraad = comNieuweFilm.CreateParameter();
                    var parPrijs = comNieuweFilm.CreateParameter();
                    var parTotaalVerhuurd = comNieuweFilm.CreateParameter();
                    var parBandNr = comNieuweFilm.CreateParameter();

                    parTitel.ParameterName = "@Titel";
                    parGenre.ParameterName = "@genreNr";
                    parInVoorraad.ParameterName = "@InVoorraad";
                    parUitVoorraad.ParameterName = "@UitVoorraad";
                    parPrijs.ParameterName = "@Prijs";
                    parTotaalVerhuurd.ParameterName = "@TotaalVerhuurd";
                    parBandNr.ParameterName = "@BandNr";


                    comNieuweFilm.Parameters.Add(parTitel);
                    comNieuweFilm.Parameters.Add(parGenre);
                    comNieuweFilm.Parameters.Add(parInVoorraad);
                    comNieuweFilm.Parameters.Add(parUitVoorraad);
                    comNieuweFilm.Parameters.Add(parPrijs);
                    comNieuweFilm.Parameters.Add(parTotaalVerhuurd);
                    comNieuweFilm.Parameters.Add(parBandNr);

                    conVideo.Open();

                    parTitel.Value = film.Titel;
                    parGenre.Value = film.Genre;
                    parInVoorraad.Value = film.InVoorraad;
                    parUitVoorraad.Value = 0;
                    parPrijs.Value = film.Prijs;
                    parTotaalVerhuurd.Value = 0;
                    parBandNr.Value = film.BandNr;

                    if (comNieuweFilm.ExecuteNonQuery() == 0)
                        throw new Exception("Opslaan mislukt");
                }
            }
        }
    }
}