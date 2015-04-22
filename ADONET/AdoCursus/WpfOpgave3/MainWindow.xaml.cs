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
using TuinCentrumGemeenschap;

namespace WpfOpgave3
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

        private void Toevoegen_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                var manager = new KlantenManager();
                if ( manager.Klanttoevoegen( naamBox.Text, adresBox.Text, postNrBox.Text, woonplaatsBox.Text ) )
                {
                    LabelStatus.Content = "Nieuwe klant toegevoegd";
                }
                else LabelStatus.Content = "Nieuwe klant NIET toegevoegd";
            }
            catch ( Exception ex )
            {
                LabelStatus.Content = ex.Message;
            }
        }
    }
}
