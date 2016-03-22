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
using System.Windows.Shapes;

namespace wpf5
{
    /// <summary>
    /// Interaction logic for SeeUsr.xaml
    /// </summary>
    public partial class SeeUsr : Window
    {
        private MainWindow main;
        private ListBoxItem item;
        public SeeUsr(ListBoxItem item)
        {
            InitializeComponent();
            this.main = (MainWindow)Application.Current.MainWindow;
            this.item = item;
        }

        private void ZamknijButton_Click(object sender, RoutedEventArgs e)
        {
            main.podgladopen = false;
            Close();
        }

        private void SeeUsr_OnLoaded(object sender, RoutedEventArgs e)
        {
            ImieTextBox.Text = main.lista[Int32.Parse(item.Tag.ToString())].imie;
            NazwiskoTextBox.Text = main.lista[Int32.Parse(item.Tag.ToString())].nazwisko;
            EmailTextBox.Text = main.lista[Int32.Parse(item.Tag.ToString())].email;
        }

        public void Update(ListBoxItem item)
        {
            this.item = item;
            ImieTextBox.Text = main.lista[Int32.Parse(item.Tag.ToString())].imie;
            NazwiskoTextBox.Text = main.lista[Int32.Parse(item.Tag.ToString())].nazwisko;
            EmailTextBox.Text = main.lista[Int32.Parse(item.Tag.ToString())].email;
        }

        private void ImieTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            main.lista[Int32.Parse(item.Tag.ToString())].imie = ImieTextBox.Text;
            UpdateContent(item);

        }

        private void NazwiskoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            main.lista[Int32.Parse(item.Tag.ToString())].nazwisko = NazwiskoTextBox.Text;
            UpdateContent(item);
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            main.lista[Int32.Parse(item.Tag.ToString())].email = EmailTextBox.Text;
            UpdateContent(item);
        }

        private void UpdateContent(ListBoxItem item)
        {
            item.Content= item.Content = ImieTextBox.Text + Environment.NewLine + NazwiskoTextBox.Text + Environment.NewLine +
                               EmailTextBox.Text;
        }
    }
}
