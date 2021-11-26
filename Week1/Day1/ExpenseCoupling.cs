using System;
using System.Linq;

namespace Week1.Day1
{
    public class Day1
    {
        
        private readonly int _targetValue;
        private readonly int[] _expenses;

        public Day1(int targetValue, int[] expenses)
        {
            _targetValue = targetValue;
            _expenses = expenses;
        }

        public int ReminderOfTargetValueTakeawayFrom(int firstValue)
        {
            return _targetValue - firstValue;
        }

        public bool IsValueInArray(int secondValue)
        {
            return _expenses.Contains(secondValue);
        }

        public (int firstValue, int secondValue) GetFirstAndSecondValue()
        {
            foreach (var firstValue in _expenses)
            {
                var possibleSecondValue = ReminderOfTargetValueTakeawayFrom(firstValue);

                if (IsTwoValueIsExactSame(firstValue, possibleSecondValue)) continue;
                
                if (IsValueInArray(possibleSecondValue))
                {
                    return (firstValue, possibleSecondValue);
                }
            }

            throw new Exception("No two number add to 2000");
        }

        private bool IsTwoValueIsExactSame(int firstValue, int possibleSecondValue)
        {
            if (firstValue != possibleSecondValue) return false;
            var isMoreThenOneValue
                = _expenses.Where(x => x == possibleSecondValue).ToList().Count > 1 ? true : false;

            return isMoreThenOneValue;
        }
    }
}