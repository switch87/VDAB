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
using System.Windows.Shapes;
using TuinCentrumGemeenschap;

namespace WpfOpgave3
{
    /// <summary>
    /// Interaction logic for WPFOpgave5.xaml
    /// </summary>
    public partial class WPFOpgave5 : Window
    {
        public WPFOpgave5()
        {
            InitializeComponent();
        }

        private void butonBerekenGemiddelde_Click( object sender, RoutedEventArgs e )
        {
            var manager = new PlantenManager();
            try
            {
                labelGemiddelde.Content = "Gemiddelde prijs: € " +
                                          manager.GemiddeldeSoortprijsRaadplegen(textBoxSoort.Text).ToString();
            }
            catch (Exception ex)
            {
                
                labelGemiddelde.Content=ex.Message;
            }

        }
    }
}
