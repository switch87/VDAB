using System;
using System.Windows;
using AdoGemeenschap;

namespace AdoWPF
{
    /// <summary>
    ///     Interaction logic for Overschrijven.xaml
    /// </summary>
    public partial class Overschrijven : Window
    {
        public Overschrijven()
        {
            InitializeComponent();
        }

        private void buttonOverschrijven_Click(object sender, RoutedEventArgs e)
        {
            decimal bedrag;
            if (decimal.TryParse(textBoxBedrag.Text, out bedrag))
            {
                try
                {
                    var manager = new RekeningenManager();
                    manager.Overschrijven(bedrag, textBoxVanRekNr.Text, textBoxNaarRekNr.Text);
                    labelStatus.Content = "OK";
                }
                catch (Exception ex)
                {
                    labelStatus.Content = ex.Message;
                }
            }
            else
            {
                labelStatus.Content = "bedrag bevat geen getal";
            }
        }
    }
}