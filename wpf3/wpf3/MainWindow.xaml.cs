using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace wpf3
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainLabel.Content = ContentTextBox.Text;
        }

        private void MarginSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainLabel.Margin = new Thickness(MarginSlider.Value);
        }

        private void PaddingSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainLabel.Padding = new Thickness(PaddingSlider.Value);
        }

        private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainLabel.Background = new SolidColorBrush(Color.FromRgb(Convert.ToByte(RSlider.Value), Convert.ToByte(GSlider.Value), Convert.ToByte(BSlider.Value)));
        }

        private void ColorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int r, g, b;
            var rres = Int32.TryParse(RTextBox.Text, out r);
            var gres = Int32.TryParse(GTextBox.Text, out g);
            var bres = Int32.TryParse(BTextBox.Text, out b);
            if (bres && gres && rres)
            {
                if(r<=255 && g<=255 && b<=255 && r>=0 && g>=0 && b>=0 )
                MainLabel.Foreground =
                    new SolidColorBrush(Color.FromRgb(Convert.ToByte(r),
                        Convert.ToByte(g), Convert.ToByte(b)));
            }
        }

        private void BrushComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem test = (ComboBoxItem) BrushComboBox.SelectedItem;
            if (test != null)
            {
                if (test.Content.ToString() != null)
                {
                    Color c = (Color) ColorConverter.ConvertFromString(test.Content.ToString());
                    SolidColorBrush brush = new SolidColorBrush(c);
                    MainLabel.BorderBrush = brush;
                }
            }
        }

        private void ThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainLabel.BorderThickness = new Thickness(ThicknessSlider.Value);
        }

        private void FontTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainLabel.FontFamily = new FontFamily(FontTextBox.Text);
        }

        private void SizeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SizeTextBox.Text))
            {
                MainLabel.FontSize = Int32.Parse(SizeTextBox.Text);
            }
        }

        private void BoldCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.FontWeight = FontWeights.Bold;
        }

        private void ItalicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.FontStyle = FontStyles.Italic;
        }

        private void ItalicCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            MainLabel.FontStyle = FontStyles.Normal;
        }

        private void BoldCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            MainLabel.FontWeight = FontWeights.Normal;
        }

        private void LeftHorRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.HorizontalAlignment = HorizontalAlignment.Left;
        }

        private void CenterHorRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.HorizontalAlignment = HorizontalAlignment.Center;
        }

        private void RightHorRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            MainLabel.HorizontalAlignment = HorizontalAlignment.Right;
        }

        private void StretchHorRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            MainLabel.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        private void TopVerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.VerticalAlignment = VerticalAlignment.Top;
        }

        private void CenterVerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.VerticalAlignment = VerticalAlignment.Center;
        }

        private void BottomVerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.VerticalAlignment = VerticalAlignment.Bottom;
        }

        private void StretchVerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.VerticalAlignment = VerticalAlignment.Stretch;
        }

        private void CLeftHorRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.HorizontalContentAlignment = HorizontalAlignment.Left;
        }

        private void CCenterHorRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        private void CRightHorRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.HorizontalContentAlignment = HorizontalAlignment.Right;
        }

        private void CStretchHorRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.HorizontalContentAlignment = HorizontalAlignment.Stretch;
        }

        private void CTopVerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.VerticalContentAlignment = VerticalAlignment.Top;
        }

        private void CCenterVerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.VerticalContentAlignment = VerticalAlignment.Center;
        }

        private void CBottomVerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.VerticalContentAlignment = VerticalAlignment.Bottom;
        }

        private void CStretchVerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainLabel.VerticalContentAlignment = VerticalAlignment.Stretch;
        }
    }
}
