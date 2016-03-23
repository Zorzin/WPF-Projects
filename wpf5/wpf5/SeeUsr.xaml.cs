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
        public Osoba osoba;
        public SeeUsr()
        {
            InitializeComponent();
            main = (MainWindow)Application.Current.MainWindow;
        }

        private void ZamknijButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SeeUsr_OnLoaded(object sender, RoutedEventArgs e)
        {
            ImieTextBox.Text = osoba.imie;
            NazwiskoTextBox.Text = osoba.nazwisko;
            EmailTextBox.Text = osoba.email;
        }

        public void Update()
        {
            ImieTextBox.Text = osoba.imie;
            NazwiskoTextBox.Text = osoba.nazwisko;
            EmailTextBox.Text = osoba.email;
        }

        private void ImieTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            osoba.imie = ImieTextBox.Text;
            main.Update();

        }

        private void NazwiskoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            osoba.nazwisko = NazwiskoTextBox.Text;
            main.Update();
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            osoba.email = EmailTextBox.Text;
            main.Update();
        }
    }
}
