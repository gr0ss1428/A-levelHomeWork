using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Rectangle : Figure
    {
        public override double Area
        {
            get
            {
                return Point.GetSizeSide(Points[0], Points[1]) * Point.GetSizeSide(Points[0], Points[3]);
            }
        }

        public override string TypeFigure
        {
            get
            {
                if (Point.GetSizeSide(Points[0], Points[1]) == Point.GetSizeSide(Points[0], Points[3]) &&
                    Point.GetSizeSide(Points[1], Points[2]) == Point.GetSizeSide(Points[2], Points[3])) return "Square";
                return "Rectangle";
            }
        }

        public Rectangle(IDisplay display, Point[] point) : base(display,point)
        {
        }

        public static Rectangle operator ++(Rectangle rec)
        {
            return new Rectangle(rec.display, Point.ResizePoints(rec.Points, 2));
        }

        public static Rectangle operator --(Rectangle rec)
        {
            return new Rectangle(rec.display, Point.ResizePoints(rec.Points, 1 / 2));
        }
    }
}