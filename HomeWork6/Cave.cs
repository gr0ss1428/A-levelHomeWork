using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    class Cave
    {
        private char fragmentWall;
        public Cave(int x, int y, char ch)
        {
            this.fragmentWall = ch;
            DrawWall(x, y);
        }
        private void DrawWall(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Point pt = new Point(i, 0, this.fragmentWall);
                pt.DrawPoint();
        
                pt = new Point(i, y, this.fragmentWall);
                pt.DrawPoint();
            }
        }
    }
}
