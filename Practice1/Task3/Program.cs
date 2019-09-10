using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface IDisplay
    {
        void Print(string message);
    }
    public class ToDisplay : IDisplay
    {
        public void Print(string messge)
        {
            Console.WriteLine(messge);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ToDisplay display = new ToDisplay();
            Point[] p = new Point[4];
            p[0] = new Point(0, 0);
            p[1] = new Point(0, 5);
            p[2] = new Point(5, 4);
            p[3] = new Point(4, 0);
            Figure figure = new Rectangle(display, p);
            figure.PrintDescriptionFigure();
            figure++;
            figure.PrintDescriptionFigure();
            Console.ReadKey();

            Point[] pT = new Point[3];
            pT[0] = new Point(2, 0);
            pT[1] = new Point(1, 3);
            pT[2] = new Point(4, 5);

            var triangle = new Triangle(display, pT);
            triangle.PrintDescriptionFigure();
            triangle++;
            triangle.PrintDescriptionFigure();
            Console.ReadKey();

            var ellipse = new Ellipse(display, new Point(0, 0), 10, 5);
            ellipse.PrintDescriptionFigure();
            ellipse++;
            ellipse.PrintDescriptionFigure();
            Console.ReadKey();
        }
    }
}
