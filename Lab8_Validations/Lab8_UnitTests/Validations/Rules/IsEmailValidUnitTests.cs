using System;
using Xunit;
using Lab8_Validations.Validations.Rules;

namespace Lab8_UnitTests
{
    public class IsEmailValidUnitTests
    {
        private readonly IsEmailValid<string> _rule;

        private const string VALID_EMAIL = "avalidemail@email.com";

        public IsEmailValidUnitTests()
        {
            _rule = new IsEmailValid<string>();
        }

        [Theory]
        [InlineData("asdasdasdasdasd")]
        [InlineData("asdasdasd.com")]
        public void Check_WhenStringDoesNotContainAtSymbol_shouldReturnFalse(string invalidEmail)
        {
            bool actualAnswer = _rule.Check(invalidEmail);

            Assert.False(actualAnswer);
        }

        [Theory]
        [InlineData("asdasdasdcom")]
        [InlineData("asdasdasd@com")]
        public void Check_WhenStringDoesNotContainsADot_shouldReturnFalse(string invalidEmail)
        {
            bool actualAnswer = _rule.Check(invalidEmail);

            Assert.False(actualAnswer);
        }

        [Fact]
        public void Check_WhenStringContainsAtAndADot_shouldReturnTrue()
        {
            bool actualAnswer = _rule.Check(VALID_EMAIL);

            Assert.True(actualAnswer);
        }
    }
}
        