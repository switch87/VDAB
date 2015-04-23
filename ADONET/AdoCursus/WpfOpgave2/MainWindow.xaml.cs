using System;
using System.Windows;
using TuinCentrumGemeenschap;

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
