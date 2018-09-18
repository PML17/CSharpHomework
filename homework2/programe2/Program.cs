using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programe2
{
    class Program
    {
        static double Min(double[] num)
        {
            double min = num[0];
            for(int i=0;i<10;i++)
            {
                if(min>num[i])
                {
                    min = num[i];
                }
            }
            return min;
        }
        static double Max(double[]num)
        {
            double max = num[0];
            for (int i=0;i<10;i++)
            {
                if(max<num[i])
                {
                    max = num[i];
                }               
            }
            return max;
        }
        static double Average(double[]num)
        {
            double average = 0, sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum = sum + num[i];
            }
            average = sum / 10;
            return average;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 10 numbers into the array and show its maximum, minimum, and average value on the screen!");
            double[]num = new double[10];
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Please enter the number of {0}: ", i + 1);
                num[i] = double.Parse(Console.ReadLine());
            }
            double min1 = Min(num);
            Console.WriteLine("The minimum value of the 10 numbers you entered is: {0} ", min1);
            double max1 = Max(num);
            Console.WriteLine("The maximum value of the 10 numbers you entered is: {0} ", max1);
            double average1 = Average(num);
            Console.WriteLine("The average of the 10 numbers you entered is: {0} ", average1);

            Console.ReadKey();
        }
    }
}
