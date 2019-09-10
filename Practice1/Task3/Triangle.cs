using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Triangle : Figure
    {
        public override double Area
        {
            get
            {
                double sin = Math.Sqrt(1 - Math.Pow(Point.GetCosP0(Points[0], Points[1], Points[2]), 2));
                return 0.5 * Point.GetSizeSide(Points[0], Points[1]) * Point.GetSizeSide(Points[0], Points[2]) * sin;
            }
        }

        public override string TypeFigure
        {
            get
            {
                if (Point.GetSizeSide(Points[0], Points[1]) == Point.GetSizeSide(Points[0], Points[2]) &&
                    Point.GetSizeSide(Points[0], Points[1]) == Point.GetSizeSide(Points[1], Points[2]) &&
                    Point.GetSizeSide(Points[0], Points[2]) == Point.GetSizeSide(Points[1], Points[2])) return "Equilateral triangle";

                else if (Point.GetSizeSide(Points[0], Points[1]) == Point.GetSizeSide(Points[0], Points[2]) ||
                    Point.GetSizeSide(Points[0], Points[1]) == Point.GetSizeSide(Points[1], Points[2]) ||
                    Point.GetSizeSide(Points[0], Points[2]) == Point.GetSizeSide(Points[1], Points[2])) return "Isosceles triangle";

                return "it's just a triangle";
            }
        }

        public Triangle(IDisplay display, Point[] point) : base(display, point)
        {

        }

        public static Triangle operator ++(Triangle tr)
        {
            return new Triangle(tr.display,Point.ResizePoints(tr.Points, 2));
        }

        public static Triangle operator --(Triangle tr)
        {
            return new Triangle(tr.display, Point.ResizePoints(tr.Points, 1 / 2));
        }
    }
}
