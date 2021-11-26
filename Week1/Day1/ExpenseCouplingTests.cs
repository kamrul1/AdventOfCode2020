using System;
using System.IO;
using Xunit;

namespace Week1.Day1
{
    public class ExpenseCouplingTests
    {
        private readonly ExpenseCoupling _sut; 

        public ExpenseCouplingTests()
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "ExpenseFile.txt", SearchOption.AllDirectories);
            if (files == null || files.Length == 0)
                throw new Exception("ExpenseFile not found.");

            var numbersList = ExpenseFileLoader.LoadAsync(files[0]).Result;
            
            _sut = new ExpenseCoupling(2020, numbersList);
        }
        
        [Fact]
        public void ShouldTakeAwayFromTargetValueGivenNumber()
        {


            var result = _sut.ReminderOfTargetValueTakeawayFrom(500);
            
            Assert.Equal(1520, result);
        }

        [Fact]
        public void ShouldReturnSecondValueGivenFirstValue()
        {

            var result = _sut.ReminderOfTargetValueTakeawayFrom(1411);
            
            Assert.Equal(609, result);
        }

        [Fact]
        public void ShouldReturnDoesSecondValueExistInArray()
        {

            var secondValue = _sut.ReminderOfTargetValueTakeawayFrom(1411);

            var result = _sut.IsValueInArray(secondValue);
            
            Assert.False(result);

        }

        [Fact]
        public void ShouldReturnActualMatchingSecondValues()
        {

            var result = _sut.GetFirstAndSecondValue();
            
            Assert.Equal(2020, result.firstValue+result.secondValue);

        }

        [Fact]
        public void ShouldReturnMultipleFirstAndSecondValues()
        {
            var result = _sut.GetFirstAndSecondValue();

            var multipliedResult = result.firstValue * result.secondValue;
            
            Assert.Equal(902451, multipliedResult);
        }
        
    }
    
}