using System.Configuration;
using System.Data.Common;

namespace TuinCentrumGemeenschap
{
    public class TuincentrumDbManager
    {
        private static ConnectionStringSettings _conTuincentrumSetting =
            ConfigurationManager.ConnectionStrings["Tuincentrum"];
        private static DbProviderFactory _factory =
            DbProviderFactories.GetFactory( _conTuincentrumSetting.ProviderName );

        public DbConnection GetConnection()
        {
            var conTuincentrum = _factory.CreateConnection();
            conTuincentrum.ConnectionString = _conTuincentrumSetting.ConnectionString;
            return conTuincentrum;
        }
    }
}
