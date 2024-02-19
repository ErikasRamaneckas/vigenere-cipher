using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacijosSaugumas1
{
    public class InputHandler
    {
        public static void TextEncryption(bool useAscii)
        {
            string originalText = Validator.GetValidInput("Įveskite pradinį tekstą: ", "Pradinis tekstas negali būti tuščias.");
            if(originalText == null)
            {
                return;
            }
            
            string key = Validator.GetValidInput("Įveskite raktą: ", "Raktas negali būti tuščias.");
            if(key == null)
            {
                return;
            }

            KeyGenerator keyGenerator = new KeyGenerator();
            string generatedKey = keyGenerator.generateKey(originalText, key);

            if(useAscii)
            {
                string resultAscii = VigenereCipher.EncryptASCII(originalText, generatedKey);
                Console.WriteLine($"\nUžsifruotas tekstas (ASCII): {resultAscii}");
                return;
            }

            key = Validator.CheckKey(VigenereCipher.CipherLetters, key, "Raktas privalo būti sudarytas iš abėcėlės simbolių.");
            if(key == null)
            {
                return;
            }
            
            string result = VigenereCipher.Encrypt(originalText, generatedKey);
            Console.WriteLine($"\nUžsifruotas tekstas: {result}");
        }

        public static void TextDecryption(bool useAscii)
        {
            string cipherText = Validator.GetValidInput("Įveskite užsifruotą tekstą: ", "Užšifruotas tekstas negali būti tuščias.");
            if(cipherText == null)
            {
                return;
            }

            string key = Validator.GetValidInput("Įveskite raktą: ", "Raktas negali būti tuščias.");
            if(key == null)
            {
                return;
            }

            KeyGenerator keyGenerator = new KeyGenerator();
            string generatedKey = keyGenerator.generateKey(cipherText, key);

            if (useAscii)
            {
                string resultAscii = VigenereCipher.DecryptASCII(cipherText, generatedKey);
                Console.WriteLine($"Dešifruotas tekstas (ASCII): {resultAscii}");
                return;
            }

            string result = VigenereCipher.Decrypt(cipherText, generatedKey);
            Console.WriteLine($"Dešifruotas tekstas: {result}");
        }
    }
}
