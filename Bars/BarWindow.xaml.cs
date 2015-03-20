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
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;

namespace Bars
{
    /// <summary>
    /// Interaction logic for BarWindow.xaml
    /// </summary>
    public partial class BarWindow : Window
    {
        public static RoutedCommand mijnRouteCtrlB = new RoutedCommand();
        public static RoutedCommand mijnRouteCtrlI = new RoutedCommand();

        public BarWindow()
        {
            InitializeComponent();

            //CommandBinding mijnCtrlB = new CommandBinding(mijnRouteCtrlB, ctrlBExecuted);
            //this.CommandBindings.Add(mijnCtrlB);
            //KeyGesture toetsCtrlB = new KeyGesture(Key.B, ModifierKeys.Control);
            //KeyBinding mijnKeyCtrlB = new KeyBinding(mijnRouteCtrlB, toetsCtrlB);
            //this.InputBindings.Add(mijnKeyCtrlB);

            //CommandBinding mijnCtrlI = new CommandBinding(mijnRouteCtrlI, ctrlIExecuted);
            //this.CommandBindings.Add(mijnCtrlI);
            //KeyGesture toetsCtrlI = new KeyGesture(Key.I, ModifierKeys.Control);
            //KeyBinding mijnKeyCtrlI = new KeyBinding(mijnRouteCtrlI,toetsCtrlI)
            //this.InputBindings.Add(mijnKeyCtrlI);
        }

        private void ctrlBExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Vet_Aan_Uit();
        }

