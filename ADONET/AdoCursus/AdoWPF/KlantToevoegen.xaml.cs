using System;
using System.Windows;
using AdoGemeenschap;

namespace AdoWPF
{
    /// <summary>
    ///     Interaction logic for KlantToevoegen.xaml
    /// </summary>
    public partial class KlantToevoegen
    {
        public KlantToevoegen()
        {
            InitializeComponent();
        }

        private void ButtonToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new KlantenManager();
                LabelStatus.Content = manager.NieuweKlant(TextBoxNaam.Text).ToString();
            }
            catch (Exception ex)
            {
                LabelStatus.Content = ex.Message;
            }
        }
    }
}