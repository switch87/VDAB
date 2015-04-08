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
using Microsoft.Win32;
using System.IO;
using System.Reflection;


namespace WensKaart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string GesellecteerdeKaartURI;

        private void SaveEnAfdruk( Boolean actief )
        {
            PrintPreview.IsEnabled = actief;
            Safe.IsEnabled = actief;
        }

        public MainWindow()
        {
            InitializeComponent();
            foreach ( PropertyInfo info in typeof( Colors ).GetProperties() )
            {
                BrushConverter bc = new BrushConverter();
                SolidColorBrush deKleur = (SolidColorBrush)bc.ConvertFromString( info.Name );
                Kleur kleurke = new Kleur();
                kleurke.Borstel = deKleur;
                kleurke.Naam = info.Name;
                kleurke.Hex = deKleur.ToString();
                kleurke.Rood = deKleur.Color.R;
                kleurke.Groen = deKleur.Color.G;
                kleurke.Blauw = deKleur.Color.B;
                comboBoxKleuren.Items.Add( kleurke );
                if ( kleurke.Naam == "Black" )
                {
                    comboBoxKleuren.SelectedItem = kleurke;
                }
            }
            Nieuw();
        }



        private void Window_Closing( object sender, System.ComponentModel.CancelEventArgs e )
        {
            if ( MessageBox.Show( "Programma afsluiten ?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No ) == MessageBoxResult.No )
                e.Cancel = true;
        }

        private double vertPositie;

        private TextBlock Regel( string tekst )
        {
            TextBlock deRegel = new TextBlock();
            deRegel.Margin = new Thickness( 300, vertPositie, 96, 96 );
            deRegel.FontSize = 18;
            vertPositie += 36; // 18 * 2
            deRegel.Text = tekst;
            return deRegel;
        }

        private void PrintPreviewExecuted( object sender, ExecutedRoutedEventArgs e )
        {
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new Size( 500, 500 );
            PageContent inhoud = new PageContent();
            document.Pages.Add( inhoud );
            FixedPage pagina = new FixedPage();
            inhoud.Child = pagina;
            pagina.Width = 500;
            pagina.Height = 500;
            Canvas Kaart = new Canvas() {Width=500, Height=400};
            Kaart.Background = KaartCanvas.Background;
            foreach( Ellipse ellipse in KaartCanvas.Children)
            {
                Ellipse ell = ( new Ellipse()
                {
                    Height = 40,
                    Width = 40,
                    Stroke = Brushes.Black,
                    StrokeThickness = 5,
                    Fill =  ellipse.Fill,
                } );
                Canvas.SetLeft( ell, Canvas.GetLeft(ellipse));
                Canvas.SetTop( ell, Canvas.GetTop(ellipse));
                Kaart.Children.Add( ell );
            }
            pagina.Children.Add( Kaart );
            pagina.Children.Add( new TextBlock() 
            { 
                Text = KaartTekst.Text, 
                FontSize = KaartTekst.FontSize, 
                FontFamily = KaartTekst.FontFamily, 
                Width=500,
                Height=80,
                Margin=new Thickness( 10, 400, 10, 0 ),
                TextAlignment = System.Windows.TextAlignment.Center
            });
            WensKaart.Afdrukvoorbeeld preview = new WensKaart.Afdrukvoorbeeld();
            preview.Owner = this;
            preview.AfdrukDocument = document;
            preview.ShowDialog();
        }

        private void Nieuw()
        {
            KaartCanvas.Background = Brushes.White;
            KaartTekst.Text = "Zet hier uw bijschrift";
            SaveEnAfdruk( false );
            TekstGrootte.Content = "20";
            KaartTekst.FontSize = 20;
            KaartCanvas.Children.Clear();
            LettertypeComboBox.SelectedItem = new FontFamily( "Vani" );
            StatusItem.Content = "Nieuw";
        }

        private void NewExecuted( object sender, ExecutedRoutedEventArgs e )
        {
            Nieuw();
            LettertypeComboBox.SelectedItem = KaartTekst.FontFamily;
        }

        private void OpenExecuted( object sender, ExecutedRoutedEventArgs e )
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Postkaarten | *.kaart";
                if ( dlg.ShowDialog() == true )
                {
                    using ( StreamReader invoer = new StreamReader( dlg.FileName ) )
                    {
                        Nieuw();
                        SaveEnAfdruk( true );
                        KaartCanvas.AllowDrop = true;
                        StatusItem.Content = dlg.FileName;
                        

                        string kaartafb =invoer.ReadLine();
                        foreach ( MenuItem huidig in KaartTypes.Items )
                        {
                            if ( huidig.Name ==  kaartafb)
                            {
                                huidig.IsChecked = true;
                                ImageBrush KaartAfbeelding = new ImageBrush();
                                KaartAfbeelding.ImageSource = new BitmapImage( new Uri( @"../../images/" + huidig.Name + ".jpg", UriKind.Relative ) );
                                KaartCanvas.Background = KaartAfbeelding;
                            }
                            else
                                huidig.IsChecked = false;
                        }
                        int aantalBollen = int.Parse( invoer.ReadLine() );
                        for ( int i = 0; i < aantalBollen; i++ )
                        {
                            Ellipse ell = (new Ellipse()
                                {
                                Height = 40,
                                Width = 40,
                                Stroke = Brushes.Black,
                                StrokeThickness = 5,
                                Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(invoer.ReadLine()),
                            });
                            ell.MouseMove += Ellipse_MouseMove;
                            Canvas.SetLeft( ell, double.Parse( invoer.ReadLine()) );
                            Canvas.SetTop( ell, double.Parse( invoer.ReadLine()) );
                            KaartCanvas.Children.Add( ell);
                        }
                        KaartTekst.Text=invoer.ReadLine();
                        LettertypeComboBox.SelectedItem = new FontFamily( invoer.ReadLine() );
                        KaartTekst.FontSize = int.Parse( invoer.ReadLine() );
                    }
                    
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show( "openen mislukt : " + ex.Message );
            }
        }

        

        

        private void SaveExecuted( object sender, ExecutedRoutedEventArgs e )
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "Postkaart";
                dlg.DefaultExt = ".kaart";
                dlg.Filter = "Postkaarten | *.kaart";

                if ( dlg.ShowDialog() == true )
                {
                    StatusItem.Content = dlg.FileName;
                    using ( StreamWriter bestand = new StreamWriter( dlg.FileName ) )
                    {
                        bestand.WriteLine( GesellecteerdeKaartURI );
                        bestand.WriteLine( KaartCanvas.Children.Count );
                        foreach (Ellipse ell in KaartCanvas.Children)
                        {
                            bestand.WriteLine( ell.Fill);
                            bestand.WriteLine( Canvas.GetLeft(ell) );
                            bestand.WriteLine( Canvas.GetTop( ell ) );
                        }
                        bestand.WriteLine(KaartTekst.Text);
                        bestand.WriteLine( KaartTekst.FontFamily );
                        bestand.WriteLine( KaartTekst.FontSize );
                    }
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show( "opslaan mislukt : " + ex.Message );
            }
        }

        private void CloseExecuted( object sender, ExecutedRoutedEventArgs e )
        {
            this.Close();
        }

        private void KaartType_Click( object sender, RoutedEventArgs e )
        {
            MenuItem hetKaarttype = (MenuItem)sender;

            foreach ( MenuItem huidig in KaartTypes.Items )
            {
                huidig.IsChecked = false;
            }
            hetKaarttype.IsChecked = true;
            SaveEnAfdruk( true );
            ImageBrush KaartAfbeelding = new ImageBrush();
            GesellecteerdeKaartURI = hetKaarttype.Name;
            KaartAfbeelding.ImageSource = new BitmapImage( new Uri( @"../../images/" + GesellecteerdeKaartURI + ".jpg", UriKind.Relative ) );
            KaartCanvas.Background = KaartAfbeelding;
            KaartCanvas.AllowDrop = true;
        }

        private void RepeatButtonGroter_Click( object sender, RoutedEventArgs e )
        {
            if ( KaartTekst.FontSize < 50 )
                TekstGrootte.Content = ++KaartTekst.FontSize;
        }

        private void RepeatButtonKleiner_Click( object sender, RoutedEventArgs e )
        {
            if ( KaartTekst.FontSize > 6 )
                TekstGrootte.Content = --KaartTekst.FontSize;
        }


        private Ellipse sleepEllipse = new Ellipse();

        private void Ellipse_MouseMove( object sender, MouseEventArgs e )
        {
            sleepEllipse = (Ellipse)sender;
            if ( e.LeftButton == MouseButtonState.Pressed )
            {
                DataObject sleepKleur = new DataObject( "deKleur",
                    sleepEllipse.Fill );
                DragDrop.DoDragDrop( sleepEllipse, sleepKleur,
                    DragDropEffects.Move );
            }
        }



        private void KaartCanvas_Drop( object sender, DragEventArgs e )
        {

            if ( sleepEllipse.Parent == KaartCanvas ) KaartCanvas.Children.Remove( sleepEllipse );
            if ( sender != Vuilbak )
            {
                Ellipse ell = ( new Ellipse()
                {
                    Height = 40,
                    Width = 40,
                    Stroke = Brushes.Black,
                    StrokeThickness = 5,
                    Fill = sleepEllipse.Fill,
                } );
                ell.MouseMove += Ellipse_MouseMove;
                Canvas.SetLeft( ell, e.GetPosition( KaartCanvas ).X );
                Canvas.SetTop( ell, e.GetPosition( KaartCanvas ).Y );
                KaartCanvas.Children.Add( ell );
            }
                if ( sleepEllipse.Parent == KaartCanvas ) KaartCanvas.Children.Remove( sleepEllipse );
            
        }
    }
}

