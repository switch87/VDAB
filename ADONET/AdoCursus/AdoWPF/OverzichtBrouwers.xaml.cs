using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using AdoGemeenschap;

namespace AdoWPF
{
    /// <summary>
    ///     Interaction logic for OverzichtBrouwers.xaml
    /// </summary>
    public partial class OverzichtBrouwers : Window
    {
        public ObservableCollection<Brouwer> brouwersOb =
            new ObservableCollection<Brouwer>();

        private CollectionViewSource brouwerViewSource;
        public List<Brouwer> GewijzigdeBrouwers = new List<Brouwer>();
        public List<Brouwer> NieuweBrouwers = new List<Brouwer>();
        public List<Brouwer> OudeBrouwers = new List<Brouwer>();

        public OverzichtBrouwers()
        {
            InitializeComponent();
        }

        private void brouwerDataGrid_RowEditEnding(object sender,
            DataGridRowEditEndingEventArgs e)
        {
            var o =
                brouwerDataGrid.ItemContainerGenerator.ItemFromContainer(e.Row);
            if (brouwersOb.Contains(o))
            {
                GewijzigdeBrouwers.Add((Brouwer) brouwerDataGrid.ItemContainerGenerator.
                    ItemFromContainer(e.Row));
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (Brouwer oudeBrouwer in e.OldItems)
                {
                    OudeBrouwers.Add(oudeBrouwer);
                }
            }
            if (e.NewItems != null)
            {
                foreach (Brouwer nieuweBrouwer in e.NewItems)
                {
                    NieuweBrouwers.Add(nieuweBrouwer);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulDeGrid();
            textBoxZoeken.Focus();
        }

        private void buttonZoeken_Click(object sender, RoutedEventArgs e)
        {
            VulDeGrid();
        }

        private void VulDeGrid()
        {
            int totalRowcount;
            brouwerViewSource = (CollectionViewSource) (FindResource("brouwerViewSource"));
            var manager = new BrouwerManager();
            brouwersOb = manager.GetBrouwersBeginNaam(textBoxZoeken.Text);
            totalRowcount = brouwersOb.Count();
            labelTotalRowCount.Content = totalRowcount;
            brouwerViewSource.Source = brouwersOb;
            goUpdate();
        }

        private void textBoxZoeken_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                VulDeGrid();
            }
        }

        private void goToFirstButton_Click(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToFirst();
            goUpdate();
        }

        private void goToPreviousButton_Click(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToPrevious();
            goUpdate();
        }

        private void goToNextButton_Click(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToNext();
            goUpdate();
        }

        private void goToLastButton_Click(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToLast();
            goUpdate();
        }

        private void goUpdate()
        {
            goToPreviousButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == 0);
            goToFirstButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == 0);
            goToNextButton.IsEnabled =
                !(brouwerViewSource.View.CurrentPosition == brouwerDataGrid.Items.Count - 2);
            goToLastButton.IsEnabled =
                !(brouwerViewSource.View.CurrentPosition == brouwerDataGrid.Items.Count - 2);
            if (brouwerDataGrid.Items.Count != 0)
            {
                if (brouwerDataGrid.SelectedItem != null)
                {
                    brouwerDataGrid.ScrollIntoView(brouwerDataGrid.SelectedItem);
                    listBoxBrouwers.ScrollIntoView(brouwerDataGrid.SelectedItem);
                }
            }
            textBoxGo.Text = (brouwerViewSource.View.CurrentPosition + 1).ToString();
        }

        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            int position;
            int.TryParse(textBoxGo.Text, out position);
            if (position > 0 && position <= brouwerDataGrid.Items.Count)
            {
                brouwerViewSource.View.MoveCurrentToPosition(position - 1);
            }
            else
            {
                MessageBox.Show("The input index is not valid.");
            }
            goUpdate();
        }

        private void brouwerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            goUpdate();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            var manager = new BrouwerManager();
            if (OudeBrouwers.Count() != 0)
            {
                manager.SchrijfVerwijderingen(OudeBrouwers);
                labelTotalRowCount.Content =
                    (int) labelTotalRowCount.Content - OudeBrouwers.Count();
            }
            OudeBrouwers.Clear();

            if (NieuweBrouwers.Count() != 0)
            {
                manager.SchrijfToevoegingen(NieuweBrouwers);
                labelTotalRowCount.Content =
                    (int) labelTotalRowCount.Content + NieuweBrouwers.Count();
            }
            NieuweBrouwers.Clear();

            if (GewijzigdeBrouwers.Count() != 0)
            {
                manager.SchrijfWijzigingen(GewijzigdeBrouwers);
            }
            GewijzigdeBrouwers.Clear();
        }
    }
}