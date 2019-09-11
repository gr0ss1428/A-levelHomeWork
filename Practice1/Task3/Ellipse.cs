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
                return (Radius1==Radius2)?"Circle":"Ellipse";
            }
        }
      /// <summary>
      /// Круг и элипс
      /// </summary>
      /// <param name="display">Интерфейс вывода на экран</param>
      /// <param name="centrePoint">Координаты центра</param>
      /// <param name="radius1">Радиус</param>
      /// <param name="radius2">Радиус 2 если у нас эллипс</param>
        public Ellipse(IDisplay display, Point centrePoint, double radius1, double? radius2=null) : base(display,new Point[] { centrePoint })
        {
            Radius1 = radius1;
            Radius2 = radius2??Radius1;
        }

        public static Ellipse operator ++(Ellipse e)
        {
            return new Ellipse(e.display, e.Points[0],++e.Radius1,++e.Radius2);
        }

        public static Ellipse operator --(Ellipse e)
        {
            e.Radius1--;
            e.Radius2--;
            if (e.Radius1 < 0) e.Radius1 = 0;
            if (e.Radius2 < 0) e.Radius2 = 0;
            return new Ellipse(e.display, e.Points[0], e.Radius1,e.Radius2);
        }

        public override void PrintDescriptionFigure()
        {
            string message = String.Empty;
            message += $"Type: {this.TypeFigure}\n";
            message += $"Area: {this.Area.ToString("0.##")}\n";
            message += $"Perimetr: {this.Perimetr.ToString("0.##")}\n";
            if (Radius1 != Radius2)
            {
                message += $"Radius1: {Radius1.ToString("0.##")}\n";
                message += $"Radius2: {Radius2.ToString("0.##")}\n";
            }
            else message += $"Radius: {Radius1.ToString("0.##")}\n";
            message += $"Centre Point: {Points[0].ToString()}\n";
            display.Print(message);
        }
    }
}
