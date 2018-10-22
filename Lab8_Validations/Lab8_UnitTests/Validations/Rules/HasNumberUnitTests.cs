using Xunit;
using Lab8_Validations.Validations.Rules;

namespace Lab8_UnitTests.Validations.Rules
{
    public class HasNumberUnitTests
    {
        private readonly HasNumber<string> _rule;

        public HasNumberUnitTests()
        {
            _rule = new HasNumber<string>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("test")]
        [InlineData(" ")]
        public void Check_WhenStringHasNumber_ShouldReturnFalse(string invalidInput)
        {
            bool actualAnswer = _rule.Check(invalidInput);

            Assert.False(actualAnswer);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("23")]
        public void Check_WhenStringHasNumber_ShouldReturnTrue(string invalidInput)
        {
            bool actualAnswer = _rule.Check(invalidInput);

            Assert.True(actualAnswer);
        }
    }
}
