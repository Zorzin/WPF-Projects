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
<<<<<<< HEAD
        public List<Osoba> lista;
        public SeeUsr see;
        private ListBoxItem podgladItem; //potrzebne do aktualizowania tresci w liscie
=======
        private List<Osoba> lista;
        private SeeUsr see;
        private ListBoxItem podgladItem;
>>>>>>> 989a701c12b616d048f993a66e3a31173bbe650e
        public MainWindow()
        {
            InitializeComponent();
            lista = new List<Osoba>();
<<<<<<< HEAD
=======
            see = new SeeUsr();
>>>>>>> 989a701c12b616d048f993a66e3a31173bbe650e
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
<<<<<<< HEAD
=======
                newitem.Tag =lista.Count;
>>>>>>> 989a701c12b616d048f993a66e3a31173bbe650e
                newitem.Content = osoba.imie + Environment.NewLine + osoba.nazwisko + Environment.NewLine + osoba.email;
                ListBox.Items.Add(newitem);
                lista.Add(osoba);
            }
            ListBox.Items.Refresh();
        }

        private void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult boxResult = MessageBox.Show("Czy na pewno chcesz usunąć?","Usunąć?", MessageBoxButton.OKCancel);
            if (boxResult == MessageBoxResult.OK && ListBox.SelectedIndex >= 0)
            {
<<<<<<< HEAD
                if (ListBox.SelectedIndex >= 0)
                {
                    see?.Close();
                    lista.RemoveAt(ListBox.SelectedIndex);
                    ListBox.Items.RemoveAt(ListBox.SelectedIndex);
                    Ukryjprzyciski();
                }
            }   
=======
                see.Close();
                var item = (ListBoxItem) ListBox.Items.GetItemAt(ListBox.SelectedIndex);
                var tagdel = Int32.Parse(item.Tag.ToString());
                lista.RemoveAt(tagdel);
                ZmniejszTag(tagdel);
                ListBox.Items.RemoveAt(ListBox.SelectedIndex);
                Ukryjprzyciski();
            }
>>>>>>> 989a701c12b616d048f993a66e3a31173bbe650e
        }

        private void EdytujButton_Click(object sender, RoutedEventArgs e)
        {
            var item = (ListBoxItem)ListBox.Items.GetItemAt(ListBox.SelectedIndex);
            Osoba edit = lista[ListBox.SelectedIndex];
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
            Osoba podglad = lista[ListBox.SelectedIndex];
            see.osoba = podglad;
            see.Show();
        }

        private void ZamknijButton_Click(object sender, RoutedEventArgs e)
        {
            see?.Close();
            Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pokazprzyciski();
            if (see != null)
            {
                if (see.IsLoaded)
                {
                    if (ListBox.SelectedIndex >= 0)
                    {
                        var item = (ListBoxItem) ListBox.Items.GetItemAt(ListBox.SelectedIndex);
                        podgladItem = item;
                        see.osoba = lista[ListBox.SelectedIndex];
                        see.Update();
                    }
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

        private void ZmniejszTag(int tagdel)
        {
            int tag;
            foreach (ListBoxItem x in ListBox.Items)
            {
                tag = Int32.Parse(x.Tag.ToString());
                if (tag > tagdel)
                {
                    x.Tag = tag - 1;
                }
            }
        }
    }   
}
