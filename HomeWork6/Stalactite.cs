using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Stalactite
    {
        int XCave { get; }
        int YCave { get; }
        char Ch { get; }
        public Random random;
        Queue<Point[][]> stalactiteQueue;
        public Stalactite(int xCave, int yCave, char ch)
        {
            XCave = xCave;
            YCave = yCave;
            Ch = ch;
            stalactiteQueue = new Queue<Point[][]>();
            random = new Random();
        }

        public void NewGeneration()
        {
            int sizeDown = random.Next(0, YCave - 7);
            int sizeUp;

            if (sizeDown < YCave - 13) sizeUp = random.Next(0, YCave - sizeDown - 5);
            else sizeUp = 0;

            Point[] upPoints = new Point[sizeUp];
            Point[] downPoints = new Point[sizeDown];

            for (int i = 0; i < sizeUp; i++)
            {
                upPoints[i] = new Point(XCave, i + 1, Ch);
                upPoints[i].DrawPoint();
            }
            for (int i = 0; i < sizeDown; i++)
            {
                downPoints[i] = new Point(XCave, YCave - i - 1, Ch);
                downPoints[i].DrawPoint();
            }
            Point[][] eqPoints = new Point[2][];
            eqPoints[0] = upPoints;
            eqPoints[1] = downPoints;
            stalactiteQueue.Enqueue(eqPoints);
        }
        public void Move()
        {
            bool remove = false;
            foreach (var point in stalactiteQueue)
            {
                for (int i = 0; i < point[0].Length; i++)
                {
                    if (point[0][i].X >= 0) point[0][i].ClearPoint();
                    point[0][i].X--;
                    if (point[0][i].X == 0)
                    {
                        remove = true;
                    }
                    if (point[0][i].X > 0) point[0][i].DrawPoint();
                }
                for (int i = 0; i < point[1].Length; i++)
                {
                    if (point[1][i].X >= 0) point[1][i].ClearPoint();
                    point[1][i].X--;
                    if (point[1][i].X > 0) point[1][i].DrawPoint();
                }
            }
            if (remove)
            {
                stalactiteQueue.Dequeue();
            }
        }
        public Point[][] GetFirstStalactiteCoord()
        {
            return stalactiteQueue.Peek();
        }
    }
}
