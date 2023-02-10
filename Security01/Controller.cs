using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security01
{
    public class Controller
    {
        public string text;
        public string originalText;

        public string key;

        public ASCIIEncoding ascii;
        public byte[] textBytes;
        public byte[] keyBytes;

        public Controller(string t)
        {
            text = t;
            originalText = t;

            ascii = new ASCIIEncoding();
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Text to be encrypted: " + text + "\n");
            Console.WriteLine("Please imput a key that will be used to encrypt your text, only use ASCII characters index [32-127]\nencryption key must be shorted or same lengh as the text, empty encryption key is not allowed too:");
            string t = Console.ReadLine();

            if (t.Length <= text.Length && t.Length != 0)
            {
                key = t;
            }
            else
            {
                Start();
            }

            Console.Clear();
            Console.WriteLine("Text to be encrypted: " + text);
            Console.WriteLine("Encryption Key: " + key + "\n");

            Encrypt();

            Console.WriteLine("Encrypted text: " + text);
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Original Text: " + originalText);
            Console.WriteLine("Encryption Key: " + key);
            Console.WriteLine("Encrypted text: " + text + "\n");

            Decrypt();

            Console.WriteLine("Decrypted text: " + text + "\n");
            Console.WriteLine("To start again press Enter, to close the console type 'close'");
            string x = Console.ReadLine();

            if (x != "close")
            {
                Start();
            }

        }

        public void Encrypt()
        {
            textBytes = ascii.GetBytes(text);
            keyBytes = ascii.GetBytes(key);

            Byte[] encryptedBytes = new byte[textBytes.Length];
            int i = 0;
            int y = 0;
            foreach (var b in textBytes)
            {
                if (y == keyBytes.Length)
                {
                    y = 0;
                }
                int k = keyBytes[y];
                int x = b;
                x = x + k;
                x = x % 127;
                x = x + 32;
                if (x >= 127)
                {
                    x = x % 127;
                    x = x + 32;
                }
                encryptedBytes[i] = (byte)x;
                text = ascii.GetString(encryptedBytes);
                i++;
                y++;
            }
        }

        public void Decrypt()
        {
            textBytes = ascii.GetBytes(text);

            Byte[] decryptedBytes = new byte[textBytes.Length];
            int i = 0;
            int y = 0;
            foreach (var b in textBytes)
            {
                if (y == keyBytes.Length)
                {
                    y = 0;
                }
                int k = keyBytes[y];
                int x = b - k;
                x = x + 95;
                x = x % 127;

                decryptedBytes[i] = (byte)x;
                text = ascii.GetString(decryptedBytes);
                i++;
                y++;
            }
        }
    }
}
