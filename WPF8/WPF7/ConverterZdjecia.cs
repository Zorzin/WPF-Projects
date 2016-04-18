using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WPF7
{
    class ConverterZdjecia :IValueConverter
    {
        public string ImageDir { get; set; }
        public ConverterZdjecia()
        {
            string dir = null, imgdir;
            do
            {
                if (dir == null)
                    dir = Directory.GetCurrentDirectory();
                else
                    dir = Directory.GetParent(dir).ToString();
                imgdir = System.IO.Path.Combine(dir, "zdjecia");
            } while (!Directory.Exists(imgdir));
            ImageDir = imgdir;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string imagePath = System.IO.Path.Combine(ImageDir, (string)value);
                return new BitmapImage(new Uri(imagePath));
            }
            catch
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
