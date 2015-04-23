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
            if (decimal.TryParse(TextBoxBedrag.Text, out bedrag))
            {
                try
                {
                    var manager = new RekeningenManager();
                    manager.Overschrijven(bedrag, TextBoxVanRekNr.Text, TextBoxNaarRekNr.Text);
                    LabelStatus.Content = "OK";
                }
                catch (Exception ex)
                {
                    LabelStatus.Content = ex.Message;
                }
            }
            else
            {
                LabelStatus.Content = "bedrag bevat geen getal";
            }
        }
    }
}