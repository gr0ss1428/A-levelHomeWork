using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public abstract class Figure
    {
        public Point[] Points { get; private set; }
        public abstract double Area { get; }
        public abstract string TypeFigure { get; }
        public IDisplay display;
        public virtual double Perimetr
        {
            get
            {
                return GetAllSizeSides().Sum();
            }
        }

        public Figure(IDisplay display,Point[] point)
        {
            this.display = display;
            Points = point;
        }

        protected virtual double[] GetAllSizeSides()
        {
            double[] sizes = new double[Points.Length];
            for (int i = 0; i < Points.Length - 1; i++)
            {
                sizes[i] = Point.GetSizeSide(Points[i], Points[i + 1]);
            }
            sizes[sizes.Length - 1] = Point.GetSizeSide(Points[Points.Length - 1], Points[0]);
            return sizes;
        }

        public virtual void Increment(double value)
        {
            Points = Point.ResizePoints(Points, value);
        }

        public virtual void Decrement(double value)
        {
            Points = Point.ResizePoints(Points, 1 / value);
        }

        public static Figure operator ++(Figure rec)
        {
            rec.Increment(2);
            return rec;
        }

        public static Figure operator --(Figure rec)
        {
            rec.Increment(1 / 2);
            return rec;
        }

        public virtual void PrintDescriptionFigure()
        {
            string message = String.Empty;
            message += $"Type: {this.TypeFigure}\n";
            message += $"Area: {this.Area.ToString("0.##")}\n";
            message += $"Perimetr: {this.Perimetr.ToString("0.##")}\n";
            for (int i = 0; i < Points.Length; i++)
                message += $"Point {i + 1}: {Points[i].ToString()}\n";
            display.Print(message);
        }
    }
}
