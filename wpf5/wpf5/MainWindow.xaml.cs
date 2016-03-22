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
        public bool podgladopen;
        public SeeUsr see;
        public MainWindow()
        {
            InitializeComponent();
            lista = new List<Osoba>();
            i = 0;
            UsunButton.IsEnabled = false;
            PodgladButton.IsEnabled = false;
            EdytujButton.IsEnabled = false;
            podgladopen = false;
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            Osoba osoba = new Osoba();
            UserDlg dodajUserDlg = new UserDlg();
            dodajUserDlg.ShowDialog();
            ListBox.Items.Refresh();
        }

        private void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult d = MessageBox.Show("Czy na pewno chcesz usunąć?","Usunąć?", MessageBoxButton.OKCancel);
            if (d == MessageBoxResult.OK)
            {
                if (ListBox.SelectedIndex >= 0)
                {
                    see.Close();
                    podgladopen = false;
                    var item = (ListBoxItem) ListBox.Items.GetItemAt(ListBox.SelectedIndex);
                    var j = item.Tag;
                    lista.RemoveAt(Int32.Parse(item.Tag.ToString()));
                    foreach (ListBoxItem x in ListBox.Items)
                    {
                        if (Int32.Parse(x.Tag.ToString()) > Int32.Parse(j.ToString()))
                        {
                            x.Tag = Int32.Parse(x.Tag.ToString()) - 1;
                        }
                    }
                    i--;
                    ListBox.Items.RemoveAt(ListBox.SelectedIndex);
                    UsunButton.IsEnabled = false;
                    PodgladButton.IsEnabled = false;
                    EdytujButton.IsEnabled = false;
                }
            }
        }

        private void EdytujButton_Click(object sender, RoutedEventArgs e)
        {
            var item = (ListBoxItem)ListBox.Items.GetItemAt(ListBox.SelectedIndex);
            UserDlg dodajUserDlg = new UserDlg(item);
            dodajUserDlg.ShowDialog();
            ListBox.Items.Refresh();
        }

        private void PodgladButton_Click(object sender, RoutedEventArgs e)
        {
            var item = (ListBoxItem)ListBox.Items.GetItemAt(ListBox.SelectedIndex);
            see = new SeeUsr(item);
            see.Show();
            podgladopen = true;
        }

        private void ZamknijButton_Click(object sender, RoutedEventArgs e)
        {
            see.Close();
            Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UsunButton.IsEnabled = true;
            PodgladButton.IsEnabled = true;
            EdytujButton.IsEnabled = true;
            if (podgladopen)
            {
                if (ListBox.SelectedIndex >= 0)
                {
                    var item = (ListBoxItem) ListBox.Items.GetItemAt(ListBox.SelectedIndex);
                    see.Update(item);
                }
            }
    }
    }   
}
