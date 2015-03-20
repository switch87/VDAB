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
using System.Media;

namespace Telefoon
{
    /// <summary>
    /// Interaction logic for TelefoonWindow.xaml
    /// </summary>
    public partial class TelefoonWindow : Window
    {
        public TelefoonWindow()
        {
            InitializeComponent();
        }

        public List<Persoon> Personen = new List<Persoon>();

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            Personen.Add(new Persoon("Anne", "0475888888", "Vrienden", new BitmapImage(new Uri(@"images\anne.jpg", UriKind.Relative))));
            Personen.Add(new Persoon("Bob", "0495625896", "Vrienden", new BitmapImage(new Uri(@"images\bob.jpg", UriKind.Relative))));
            Personen.Add(new Persoon("Jonas", "012589575", "Werk", new BitmapImage(new Uri(@"images\collega1.jpg", UriKind.Relative))));
            Personen.Add(new Persoon("Yohanna", "012557453", "Werk", new BitmapImage(new Uri(@"images\collega2.jpg", UriKind.Relative))));
            Personen.Add(new Persoon("Ronny", "089256242", "Werk", new BitmapImage(new Uri(@"images\collega3.jpg", UriKind.Relative))));
            Personen.Add(new Persoon("Ed", "0485653415", "Vrienden", new BitmapImage(new Uri(@"images\ed.jpg", UriKind.Relative))));
            Personen.Add(new Persoon("Grote zus", "0475242525", "Familie", new BitmapImage(new Uri(@"images\grotezus.jpg", UriKind.Relative))));
            Personen.Add(new Persoon("Kleine zus", "0496563258", "Familie", new BitmapImage(new Uri(@"images\kleinezus.jpg", UriKind.Relative))));
            Personen.Add(new Persoon("Tante non", "01185653525", "Familie", new BitmapImage(new Uri(@"images\tantenon.jpg", UriKind.Relative))));
            Personen.Add(new Persoon("Telefoon Boven", "#2", "Familie", new BitmapImage(new Uri(@"images\telefoon2.jpg", UriKind.Relative))));
            Personen.Add(new Persoon("Papa", "0473858802", "Familie", new BitmapImage(new Uri(@"images\vader.jpg", UriKind.Relative))));

            ComboboxCategorie.Items.Add("Alle Categorieën");
            ComboboxCategorie.Items.Add("Vrienden");
            ComboboxCategorie.Items.Add("Familie");
            ComboboxCategorie.Items.Add("Werk");
            ComboboxCategorie.SelectedIndex = 0;
        }


        private void ComboBoxCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxContacten.Items.Clear();
            foreach (Persoon p in Personen)
            {
                if (p.Groep == ComboboxCategorie.SelectedItem.ToString() || ComboboxCategorie.SelectedIndex == 0)
                {
                    ListBoxContacten.Items.Add(p);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxContacten.SelectedIndex == -1)
            {
                MessageBox.Show("Je moet eerst iemand selecteren", "Niemand gekozen", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                if (MessageBox.Show("Wil je " + ((Persoon)ListBoxContacten.SelectedItem).Naam + " bellen \nop het nummer: " + ((Persoon)ListBoxContacten.SelectedItem).Telefoonnr, "Telefoon", MessageBoxButton.YesNo, MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    //SoundPlayer speler = new SoundPlayer("PHONE.wav");
                    //speler.Play();
                }
        }
    }
}
