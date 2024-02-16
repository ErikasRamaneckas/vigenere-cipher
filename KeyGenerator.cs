using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacijosSaugumas1
{
    public class KeyGenerator
    {
        public string generateKey(string originalText, string key)
        {
            string generatedKey = "";
            int keyIndex = 0;
            for(int i = 0; i < originalText.Length; i++)
            {
                generatedKey += key[keyIndex];
                keyIndex = (keyIndex + 1) % key.Length;
            }
            return generatedKey;
        }
    }
}
