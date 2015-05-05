using System;
using System.Windows;
using System.Windows.Controls;
using VideoGemeenschap;

namespace Videotheek
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _toevoegen;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Update()
        {
            var videoManager = new VideoDbManager();
            ListBoxFilms.ItemsSource = videoManager.GetFilms();
            ListBoxFilms.DisplayMemberPath = "Titel";
            ListBoxFilms.SelectedIndex = 0;

            ComboBoxGenres.ItemsSource = videoManager.GetGenres();
            ComboBoxGenres.DisplayMemberPath = "GenreNaam";

            ComboBoxGenres.SelectedIndex = ((Film) ListBoxFilms.SelectedItem).Genre - 1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _toevoegen = false;
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonWijzigingenOpslaan_Click(object sender, RoutedEventArgs e)

        {
            if (!_toevoegen)
            {
                var manager = new VideoDbManager();
                try
                {
                    var film = (Film) ListBoxFilms.SelectedItem;
                    film.Genre = ComboBoxGenres.SelectedIndex + 1;
                    film.InVoorraad = int.Parse(TextBoxInVoorraad.Text);
                    film.Prijs = decimal.Parse(TextBoxPrijs.Text)/100;
                        // Delen door 100 om te werken met de format in de xaml
                    film.Titel = TextBoxTitel.Text;
                    manager.GewijzigdeFilmOpslaan(film);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    var manager = new VideoDbManager();
                    var film = new Film
                    {
                        Genre = ComboBoxGenres.SelectedIndex + 1,
                        InVoorraad = int.Parse(TextBoxInVoorraad.Text),
                        Prijs = decimal.Parse(TextBoxPrijs.Text)/100,
                            // Delen door 100 om te werken met de format in de xaml
                        Titel = TextBoxTitel.Text
                    };
                    ;
                    manager.FilmToevoegen(film);
                    VeranderButtons();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ButtonToevoegen_Click(object sender, RoutedEventArgs e)
        {
            VeranderButtons();
        }

        private void VeranderButtons()
        {
            _toevoegen = !_toevoegen;
            Update();
            if (_toevoegen)
            {
                ListBoxFilms.SelectedIndex = -1;
                ListBoxFilms.IsEnabled = false;
                ButtonToevoegen.Content = "_toevoegen annuleren";
                ButtonVerwijderen.IsEnabled = false;
                ButtonWijzigingenOpslaan.Content = "Nieuwe film opslaan";
            }
            else
            {
                ListBoxFilms.SelectedIndex = 0;
                ListBoxFilms.IsEnabled = true;
                ButtonToevoegen.Content = "_toevoegen";
                ButtonVerwijderen.IsEnabled = true;
                ButtonWijzigingenOpslaan.Content = "Wijzigingen opslaan";
            }
        }

        private void ButtonVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            var vraag = MessageBox.Show("Weet u zeker dat u deze film wit verwijderen?", "Verwijdewren",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question, MessageBoxResult.No);
            if (vraag != MessageBoxResult.Yes) return;
            try
            {
                var selectedIndex = ListBoxFilms.SelectedIndex;
                var manager = new VideoDbManager();
                manager.FilmVerwijderen((Film) ListBoxFilms.SelectedItem);
                Update();
                ListBoxFilms.SelectedIndex = selectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListBoxFilms_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxGenres.SelectedIndex = ((Film) ListBoxFilms.SelectedItem) != null
                ? ((Film) ListBoxFilms.SelectedItem).Genre - 1
                : 0;
        }
    }
}