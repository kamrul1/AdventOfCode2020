using System;
using System.IO;
using System.Threading.Tasks;
using Week1.Day1;
using Xunit;

namespace Week1.Day2
{
    public class ValidPasswordsCounterTests
    {
        [Fact]
        public void ShouldReturnValidPasswordCount()
        {
            var policyPasswords = new[]
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };

            var sut = new ValidPasswordsCounter(policyPasswords);

            var result = sut.Count();

            Assert.Equal(2, result);
        }
        
        [Fact]
        public async Task ShouldReturnActualValidPasswordCountFromFile()
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "PasswordsFile.txt", SearchOption.AllDirectories);
            if (files == null || files.Length == 0)
                throw new Exception("PasswordsFile not found.");
        
            var policyPasswords = await PasswordFileLoader.LoadAsync(files[0]);
            
            var sut = new ValidPasswordsCounter(policyPasswords);

            var result = sut.Count();
            
            Assert.Equal(640, result);
        }
    }
}