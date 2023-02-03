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
        public int k;
        public string type;

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
            Console.WriteLine("Text to be encrypted");
            Console.WriteLine(text + "\n");
            Console.WriteLine("Please imput a number or a word that will be used to encrypt your text");
            string t = Console.ReadLine();

            TextOrNumber(t);
            Encrypt();
            Decrypt();
        }

        public void TextOrNumber(string t)
        {
            try
            {
                type = "number";
                k = int.Parse(t);
            }
            catch (Exception)
            {
                if (t.Length <= text.Length)
                {
                    type = "word";
                    key = t;
                }
                else
                {
                    Start();
                }
            }
        }

        public void Encrypt()
        {
            textBytes = ascii.GetBytes(text);

            if (type == "number")
            {
                Byte[] encryptedBytes = new byte[textBytes.Length];
                int i = 0;
                foreach (var b in textBytes)
                {
                    int x = b + k % 128;
                    encryptedBytes[i] = (byte)x;
                    text = ascii.GetString(encryptedBytes);
                    Console.WriteLine(x);
                    i++;
                }
                Console.WriteLine(text);
                Console.ReadLine();
            }
            else
            {
                keyBytes = ascii.GetBytes(key);

                Byte[] encryptedBytes = new byte[textBytes.Length];
                int i = 0;
                int y;
                foreach (var b in textBytes)
                {
                    int x = b + k % 128;
                    encryptedBytes[i] = (byte)x;
                    text = ascii.GetString(encryptedBytes);
                    Console.WriteLine(x);
                    i++;
                }
                Console.WriteLine(text);
                Console.ReadLine();
            }
        }

        public void Decrypt()
        {
            textBytes = ascii.GetBytes(text);

            if (type == "number")
            {
                Byte[] decryptedBytes = new byte[textBytes.Length];
                int i = 0;
                foreach (var b in textBytes)
                {
                    int x = b - k + 128 % 128;
                    decryptedBytes[i] = (byte)x;
                    text = ascii.GetString(decryptedBytes);
                    Console.WriteLine(x);
                    i++;
                }
                Console.WriteLine(originalText);
                Console.WriteLine(text);
                Console.ReadLine();
            }
            else
            {

            }
        }
    }
}
