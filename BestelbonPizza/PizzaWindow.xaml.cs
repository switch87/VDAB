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

namespace BestelbonPizza
{
    /// <summary>
    /// Interaction logic for PizzaWindow.xaml
    /// </summary>
    public partial class PizzaWindow : Window
    {

        public string maat = "medium";
        public int AantalInt = 1;
        public PizzaWindow()
        {
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bestelling.Text = "U heeft "+AantalInt+" "+maat+ " pizza(\'s) besteld met: ";
            foreach(CheckBox x in Beleg.Children)
            {
                if (x.IsChecked == true) bestelling.Text += x.Content+" ";
            }
            if (ExtraDikkeKorst.IsChecked == true) bestelling.Text += "met extra dikke korst ";
            if (ExtraKaas.IsChecked == true) bestelling.Text += "met extra kaas ";

        }


        private void Maat_Checked(object sender, RoutedEventArgs e)
        {
            maat = (string)((RadioButton)sender).Content;
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            Aantal.Content=++AantalInt;
            Min.IsEnabled = true;
        }

        private void min_Click(object sender, RoutedEventArgs e)
        {
            if (AantalInt > 1)
            {
                Aantal.Content = --AantalInt;
                if (AantalInt == 1) ((Button)sender).IsEnabled = false;
            }
        }
    }
}
