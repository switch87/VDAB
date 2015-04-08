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
using System.IO;
using System.ComponentModel;
using Microsoft.Win32;

namespace ParkingBon
{
    /// <summary>
    /// Interaction logic for ParkingBonWindow.xaml
    /// </summary>
    public partial class ParkingBonWindow : Window
    {
        public ParkingBonWindow()
        {
            InitializeComponent();
            Nieuw();
        }


        private void Nieuw()
        { 
            DatumBon.SelectedDate = DateTime.Now;
            AankomstLabelTijd.Content = DateTime.Now.ToLongTimeString();
            TeBetalenLabel.Content = "0 €";
            VertrekLabelTijd.Content = AankomstLabelTijd.Content;
            StatusItem.Content = "nieuwe bon";
            SaveEnAfdruk(false);
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Programma afsluiten ?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void minder_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            if (bedrag > 0)
                bedrag -= 1;
            if (bedrag == 0)
            {
                SaveEnAfdruk(false);
            }
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag).ToLongTimeString();
        }

        private void meer_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            DateTime vertrekuur = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag);
            if (vertrekuur.Hour < 22)
            {
                bedrag += 1;
                SaveEnAfdruk(true);
            }
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag).ToLongTimeString();
        }

        private void SaveEnAfdruk(Boolean actief)
        {
            
            PrintButton.IsEnabled = actief;
            PrintMenu.IsEnabled = actief;
        }

        // Opslaan
        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                DateTime tijd = (DateTime)DatumBon.SelectedDate;
                dlg.FileName = tijd.Day.ToString() + "-" + tijd.Month.ToString() +
                "-" + tijd.Year.ToString() + "om" +
                AankomstLabelTijd.Content.ToString().Replace(":", "-");
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Parkeerbonnen | *.bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter uitvoer = new StreamWriter(dlg.FileName))
                    {
                        uitvoer.WriteLine(tijd.ToShortDateString());
                        uitvoer.WriteLine(AankomstLabelTijd.Content);
                        uitvoer.WriteLine(TeBetalenLabel.Content);
                        uitvoer.WriteLine(VertrekLabelTijd.Content);
                    }
                    StatusItem.Content = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan mislukt : " + ex.Message);
            }
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Parkeerbonnen | *.bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader invoer = new StreamReader(dlg.FileName))
                    {
                        DatumBon.SelectedDate = Convert.ToDateTime(invoer.ReadLine());
                        AankomstLabelTijd.Content = invoer.ReadLine();
                        TeBetalenLabel.Content = invoer.ReadLine();
                        VertrekLabelTijd.Content = invoer.ReadLine();
                    }
                    StatusItem.Content = dlg.FileName;
                    SaveEnAfdruk(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("openen mislukt : " + ex.Message);
            }
        }

        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Nieuw();
        }

        private double vertPositie;

        private TextBlock Regel(string tekst)
        {
            TextBlock deRegel = new TextBlock();
            deRegel.Margin = new Thickness(300, vertPositie, 96, 96);
            deRegel.FontSize = 18;
            vertPositie += 36; // 18 * 2
            deRegel.Text = tekst;
            return deRegel;
        }

        private void PrintPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new Size(640,320);
            PageContent inhoud = new PageContent();
            document.Pages.Add(inhoud);
            FixedPage pagina = new FixedPage();
            inhoud.Child = pagina;
            pagina.Width = 640;
            pagina.Height = 320;
            Image logo = new Image();
            logo.Source = logoImage.Source;
            logo.Margin = new Thickness(96);
            pagina.Children.Add(logo);
            vertPositie = 96;
            pagina.Children.Add(Regel("datum: "+ DatumBon.Text));
            pagina.Children.Add(Regel("starttijd : "+AankomstLabelTijd.Content));
            pagina.Children.Add(Regel("eindtijd : "+VertrekLabelTijd.Content));
            pagina.Children.Add(Regel("bedrag betaald : "+TeBetalenLabel.Content));
            Bars.Afdrukvoorbeeld preview = new Bars.Afdrukvoorbeeld();
            preview.Owner = this;
            preview.AfdrukDocument = document;
            preview.ShowDialog();
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
 

    }
}
