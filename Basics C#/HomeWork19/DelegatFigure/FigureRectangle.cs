using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatFigure
{
    class FigureRectangle
    {
        double SideA { get; }
        double SideB { get; }
        public Func<double, double, double> Perimeter;
        public Func<double, double, double> Area;

        public FigureRectangle(double a, double b)
        {
            SideA = a;
            SideB = b;
        }

        public void Calculation()
        {
            Console.WriteLine("Rectangle:");
            if (Perimeter != null)
                Console.Write($"Perimeter:{Perimeter(SideA, SideB)} ");
            else
                Console.Write($"I can not count Perimeter. ");

            if (Area != null)
                Console.WriteLine($"Area:{Area(SideA, SideB)}");
            else
                Console.WriteLine($"I can not count Area.");
        }
    }

}
