using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_And_Boundry.BL
{
    class Point
    {
        public Point(Point p)
        {
            this.x = p.getX();
            this.y = p.getY();
        }
        public Point()
        {

        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        private int x;
        private int y;
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void setXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
