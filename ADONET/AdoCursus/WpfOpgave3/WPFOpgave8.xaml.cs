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
                var manager = new TuincentrumDbManager();
                listBoxInstanties.ItemsSource = manager.GetPlanten( Convert.ToInt32(comboBoxSoort.SelectedValue) );
                listBoxInstanties.DisplayMemberPath = "Naam";

            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message ); ;
            }
        }

        private void buttonOpslaan_Click( object sender, RoutedEventArgs e )
        {
            var manager = new TuincentrumDbManager();
            try
            {
                manager.GewijzigdePlantOpslaan((plant) listBoxInstanties.SelectedItem);
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}