using Xunit;
using Lab8_Validations.Validations.Rules;

namespace Lab8_UnitTests.Validations.Rules
{
    public class HasLowerCaseUnitTests
    {
        private readonly HasLowerCase<string> _rule;

        public HasLowerCaseUnitTests()
        {
            _rule = new HasLowerCase<string>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("TEST")]
        [InlineData(" ")]
        public void Check_WhenStringHasNoLowerCaseLetter_ShouldReturnFalse(string invalidInput)
        {
            bool actualAnswer = _rule.Check(invalidInput);

            Assert.False(actualAnswer);
        }

        [Theory]
        [InlineData("t")]
        [InlineData("test")]
        public void Check_WhenStringHasLowerCaseLetter_ShouldReturnTrue(string invalidInput)
        {
            bool actualAnswer = _rule.Check(invalidInput);

            Assert.True(actualAnswer);
        }
    }
}
