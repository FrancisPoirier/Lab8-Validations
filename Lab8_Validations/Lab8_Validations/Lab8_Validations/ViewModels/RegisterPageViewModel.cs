﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using Lab8_Validations.Validations;
using Lab8_Validations.Validations.Rules;
using Lab8_Validations.Externalization;
using Lab8_Validations.Views;

namespace Lab8_Validations.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;
        private INavigationService _navigationService;

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

        public DelegateCommand ValidateUserNameCommand => new DelegateCommand(ValidateUserName);
        public DelegateCommand ValidatePasswordCommand => new DelegateCommand(ValidatePassword);
        public DelegateCommand NavigateToHomePageCommand => new DelegateCommand(NavigateToHomePage);

        public RegisterPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();
            _navigationService = navigationService;
            AddValidations();
        }

        private void AddValidations()
        {
            AddUserNameValidations();
            AddPasswordValidations();
        }

        private void AddUserNameValidations()
        {
            var usernameRequired = new IsNotNullOrEmpty<string>()
            {
                ValidationMessage = UiText.UsernameRequired
            };
            _userName.AddValidationRule(usernameRequired);

            var isEmailValid = new IsEmailValid<string>()
            {
                ValidationMessage = UiText.EmailInvalid
            };
            _userName.AddValidationRule(isEmailValid);
        }

        private void AddPasswordValidations()
        {
            var passwordRequired = new IsNotNullOrEmpty<string>()
            {
                ValidationMessage = UiText.PasswordRequired
            };
            _password.AddValidationRule(passwordRequired);

            var hasTenOrMoreChars = new HasTenCharactersOrMore<string>()
            {
                ValidationMessage = UiText.TooShortPassword
            };
            _password.AddValidationRule(hasTenOrMoreChars);

            var hasLowerCase = new HasLowerCase<string>()
            {
                ValidationMessage = UiText.NoLowerCasePassword
            };
            _password.AddValidationRule(hasLowerCase);

            var hasUpperCase = new HasUpperCase<string>()
            {
                ValidationMessage = UiText.NoUpperCasePassword
            };
            _password.AddValidationRule(hasUpperCase);

            var hasNumber = new HasNumber<string>()
            {
                ValidationMessage = UiText.NoNumberPassword
            };
            _password.AddValidationRule(hasNumber);
        }

        private void ValidateUserName()
        {
            _userName.Validate();
            //RefreshCanExecutes();
        }

        private void ValidatePassword()
        {
            _password.Validate();
            //RefreshCanExecutes();
        }

        private void NavigateToHomePage()
        {
            if (_userName.IsValid && _password.IsValid)
                _navigationService.NavigateAsync(nameof(HomePageView));
        }

        //private bool CanExecuteNavigateToHomePage()
        //{
        //    return _userName.IsValid && _password.IsValid ? true : false;
        //}

        //private void RefreshCanExecutes()
        //{
        //    NavigateToHomePageCommand.CanExecute();
        //}
    }
}
