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
using System.Xml.Serialization;

namespace wpf4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool obrotpionlewo;
        private bool obrotpionprawo;
        private bool obrotpoziomgora;
        private bool obrotpoziomdol;
        private bool wcisniety;
        private Point startowy;
        private Rectangle r;
        private void GoraUp()
        {
            Canvas.SetTop(r, Canvas.GetTop(r) - 1);
            r.Height = r.Height + 1;
        }

        private void GoraDown()
        {
            Canvas.SetTop(r, Canvas.GetTop(r) + 1);
            r.Height = r.Height - 1;
        }

        private void DolUp()
        {
            r.Height = r.Height - 1;
        }

        private void DolDown()
        {
            r.Height = r.Height + 1;
        }
        //komentarz testowy
        private void LewyLeft()
        {
            //zrobmy zmiane
            r.Width = r.Width + 1;
            Canvas.SetLeft(r, Canvas.GetLeft(r) - 1);
        }

        private void LewyRight()
        {
            r.Width = r.Width - 1;
            Canvas.SetLeft(r, Canvas.GetLeft(r) + 1);
        }

        private void PrawyLeft()
        {
            r.Width = r.Width - 1;
        }

        private void PrawyRight()
        {
            r.Width = r.Width + 1;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void KeyEvent(object sender, KeyEventArgs e)
        {
            //control, gorna krawedz do dolu
            if (e.Key == Key.Down &&
                (Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) ==
                (ModifierKeys.Control | ModifierKeys.Shift))
            {
                if (r.Height > 1)
                {
                    if ((obrotpoziomdol&&!obrotpoziomgora)||(obrotpoziomgora&&!obrotpoziomdol))
                    {
                        DolDown();
                    }
                    else
                    {
                        GoraDown();
                    }
                }
                else
                {
                    obrotpoziomdol = !obrotpoziomdol;
                    r.Height = r.Height + 1;
                }
            }

            //control, gorna krawedz do gory
            if (e.Key == Key.Up && (Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) ==
                (ModifierKeys.Control | ModifierKeys.Shift))
            {
                if (r.Height > 1)
                {
                    if ((obrotpoziomgora && !obrotpoziomdol) || (obrotpoziomdol && !obrotpoziomgora))
                    {
                        DolUp();
                    }
                    else
                    {
                        GoraUp();
                    }
                }
                else
                {
                    obrotpoziomgora = !obrotpoziomgora;
                    r.Height = r.Height + 1;
                }
            }
            
            //control, lewa krawedz w lewo
            if (e.Key == Key.Left &&
                (Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) ==
                (ModifierKeys.Control | ModifierKeys.Shift))
            {
                if (r.Width > 1)
                {
                    if ((obrotpionprawo&&!obrotpionlewo)||(obrotpionlewo&&!obrotpionprawo))
                    {
                        PrawyLeft();
                    }
                    else
                    {
                        LewyLeft();
                    }
                }
                else
                {
                    obrotpionlewo= !obrotpionlewo;
                    r.Width = r.Width + 1;
                }
            }
            
            //control, lewa krawedz w prawo
            if (e.Key == Key.Right &&
                (Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) ==
                (ModifierKeys.Control | ModifierKeys.Shift))
            {
                if (r.Width > 1)
                {
                    if ((obrotpionprawo && !obrotpionlewo) || (obrotpionlewo && !obrotpionprawo))
                    {
                        PrawyRight();
                    }
                    else
                    {
                        LewyRight();
                    }
                }
                else
                {
                    obrotpionprawo = !obrotpionprawo;
                    r.Width = r.Width + 1;
                }
            }
            
            //shift, dolna krawedz w dol
            if (e.Key == Key.Down && (Keyboard.Modifiers & ModifierKeys.Shift) == 
                ModifierKeys.Shift && (Keyboard.Modifiers & ModifierKeys.Control) != ModifierKeys.Control)
            {
                if (r.Height > 1)
                {
                    if ((obrotpoziomdol && !obrotpoziomgora) || (obrotpoziomgora && !obrotpoziomdol))
                    {
                        GoraDown();
                    }
                    else
                    {
                        DolDown();
                    }
                }
                else
                {
                    obrotpoziomdol = !obrotpoziomdol;
                    r.Height = r.Height + 1;
                }

            }

            //shift, dolna krawedz w gore
            if (e.Key == Key.Up && (Keyboard.Modifiers & ModifierKeys.Shift) == 
                ModifierKeys.Shift && (Keyboard.Modifiers & ModifierKeys.Control) != ModifierKeys.Control)
            {
                if (r.Height > 1)
                {
                    if ((obrotpoziomgora && !obrotpoziomdol) || (obrotpoziomdol && !obrotpoziomgora))
                    {
                        GoraUp();
                    }
                    else
                    {
                        DolUp();
                    }
                }
                else
                {
                    obrotpoziomgora = !obrotpoziomgora; 
                    r.Height = r.Height + 1;
                }
            }
        
        
            //shift, prawa krawedz w lewo
            if (e.Key == Key.Left && (Keyboard.Modifiers & ModifierKeys.Shift) == 
                ModifierKeys.Shift && (Keyboard.Modifiers & ModifierKeys.Control) != ModifierKeys.Control)
            {
                if (r.Width > 1)
                {
                    if ((obrotpionprawo && !obrotpionlewo) || (obrotpionlewo && !obrotpionprawo))
                    {
                        LewyLeft();
                    }
                    else
                    {
                        PrawyLeft();
                    }
                }
                else
                {
                    obrotpionlewo = !obrotpionlewo;
                    r.Width = r.Width + 1;
                }
            }

            //shift, prawa krawedz w prawo
            if (e.Key == Key.Right && (Keyboard.Modifiers & ModifierKeys.Shift) == 
                ModifierKeys.Shift && (Keyboard.Modifiers & ModifierKeys.Control) != ModifierKeys.Control)
            {
                if (r.Width > 1)
                {
                    if ((obrotpionprawo && !obrotpionlewo) || (obrotpionlewo && !obrotpionprawo))
                    {
                        LewyRight();
                    }
                    else
                    {
                        PrawyRight();
                    }
                }
                else
                {
                    obrotpionprawo = !obrotpionprawo;
                    r.Width = r.Width + 1;
                }
            }
    
            //przemieszczanie
            if (e.Key == Key.Down && (Keyboard.Modifiers & ModifierKeys.Shift) != 
                ModifierKeys.Shift && (Keyboard.Modifiers & ModifierKeys.Control) != ModifierKeys.Control)
            {
                Canvas.SetTop(r, Canvas.GetTop(r) + 1);
            }
            //przemieszczanie
            if (e.Key == Key.Up && (Keyboard.Modifiers & ModifierKeys.Shift) != 
                ModifierKeys.Shift && (Keyboard.Modifiers & ModifierKeys.Control) != ModifierKeys.Control)
            {
                Canvas.SetTop(r, Canvas.GetTop(r) - 1);

            }
            //przemieszczanie
            if (e.Key == Key.Left && (Keyboard.Modifiers & ModifierKeys.Shift) != 
                ModifierKeys.Shift && (Keyboard.Modifiers & ModifierKeys.Control) != ModifierKeys.Control)
            {
                Canvas.SetLeft(r, Canvas.GetLeft(r) - 1);
            }
            //przemieszczanie
            if (e.Key == Key.Right && (Keyboard.Modifiers & ModifierKeys.Shift) != 
                ModifierKeys.Shift && (Keyboard.Modifiers & ModifierKeys.Control) != ModifierKeys.Control)
            {
                Canvas.SetLeft(r, Canvas.GetLeft(r) + 1);
            }
        }


        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            wcisniety = true;
            startowy = e.GetPosition(Can);
            r = new Rectangle();
            r.Stroke = Brushes.Blue;
            r.StrokeThickness = 10;
            Canvas.SetBottom(r, startowy.X);
            Canvas.SetLeft(r, startowy.X);
            r.Height = 0;
            r.Width = 0;
            Can.Children.Add(r);
            obrotpionlewo = false;
            obrotpionprawo = false;
            obrotpoziomgora = false;
            obrotpoziomdol = false;

        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            wcisniety = false;
            Mouse.Capture(null);
            var koncowy = e.GetPosition(Can);

            var x = Math.Min(koncowy.X, startowy.X);
            var y = Math.Min(koncowy.Y, startowy.Y);

            r.Width = Math.Abs(startowy.X-koncowy.X);
            r.Height = Math.Abs(startowy.Y-koncowy.Y);
            
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (wcisniety)
            {
                Mouse.Capture(this);
                var koncowy = e.GetPosition(Can);

                var x = Math.Min(koncowy.X, startowy.X);
                var y = Math.Min(koncowy.Y, startowy.Y);

                r.Width = Math.Abs(startowy.X - koncowy.X);
                r.Height = Math.Abs(startowy.Y - koncowy.Y);

                Canvas.SetLeft(r, x);
                Canvas.SetTop(r, y);
            }
        }
    }
}
