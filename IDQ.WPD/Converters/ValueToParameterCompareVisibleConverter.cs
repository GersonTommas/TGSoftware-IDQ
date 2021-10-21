using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace IDQ.WPF.Converters
{
    [ValueConversion(typeof(int), typeof(Visibility))]
    class ValueToParameterCompareVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                if (value.ToString() == parameter.ToString()) { return Visibility.Visible; }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotImplementedException(); }
    }
}
