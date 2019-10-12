using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatFigure
{
    class Triangle
    {
        double SideA { get; }
        double SideB { get; }
        double SideC { get; }
        public Func<double, double, double, double> Perimeter;
        public Func<double, double, double, double> Area;

        public Triangle(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }

        public void Calculation()
        {
            Console.WriteLine("Triangle:");
            if (Perimeter != null)
                Console.Write($"Perimeter:{Perimeter(SideA, SideB, SideC)} ");
            else
                Console.Write($"I can not count Perimeter. ");

            if (Area != null)
                Console.WriteLine($"Area:{Area(SideA, SideB, SideC)}");
            else
                Console.WriteLine($"I can not count Area.");
        }

    }
}
