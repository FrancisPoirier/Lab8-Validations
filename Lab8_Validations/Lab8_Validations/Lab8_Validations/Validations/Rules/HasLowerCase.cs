using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab8_Validations.Validations.Rules
{
    public class HasLowerCase<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
                return false;

            var str = value as string;
            return str.Any(char.IsLower) ? true : false;
        }
    }
}
