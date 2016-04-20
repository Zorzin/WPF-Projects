using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WPF7.Annotations;

namespace WPF7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Osoba osoba;
        public MainWindow()
        {
            Listy.lista = new ObservableCollection<Osoba>();
            Listy.comboList = new List<string>();
            InitializeComponent();
            DodajRegion();
            DodajOsobe();
            ComboBox.ItemsSource = Listy.comboList;
            ListBox.ItemsSource = Listy.lista;
            
        }
        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
                DodajOsobe();
        }
        private void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            Listy.lista.RemoveAt(ListBox.SelectedIndex);
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
        }

        private void DodajOsobe()
        {
            osoba = new Osoba();
            Listy.lista.Add(osoba);
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
            imieText.Focus();
        }
        private void DodajRegion()
        {
            Listy.comboList = new List<string>();
            Listy.comboList.Add("Białystok");
            Listy.comboList.Add("Warszawa");
            Listy.comboList.Add("Poznań");
            Listy.comboList.Add("Kraków");
            Listy.comboList.Add("Wrocław");
        }

        private ListCollectionView View
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(Listy.lista);
            }
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            var region = regionfiltertxt.Text;
            View.Filter = delegate(object item)
            {
                var osoba = item as Osoba;
                if (osoba != null)
                {
                    return osoba.Region == region;
                }
                return false;
            };
            
        }

        private void FilterNone(object sender, RoutedEventArgs e)
        {
            View.Filter = null;
        }

        private void SortNone(object sender, RoutedEventArgs e)
        {
            View.SortDescriptions.Clear();
            View.CustomSort = null;
        }
        private class SortByEmailLetter: System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                Osoba osoba1 = (Osoba)x;
                Osoba osoba2 = (Osoba)y;
                try
                {
                    var letter1 = osoba1.Email.Substring(0, 1);
                    var letter2 = osoba2.Email.Substring(0, 1);
                    return letter1.CompareTo(letter2);
                }
                catch (Exception)
                {
                    if (string.IsNullOrEmpty(osoba1.Email))
                    {
                        return -1;
                    }
                    else if(string.IsNullOrEmpty(osoba2.Email))
                    {
                        return 1;
                    }
                    return 0;
                }
                
            }
        }
        private void SortFirstEmailLetter(object sender, RoutedEventArgs e)
        {
            View.CustomSort = new SortByEmailLetter();
        }
        private class SortBySecondNameLength : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                Osoba osoba1 = (Osoba)x;
                Osoba osoba2 = (Osoba)y;
                try
                {
                    
                    return osoba1.Nazwisko.Length.CompareTo(osoba2.Nazwisko.Length);
                }
                catch (Exception)
                {

                    if (string.IsNullOrEmpty(osoba1.Nazwisko))
                    {
                        return -1;
                    }
                    else if (string.IsNullOrEmpty(osoba2.Nazwisko))
                    {
                        return 1;
                    }
                    return 0;
                }
                
            }
        }
        private void SortSecondNameLength(object sender, RoutedEventArgs e)
        {
            View.CustomSort = new SortBySecondNameLength();
        }

        private void GroupNone(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
        }

        private void GroupMale(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Plec"));
        }

        private void GroupName(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Imie"));
        }
    }
}
