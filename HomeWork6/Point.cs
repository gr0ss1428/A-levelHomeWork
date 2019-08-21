using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Ch { get; set; }
        public Point(int x, int y, char ch)
        {
            X = x;
            Y = y;
            Ch = ch;
        }
        public void DrawPoint()
        {
            if (X < 0) X = 0;
            Console.SetCursorPosition(X, Y);
            Console.Write(Ch);
        }
        public void ClearPoint()
        {
            if (X < 0) X = 0;
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.X == p2.X && p1.Y == p2.Y);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return (p1.X != p2.X && p1.Y != p2.Y);
        }
    }
}
