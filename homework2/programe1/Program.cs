using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input a number：");
            String s = Console.ReadLine();
            int a = int.Parse(s);
            Console.Write(a + " can be devided into :" + "\n\t1\n");
            for (int i = 2; i < a + 1; i++)  
            {
                while (a % i == 0 && a != i)
                {
                    a /= i;
                    Console.WriteLine("\t"+i);
                }
                if (a == i)
                {
                    Console.WriteLine("\t"+i);
                    break;
                }   
            }           
        }
    }
}
