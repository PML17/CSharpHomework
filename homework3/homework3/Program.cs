using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    public abstract class Shape
    {
        public abstract void Area();
        public virtual void data(double a, double b, double c) { }
    }

    public class Triangle : Shape
    {
        private double a, b, c;
        public Triangle()
        {
            Console.WriteLine("Init a triangle");
        }
        public override void data(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override void Area()
        {

            double s = Math.Sqrt((0.5 * (a + b + c)) * ((0.5 * (a + b + c)) - a) * ((0.5 * (a + b + c)) - b) * ((0.5 * (a + b + c)) - c));
            Console.WriteLine("The area of this triangle is " + s);
        }
    }

    public class Circle : Shape
    {
        private double radius;

        public Circle()
        {
            Console.WriteLine("Init a circle");
        }
        public override void data(double radius, double b, double c)
        {
            this.radius = radius;
        }
        public override void Area()
        {

            double s = radius * radius * System.Math.PI;
            Console.WriteLine("The area of this circle is " + s);
        }
    }

    public class Square : Shape
    {
        private double side;

        public Square()
        {
            Console.WriteLine("Init a square");
        }
        public override void data(double side, double b, double c)
        {
            this.side = side;
        }
        public override void Area()
        {
            double s = side * side;
            Console.WriteLine("The area of this square is " + s);
        }
    }

    public class Rectangel : Shape
    {
        private double height;
        private double width;

        public Rectangel()
        {
            Console.WriteLine("Init a rectangel");
        }
        public override void data(double height, double width, double c)
        {
            this.height = height;
            this.width = width;
        }
        public override void Area()
        {

            double s = height * width;
            Console.WriteLine("The area of this rectangel is " + s);
        }
    }

    class Factory
    {
        public static Shape GetShape(string type)
        {
            Shape shape = null;
            try
            {
                if (type.Equals("Triangel"))
                {
                    shape = new Triangle();
                }
                else if (type.Equals("Square"))
                {
                    shape = new Square();
                }
                else if (type.Equals("Circle"))
                {
                    shape = new Circle();
                }
                else if (type.Equals("Rectangel"))
                {
                    shape = new Rectangel();
                }

            }
            catch
            {
                Console.WriteLine("Error Iuput!");
            };
            return shape;
        }
    }

    class Program1
    {
        public static void Main(string[] args)
        {
            Shape shape;
            shape = Factory.GetShape("Triangel");
            shape.data(6, 8, 10);
            shape.Area();
            shape = Factory.GetShape("Circle");
            shape.data(5, 0, 0);
            shape.Area();
            shape = Factory.GetShape("Square");
            shape.data(6, 0, 0);
            shape.Area();
            shape = Factory.GetShape("Rectangel");
            shape.data(6, 8, 0);
            shape.Area();


        }
    }
}
