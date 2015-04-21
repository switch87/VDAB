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
using System.Configuration;
using System.Data.Common;
using O2Gemeenschap;

namespace WpfOpgave2
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

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                var manager = new TuincentrumDbManager();
                using ( var conTuinCentrum = manager.GetConnection() )
                {
                    conTuinCentrum.Open();
                    LabelStatus.Content = "Tuincentrum geopend";
                }
            }
            catch ( Exception ex )
            {
                LabelStatus.Content = ex.Message;
            }
        }
    }
}
