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
        public SeeUsr see;
        private int tag;
        private ListBoxItem podgladItem;
        public MainWindow()
        {
            InitializeComponent();
            lista = new List<Osoba>();
            see = new SeeUsr();
            tag = 0;
            Ukryjprzyciski();
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            Osoba osoba = new Osoba();
            UserDlg dodajUserDlg = new UserDlg();
            dodajUserDlg.osoba = osoba;
            if (dodajUserDlg.ShowDialog() == true)
            {
                osoba = dodajUserDlg.osoba;
                ListBoxItem newitem = new ListBoxItem();
                newitem.Tag =tag++;
                newitem.Content = osoba.imie + Environment.NewLine + osoba.nazwisko + Environment.NewLine + osoba.email;
                ListBox.Items.Add(newitem);
                lista.Add(osoba);
            }
            ListBox.Items.Refresh();
        }

        private void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult boxResult = MessageBox.Show("Czy na pewno chcesz usunąć?","Usunąć?", MessageBoxButton.OKCancel);
            if (boxResult == MessageBoxResult.OK)
            {
                if (ListBox.SelectedIndex >= 0)
                {
                    see.Close();
                    var item = (ListBoxItem) ListBox.Items.GetItemAt(ListBox.SelectedIndex);
                    var j = Int32.Parse(item.Tag.ToString());
                    lista.RemoveAt(j);
                    foreach (ListBoxItem x in ListBox.Items)
                    {
                        if (Int32.Parse(x.Tag.ToString()) > j)
                        {
                            x.Tag=Int32.Parse(x.Tag.ToString())-1;
                        }
                    }
                    tag--;
                    ListBox.Items.RemoveAt(ListBox.SelectedIndex);
                    Ukryjprzyciski();
                }
            }
        }

        private void EdytujButton_Click(object sender, RoutedEventArgs e)
        {
            var item = (ListBoxItem)ListBox.Items.GetItemAt(ListBox.SelectedIndex);
            int tag = Int32.Parse(item.Tag.ToString());
            Osoba edit = lista[tag];
            UserDlg dodajUserDlg = new UserDlg();
            dodajUserDlg.osoba = edit;
            if (dodajUserDlg.ShowDialog()==true)
            {
                edit = dodajUserDlg.osoba;
                item.Content = edit.imie + Environment.NewLine + edit.nazwisko + Environment.NewLine + edit.email;
            }
            ListBox.Items.Refresh();
        }

        private void PodgladButton_Click(object sender, RoutedEventArgs e)
        {
            see = new SeeUsr();
            podgladItem = (ListBoxItem)ListBox.Items.GetItemAt(ListBox.SelectedIndex);
            int tag = Int32.Parse(podgladItem.Tag.ToString());
            Osoba podglad = lista[tag];
            see.osoba = podglad;
            see.Show();
        }

        private void ZamknijButton_Click(object sender, RoutedEventArgs e)
        {
            see.Close();
            Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pokazprzyciski();
            if (see.IsLoaded)
            {
                if (ListBox.SelectedIndex >= 0)
                {
                    var item = (ListBoxItem) ListBox.Items.GetItemAt(ListBox.SelectedIndex);
                    podgladItem = item;
                    int tag = Int32.Parse(item.Tag.ToString());
                    see.osoba = lista[tag];
                    see.Update();
                }
            }
        }

        public void Update()
        {
            podgladItem.Content = see.osoba.imie + Environment.NewLine + see.osoba.nazwisko + Environment.NewLine + see.osoba.email;
        }

        private void Ukryjprzyciski()
        {
            UsunButton.IsEnabled = false;
            PodgladButton.IsEnabled = false;
            EdytujButton.IsEnabled = false;
        }

        private void Pokazprzyciski()
        {
            UsunButton.IsEnabled = true;
            PodgladButton.IsEnabled = true;
            EdytujButton.IsEnabled = true;
        }
    }   
}
