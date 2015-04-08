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

namespace TekstVerwerken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowText : Window
    {
        public WindowText()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlockAanmelding.TextWrapping = TextWrapping.Wrap;
            TextBlockAanmelding.Text = "Je probeerde aan te melden met: " +
                textBoxGebruikersnaam.Text + " en paswoord: " + psdBox.Password;
        }
    }
}
