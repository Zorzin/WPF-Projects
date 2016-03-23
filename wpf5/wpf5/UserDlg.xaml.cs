using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for UserDlg.xaml
    /// </summary>
    public partial class UserDlg : Window
    {
        public Osoba osoba;

        public UserDlg()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
                osoba.imie = ImieTextBox.Text;
                osoba.nazwisko = NazwiskoTextBox.Text;
                osoba.email = EmailTextBox.Text;
                DialogResult = true;
                Close();
        }

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UserDlg_OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
                ImieTextBox.Text = osoba.imie;
                NazwiskoTextBox.Text = osoba.nazwisko;
                EmailTextBox.Text = osoba.email;
        }
    }
}
