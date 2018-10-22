using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
namespace Lab8_Validations.Converters
{
    public class IsValueGreaterThanZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value) > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
