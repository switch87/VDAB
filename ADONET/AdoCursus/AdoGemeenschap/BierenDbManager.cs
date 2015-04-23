using System.Configuration;
using System.Data.Common;

namespace AdoGemeenschap
{
    public class BierenDbManager
    {
        private static readonly ConnectionStringSettings ConBierenSetting =
            ConfigurationManager.ConnectionStrings["Bieren"];

        private static readonly DbProviderFactory Factory = DbProviderFactories.GetFactory(ConBierenSetting.ProviderName);

        public DbConnection GetConnection()
        {
            var conBieren = Factory.CreateConnection();
            // ReSharper disable once PossibleNullReferenceException
            conBieren.ConnectionString = ConBierenSetting.ConnectionString;
            return conBieren;
        }
    }
}