using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace GUI7
{
    public class HighlightTextConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Int64 convertedValue = System.Convert.ToInt64(value);
            //Int64 threshold = System.Convert.ToInt64(parameter);
            if (value == parameter)
                return true;
            return false;  
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
