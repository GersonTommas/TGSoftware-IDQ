﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace IDQ.WPF.Converters
{
    class NullToTrueComparerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter?.ToString().ToLower() == "true" ? value != null : (object)(value == null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotSupportedException(); }
    }
}
