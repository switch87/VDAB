using System;
using System.Windows;
using AdoGemeenschap;

namespace AdoWPF
{
    /// <summary>
    ///     Interaction logic for SaldoRekeningRaadplegen.xaml
    /// </summary>
    public partial class SaldoRekeningRaadplegen
    {
        public SaldoRekeningRaadplegen()
        {
            InitializeComponent();
        }

        private void buttonSaldo_Click(object sender, RoutedEventArgs e)
        {
            var manager = new RekeningenManager();
            try
            {
                LabelStatus.Content = manager.SaldoRekeningRaadplegen(TextBoxRekeningNr.Text).ToString("N");
            }
            catch (Exception ex)
            {
                LabelStatus.Content = ex.Message;
            }
        }
    }
}