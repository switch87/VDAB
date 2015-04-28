﻿using System.Windows;
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
        private CollectionViewSource brouwerViewSource;

        public OverzichtBrouwers()
        {
            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            VulDeGrid();
            textBoxZoeken.Focus();
        }

        private void buttonZoeken_Click( object sender, RoutedEventArgs e )
        {
            VulDeGrid();
        }

        private void VulDeGrid()
        {
            brouwerViewSource = (CollectionViewSource)( this.FindResource( "brouwerViewSource" ) );
            var manager = new BrouwerManager();
            brouwerViewSource.Source = manager.GetBrouwersBeginNaam( textBoxZoeken.Text );
            goUpdate();
        }

        private void textBoxZoeken_KeyUp( object sender, KeyEventArgs e )
        {
            if ( e.Key == Key.Enter )
            {
                VulDeGrid();
            }
        }

        private void goToFirstButton_Click( object sender, RoutedEventArgs e )
        {
            brouwerViewSource.View.MoveCurrentToFirst();
            goUpdate();
        }

        private void goToPreviousButton_Click( object sender, RoutedEventArgs e )
        {
            brouwerViewSource.View.MoveCurrentToPrevious();
            goUpdate();
        }

        private void goToNextButton_Click( object sender, RoutedEventArgs e )
        {
            brouwerViewSource.View.MoveCurrentToNext();
            goUpdate();
        }

        private void goToLastButton_Click( object sender, RoutedEventArgs e )
        {
            brouwerViewSource.View.MoveCurrentToLast();
            goUpdate();
        }

        private void goUpdate()
        {
            goToPreviousButton.IsEnabled = !( brouwerViewSource.View.CurrentPosition == 0 );
            goToFirstButton.IsEnabled = !( brouwerViewSource.View.CurrentPosition == 0 );
            goToNextButton.IsEnabled =
                !( brouwerViewSource.View.CurrentPosition == brouwerDataGrid.Items.Count - 1 );
            goToLastButton.IsEnabled =
                !( brouwerViewSource.View.CurrentPosition == brouwerDataGrid.Items.Count - 1 );
            if ( brouwerDataGrid.Items.Count != 0 )
            {
                if ( brouwerDataGrid.SelectedItem != null )
                    brouwerDataGrid.ScrollIntoView( brouwerDataGrid.SelectedItem );
            }
        }
    }
}