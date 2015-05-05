using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace TuinCentrumGemeenschap
{
    public class TuincentrumDbManager
    {
        private static readonly ConnectionStringSettings _conTuincentrumSetting =
            ConfigurationManager.ConnectionStrings["Tuincentrum"];

        private static readonly DbProviderFactory _factory =
            DbProviderFactories.GetFactory(_conTuincentrumSetting.ProviderName);

        public List<Leverancier> GetLeveranciersBeginNaam(string beginNaam)
        {
            var leveranciers = new List<Leverancier>();
            var manager = new TuincentrumDbManager();
            using (var conPlanten = manager.GetConnection())
            {
                using (var comLeveranciers = conPlanten.CreateCommand())
                {
                    comLeveranciers.CommandType = CommandType.Text;
                    if (beginNaam != string.Empty)
                    {
                        comLeveranciers.CommandText = "select * from leveranciers where naam like @zoals order by naam";
                        var parZoals = comLeveranciers.CreateParameter();
                        parZoals.ParameterName = "@zoals";
                        parZoals.Value = beginNaam + "%";
                        comLeveranciers.Parameters.Add(parZoals);
                    }
                    else comLeveranciers.CommandText = "select * from leveranciers";
                    conPlanten.Open();
                    using (var readerLeveranciers = comLeveranciers.ExecuteReader())
                    {
                        var levNrPos = readerLeveranciers.GetOrdinal("levnr");
                        var naamPos = readerLeveranciers.GetOrdinal("naam");
                        var adresPos = readerLeveranciers.GetOrdinal("adres");
                        var postcodePos = readerLeveranciers.GetOrdinal("postnr");
                        var gemeentePos = readerLeveranciers.GetOrdinal("woonplaats");

                        while (readerLeveranciers.Read())
                        {
                            leveranciers.Add(new Leverancier(readerLeveranciers.GetInt32(levNrPos),
                                readerLeveranciers.GetString(naamPos), readerLeveranciers.GetString(adresPos),
                                readerLeveranciers.GetString(postcodePos), readerLeveranciers.GetString(gemeentePos)));
                        }
                    }
                }
            }
            return leveranciers;
        }

        public DbConnection GetConnection()
        {
            var conTuincentrum = _factory.CreateConnection();
            conTuincentrum.ConnectionString = _conTuincentrumSetting.ConnectionString;
            return conTuincentrum;
        }

        public List<Soort> GetSoorten()
        {
            var soorten = new List<Soort>();
            var manager = new TuincentrumDbManager();
            using (var conTuincentrum = manager.GetConnection())
            {
                using (var comSoorten = conTuincentrum.CreateCommand())
                {
                    comSoorten.CommandType = CommandType.Text;
                    comSoorten.CommandText = "select SoortNr, Soort from Soorten order by soort";
                    conTuincentrum.Open();
                    using (var readerSoorten = comSoorten.ExecuteReader())
                    {
                        var soortPos = readerSoorten.GetOrdinal("soort");
                        var soortNrPos = readerSoorten.GetOrdinal("soortnr");
                        while (readerSoorten.Read())
                        {
                            soorten.Add(new Soort(readerSoorten.GetString(soortPos), readerSoorten.GetInt32(soortNrPos)));
                        }
                    }
                }
            }
            return soorten;
        }

        public List<plant> GetPlanten(int soortNr)
        {
            var planten = new List<plant>();
            var manager = new TuincentrumDbManager();
            using (var conTuinCentrum = manager.GetConnection())
            {
                using (var comPlanten = conTuinCentrum.CreateCommand())
                {
                    comPlanten.CommandType = CommandType.Text;
                    comPlanten.CommandText =
                        "select plantnr, naam, levnr, verkoopprijs, kleur from planten where soortnr=@soortnr order by naam";
                    var parSoortNr = comPlanten.CreateParameter();
                    parSoortNr.ParameterName = "@soortnr";
                    parSoortNr.Value = soortNr;
                    comPlanten.Parameters.Add(parSoortNr);
                    conTuinCentrum.Open();
                    using (var readerPlanten = comPlanten.ExecuteReader())
                    {
                        var plantNaamPos = readerPlanten.GetOrdinal("Naam");
                        var plantNrPos = readerPlanten.GetOrdinal("plantnr");
                        var levNrPos = readerPlanten.GetOrdinal("Levnr");
                        var prijsPos = readerPlanten.GetOrdinal("VerkoopPrijs");
                        var kleurPos = readerPlanten.GetOrdinal("Kleur");

                        while (readerPlanten.Read())
                        {
                            planten.Add(new plant(readerPlanten.GetString(plantNaamPos),
                                readerPlanten.GetInt32(plantNrPos), readerPlanten.GetInt32(levNrPos),
                                readerPlanten.GetDecimal(prijsPos), readerPlanten.GetString(kleurPos)));
                        }
                    }
                }
            }
            return planten;
        }

        public void GewijzigdePlantOpslaan(plant plant)
        {
            var manager = new TuincentrumDbManager();
            using (var conTuinCentrum = manager.GetConnection())
            {
                using (var comOpslaan = conTuinCentrum.CreateCommand())
                {
                    comOpslaan.CommandType = CommandType.Text;
                    comOpslaan.CommandText =
                        "update planten set Kleur=@kleur,verkoopprijs=@prijs where plantnr=@plantnr";
                    var parKleur = comOpslaan.CreateParameter();
                    var parPrijs = comOpslaan.CreateParameter();
                    var parplantnr = comOpslaan.CreateParameter();

                    parKleur.ParameterName = "@kleur";
                    parPrijs.ParameterName = "@prijs";
                    parplantnr.ParameterName = "@plantnr";

                    parKleur.Value = plant.Kleur;
                    parplantnr.Value = plant.PlantNr;
                    parPrijs.Value = plant.Prijs;

                    comOpslaan.Parameters.Add(parplantnr);
                    comOpslaan.Parameters.Add(parKleur);
                    comOpslaan.Parameters.Add(parPrijs);

                    conTuinCentrum.Open();
                    if (comOpslaan.ExecuteNonQuery() == 0)
                        throw new Exception("Opslaan mislukt");
                }
            }
        }
    }
}