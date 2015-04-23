using System.Configuration;
using System.Data.Common;

namespace AdoGemeenschap
{
    public class Bank2DbManager
    {
        private static readonly ConnectionStringSettings ConBankSetting =
            ConfigurationManager.ConnectionStrings["Bank2"];

        private static readonly DbProviderFactory Factory = DbProviderFactories.GetFactory(ConBankSetting.ProviderName);

        public DbConnection GetConnection()
        {
            var conBank = Factory.CreateConnection();
            // ReSharper disable once PossibleNullReferenceException
            conBank.ConnectionString = ConBankSetting.ConnectionString;
            return conBank;
        }
    }
}