using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformacijosSaugumas1
{
    public class Validator
    {
        public static string GetValidInput(string prompt, string errorMessage)
            {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(errorMessage);
                return null;
            }
            return input;
        }
    }
}