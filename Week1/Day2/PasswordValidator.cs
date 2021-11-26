using System;
using System.Linq;
using System.Security.Principal;

namespace Week1.Day2
{
    public class PasswordValidator 
    {
        private readonly string _policy;
        private readonly char _policyChar;
        private readonly string _password;

        public PasswordValidator(string inputRuleAndPassword)
        {
            string[] policyAndPassword = inputRuleAndPassword.Split(" ")!;
            _policy = policyAndPassword[0]!;
            _policyChar = policyAndPassword[1].Replace(":", "").ToCharArray().First();
            _password = policyAndPassword[2]!;
        }

        public bool IsCharOccuranceWithinPolicy()
        {
            
            var wordCounter = _password.Count(x => x.Equals(_policyChar));
            var (min, max) = GetMinMaxCharPolicy();
            
            return wordCounter>=min && wordCounter<=max;
            
        }

        public (int min, int max) GetMinMaxCharPolicy()
        {
            var policies = _policy.Split("-");
            var min = int.Parse(policies[0]);
            var max = int.Parse(policies[1]);

            return (min, max);
        }
    }
}