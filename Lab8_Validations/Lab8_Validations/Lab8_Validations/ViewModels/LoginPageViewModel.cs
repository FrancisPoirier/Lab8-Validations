using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using Lab8_Validations.Validations;
using Lab8_Validations.Validations.Rules;
using Lab8_Validations.Externalization;

namespace Lab8_Validations.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;
        
        public ValidatableObject<string> UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                RaisePropertyChanged();
            }
        }

        public ValidatableObject<string> Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand ConnectCommand => new DelegateCommand(ValidateConnexionCriterias);        

        public LoginPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();
            AddValidations();
        }

        private void AddValidations()
        {
            AddUserNameValidations();
            
        }

        private void AddUserNameValidations()
        {
            var isEmailValid = new IsEmailValid<string>()
            {
                ValidationMessage = UiText.EmailInvalid
            };
            _userName.AddValidationRule(isEmailValid);
        }

        private void ValidateConnexionCriterias()
        {
            _userName.Validate();    
        }

        
    }
}
