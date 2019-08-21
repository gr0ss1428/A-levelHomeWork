using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Helicopter
    {
        Point[] pointHelicopter;
        int XCave { get; }
        int YCave { get; }
        Movement movement;
        public Helicopter(int xCave, int yCave)
        {
            XCave = xCave;
            YCave = yCave;
            pointHelicopter = new Point[6];
            Point pt = new Point(4, YCave / 2, '▄');
            pt.DrawPoint();
            pointHelicopter[0] = pt;

            pt = new Point(3, YCave / 2, '▄');
            pt.DrawPoint();
            pointHelicopter[1] = pt;

            pt = new Point(4, YCave / 2 + 1, '▀');
            pt.DrawPoint();
            pointHelicopter[2] = pt;

            pt = new Point(3, YCave / 2 + 1, '▀');
            pt.DrawPoint();
            pointHelicopter[3] = pt;

            pt = new Point(2, YCave / 2 + 1, '─');
            pt.DrawPoint();
            pointHelicopter[4] = pt;

            pt = new Point(1, YCave / 2 + 1, '└');
            pt.DrawPoint();
            pointHelicopter[5] = pt;

            movement = Movement.DOWN;

        }
        public void Move()
        {
            int nextCord = 0;
            switch (movement)
            {
                case Movement.DOWN:
                    nextCord = 1;
                    break;
                case Movement.UP:
                    nextCord = -1;
                    break;
                case Movement.FIX:
                    nextCord = 0;
                    break;
            }
            if (movement == Movement.DOWN)
            {
                for (int i = pointHelicopter.Length - 1; i >= 0; i--)
                {
                    pointHelicopter[i].ClearPoint();
                    pointHelicopter[i].Y += nextCord;
                    pointHelicopter[i].DrawPoint();
                }
            }
            else
            {
                for (int i = 0; i < pointHelicopter.Length; i++)
                {
                    pointHelicopter[i].ClearPoint();
                    pointHelicopter[i].Y += nextCord;
                    pointHelicopter[i].DrawPoint();
                }
            }
            //movement = Movement.DOWN;
        }
        public void Wheel(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    movement = Movement.DOWN;
                    break;
                case ConsoleKey.DownArrow:
                    movement = Movement.UP;
                    break;
                case ConsoleKey.Spacebar:
                    movement = Movement.FIX;
                    break;
            }
        }
        public bool Crash(Point[][] stalactite)
        {
            bool crash = false;
            if (pointHelicopter[0].Y == 0) crash = true;
            else if (pointHelicopter[2].Y == YCave) crash = true;
            else
            {
                for (int i = 0; i < pointHelicopter.Length; i++)
                {
                    foreach (var point in stalactite[0])
                    {
                        if (pointHelicopter[i] == point)
                        {
                            crash = true;
                            break;
                        }
                    }
                    if (crash) break;
                    else
                    {
                        foreach (var point in stalactite[1])
                        {
                            if (pointHelicopter[i] == point)
                            {
                                crash = true;
                                break;
                            }
                        }
                    }
                    if (crash) break;
                }
            }
            return crash;
        }
    }
}
