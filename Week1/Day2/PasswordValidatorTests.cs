using Xunit;

namespace Week1.Day2
{
    public class PasswordValidatorTests
    {
        [Fact]
        public void ShouldReturnTrueForIsCharOccuranceInPolicy()
        {
            const string inputRuleAndPassword = "1-3 a: abcde";
            var sut = new PasswordValidator(inputRuleAndPassword);

            var isValid = sut.IsCharOccuranceWithinPolicy();

            Assert.True(isValid);
            
        }

        [Fact]
        public void ShouldReturnMinAndMaxCharPolicy()
        {
            const string inputRuleAndPassword = "1-3 a: abcde";
            var sut = new PasswordValidator(inputRuleAndPassword);

            var (min, max) = sut.GetMinMaxCharPolicy();
            
            Assert.Equal(1, min);
            Assert.Equal(3, max);

        }

        [Fact]
        public void ShouldReturnFalseForIsCharOccuranceInPolicy()
        {
            const string inputRuleAndPassword = "1-3 b: cdefg";
            var sut = new PasswordValidator(inputRuleAndPassword);

            var notValid = sut.IsCharOccuranceWithinPolicy();

            Assert.False(notValid);
            
        }
    }
}