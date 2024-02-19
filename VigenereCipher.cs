using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacijosSaugumas1
{
    public static class VigenereCipher
    {
        private static char[] _cipherLetters = new char[]
        { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
        'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
        'R', 'S','T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

        public static char[] CipherLetters { get {return _cipherLetters; } }
        private static int _lowerBound = 32;
        private static int _upperBound = 127;
        private static int _asciiLength = _upperBound - _lowerBound;
        public static string Encrypt(string originalText, string generatedKey)
        {
            string cipherText = "";
            int j = 0;
            for (int i = 0; i < originalText.Length; i++)
            {
                bool isUpperCase = char.IsUpper(originalText[i]);
                if(Array.IndexOf(_cipherLetters, char.ToUpper(originalText[i])) != -1)
                {
                    char encryptedChar = _cipherLetters[(Array.IndexOf(_cipherLetters, char.ToUpper(originalText[i])) +
                                            Array.IndexOf(_cipherLetters, char.ToUpper(generatedKey[j]))) % _cipherLetters.Length];
                    if (!isUpperCase)
                    {
                        encryptedChar = char.ToLower(encryptedChar);
                    }
                    cipherText += encryptedChar;
                    j++;
                }
                else
                {
                    cipherText += originalText[i];
                }
            }
            return cipherText;
        }

        public static string EncryptASCII(string originalText, string generatedKey)
        {
            string cipherText = "";
            for (int i = 0; i < originalText.Length; i++)
            {
                int charIndex = (originalText[i] - _lowerBound + (generatedKey[i] - _lowerBound)) % _asciiLength + _lowerBound;
                cipherText += (char)charIndex;
            }
            return cipherText;
        }

        public static string Decrypt(string encryptedText, string generatedKey)
        {
            string originalText = "";
            int j = 0;
            for (int i = 0; i < encryptedText.Length; i++)
            {
                if (char.IsLetter(encryptedText[i]))
                {
                    bool isUpperCase = char.IsUpper(encryptedText[i]);
                    int decryptedIndex = (Array.IndexOf(_cipherLetters, char.ToUpper(encryptedText[i])) -
                                            Array.IndexOf(_cipherLetters, char.ToUpper(generatedKey[j])) + _cipherLetters.Length) % _cipherLetters.Length;
                    char decryptedChar = _cipherLetters[decryptedIndex];
                    if (!isUpperCase)
                    {
                        decryptedChar = char.ToLower(decryptedChar);
                    }
                    originalText += decryptedChar;
                    j++;
                }
                else
                {
                    originalText += encryptedText[i];
                }
            }
            return originalText;
        }

        public static string DecryptASCII(string encryptedText, string generatedKey)
        {
            string originalText = "";
            for (int i = 0; i < encryptedText.Length; i++)
            {
                int decryptedIndex = (encryptedText[i] - _lowerBound - (generatedKey[i] - _lowerBound) + _asciiLength) % _asciiLength + _lowerBound;
                originalText += (char)decryptedIndex;
            }
            return originalText;
        }
    }
}
