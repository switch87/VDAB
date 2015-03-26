﻿using System;
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
using System.Reflection;

namespace BloemSamenstelling
{
    /// <summary>
    /// Interaction logic for BloemWindow.xaml
    /// </summary>
    public partial class BloemWindow : Window
    {
         public BloemWindow()
        {
            InitializeComponent();
            foreach (PropertyInfo info in typeof(Colors).GetProperties())
            {
                BrushConverter bc = new BrushConverter();
                SolidColorBrush deKleur = (SolidColorBrush)bc.ConvertFromString(info.Name);
                Kleur kleurke = new Kleur();
                kleurke.Borstel = deKleur;
                kleurke.Naam = info.Name;
                kleurke.Hex = deKleur.ToString();
                kleurke.Rood = deKleur.Color.R;
                kleurke.Groen = deKleur.Color.G;
                kleurke.Blauw = deKleur.Color.B;
                cirkelsKleuren.Items.Add(kleurke);
                cirkelKaderKleuren.Items.Add(kleurke);
                rechthoekenKleuren.Items.Add(kleurke);
                rechthoekKaderKleuren.Items.Add(kleurke);
                if (kleurke.Naam == "Black")
                {
                    cirkelsKleuren.SelectedItem = kleurke;
                    cirkelKaderKleuren.SelectedItem = kleurke;
                    rechthoekenKleuren.SelectedItem = kleurke;
                    rechthoekKaderKleuren.SelectedItem = kleurke;
                }
            }
        }
    }
}
