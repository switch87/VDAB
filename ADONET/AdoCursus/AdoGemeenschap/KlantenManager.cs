using System;
using System.Data;

namespace AdoGemeenschap
{
    public class KlantenManager
    {
        public long NieuweKlant( string naam )
        {
            var manager = new BankDbManager();
            using (var conBank = manager.GetConnection())
            {
                using (var comToevoegen = conBank.CreateCommand())
                {
                    comToevoegen.CommandType=CommandType.StoredProcedure;
                    comToevoegen.CommandText = "NieuweKlant";
                    var parNaam = comToevoegen.CreateParameter();
                    parNaam.ParameterName = "@Naam";
                    parNaam.Value = naam;
                    comToevoegen.Parameters.Add(parNaam);

                    conBank.Open();
                    var klantNr = Convert.ToInt64(comToevoegen.ExecuteScalar());
                    return klantNr;
                }
            }
        }
    }
}
