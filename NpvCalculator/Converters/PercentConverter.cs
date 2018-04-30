using System;
using System.Globalization;
using System.Windows.Data;
using NpvCalculator.Core.Extensions;

namespace NpvCalculator.Converters
{
    public class PercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var returnValue = (double?)value * 100;

            if (!returnValue.HasValue) return null;

            return returnValue.Value.IsZero() ? null : returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;

            double d = 0;

            if (double.TryParse(value.ToString(), out d))
            {
                return d / 100;
            }

            return 0;
        }
    }
}
