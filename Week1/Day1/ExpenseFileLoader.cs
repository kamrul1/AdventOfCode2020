using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Week1.Day1
{
    public static class ExpenseFileLoader
    {
        public static async Task<int[]> LoadAsync(string fileName)
        {
            List<int> numbers = new();
            
            using (var reader = new StreamReader(fileName))
            {
                while (true)
                {
                    var line = await reader.ReadLineAsync();
                    if (line is null)
                    {
                        break;
                    }

                    if (int.TryParse(line, out var number))
                    {
                        numbers.Add(number);
                    }
          
                }
            }

            return numbers.ToArray();

        }
        
    }
}