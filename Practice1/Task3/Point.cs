using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"[{X.ToString("0.##")};{Y.ToString("0.##")}]";
        }

        public static double GetSizeSide(Point p0, Point p1)
        {
            return Math.Sqrt(Math.Pow(p1.X - p0.X, 2) + Math.Pow(p1.Y - p0.Y, 2));
        }

        public static Point[] ResizePoints(Point[] point, double koef)
        {
            Point[] newPoint = new Point[point.Length];
            newPoint[0] = point[0];
            for (int i = 1; i < point.Length; i++)
            {
                newPoint[i].X = point[0].X + Math.Sqrt(koef) * (point[i].X - point[0].X);
                newPoint[i].Y = point[0].Y + Math.Sqrt(koef) * (point[i].Y - point[0].Y);
            }
            return newPoint;
        }

        public static double GetCosP0(Point p0, Point p1, Point p2)
        {
            return ((p2.X - p0.X) * (p1.X - p0.X) + (p2.Y - p0.Y) * (p1.Y - p0.Y)) / (GetSizeSide(p1, p0) * GetSizeSide(p2, p0));
        }
    }
}
