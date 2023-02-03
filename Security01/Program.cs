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
            Console.WriteLine("Input the text you wish to encrypt:");
            string text = Console.ReadLine();

            Controller controller = new Controller(text);
            controller.Start();
        }
    }
}
