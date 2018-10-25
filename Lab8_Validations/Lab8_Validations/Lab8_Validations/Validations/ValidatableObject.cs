using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;
using System.Linq;

namespace Lab8_Validations.Validations
{
    public class ValidatableObject<T> : BindableBase
    {
        private readonly List<IValidationRule<T>> _validationRules;
        private List<string> _errors;
        private T _value;
        private bool _isValid;


        public List<string> Errors
        {
            get => _errors;
            set
            {
                _errors = value;
                RaisePropertyChanged();
            }
        }

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }

        public bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                RaisePropertyChanged();
            }
        }

        public ValidatableObject()
        {
            _isValid = false;
            _errors = new List<string>();
            _validationRules = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validationRules
                .Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return IsValid;
        }

        public void AddValidationRule(IValidationRule<T> validationRule)
        {
            _validationRules.Add(validationRule);
        }
    }
}
