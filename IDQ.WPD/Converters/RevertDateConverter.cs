using System;
using System.Globalization;
using System.Windows.Data;

namespace IDQ.WPF.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    class RevertDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.Parse((string)value).ToString("dd/MM/yy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotSupportedException(); }
    }
}
