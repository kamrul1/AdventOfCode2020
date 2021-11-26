namespace Week1.Day2
{
    public class ValidPasswordsCounter
    {
        private readonly string[] _policyPasswords;

        public ValidPasswordsCounter(string[] policyPasswords)
        {
            _policyPasswords = policyPasswords;
        }

        public int Count()
        {
            var counter = 0;
            foreach (var policyPassword in _policyPasswords)
            {
                var pv = new PasswordValidator(policyPassword);
                if (pv.IsCharOccuranceWithinPolicy())
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}