using System;
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
    }
}