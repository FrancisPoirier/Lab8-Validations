using Lab8_Validations.Validations.Rules;
using Xunit;

namespace Lab8_UnitTests.Validations.Rules
{
    public class IsNotNullOrEmptyUnitTests
    {
        private readonly IsNotNullOrEmpty<string> _rule;

        public IsNotNullOrEmptyUnitTests()
        {
            _rule = new IsNotNullOrEmpty<string>();
        }

        [Fact]
        public void Check_WhenStringIsNull_ShouldReturnFalse()
        {
            var isValid = _rule.Check(null);

            Assert.False(isValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        public void Check_WhenStringIsEmpty_ShouldReturnFalse(string emptyString)
        {
            var isValid = _rule.Check(emptyString);

            Assert.False(isValid);
        }

        [Theory]
        [InlineData("ok")]
        [InlineData("ok ok")]
        public void Check_WhenStingIsNotEmptyOrNotNull_ShouldReturnTrue(string email)

        {
            var isValid = _rule.Check(email);

            Assert.True(isValid);
        }
    }
}
