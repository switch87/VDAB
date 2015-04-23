using System.Configuration;
using System.Data.Common;

namespace TuinCentrumGemeenschap
{
    public class TuincentrumDbManager
    {
        private static ConnectionStringSettings conTuincentrumSetting =
            ConfigurationManager.ConnectionStrings["Tuincentrum"];
        private static DbProviderFactory factory =
            DbProviderFactories.GetFactory( conTuincentrumSetting.ProviderName );

        public DbConnection GetConnection()
        {
            var conTuincentrum = factory.CreateConnection();
            conTuincentrum.ConnectionString = conTuincentrumSetting.ConnectionString;
            return conTuincentrum;
        }
    }
}
