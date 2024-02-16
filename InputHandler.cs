using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacijosSaugumas1
{
    public class InputHandler
    {
        public static void TextEncryption()
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

            string result = VigenereCipher.Encrypt(originalText, generatedKey);
            Console.WriteLine($"\nUžsifruotas tekstas: {result}");

            string resultAscii = VigenereCipher.EncryptASCII(originalText, generatedKey);
            Console.WriteLine($"\nUžsifruotas tekstas (ASCII): {resultAscii}");
        }

        private static void DecryptText(bool useAscii)
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

            string result;
            if (useAscii)
            {
                result = VigenereCipher.DecryptASCII(cipherText, generatedKey);
                Console.WriteLine($"Dešifruotas tekstas (ASCII): {result}");
            }
            else
            {
                result = VigenereCipher.Decrypt(cipherText, generatedKey);
                Console.WriteLine($"Dešifruotas tekstas: {result}");
            }
        }

        public static void TextDecryption()
        {
            DecryptText(false);
        }

        public static void TextDecryptionAscii()
        {
            DecryptText(true);
        }
    }
}
