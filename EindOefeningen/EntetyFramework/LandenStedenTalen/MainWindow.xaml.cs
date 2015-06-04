using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LandenStedenTalen
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

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            using (var enteties = new LandenStedenTalenEntities())
            {
                ListBoxLanden.ItemsSource = (enteties.Landen.Select(land => land).OrderBy(land => land.Naam)).ToList();
                //ListBoxLanden.SelectedIndex = 0;
                var selectedLand = (Landen)ListBoxLanden.SelectedItem;

            }
            //FillStedenTalen();
        }

        private void FillStedenTalen()
        {

            if ( ListBoxLanden.SelectedItem != null )
            {

                //var selectedLand = (Landen)ListBoxLanden.SelectedItem;
                using ( var enteties = new LandenStedenTalenEntities() )
                {
                   var selectedLand = (Landen)ListBoxLanden.SelectedItem;
                    ListBoxSteden.ItemsSource =
                        ( enteties.Steden.Select( stad => stad )
                            .Where( stad => stad.LandCode == selectedLand.LandCode )
                            .OrderBy( stad => stad.Naam ) ).ToList();
                    //ListBoxTalen.ItemsSource =
                    //        ( selectedLand.Talen.Select( taal => taal ).OrderBy( taal => taal.Naam ) ).ToList();
                    ListBoxTalen.ItemsSource = selectedLand.Talen;
                } 
            }
        }

        private void ListBoxLanden_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillStedenTalen();
        }

        private void ButtonStadToevoegen_Click( object sender, RoutedEventArgs e )
        {
            var selectedLand = (Landen) ListBoxLanden.SelectedItem;
            if (TextBoxStad.Text == "")
            {
                MessageBox.Show( "De textbox is leeg", "fout bij stad toevoegen", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else if (selectedLand == null)
            {
                MessageBox.Show( "Er is geen land geselecteerd", "fout bij stad toevoegen", MessageBoxButton.OK,
                    MessageBoxImage.Error );
            }
            else
            {
                var stad = new Steden() { Naam = TextBoxStad.Text, LandCode = selectedLand.LandCode };
                 
                using ( var enteties = new LandenStedenTalenEntities() )
                {
                    enteties.Steden.Add(stad);
                    enteties.SaveChanges();
                }
                FillStedenTalen();
                TextBoxStad.Text = "";
            }
        }
    }
}