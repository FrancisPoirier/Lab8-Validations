using Lab8_Validations.ViewModels;
using Prism.Navigation;
using Lab8_UnitTests.Mocks;
using Xunit;

namespace Lab8_UnitTests.ViewModels
{
    public class LoginPageViewModelUnitTests
    {
        private readonly LoginPageViewModel _viewModel;
        private readonly MockNavigationService _navigationService;

        public LoginPageViewModelUnitTests()
        {
            _navigationService = new MockNavigationService();
            _viewModel = new LoginPageViewModel(_navigationService);            
        }

        [Fact]
        public void ValidateConnexionCommand_WithBadUserName_ShouldValidateUserNameValidatableObject()
        {
            const string INVALID_USERNAME = "invalid";

            _viewModel.ConnectCommand.Execute();

            Assert.False(_viewModel.UserName.IsValid);
        }
    }
}
