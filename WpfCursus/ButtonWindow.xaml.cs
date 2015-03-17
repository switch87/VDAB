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

namespace WpfCursus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ButtonWindow : Window
    {
        public ButtonWindow()
        {
            InitializeComponent();
        }

        private void ButtonRed_Click(object sender, RoutedEventArgs e)
        {
            this.gridje.Background = new SolidColorBrush(Colors.Red);
        }

        private void ButtonGreen_Click(object sender, RoutedEventArgs e)
        {
            this.gridje.Background = new SolidColorBrush(Colors.Green);
        }

        private void ButtonBlue_Click(object sender, RoutedEventArgs e)
        {
            this.gridje.Background = new SolidColorBrush(Colors.Blue);
        }
    }
}
