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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class HanoiCommands
    {
        private static RoutedUICommand gora;
        private static RoutedUICommand dol;

        static HanoiCommands()
        {
            gora = new RoutedUICommand("Przenies do gory", "gora", typeof(HanoiCommands));
            dol = new RoutedUICommand("Przenies do dolu", "dol", typeof(HanoiCommands));
        }

        public static RoutedUICommand Gora
        {
            get { return gora; }
            set { gora = value; }
        }

        public static RoutedUICommand Dol
        {
            get { return dol; }
            set { dol = value; }
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoraCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ListBox listBox;
            if (A != null)
            {
                Button button = (Button) e.Source;
                switch (button.Name)
                {
                    case "aUp":
                        listBox = A;
                        break;
                    case "bUp":
                        listBox = B;
                        break;
                    case "cUp":
                        listBox = C;
                        break;
                    default:
                        return;
                }
                e.CanExecute = false;
                if (listBox.Items.Count > 0 && TymczasowyTextBox.Text == "")
                {
                    e.CanExecute = true;
                }
            }
        }

        private void DolCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (A != null)
            {
                var button = (Button) e.Source;
                int gora;
                ListBox listbox;
                ListBoxItem item;
                bool tekst = int.TryParse(TymczasowyTextBox.Text, out gora);

                switch (button.Name)
                {

                    case "aDown":
                        listbox = A;
                        break;
                    case "bDown":
                        listbox = B;
                        break;
                    case "cDown":
                        listbox = C;
                        break;
                    default:
                        return;
                }
                e.CanExecute = false;
                if (listbox.Items.Count > 0)
                {
                    item =  (ListBoxItem)listbox.Items[0];
                    if (tekst && gora < Int32.Parse(item.Content.ToString()))
                    {
                        e.CanExecute = true;
                    }
                }
                else if (TymczasowyTextBox.Text != "")
                {
                    e.CanExecute = true;
                }

            }
        }

        private void DolExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Button button = (Button)e.Source;
            ListBoxItem item = new ListBoxItem();
            ListBox listBox;
            switch (button.Name)
            {
                case "aDown":
                    listBox = A;
                    break;
                case "bDown":
                    listBox = B;
                    break;
                case "cDown":
                    listBox = C;
                    break;
                default:
                    return;
            }
            item.Content = TymczasowyTextBox.Text;
            listBox.Items.Insert(0, item);
            TymczasowyTextBox.Text = "";
        }

        private void GoraExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Button button = (Button) e.Source;
            ListBoxItem item;
            ListBox listBox;
            switch (button.Name)
            {
                case "aUp":
                    listBox = A;
                    break;
                case "bUp":
                    listBox = B;
                    break;
                case "cUp":
                    listBox = C;
                    break;
                default:
                    return;
            }
            item = (ListBoxItem)listBox.Items[0];
            TymczasowyTextBox.Text = item.Content.ToString();
            listBox.Items.RemoveAt(0);
        }

        
    }
}
