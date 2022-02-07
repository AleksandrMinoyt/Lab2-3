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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelFntSize.SelectedIndex++;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SelFntSize.SelectedIndex > 0)
            {
                SelFntSize.SelectedIndex--;
            }
        }



        //FontWeight="Bold" TextDecorations="Underline" FontStyle="Italic"

        private void Button_Click_3(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Editor.TextDecorations == TextDecorations.Underline)
            {
                Editor.TextDecorations = null;
            }
            else
            {
                Editor.TextDecorations  = TextDecorations.Underline;
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            string color = (sender as RadioButton).Content.ToString();
            
            switch (color)
            {
               case "Чёрный":
                    {
                        Editor.Foreground = Brushes.Black;
                        break;
                    }
                case "Красный":
                    {
                        Editor.Foreground = Brushes.Red;
                        break;
                    }
                case "Синий":
                    {
                        Editor.Foreground = Brushes.Blue;
                        break;
                    }

            }

            


    }
    }
}
