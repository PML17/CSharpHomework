using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = " ";
            double n = 0;
            double d = 0;
            Console.Write("Input one number: ");
            s = Console.ReadLine();
            n = Double.Parse(s);
            Console.Write("Input another number: ");
            s = Console.ReadLine();
            d = Double.Parse(s);
            Console.WriteLine("the result of " + n+" * "+d+" is "+(n*d));
        }
    }
}
