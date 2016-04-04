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
        private List<int> listaA = new List<int>();
        private List<int> listaB = new List<int>();
        private List<int> listaC = new List<int>();
        private Dictionary<object, bool> isDirty = new Dictionary<object, bool>();
        public MainWindow()
        {
            for (int i = 5; i > 0; i--)
            {
                listaA.Add(i);
            }
            InitializeComponent();
            
        }

        private void GoraCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Button button = (Button)e.Source;
            switch (button.Name)
            {
                case "aUp":
                    e.CanExecute = false;
                    if (listaA.Count > 0 && TymczasowyTextBox.Text == "")
                    {
                        e.CanExecute = true;
                    }
                    break;
                case "bUp":
                    e.CanExecute = false;
                    if (listaB.Count > 0 && TymczasowyTextBox.Text == "")
                    {
                        e.CanExecute = true;
                    }
                    break;
                case "cUp":
                    e.CanExecute = false;
                    if (listaC.Count > 0 && TymczasowyTextBox.Text == "")
                    {
                        e.CanExecute = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void DolCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Button button = (Button)e.Source;
            int gora;
            bool tekst = Int32.TryParse(TymczasowyTextBox.Text,out gora);
            switch (button.Name)
            {
                case "aDown":
                    e.CanExecute = false;
                    if (listaA.Count > 0)
                    {
                        if (tekst && gora < listaA[listaA.Count - 1])
                        {
                            e.CanExecute = true;
                        }
                    }
                    else if (TymczasowyTextBox.Text != "")
                    {
                        e.CanExecute = true;
                    }
                    break;
                case "bDown":
                    e.CanExecute = false;
                    if (listaB.Count > 0)
                    {
                        if (tekst && gora < listaB[listaB.Count - 1])
                        {
                            e.CanExecute = true;
                        }
                    }
                    else if (TymczasowyTextBox.Text != "")
                    {
                        e.CanExecute = true;
                    }
                    break;
                case "cDown":
                    e.CanExecute = false;
                    if (listaC.Count > 0)
                    {
                        if (tekst && gora < listaC[listaC.Count - 1])
                        {
                            e.CanExecute = true;
                        }
                    }
                    else if(TymczasowyTextBox.Text!="")
                    {
                        e.CanExecute = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void DolExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Button button = (Button)e.Source;
            ListBoxItem item = new ListBoxItem();
            switch (button.Name)
            {
                case "aDown":
                    listaA.Add(Int32.Parse(TymczasowyTextBox.Text));
                    item.Content = TymczasowyTextBox.Text;
                    A.Items.Insert(0, item);
                    TymczasowyTextBox.Text = "";
                    break;
                case "bDown":
                    listaB.Add(Int32.Parse(TymczasowyTextBox.Text));
                    item.Content = TymczasowyTextBox.Text;
                    B.Items.Insert(0,item);
                    TymczasowyTextBox.Text = "";
                    break;
                case "cDown":
                    listaC.Add(Int32.Parse(TymczasowyTextBox.Text));
                    item.Content = TymczasowyTextBox.Text;
                    C.Items.Insert(0, item);
                    TymczasowyTextBox.Text = "";
                    break;
                default:
                    break;
            }
        }

        private void GoraExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Button button = (Button) e.Source;
            switch (button.Name)
            {
                case "aUp":
                    TymczasowyTextBox.Text = listaA[listaA.Count - 1].ToString();
                    listaA.RemoveAt(listaA.Count-1);
                    A.Items.RemoveAt(0);
                    break;
                case "bUp":
                    TymczasowyTextBox.Text = listaB[listaB.Count - 1].ToString();
                    listaB.RemoveAt(listaB.Count - 1);
                    B.Items.RemoveAt(0);
                    break;
                case "cUp":
                    TymczasowyTextBox.Text = listaC[listaC.Count - 1].ToString();
                    listaC.RemoveAt(listaC.Count - 1);
                    C.Items.RemoveAt(0);
                    break;
                default:
                    break;
            }
        }

        
    }
}
