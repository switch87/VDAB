using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace TuinCentrumGemeenschap
{
    public class TuincentrumDbManager
    {
        private static ConnectionStringSettings _conTuincentrumSetting =
            ConfigurationManager.ConnectionStrings["Tuincentrum"];

        private static DbProviderFactory _factory =
            DbProviderFactories.GetFactory(_conTuincentrumSetting.ProviderName);

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

        public List<string> GetPlanten( int soortNr )
        {
            var planten = new List<string>();
            var manager = new TuincentrumDbManager();
            using ( var conTuinCentrum = manager.GetConnection() )
            {
                using ( var comPlanten = conTuinCentrum.CreateCommand() )
                {
                    comPlanten.CommandType = CommandType.Text;
                    comPlanten.CommandText = "select naam from planten where soortnr=@soortnr order by naam";
                    var parSoortNr = comPlanten.CreateParameter();
                    parSoortNr.ParameterName = "@soortnr";
                    parSoortNr.Value = soortNr;
                    comPlanten.Parameters.Add( parSoortNr );
                    conTuinCentrum.Open();
                    using ( var readerPlanten = comPlanten.ExecuteReader() )
                    {
                        while ( readerPlanten.Read() )
                        {
                            planten.Add( readerPlanten["naam"].ToString() );
                        }
                    }
                }
            }
            return planten;
        }
    }
}
