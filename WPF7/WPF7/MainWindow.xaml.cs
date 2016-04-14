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
        public List<string> comboList; 
        public Collection<Osoba> lista = new ObservableCollection<Osoba>();
        public MainWindow()
        {
            InitializeComponent();
            DodajRegion();
            ComboBox.ItemsSource = comboList;
            ListBox.ItemsSource = lista;
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            lista.Add(new Osoba());
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
            imieText.Focus();
        }

        private void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            lista.RemoveAt(ListBox.SelectedIndex);

        }

        private void DodajRegion()
        {
            comboList = new List<string>();
            comboList.Add("Białystok");
            comboList.Add("Warszawa");
            comboList.Add("Poznań");
            comboList.Add("Kraków");
            comboList.Add("Wrocław");
        }
        
    }
}
