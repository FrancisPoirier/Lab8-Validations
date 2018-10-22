using Lab8_Validations.ViewModels;
using Lab8_Validations.Externalization;
using Lab8_Validations.Validations;
using Prism.Navigation;
using System;
using Lab8_UnitTests.Mocks;
using System.Linq;
using Xunit;

namespace Lab8_UnitTests.ViewModels
{
    public class LoginPageViewModelUnitTests
    {
        private readonly LoginPageViewModel _viewModel;
        private readonly MockNavigationService _navigationService;
        private bool _eventRaised;

        public LoginPageViewModelUnitTests()
        {
            _navigationService = new MockNavigationService();
            _viewModel = new LoginPageViewModel(_navigationService);
            _eventRaised = false;
        }

        [Fact]
        public void ValidateConnexionCommand_WithInvalidUserName_ShouldInvalidateUserNameValidatableObject()
        {
            const string INVALID_USERNAME = "invalid";
            _viewModel.UserName.Value = INVALID_USERNAME;

            _viewModel.ConnectCommand.Execute();

            Assert.False(_viewModel.UserName.IsValid);
        }

        [Fact]
        public void ValidateConnexionCommand_WithInvalidUserName_ShouldAddErrorsToTheUserNameValidatableObject()
        {
            const string INVALID_USERNAME = "invalid";
            _viewModel.UserName.Value = INVALID_USERNAME;

            _viewModel.ConnectCommand.Execute();

            var firstUserNameError = _viewModel.UserName.Errors.ElementAt(0);
            Assert.Equal(UiText.EmailInvalid, firstUserNameError);
        }

        [Fact]
        public void ValidateConnexionCommand_WithValidUserName_ShouldValidateUserNameValidatableObject()
        {
            const string VALID_USERNAME = "validUsername@valid.com";
            _viewModel.UserName.Value = VALID_USERNAME;

            _viewModel.ConnectCommand.Execute();

            Assert.True(_viewModel.UserName.IsValid);
        }

        [Fact]
        public void UserName_WhenValueChanges_ShouldRaisedPropertyChanged()
        {
            _viewModel.PropertyChanged += RaisedPropertyChange;

            _viewModel.UserName = new ValidatableObject<string>();

            Assert.True(_eventRaised);
        }

        [Fact]
        public void ValidateConnexionCommand_WithInvalidPassword_ShouldInvalidatePasswordValidatableObject()
        {
            const string INVALID_PASSWORD = "invalid";
            _viewModel.Password.Value = INVALID_PASSWORD;

            _viewModel.ConnectCommand.Execute();

            Assert.False(_viewModel.Password.IsValid);
        }

        private void RaisedPropertyChange(object sender, EventArgs e)
        {
            _eventRaised = true;
        }
    }
}
