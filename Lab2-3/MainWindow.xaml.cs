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
using System.IO;
using Microsoft.Win32;

namespace Lab2_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ThemeChange(0);
        }


        public void ThemeChange(int IndTheme)
        {

            Uri uri = new Uri("LightTheme.xaml", UriKind.Relative);
            switch (IndTheme)
            {
                case 0: { uri = new Uri("LightTheme.xaml", UriKind.Relative); break; }
                case 1: { uri = new Uri("DarkTheme.xaml", UriKind.Relative); break; }
                default:
                    { uri = new Uri("LightTheme.xaml", UriKind.Relative); break; }
                    
            }
            Application.Current.Resources.Clear();

            ResourceDictionary rd = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(rd);

            uri = new Uri("Dict.xaml", UriKind.Relative);
            rd = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(rd);
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            string tb = cmb.SelectedItem as string;
            if (tb != null && Editor != null)
            {
                Editor.FontFamily = new FontFamily(tb);
            }

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            string tb = cmb.SelectedItem as string;

            if (tb != null && Editor != null)
            {

                Editor.FontSize = Convert.ToDouble(tb);

            }
        }



        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (ofd.ShowDialog() == true)
            {
                Editor.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (sfd.ShowDialog() == true)
            {
                File.WriteAllText(sfd.FileName, Editor.Text);
            }
        }

        private void SelectColorExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (((sender as Window).FindName("RBBlack") as RadioButton).IsChecked == true)
            {
                Editor.Foreground = Brushes.Black;
            }
            if (((sender as Window).FindName("RBRed") as RadioButton).IsChecked == true)
            {
                Editor.Foreground = Brushes.Red;
            }
            if (((sender as Window).FindName("RBBlue") as RadioButton).IsChecked == true)
            {
                Editor.Foreground = Brushes.Blue;
            }
        }

        private void FontUpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SelFntSize.SelectedIndex++;
        }

        private void FontDownExecuted(object sender, ExecutedRoutedEventArgs e)
        {

            if (SelFntSize.SelectedIndex > 0)
            {
                SelFntSize.SelectedIndex--;
            }

        }

        private void FontBoldExecuted(object sender, ExecutedRoutedEventArgs e)
        {

            if (Editor.FontWeight == FontWeights.Bold)
            {
                Editor.FontWeight = FontWeights.Normal;
            }
            else
            {
                Editor.FontWeight = FontWeights.Bold;
            }
        }

        private void FontItalicExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (Editor.FontStyle == FontStyles.Italic)
            {
                Editor.FontStyle = FontStyles.Normal;
            }
            else
            {
                Editor.FontStyle = FontStyles.Italic;
            }
        }

        private void FontLowExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (Editor.TextDecorations == TextDecorations.Underline)
            {
                Editor.TextDecorations = null;
            }
            else
            {
                Editor.TextDecorations = TextDecorations.Underline;
            }
        }

        private void SelectThemeExecuted(object sender, ExecutedRoutedEventArgs e)
        {
           

            if (((sender as Window).FindName("RBWT") as RadioButton).IsChecked == true)
            {
                ThemeChange(0);
            }
            if (((sender as Window).FindName("RBDT") as RadioButton).IsChecked == true)
            {
                ThemeChange(1);
            }


        }
    }
}