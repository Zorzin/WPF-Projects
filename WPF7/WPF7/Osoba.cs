using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF7
{
    public class Osoba : INotifyPropertyChanged
    {
        public bool szczegoly { get; set; }
        private string imie;
        private string nazwisko;
        private string email;
        public string Imie
        {
            get { return imie; }
            set
            { imie = value; OnPropertyChanged("wyswietl"); }
        }

        public string Nazwisko
        {
            get { return nazwisko; }
            set
            { nazwisko = value; OnPropertyChanged("wyswietl"); }
        }
        public string Email
        {
            get { return email; }
            set
            { email = value; OnPropertyChanged("wyswietl"); }
        }
        public int Kwota { get; set; }
        public string Region { get; set; }
        public int Dostep { get; set; }

        public string wyswietl
        {
            get { return imie + " " + nazwisko + " (" + email + ")"; }
        }

        public Osoba()
        {
            this.Imie = null;
            this.Nazwisko = null;
            this.Email = null;
            this.Kwota = 0;
            this.Region = null;
            this.Dostep = 0;
            this.szczegoly = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                new PropertyChangedEventArgs(property));
        }
    }
}
