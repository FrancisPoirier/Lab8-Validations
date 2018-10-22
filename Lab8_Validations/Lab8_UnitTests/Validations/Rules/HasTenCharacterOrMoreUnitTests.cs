using Xunit;
using Lab8_Validations.Validations.Rules;

namespace Lab8_UnitTests.Validations.Rules
{
    public class HasTenCharacterOrMoreUnitTests
    {
        private readonly HasTenCharactersOrMore<string> _rule;

        public HasTenCharacterOrMoreUnitTests()
        {
            _rule = new HasTenCharactersOrMore<string>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("TEST")]
        public void Check_WhenStringHasLessThen10Chars_ShouldReturnFalse(string invalidInput)
        {
            bool actualAnswer = _rule.Check(invalidInput);

            Assert.False(actualAnswer);
        }

        [Theory]
        [InlineData("aaaaabbbbb")]
        [InlineData("aaaaabbbbbc")]
        public void Check_WhenStringHas10OrMoreChars_ShouldReturnTrue(string invalidInput)
        {
            bool actualAnswer = _rule.Check(invalidInput);

            Assert.True(actualAnswer);
        }
    }
}
