using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace wpf5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Osoba
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string email { get; set; }

        public Osoba()
        {
            this.imie = null;
            this.nazwisko = null;
            this.email = null;
        }

        public Osoba(string imie, string nazwisko, string email)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.email = email;
        }
        
    }

    public partial class MainWindow : Window
    {
        public List<Osoba> lista;
        public int i; 
        public MainWindow()
        {
            InitializeComponent();
            lista = new List<Osoba>();
            i = 0;
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            Osoba osoba = new Osoba();
            UserDlg dodajUserDlg = new UserDlg();
            dodajUserDlg.Show();
            
        }

        private void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult d = MessageBox.Show("Czy na pewno chcesz usunąć?","Usunąć?", MessageBoxButton.OKCancel);
            if (d == MessageBoxResult.OK)
            {
                if (ListBox.SelectedIndex >= 0)
                {
                    var item = (ListBoxItem) ListBox.Items.GetItemAt(ListBox.SelectedIndex);
                    lista.RemoveAt(Int32.Parse(item.Tag.ToString()));
                    ListBox.Items.RemoveAt(ListBox.SelectedIndex);
                }
            }
        }

        private void EdytujButton_Click(object sender, RoutedEventArgs e)
        {
            var item = (ListBoxItem)ListBox.Items.GetItemAt(ListBox.SelectedIndex);
            UserDlg dodajUserDlg = new UserDlg(item);
            dodajUserDlg.ImieTextBox.Text =lista[Int32.Parse(item.Tag.ToString())].imie;
            dodajUserDlg.NazwiskoTextBox.Text = lista[Int32.Parse(item.Tag.ToString())].nazwisko;
            dodajUserDlg.EmailTextBox.Text = lista[Int32.Parse(item.Tag.ToString())].email;
            dodajUserDlg.Show();
        }

        private void PodgladButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
