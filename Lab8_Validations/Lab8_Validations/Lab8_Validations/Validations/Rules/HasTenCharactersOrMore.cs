using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8_Validations.Validations.Rules
{
    public class HasTenCharactersOrMore<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
                return false;

            var str = value as string;
            return str.Length >= 10 ? true : false;
        }
    }
}
