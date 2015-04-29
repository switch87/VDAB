using System;
using System.Windows;
using TuinCentrumGemeenschap;

namespace WpfOpgave3
{
    /// <summary>
    ///     Interaction logic for WPFOpgave6.xaml
    /// </summary>
    public partial class WPFOpgave6 : Window
    {
        public WPFOpgave6()
        {
            InitializeComponent();
        }

        private void buttonOpzoeken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new PlantenManager();
                var info = manager.PlantInfoOpvragen(Convert.ToInt32(textBoxNummer.Text));
                labelNaam.Content = info.Naam;
                labelSoort.Content = info.Soort;
                labelKleur.Content = info.Kleur;
                labelLeverancier.Content = info.Leverancier;
                labelKostprijs.Content = info.Kostprijs.ToString("N");
            }
            catch (Exception ex)
            {

                labelNaam.Content = ex.Message;
            }
        }
    }
}