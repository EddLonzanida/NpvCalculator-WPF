using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace NpvCalculator.Converters
{
    public class InvertableBooleanToVisibilityConverter : IValueConverter
    {
        private enum Parameters
        {
            Normal,
            Inverted
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return null;
            }

            if (value == null) return null;

            if (DBNull.Value == value)
            {
                return Visibility.Collapsed;
            }

            var boolValue = (bool)value;
            var direction = parameter != null
                ? (Parameters)Enum.Parse(typeof(Parameters), parameter.ToString())
                : Parameters.Normal;

            if (direction == Parameters.Inverted) return !boolValue ? Visibility.Visible : Visibility.Collapsed;

            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
