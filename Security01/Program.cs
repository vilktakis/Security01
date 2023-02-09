using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security01
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.ASCII;
            Console.WriteLine("Input the text you wish to encrypt, only use ASCII characters index [32-127]:");
            string text = Console.ReadLine();

            Controller controller = new Controller(text);
            controller.Start();
        }
    }
}
