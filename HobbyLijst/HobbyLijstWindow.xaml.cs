﻿using System;
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
using System.ComponentModel;

namespace HobbyLijst
{
    /// <summary>
    /// Interaction logic for HobbyLijstWindow.xaml
    /// </summary>
    public partial class HobbyLijstWindow : Window
    {
        public HobbyLijstWindow()
        {
            InitializeComponent();
        }

        public List<Hobby> hobbies = new List<Hobby>();
        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            hobbies.Add(new Hobby("sport", "voetbal", 
                new BitmapImage(new Uri(@"images\voetbal.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("sport", "atletiek",
                new BitmapImage(new Uri(@"images\atletiek.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("sport", "basketbal",
                new BitmapImage(new Uri(@"images\basketbal.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("sport", "tennis",
                new BitmapImage(new Uri(@"images\tennis.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("sport", "turnen",
                new BitmapImage(new Uri(@"images\turnen.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("muziek", "trompet",
                new BitmapImage(new Uri(@"images\trompet.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("muziek", "drum",
                new BitmapImage(new Uri(@"images\drum.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("muziek", "gitaar",
                new BitmapImage(new Uri(@"images\gitaar.jpg", UriKind.Relative))));
            hobbies.Add(new Hobby("muziek", "piano",
                new BitmapImage(new Uri(@"images\piano.jpg", UriKind.Relative))));

            ComboBoxCategorie.Items.Add("- alle categorieën -");
            ComboBoxCategorie.Items.Add("muziek");
            ComboBoxCategorie.Items.Add("sport");
            ComboBoxCategorie.SelectedIndex = 0;
        }

        private void ComboBoxCategorie_SelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            ListBoxHobbies.Items.Clear();
            foreach (Hobby hob in hobbies)
            {
                if (hob.Categorie == ComboBoxCategorie.SelectedItem.ToString() || ComboBoxCategorie.SelectedIndex == 0)
                    ListBoxHobbies.Items.Add(hob);
            }
            ListBoxHobbies.Items.SortDescriptions.Add(new SortDescription("Activiteit", ListSortDirection.Ascending));
        }


    }

}
