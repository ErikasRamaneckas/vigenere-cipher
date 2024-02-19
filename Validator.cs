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

        public static string CheckKey(char[] cipherLetters, string key, string errorMessage)
        {
           foreach (char c in key)
            {
                if (Array.IndexOf(cipherLetters, char.ToUpper(c)) == -1)
                {
                    Console.WriteLine(errorMessage);
                    return null;
                }
             }
            return key;
        }
    }
}