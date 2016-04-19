using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WPF7
{
    public class Osoba : IDataErrorInfo,INotifyPropertyChanged
    {
        public bool szczegoly { get; set; }
        private string imie;
        private string nazwisko;
        private string email;
        private string zdjecie;
        private string plec;
        public string Pesel { get; set; }
        public string Zdjecie
        {
            get { return zdjecie; }
            set { zdjecie = value; OnPropertyChanged("Zdjecie"); }
        }
        public string Region { get; set; }
        public int Dostep { get; set; }
        public double Kwota { get; set; }

        public string Plec
        {
            get
            {
                return plec;
            }
            set { plec = value; OnPropertyChanged("Plec"); }
        }
        public int Wiek { get; set; }
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
            {
                nazwisko = value;
                OnPropertyChanged("wyswietl");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("wyswietl");
            }
        }
        public bool boolplecm
        {
            get { return Plec.Equals("mezczyzna"); }
            set { Plec = "mezczyzna"; OnPropertyChanged("boolpleck"); }
        }
        public bool boolpleck
        {
            get { return Plec.Equals("kobieta"); }
            set { Plec = "kobieta"; OnPropertyChanged("boolplecm"); }
        }
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
            this.Plec = "";
            this.Wiek = 0;
            this.Zdjecie = null;
            this.Pesel = "";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                new PropertyChangedEventArgs(property));
        }
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Wiek":
                        if (Wiek < 0)
                        {
                            return "wiek musi byc dodatni";
                        }
                        break;
                    case "Kwota":
                        if (Kwota < 0)
                        {
                            return "kwota musi byc dodatnia";
                        }
                        break;
                    case "Nazwisko":
                        if (string.IsNullOrEmpty(Nazwisko))
                        {
                            return "nazwisko nie moze byc puste";
                        }
                        break;
                    case "Email":
                        if (!string.IsNullOrEmpty(Email))
                        {
                                try
                                {
                                    MailAddress mail = new MailAddress(Email);
                                    email = Email;
                                }
                                catch (FormatException)
                                {
                                    email = null;
                                    return "To nie jest poprawny formal adresu email";
                                }
                        }
                        break;
                    case "Pesel":
                        long pesel;
                        if (long.TryParse(Pesel, out pesel))
                        {
                            if (Pesel.ToString().Length != 11)
                            {
                                return "pesel musi miec 11 znakow!";
                            }
                        }
                        else
                        {
                            return "pesel musi miec 11 znakow!";
                        }
                        
                        break;
                    default:
                        break;
                }
                return null;
            }
        }
        public string Error
        {
            get { return null; }
        }
    }
    
}
