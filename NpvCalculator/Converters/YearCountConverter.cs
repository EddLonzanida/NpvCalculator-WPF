using System;
using System.Globalization;
using System.Windows.Data;

namespace NpvCalculator.Converters
{
    public class YearCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var index = (int?)value;

            if (!index.HasValue) return null;

            var yearCount = index.Value + 1;

            return yearCount;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
