using System;
using System.Windows;
using TuinCentrumGemeenschap;

namespace WpfOpgave3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
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
                if ( manager.Klanttoevoegen( NaamBox.Text, AdresBox.Text, PostNrBox.Text, WoonplaatsBox.Text ) )
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

        private void buttonVervang_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                var tuinManager = new KlantenManager();
                tuinManager.VervangLeverancier( 2, 3 );
                LabelStatus.Content = "Leverancier 2 is verwijderd en vervangen door 3";
            }
            catch ( Exception ex )
            {
                LabelStatus.Content = ex.Message;
            }
        }
    }
}
