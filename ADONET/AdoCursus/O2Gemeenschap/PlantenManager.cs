using System;
using System.Collections.Generic;
using System.Data;

namespace TuinCentrumGemeenschap
{
    public class PlantenManager
    {
        

        public decimal GemiddeldeSoortprijsRaadplegen(string soortNaam)
        {
            var dbManager = new TuincentrumDbManager();
            using (var conTuincentrum = dbManager.GetConnection())
            {
                using (var comAvr = conTuincentrum.CreateCommand())
                {
                    comAvr.CommandType = CommandType.StoredProcedure;
                    comAvr.CommandText = "GemiddeldeSoortprijsRaadplegen";
                    var parSoort = comAvr.CreateParameter();
                    parSoort.ParameterName = "@soort";
                    parSoort.Value = soortNaam;
                    comAvr.Parameters.Add(parSoort);
                    conTuincentrum.Open();
                    var resultaat = comAvr.ExecuteScalar();
                    if (resultaat == null)
                    {
                        throw new Exception("Soort bestaat niet");
                    }
                    return (decimal) resultaat;
                }
            }
        }

        public PlantInfo PlantInfoOpvragen(int plantNr)
        {
            var dbManager = new TuincentrumDbManager();
            using (var conTuincentrum = dbManager.GetConnection())
            {
                using (var comInfo = conTuincentrum.CreateCommand())
                {
                    comInfo.CommandType = CommandType.StoredProcedure;
                    comInfo.CommandText = "plantInfoOpvragen";

                    var parPlantNr = comInfo.CreateParameter();
                    parPlantNr.ParameterName = "@plantNr";
                    parPlantNr.Value = plantNr;

                    var parNaam = comInfo.CreateParameter();
                    parNaam.ParameterName = "@naam";
                    parNaam.DbType = DbType.String;
                    parNaam.Size = 50;
                    parNaam.Direction = ParameterDirection.Output;

                    var parSoort = comInfo.CreateParameter();
                    parSoort.ParameterName = "@soort";
                    parSoort.DbType = DbType.String;
                    parSoort.Size = 50;
                    parSoort.Direction = ParameterDirection.Output;

                    var parLeverancier = comInfo.CreateParameter();
                    parLeverancier.ParameterName = "@leverancier";
                    parLeverancier.DbType = DbType.String;
                    parLeverancier.Size = 50;
                    parLeverancier.Direction = ParameterDirection.Output;

                    var parKleur = comInfo.CreateParameter();
                    parKleur.ParameterName = "@kleur";
                    parKleur.DbType = DbType.String;
                    parKleur.Size = 50;
                    parKleur.Direction = ParameterDirection.Output;

                    var parKostprijs = comInfo.CreateParameter();
                    parKostprijs.ParameterName = "@kostprijs";
                    parKostprijs.DbType = DbType.Decimal;
                    parKostprijs.Direction = ParameterDirection.Output;

                    comInfo.Parameters.Add(parPlantNr);
                    comInfo.Parameters.Add(parNaam);
                    comInfo.Parameters.Add(parSoort);
                    comInfo.Parameters.Add(parLeverancier);
                    comInfo.Parameters.Add(parKleur);
                    comInfo.Parameters.Add(parKostprijs);

                    conTuincentrum.Open();
                    comInfo.ExecuteNonQuery();
                    if (parKostprijs.Value.Equals(DBNull.Value))
                    {
                        throw new Exception("Plant bestaat niet");
                    }
                    return new PlantInfo((string) parNaam.Value, (string) parSoort.Value, (string) parLeverancier.Value,
                        (string) parKleur.Value, (decimal) parKostprijs.Value);
                }
            }
        }

        
    }
}