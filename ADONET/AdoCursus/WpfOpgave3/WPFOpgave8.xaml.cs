using System;
using System.Windows;
using System.Windows.Controls;
using TuinCentrumGemeenschap;

namespace WpfOpgave3
{
    /// <summary>
    ///     Interaction logic for WPFOpgave8.xaml
    /// </summary>
    public partial class WPFOpgave8 : Window
    {
        public WPFOpgave8()
        {
            InitializeComponent();
        }

        private void WPFOpgave8_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var tuincentrumManager = new TuincentrumDbManager();
                comboBoxSoort.DisplayMemberPath = "SoortNaam";
                comboBoxSoort.SelectedValuePath = "SoortNr";
                comboBoxSoort.ItemsSource = tuincentrumManager.GetSoorten();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ComboBoxSoort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                listBoxInstanties.Items.Clear();
                var soortNr = ((Soort)comboBoxSoort.SelectedItem).SoortNr;
                var Manager = new TuincentrumDbManager();
                var plantInstanties = Manager.GetPlanten( soortNr );
                foreach (var plant in plantInstanties)
                {
                    listBoxInstanties.Items.Add(plant);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message ); ;
            }
        }
    }
}