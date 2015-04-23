using System;
using System.Windows;
using AdoGemeenschap;

namespace AdoWPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonBieren_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new BierenDbManager();
                using (var conBieren = manager.GetConnection())
                {
                    conBieren.Open();
                    LabelStatus.Content = "Bieren geopend";
                }
            }
            catch (Exception ex)
            {
                LabelStatus.Content = ex.Message;
            }
        }

        private void buttonBonus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new RekeningenManager();
                LabelStatus.Content = manager.SaldoBonus() + " rekeningen aangepast";
            }
            catch (Exception ex)
            {
                LabelStatus.Content = ex.Message;
            }
        }

        private void buttonStorten_Click(object sender, RoutedEventArgs e)
        {
            decimal teStorten;
            if (decimal.TryParse(TextBoxTeStorten.Text, out teStorten))
            {
                try
                {
                    var manager = new RekeningenManager();
                    LabelStatus.Content = manager.Storten(teStorten, TextBoxRekeningNr.Text)
                        ? "OK"
                        : "Rekening niet gevonden";
                }
                catch (Exception ex)
                {
                    LabelStatus.Content = ex.Message;
                }
            }
            else
            {
                LabelStatus.Content = "Tik een getal bij het storten";
            }
        }
    }
}