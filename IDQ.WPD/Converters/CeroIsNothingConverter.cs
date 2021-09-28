using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IDQ.WPF.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    class CeroIsNothingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int tempInt = (int)value;

            return tempInt > 0 ? tempInt : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotSupportedException(); }
    }
}
