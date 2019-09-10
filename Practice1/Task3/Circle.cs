using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Circle:Ellipse
    {
        public override string TypeFigure
        {
            get
            {
                return "Circle";
            }
        }

        public Circle(IDisplay display, Point centrePoint, double radius1) : base(display,centrePoint, radius1, radius1)
        {
        }

        public override void PrintDescriptionFigure()
        {
            string message = String.Empty;
            message += $"Type: {this.TypeFigure}\n";
            message += $"Area: {this.Area.ToString("0.##")}\n";
            message += $"Perimetr: {this.Perimetr.ToString("0.##")}\n";
            message += $"Radius: {Radius1.ToString("0.##")}\n";
            message += $"Centre Point: {Points[0].ToString()}\n";
            display.Print(message);
        }
    }
}
