using System.Configuration;
using System.Data.Common;

namespace AdoGemeenschap
{
    internal class BankDbManager
    {
        private static readonly ConnectionStringSettings conBankSetting =
            ConfigurationManager.ConnectionStrings["Bank"];

        private static readonly DbProviderFactory factory =
            DbProviderFactories.GetFactory(conBankSetting.ProviderName);

        public DbConnection GetConnection()
        {
            var conBank = factory.CreateConnection();
            conBank.ConnectionString = conBankSetting.ConnectionString;
            return conBank;
        }
    }
}