using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace TicTacToe.Converters
{
    internal class CoordinateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values != null && values.Length == 2)
            {
                var datagridcellinfo = (DataGridCellInfo)values[0]; // from left to right

                var datagrid = (DataGrid)values[1];

                DataGridRow dgrow = (DataGridRow)datagrid.ItemContainerGenerator.ContainerFromItem(datagridcellinfo.Item);

                return new int[2] { datagridcellinfo.Column != null ? datagridcellinfo.Column.DisplayIndex : 0, dgrow != null ? dgrow.GetIndex() : 0};
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
