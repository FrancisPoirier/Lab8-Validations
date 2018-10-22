﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace Lab8_Validations.Converters
{
    public class FirstValidationErrorToTextConverter : IValueConverter
    {
        // Input: une collection d'erreurs.
        // Output:une chaine de caractères contenant la première erreur de la collection
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ICollection<string> errors = value as ICollection<string>;
            return errors != null && errors.Count > 0 ? errors.ElementAt(0) : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}