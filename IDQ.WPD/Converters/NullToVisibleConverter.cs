using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace IDQ.WPF.Converters
{
    class NullToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter?.ToString().ToLower() == "true"
                ? value is not null ? Visibility.Visible : Visibility.Collapsed
                : (object)(value is null ? Visibility.Visible : Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotSupportedException(); }
    }
}
