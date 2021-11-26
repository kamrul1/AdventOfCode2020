using System;
using System.Collections.Generic;
using System.Linq;

namespace Week1.Day1
{
    public class ExpenseCoupling
    {
        
        private readonly int _targetValue;
        private readonly int[] _expenses;

        public ExpenseCoupling(int targetValue, int[] expenses)
        {
            _targetValue = targetValue;
            _expenses = expenses;
        }

        public int ReminderOfTargetValueTakeawayFrom(int firstValue) => _targetValue - firstValue;

        public bool IsValueInArray(int secondValue) => _expenses.Contains(secondValue);

        public (int firstValue, int secondValue) GetFirstAndSecondValue()
        {
            foreach (var firstValue in _expenses)
            {
                var possibleSecondValue = ReminderOfTargetValueTakeawayFrom(firstValue);

                if (IsOneOccuranceOfNumber(firstValue, possibleSecondValue)) continue;
                
                if (IsValueInArray(possibleSecondValue)) return (firstValue, possibleSecondValue);
            }

            throw new Exception($"No two number add to {_targetValue}");
        }

        public bool IsOneOccuranceOfNumber(int firstValue, int possibleSecondValue)
        {
            if (firstValue != possibleSecondValue) return false;
            
            var sameNumbers = _expenses.Where(x => x == possibleSecondValue).ToList();

            return sameNumbers.Count > 1;
        }
    }
}