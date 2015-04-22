using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuinCentrumGemeenschap
{
    public class KlantenManager
    {
        public Boolean Klanttoevoegen(string naam, string adres, string postNr, string woonplaats)
        {
            var dbManager = new TuincentrumDbManager();

            using ( var conTuincentrum = dbManager.GetConnection() )
            {
                using ( var comNieuweKlant = conTuincentrum.CreateCommand() )
                {
                    comNieuweKlant.CommandType = System.Data.CommandType.StoredProcedure;
                    comNieuweKlant.CommandText = "leverancierToevoegen";

                    DbParameter parNaam = comNieuweKlant.CreateParameter();
                    DbParameter parAdres = comNieuweKlant.CreateParameter();
                    DbParameter parPostNr = comNieuweKlant.CreateParameter();
                    DbParameter parWoonplaats = comNieuweKlant.CreateParameter();

                    parNaam.ParameterName = "@naam";
                    parAdres.ParameterName = "@adres";
                    parPostNr.ParameterName = "@postNr";
                    parWoonplaats.ParameterName = "@woonplaats";

                    parNaam.Value = naam;
                    parAdres.Value = adres;
                    parPostNr.Value = postNr;
                    parWoonplaats.Value = woonplaats;

                    comNieuweKlant.Parameters.Add( parNaam );
                    comNieuweKlant.Parameters.Add( parAdres );
                    comNieuweKlant.Parameters.Add( parPostNr );
                    comNieuweKlant.Parameters.Add( parWoonplaats );

                    conTuincentrum.Open();
                    return comNieuweKlant.ExecuteNonQuery() != 0;
                }
            }
        }
    }
}
