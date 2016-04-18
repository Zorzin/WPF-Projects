using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF7
{
    class TloConverter : IValueConverter
    {
        public Brush MeskiBrush { get; set; }
        public Brush ZenskiBrush { get; set; }
        public Brush MainBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string plec = (string)value;
                if (plec == "mezczyzna")
                {
                    return MeskiBrush;
                }
                if (plec == "kobieta")
                {
                    return ZenskiBrush;
                }
                return MainBrush;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
