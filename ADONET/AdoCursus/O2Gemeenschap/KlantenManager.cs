using System;
using System.Data;

namespace TuinCentrumGemeenschap
{
    public class KlantenManager
    {
        public bool Klanttoevoegen(string naam, string adres, string postNr, string woonplaats)
        {
            var dbManager = new TuincentrumDbManager();

            using (var conTuincentrum = dbManager.GetConnection())
            {
                using (var comNieuweKlant = conTuincentrum.CreateCommand())
                {
                    comNieuweKlant.CommandType = CommandType.StoredProcedure;
                    comNieuweKlant.CommandText = "leverancierToevoegen";

                    var parNaam = comNieuweKlant.CreateParameter();
                    var parAdres = comNieuweKlant.CreateParameter();
                    var parPostNr = comNieuweKlant.CreateParameter();
                    var parWoonplaats = comNieuweKlant.CreateParameter();

                    parNaam.ParameterName = "@naam";
                    parAdres.ParameterName = "@adres";
                    parPostNr.ParameterName = "@postNr";
                    parWoonplaats.ParameterName = "@woonplaats";

                    parNaam.Value = naam;
                    parAdres.Value = adres;
                    parPostNr.Value = postNr;
                    parWoonplaats.Value = woonplaats;

                    comNieuweKlant.Parameters.Add(parNaam);
                    comNieuweKlant.Parameters.Add(parAdres);
                    comNieuweKlant.Parameters.Add(parPostNr);
                    comNieuweKlant.Parameters.Add(parWoonplaats);

                    conTuincentrum.Open();
                    return comNieuweKlant.ExecuteNonQuery() != 0;
                }
            }
        }

        public void VervangLeverancier(int oudLevNr, int nieuwLevNr)
        {
            var manager = new TuincentrumDbManager();
            using (var conTuin = manager.GetConnection())
            {
                conTuin.Open();
                using (var traVervangen =
                    conTuin.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    using (var comWijzigen = conTuin.CreateCommand())
                    {
                        comWijzigen.Transaction = traVervangen;
                        comWijzigen.CommandType = CommandType.StoredProcedure;
                        comWijzigen.CommandText = "LeverancierWijzigen";
                        var parOudLevNr = comWijzigen.CreateParameter();
                        parOudLevNr.ParameterName = "@OudLevNr";
                        parOudLevNr.Value = oudLevNr;
                        comWijzigen.Parameters.Add(parOudLevNr);
                        var parNieuwLevNr = comWijzigen.CreateParameter();
                        parNieuwLevNr.ParameterName = "@NieuwLevNr";
                        parNieuwLevNr.Value = nieuwLevNr;
                        comWijzigen.Parameters.Add(parNieuwLevNr);
                        if (comWijzigen.ExecuteNonQuery() == 0)
                        {
                            traVervangen.Rollback();
                            throw new Exception("Leverancier " + oudLevNr + " kon niet vervangen worden door " +
                                                nieuwLevNr);
                        }
                    }
                    using (var comVerwijderen = conTuin.CreateCommand())
                    {
                        comVerwijderen.Transaction = traVervangen;
                        comVerwijderen.CommandType = CommandType.StoredProcedure;
                        comVerwijderen.CommandText = "LeverancierVerwijderen";
                        var parLevNr = comVerwijderen.CreateParameter();
                        parLevNr.ParameterName = "@LevNr";
                        parLevNr.Value = oudLevNr;
                        comVerwijderen.Parameters.Add(parLevNr);
                        if (comVerwijderen.ExecuteNonQuery() == 0)
                        {
                            traVervangen.Rollback();
                            throw new Exception("Leverancier " + oudLevNr + " kon niet verwijderd worden");
                        }
                        traVervangen.Commit();
                    }
                }
            }
        }
    }
}