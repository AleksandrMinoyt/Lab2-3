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
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            TextBlock tb = cmb.SelectedItem as TextBlock;
            if (tb != null && Editor != null)
            {
                Editor.FontFamily = new FontFamily(tb.Text);
            }

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            TextBlock tb = cmb.SelectedItem as TextBlock;

            if (tb != null && Editor != null)
            {

                Editor.FontSize = Convert.ToDouble(tb.Text);

            }
        }


        /********************/

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
    }
}