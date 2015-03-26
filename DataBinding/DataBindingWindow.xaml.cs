using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DataBindingWindow : Window
    {
        public Persoon persoon = new Persoon("Jan");
        
        public DataBindingWindow()
        {
            InitializeComponent();
            SortDescription sd = new SortDescription("Source", ListSortDirection.Ascending);
            lettertypeComboBox.Items.SortDescriptions.Add(sd);
            lettertypeComboBox.SelectedItem = new FontFamily("Arial");
            veranderTextBox.DataContext = persoon;
        }

        private void toonNaamButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(persoon.Naam);
        }

        private void veranderButton_Click(object sender, RoutedEventArgs e)
        {
            persoon.Naam = "piet";
        }
    }

    public class Persoon : INotifyPropertyChanged
    {
        private string naamValue;
        public string Naam 
        {
            get
            {
                return naamValue;
            }
            set
            {
                naamValue = value;
                RaisePropertyChanged("Naam");
            }
        }
        public Persoon(string nNaam)
        {
            Naam = nNaam;
        }

        private void RaisePropertyChanged(String info)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
