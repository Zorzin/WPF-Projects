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

namespace stosik
{
    class Stos
    {
        private Stack<string> stack;

        public Stos()
        {
            stack = new Stack<string>();
        }

        public void Push(string data)
        {
            stack.Push(data);
        }

        public void Pop()
        {
            stack.Pop();
        }

        public bool Empty()
        {
            if(stack.Count()==0)
            {
                return true;
            }
            return false;
        }
        public string Top()
        {
            if(Empty())
            {
                return "Empty";
            }
            return stack.First();
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stos stos;
        public MainWindow()
        {
            stos = new Stos();
            InitializeComponent();
            
        }

        private void PushButton_Click(object sender, RoutedEventArgs e)
        {
            stos.Push(PushTextBox.Text);
            StatusLabel.Content = stos.Top();
        }

        private void PopButton_Click(object sender, RoutedEventArgs e)
        {
            if(!stos.Empty())
            {
                stos.Pop();
            }
            if (stos.Empty())
            {
                StatusLabel.Content = "Empty";
            }
            else
            {
                StatusLabel.Content = stos.Top();
            }
        }
    }
}
