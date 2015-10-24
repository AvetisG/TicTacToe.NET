using System;
using System.Windows.Data;
using TicTacToe.Enums;

namespace TicTacToe.Converters
{
    internal class EmptyCellEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(String))
                throw new InvalidOperationException("The target must be a string");

            return value.ToString().Equals(ControlEnums.Player.None.ToString()) ? String.Empty : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
