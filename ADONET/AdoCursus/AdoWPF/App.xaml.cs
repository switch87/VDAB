using System.Windows;

namespace AdoWPF
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            const string connectionString = @"server=.\sqlexpress;database=Bieren;integrated security=true";
            Current.Properties["Bieren2"] = connectionString;
        }
    }
}