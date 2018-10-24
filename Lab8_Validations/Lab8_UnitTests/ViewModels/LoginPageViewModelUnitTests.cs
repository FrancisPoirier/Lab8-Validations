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
        public void ValidateUserNameCommand_WithInvalidUserName_ShouldInvalidateUserNameValidatableObject()
        {
            const string INVALID_USERNAME = "invalid";
            _viewModel.UserName.Value = INVALID_USERNAME;

            _viewModel.ValidateUserNameCommand.Execute();

            Assert.False(_viewModel.UserName.IsValid);
        }

        [Fact]
        public void ValidateUserNameCommand_WithInvalidUserName_ShouldAddErrorsToTheUserNameValidatableObject()
        {
            const string INVALID_USERNAME = "invalid";
            _viewModel.UserName.Value = INVALID_USERNAME;

            _viewModel.ValidateUserNameCommand.Execute();

            var firstUserNameError = _viewModel.UserName.Errors.ElementAt(0);
            Assert.Equal(UiText.EmailInvalid, firstUserNameError);
        }

        [Fact]
        public void ValidateUserNameCommand_WithValidUserName_ShouldValidateUserNameValidatableObject()
        {
            const string VALID_USERNAME = "validUsername@valid.com";
            _viewModel.UserName.Value = VALID_USERNAME;

            _viewModel.ValidateUserNameCommand.Execute();

            Assert.True(_viewModel.UserName.IsValid);
        }

        [Fact]
        public void ValidatePasswordCommand_WithInvalidPassword_ShouldInvalidatePasswordValidatableObject()
        {
            const string INVALID_PASSWORD = "invalid";
            _viewModel.Password.Value = INVALID_PASSWORD;

            _viewModel.ValidatePasswordCommand.Execute();

            Assert.False(_viewModel.Password.IsValid);
        }

        [Fact]
        public void ValidatePasswordCommand_WithInvalidPasswordThatHasOneError_ShouldAddAnErrorToThePasswordValidatableObject()
        {
            const string INVALID_PASSWORD = "Ab1";
            _viewModel.Password.Value = INVALID_PASSWORD;

            _viewModel.ValidatePasswordCommand.Execute();

            var firstPasswordError = _viewModel.Password.Errors.ElementAt(0);
            Assert.Equal(UiText.TooShortPassword, firstPasswordError);
        }

        [Fact]
        public void ValidatePasswordCommand_WithInvalidPasswordThatHasMultipleErrors_ShouldAddErrorsToThePasswordValidatableObject()
        {
            const string INVALID_PASSWORD = "Ab";
            _viewModel.Password.Value = INVALID_PASSWORD;

            _viewModel.ValidatePasswordCommand.Execute();

            var expectedNumberOfErrors = 2;
            Assert.Equal(expectedNumberOfErrors, _viewModel.Password.Errors.Count);
        }

        [Fact]
        public void CanNavigateToHomePage_WithValidPasswordAndUsername_shouldReturnTrue()
        {
            const string VALID_USERNAME = "validUser@hotmail.com";
            const string VALID_PASSWORD = "Abcdefghijkl134";
            _viewModel.UserName.Value = VALID_USERNAME;
            _viewModel.Password.Value = VALID_PASSWORD;

            bool actualAnswer = _viewModel.NavigateToHomePageCommand.CanExecute();

            const bool EXPECTED_ANSWER = true;
            Assert.Equal(EXPECTED_ANSWER, actualAnswer);
        }

        [Fact]
        public void CanNavigateToHomePage_WithInvalidPasswordOrUsername_shouldReturnFalse()
        {
            const string INVALID_USERNAME = "invalidUser";
            const string INVALID_PASSWORD = "abc";
            _viewModel.UserName.Value = INVALID_USERNAME;
            _viewModel.Password.Value = INVALID_PASSWORD;

            bool actualAnswer = _viewModel.NavigateToHomePageCommand.CanExecute();

            const bool EXPECTED_ANSWER = false;
            Assert.Equal(EXPECTED_ANSWER, actualAnswer);
        }

        [Fact]
        public void UserName_WhenValueChanges_ShouldRaisedPropertyChanged()
        {
            _viewModel.PropertyChanged += RaisedPropertyChange;

            _viewModel.UserName = new ValidatableObject<string>();

            Assert.True(_eventRaised);
        }

        [Fact]
        public void Password_WhenValueChanges_ShouldRaisedPropertyChanged()
        {
            _viewModel.PropertyChanged += RaisedPropertyChange;

            _viewModel.Password = new ValidatableObject<string>();

            Assert.True(_eventRaised);
        }

        private void RaisedPropertyChange(object sender, EventArgs e)
        {
            _eventRaised = true;
        }
    }
}
