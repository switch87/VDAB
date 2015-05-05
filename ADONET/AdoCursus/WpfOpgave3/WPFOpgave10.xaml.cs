using System.Windows;
using System.Windows.Data;
using TuinCentrumGemeenschap;

namespace WpfOpgave3
{
    /// <summary>
    ///     Interaction logic for WPFOpgave10.xaml
    /// </summary>
    public partial class WPFOpgave10 : Window
    {
        public WPFOpgave10()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var leverancierViewSource =
                ((CollectionViewSource) (FindResource("leverancierViewSource")));
            var manager = new TuincentrumDbManager();
            leverancierViewSource.Source = manager.GetLeveranciersBeginNaam("gert");
        }
    }
}