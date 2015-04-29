using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using AdoGemeenschap;

namespace AdoWPF
{
    /// <summary>
    ///     Interaction logic for StripFiguren.xaml
    /// </summary>
    public partial class StripFiguren : Window
    {
        private List<Figuur> figuren = new List<Figuur>();

        public StripFiguren()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var figuurViewSource =
                ((CollectionViewSource)
                    (FindResource("figuurViewSource")));
            var manager = new FiguurManager();
            figuren = manager.GetFiguren();
            figuurViewSource.Source = figuren;
        }

        public List<Figuur> GewijzigdeFiguren = new List<Figuur>();
        private void figuurDataGrid_RowEditEnding( object sender,
        DataGridRowEditEndingEventArgs e )
        {
            object o =
            figuurDataGrid.ItemContainerGenerator.ItemFromContainer( e.Row );
            if ( figuren.Contains( o ) )
            {
                GewijzigdeFiguren.Add( (Figuur)figuurDataGrid.ItemContainerGenerator.
                ItemFromContainer( e.Row ) );
            }
        }

        private void buttonSave_Click( object sender, RoutedEventArgs e )
        {
            var manager = new FiguurManager();
            if ( GewijzigdeFiguren.Count() != 0 )
            {
                manager.SchrijfWijzigingen( GewijzigdeFiguren );
            }
        }


    }
}