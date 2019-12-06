using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatFigure
{
    class Circle
    {
        double Radius { get; }
        public Func<double, double> Circumference;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public void Calculation()
        {
            Console.WriteLine("Circle:");
            if (Circumference != null)
                Console.WriteLine($"Circumference {Circumference(Radius)}");
            else
                Console.WriteLine("I can not coun Circumference");
        }
    }
}
