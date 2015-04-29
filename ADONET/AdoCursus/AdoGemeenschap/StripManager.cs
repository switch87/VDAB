using System.Configuration;
using System.Data.Common;

public class StripManager
{
    private static readonly ConnectionStringSettings conStripSetting =
        ConfigurationManager.ConnectionStrings["strips"];

    private static readonly DbProviderFactory factory =
        DbProviderFactories.GetFactory(conStripSetting.ProviderName);

    public DbConnection GetConnection()
    {
        var conStrip = factory.CreateConnection();
        conStrip.ConnectionString = conStripSetting.ConnectionString;
        return conStrip;
    }
}