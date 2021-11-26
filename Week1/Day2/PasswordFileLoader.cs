using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Week1.Day2
{
    public static class PasswordFileLoader
    {
        public static async Task<string[]> LoadAsync(string fileName)
        {
            List<string> policyPasswords = new();

            using var reader = new StreamReader(fileName);
            
            while (true)
            {
                var line = await reader.ReadLineAsync();
                if (line is null)
                    break;

                policyPasswords.Add(line);
                    
            }
            
            reader.Close();

            return policyPasswords.ToArray();
        }
    }
}