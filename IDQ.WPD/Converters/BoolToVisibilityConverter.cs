using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace IDQ.WPF.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tempString = (string)parameter;

            return !string.IsNullOrWhiteSpace(tempString) ?
                tempString.ToLower() == "true" ? (bool)value ? Visibility.Collapsed : Visibility.Visible : (object)((bool)value ? Visibility.Visible : Visibility.Collapsed)
                : (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotSupportedException(); }
    }
}
