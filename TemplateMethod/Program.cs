using System;
using TemplateMethod.Square;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangle = new TriangleSquare(10, 15);
            var circle = new CircleSquare(20);

            var shapes = new ISquare[] { triangle, circle };

            DisplaySquare(shapes);

            Console.ReadKey();
        }

        static void DisplaySquare(ISquare[] shapes)
        {
            foreach(var shape in shapes)
            {
                shape.Calculate();
            }
        }
    }
}
