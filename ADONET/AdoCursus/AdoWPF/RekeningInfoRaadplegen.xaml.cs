using System;
using System.Windows;
using AdoGemeenschap;

namespace AdoWPF
{
    /// <summary>
    ///     Interaction logic for RekeningInfoRaadplegen.xaml
    /// </summary>
    public partial class RekeningInfoRaadplegen : Window
    {
        public RekeningInfoRaadplegen()
        {
            InitializeComponent();
        }

        private void buttonInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new RekeningenManager();
                var info = manager.RekeningInfoRaadplegen(textBoxRekeningNr.Text);
                labelSaldo.Content = info.Saldo.ToString("N");
                labelKlantNaam.Content = info.Klantnaam;
                labelStatus.Content = string.Empty;
            }
            catch (Exception ex)
            {
                labelSaldo.Content = string.Empty;
                labelKlantNaam.Content = string.Empty;
                labelStatus.Content = string.Empty;
            }
        }
    }
}