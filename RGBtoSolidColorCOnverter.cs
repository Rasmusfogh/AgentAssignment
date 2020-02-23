using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;


namespace GUI7
{
    public class RGBtoSolidColorConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) =>
            System.Windows.Media.Color.FromRgb(
                System.Convert.ToByte(values[0]),
                System.Convert.ToByte(values[1]),
                System.Convert.ToByte(values[2]));

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) =>
            throw new NotImplementedException();
    }

}
