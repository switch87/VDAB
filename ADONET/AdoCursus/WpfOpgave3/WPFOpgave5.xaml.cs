using System;
using System.Windows;
using TuinCentrumGemeenschap;

namespace WpfOpgave3
{
    /// <summary>
    ///     Interaction logic for WPFOpgave5.xaml
    /// </summary>
    public partial class WPFOpgave5 : Window
    {
        public WPFOpgave5()
        {
            InitializeComponent();
        }

        private void butonBerekenGemiddelde_Click(object sender, RoutedEventArgs e)
        {
            var manager = new PlantenManager();
            try
            {
                labelGemiddelde.Content = "Gemiddelde prijs: € " +
                                          manager.GemiddeldeSoortprijsRaadplegen(textBoxSoort.Text);
            }
            catch (Exception ex)
            {
                labelGemiddelde.Content = ex.Message;
            }
        }
    }
}