        private void ctrlIExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Schuin_Aan_Uit();
        }

        private void Vet_Aan_Uit()
        {
            if (TextBoxVoorbeeld.FontWeight==FontWeights.Normal)
            {
                TextBoxVoorbeeld.FontWeight = FontWeights.Bold;
                MenuVet.IsChecked = true;
                ButtonVet.IsChecked = true;
            }
            else
            {
                TextBoxVoorbeeld.FontWeight = FontWeights.Normal;
                MenuVet.IsChecked = false;
                ButtonVet.IsChecked = false;
            }
        }
        private void MenuVet_Click(object sender, RoutedEventArgs e)
        {
            Vet_Aan_Uit();
        }
        private void Schuin_Aan_Uit()
        {
            if (TextBoxVoorbeeld.FontStyle==FontStyles.Normal)
            {
                TextBoxVoorbeeld.FontStyle = FontStyles.Italic;
                MenuSchuin.IsChecked = true;
                ButtonSchuin.IsChecked = true;
            }
            else
            {
                TextBoxVoorbeeld.FontStyle = FontStyles.Normal;
                MenuSchuin.IsChecked = false;
                ButtonSchuin.IsChecked = false;
            }
        }
        private void MenuSchuin_Click(object sender, RoutedEventArgs e)
        {
            Schuin_Aan_Uit();
        }
        private void Lettertype_Click(object sender, RoutedEventArgs e)
        {
            MenuItem hetLettertype = (MenuItem)sender;
            foreach (MenuItem huidig in Fontjes.Items)
            {
                huidig.IsChecked = false;
            }
            hetLettertype.IsChecked = true;
            LettertypeComboBox.SelectedItem = new FontFamily(hetLettertype.Header.ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LettertypeComboBox.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Source", System.ComponentModel.ListSortDirection.Ascending));
            LettertypeComboBox.SelectedItem = new FontFamily(TextBoxVoorbeeld.FontFamily.ToString());
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "Document";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "text documents | *.txt";

                if (dlg.ShowDialog()==true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(LettertypeComboBox.SelectedValue);
                        bestand.WriteLine(TextBoxVoorbeeld.FontWeight.ToString());
                        bestand.WriteLine(TextBoxVoorbeeld.FontStyle.ToString());
                        bestand.WriteLine(TextBoxVoorbeeld.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan mislukt : " + ex.Message);
            }
        }

        private void OpenExecution(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "Document";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents |*.txt";

                if (dlg.ShowDialog()==true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        LettertypeComboBox.SelectedValue = new FontFamily(bestand.ReadLine());

                        TypeConverter convertBold = TypeDescriptor.GetConverter(typeof(FontWeight));
                        TextBoxVoorbeeld.FontWeight = (FontWeight)convertBold.ConvertFromString(bestand.ReadLine());
                        Vet_Aan_Uit(true);
                        TypeConverter convertStyle = TypeDescriptor.GetConverter(typeof(FontStyle));
                        TextBoxVoorbeeld.FontStyle = (FontStyle)convertStyle.ConvertFromString(bestand.ReadLine());
                        Schuin_Aan_Uit(true);

                        TextBoxVoorbeeld.Text = bestand.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("openen mislukt : " + ex.Message);
            }
        }

        private void Vet_Aan_Uit(Boolean wissel = false)
        {
            if ((wissel == true && TextBoxVoorbeeld.FontWeight == FontWeights.Bold) || (wissel == false && TextBoxVoorbeeld.FontWeight == FontWeights.Normal))
            {
                TextBoxVoorbeeld.FontWeight = FontWeights.Bold;
                MenuVet.IsChecked = true;
                StatusVet.FontWeight = FontWeights.Bold;
                ButtonVet.IsChecked = true;
            }
            else
            {
                TextBoxVoorbeeld.FontWeight = FontWeights.Normal;
                MenuVet.IsChecked = false;
                StatusVet.FontWeight = FontWeights.Normal;
                ButtonVet.IsChecked = false;

            }
        }

        private void Schuin_Aan_Uit(Boolean wissel = false)
        {
            if ((wissel == true
                    && TextBoxVoorbeeld.FontStyle == FontStyles.Italic)
                    || (wissel == false
                    && TextBoxVoorbeeld.FontStyle == FontStyles.Normal))
            {
                TextBoxVoorbeeld.FontStyle = FontStyles.Italic;
                MenuSchuin.IsChecked = true;
                ButtonSchuin.IsChecked = true;
                StatusSchuin.FontStyle = FontStyles.Italic;
            }
            else
            {
                TextBoxVoorbeeld.FontStyle = FontStyles.Normal;
                MenuSchuin.IsChecked = false;
                ButtonSchuin.IsChecked = false;
                StatusSchuin.FontStyle = FontStyles.Normal;
            }
        }

        private double A4breedte = 21 / 2.54 * 96;
        private double A4hoogte = 29.7 / 2.54 * 96;
        private double vertPositie;

        private FixedDocument StelAfdrukSamen()
        {
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new System.Windows.Size(A4breedte, A4hoogte);

            PageContent inhoud = new PageContent();
            document.Pages.Add(inhoud);
            FixedPage page = new FixedPage();
            inhoud.Child = page;

            page.Width = A4breedte;
            page.Height = A4hoogte;
            vertPositie = 96;

            page.Children.Add(Regel("Gerbruikt lettertype : " + TextBoxVoorbeeld.FontFamily.ToString()));
            page.Children.Add(Regel("gewicht van het lettertype : " + TextBoxVoorbeeld.FontWeight.ToString()));
            page.Children.Add(Regel("stijl van het lettertype : " + TextBoxVoorbeeld.FontStyle.ToString()));
            page.Children.Add(Regel(""));
            page.Children.Add(Regel("inhoud van de textbox : "));
            for (int i = 0; i < TextBoxVoorbeeld.LineCount; i++)
            {
                page.Children.Add(Regel(TextBoxVoorbeeld.GetLineText(i)));
            }
            return document;
        }

        private TextBlock Regel(string tekst)
        {
            TextBlock deRegel = new TextBlock();
            deRegel.Text = tekst;
            deRegel.FontSize = TextBoxVoorbeeld.FontSize;
            deRegel.FontFamily = TextBoxVoorbeeld.FontFamily;
            deRegel.FontWeight = TextBoxVoorbeeld.FontWeight;
            deRegel.FontStyle = TextBoxVoorbeeld.FontStyle;
            deRegel.Margin = new Thickness(96, vertPositie, 96, 96);
            vertPositie += 30;
            return deRegel;
        }


        private void PrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PrintDialog afdrukken = new PrintDialog();
            if (afdrukken.ShowDialog() == true)
            {
                afdrukken.PrintDocument(StelAfdrukSamen().DocumentPaginator, "textbox");
            }
        }


    }
}
