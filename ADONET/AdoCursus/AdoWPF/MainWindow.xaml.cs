using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonBieren_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                // 2 schrijfwijzen voor connectie maken met sql-database

                //using ( var conBieren = new SqlConnection() )
                //{
                //    conBieren.ConnectionString =
                //    @"server=.\sqlexpress;database=Bieren;integrated security=true";

                using ( var conBieren = new SqlConnection() )
                {
                    ConnectionStringSettings conString =
                    ConfigurationManager.ConnectionStrings["Bieren"];
                    conBieren.ConnectionString = conString.ConnectionString;
                    conBieren.Open();
                    labelStatus.Content = "Bieren geopend";
                }
            }
            catch ( Exception ex )
            {
                labelStatus.Content = ex.Message;
            }
        }
    }
}
