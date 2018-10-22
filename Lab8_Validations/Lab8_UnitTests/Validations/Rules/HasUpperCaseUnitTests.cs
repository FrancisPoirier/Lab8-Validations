using Xunit;
using Lab8_Validations.Validations.Rules;

namespace Lab8_UnitTests.Validations.Rules
{
    public class HasUpperCaseUnitTests
    {
        private readonly HasUpperCase<string> _rule;

        public HasUpperCaseUnitTests()
        {
            _rule = new HasUpperCase<string>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("test")]
        [InlineData(" ")]
        public void Check_WhenStringHasNoUpperCaseLetter_ShouldReturnFalse(string invalidInput)
        {
            bool actualAnswer = _rule.Check(invalidInput);

            Assert.False(actualAnswer);
        }

        [Theory]
        [InlineData("T")]
        [InlineData("TEST")]
        public void Check_WhenStringHasUpperCaseLetter_ShouldReturnTrue(string invalidInput)
        {
            bool actualAnswer = _rule.Check(invalidInput);

            Assert.True(actualAnswer);
        }
    }
}
