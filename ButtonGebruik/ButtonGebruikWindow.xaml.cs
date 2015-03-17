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

namespace ButtonGebruik
{
    /// <summary>
    /// Interaction logic for ButtonGebruikWindow.xaml
    /// </summary>
    public partial class ButtonGebruikWindow : Window
    {
        public ButtonGebruikWindow()
        {
            InitializeComponent();
        }

        private void ButtonBold_Checked(object sender, RoutedEventArgs e)
        {
            LabelTekst.FontWeight = FontWeights.Bold;
        }

        private void ButtonBold_Unchecked(object sender, RoutedEventArgs e)
        {
            LabelTekst.FontWeight = FontWeights.Normal;
        }

        private void ButtonItalic_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonItalic.IsChecked == true)
                LabelTekst.FontStyle = FontStyles.Italic;
            else
                LabelTekst.FontStyle = FontStyles.Normal;
        }

    }
}
