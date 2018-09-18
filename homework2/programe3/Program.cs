using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programe3
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] num1 = new int [50];
            int n = 0;
            Console.WriteLine("********2--100的素数********");
            for(int i=2;i<101;i++)
            {
               int j = 2;
               for (; j < i; j++)
            {
                    if (i % j == 0)
                        break;
            }
               if(i==j)
                {
                    num1[n] = i;
                    Console.Write(num1[n] + " ");
                    n++;
                }
            }
        }
    }
}
