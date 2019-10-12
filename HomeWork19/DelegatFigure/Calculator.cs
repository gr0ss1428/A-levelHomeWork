using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatFigure
{
    class Calculator
    {
        public double RectangleArea(double a,double b)
        {
            return a*b;
        }

        public double RectanglePerimetr(double a, double b)
        {
            return (a + b)*2;
        }

        public double Circumference(double radius)
        {
            return 2*Math.PI * radius;
        }

        public double TrianglePerimetr(double a, double b,double c)
        {
            return a+b+c;
        }

        public double TriangleArea(double a, double b, double c)
        {
            double p = TrianglePerimetr(a, b, c)/2;
            return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
        }
    }
}
