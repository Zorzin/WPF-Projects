﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Shapes;

namespace wpf5
{
    /// <summary>
    /// Interaction logic for UserDlg.xaml
    /// </summary>
    public partial class UserDlg : Window
    {
        private bool e;
        private ListBoxItem item;
        private MainWindow main;

        public UserDlg()
        {
            InitializeComponent();
            e = false;
            main = (MainWindow)Application.Current.MainWindow;
        }
        public UserDlg(ListBoxItem item)
        {
            InitializeComponent();
            this.item = item;
            this.e = true;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!this.e)
            {
                Osoba osoba = new Osoba(ImieTextBox.Text, NazwiskoTextBox.Text, EmailTextBox.Text);
                main.lista.Add(osoba);
                ListBoxItem newitem = new ListBoxItem();
                newitem.Content = ImieTextBox.Text + Environment.NewLine + NazwiskoTextBox.Text + Environment.NewLine +
                               EmailTextBox.Text;
                newitem.Tag = main.i++;
                main.ListBox.Items.Add(newitem);
                Close();
            }
            else
            {
                item.Content = ImieTextBox.Text + Environment.NewLine + NazwiskoTextBox.Text + Environment.NewLine +
                               EmailTextBox.Text;
                main.lista[Int32.Parse(item.Tag.ToString())].imie = ImieTextBox.Text;
                main.lista[Int32.Parse(item.Tag.ToString())].nazwisko = NazwiskoTextBox.Text;
                main.lista[Int32.Parse(item.Tag.ToString())].email = EmailTextBox.Text;
                Close();
            }
        }

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UserDlg_OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            if (this.e)
            {
                main = (MainWindow)Application.Current.MainWindow;
                ImieTextBox.Text = main.lista[Int32.Parse(item.Tag.ToString())].imie;
                NazwiskoTextBox.Text = main.lista[Int32.Parse(item.Tag.ToString())].nazwisko;
                EmailTextBox.Text = main.lista[Int32.Parse(item.Tag.ToString())].email; //Int32.Parse(item.Tag.ToString())
            }
        }
    }
}