using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Ellipse : Figure
    {
        public double Radius1 { get; private set; }
        public double Radius2 { get; private set; }

        public override double Area
        {
            get
            {
                return Math.PI * Radius1 * Radius2;
            }
        }

        public override double Perimetr
        {
            get
            {
                return 2 * Math.PI * Math.Sqrt((Math.Pow(Radius1, 2) + Math.Pow(Radius2, 2)) / 2);
            }
        }

        public override string TypeFigure
        {
            get
            {
                return "Ellipse";
            }
        }
      
        public Ellipse(IDisplay display, Point centrePoint, double radius1, double radius2) : base(display,new Point[] { centrePoint })
        {
            Radius1 = radius1;
            Radius2 = radius2;
        }

        public static Ellipse operator ++(Ellipse e)
        {
            return new Ellipse(e.display, e.Points[0],++e.Radius1,++e.Radius2);
        }

        public static Ellipse operator --(Ellipse e)
        {
            return new Ellipse(e.display, e.Points[0], --e.Radius1, --e.Radius2);
        }

        public override void PrintDescriptionFigure()
        {
            string message = String.Empty;
            message += $"Type: {this.TypeFigure}\n";
            message += $"Area: {this.Area.ToString("0.##")}\n";
            message += $"Perimetr: {this.Perimetr.ToString("0.##")}\n";
            message += $"Radius1: {Radius1.ToString("0.##")}\n";
            message += $"Radius2: {Radius2.ToString("0.##")}\n";
            message += $"Centre Point: {Points[0].ToString()}\n";
            display.Print(message);
        }
    }
}
