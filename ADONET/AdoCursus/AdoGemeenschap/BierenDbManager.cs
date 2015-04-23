using System.Configuration;
using System.Data.Common;

namespace AdoGemeenschap
{
    public class BierenDbManager
    {
        private static readonly ConnectionStringSettings conBierenSetting =
            ConfigurationManager.ConnectionStrings["Bieren"];

        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory(conBierenSetting.ProviderName);

        public DbConnection GetConnection()
        {
            var conBieren = factory.CreateConnection();
            conBieren.ConnectionString = conBierenSetting.ConnectionString;
            return conBieren;
        }
    }
}