using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatFigure
{
    /*
     * 
     * Совсем не понял задание
     * 
     * */
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            FigureRectangle rectangle = new FigureRectangle(2, 3);

            rectangle.Area = calc.RectangleArea;
            rectangle.Perimeter = calc.RectanglePerimetr;
            rectangle.Calculation();
            Console.WriteLine("----");

            Circle circle = new Circle(5);
            circle.Circumference = calc.Circumference;
            circle.Calculation();
            Console.WriteLine("----");

            Triangle triangle = new Triangle(4, 5, 6);
            triangle.Area = calc.TriangleArea;
            triangle.Perimeter = calc.TrianglePerimetr;
            triangle.Calculation();
            Console.ReadKey();


        }
    }
}
