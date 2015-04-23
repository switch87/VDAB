using System.Configuration;
using System.Data.Common;

namespace AdoGemeenschap
{
    internal class BankDbManager
    {
        private static readonly ConnectionStringSettings ConBankSetting =
            ConfigurationManager.ConnectionStrings["Bank"];

        private static readonly DbProviderFactory Factory =
            DbProviderFactories.GetFactory(ConBankSetting.ProviderName);

        public DbConnection GetConnection()
        {
            var conBank = Factory.CreateConnection();
            // ReSharper disable once PossibleNullReferenceException
            conBank.ConnectionString = ConBankSetting.ConnectionString;
            return conBank;
        }
    }
}