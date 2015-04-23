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
                var info = manager.RekeningInfoRaadplegen(TextBoxRekeningNr.Text);
                LabelSaldo.Content = info.Saldo.ToString("N");
                LabelKlantNaam.Content = info.Klantnaam;
                LabelStatus.Content = string.Empty;
            }
            catch (Exception)
            {
                LabelSaldo.Content = string.Empty;
                LabelKlantNaam.Content = string.Empty;
                LabelStatus.Content = string.Empty;
            }
        }
    }
}