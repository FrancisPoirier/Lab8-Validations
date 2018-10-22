using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8_Validations.Validations.Rules
{
    public class IsEmailValid<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
                return false;

            var str = value as string;

            return str.Contains("@") && str.Contains(".") ? true : false;
        }
    }
}

