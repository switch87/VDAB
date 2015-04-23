using System.Configuration;
using System.Data.Common;

namespace AdoGemeenschap
{
    public class Bank2DbManager
    {
        private static readonly ConnectionStringSettings conBankSetting =
            ConfigurationManager.ConnectionStrings["Bank2"];

        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory(conBankSetting.ProviderName);

        public DbConnection GetConnection()
        {
            var conBank = factory.CreateConnection();
            conBank.ConnectionString = conBankSetting.ConnectionString;
            return conBank;
        }
    }
}