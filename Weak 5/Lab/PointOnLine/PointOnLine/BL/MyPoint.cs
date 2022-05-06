using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOnLine.BL
{
    class MyPoint
    {
        public MyPoint()
        {

        }
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;

        }
        public int x;
        public int y;
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public void setXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public double DistanceFromCord(int x, int y)
        {
            double distance = Math.Sqrt(Math.Pow((this.x - x), 2) + Math.Pow((this.y - y), 2));
            return distance;
        }
        public double DistanceFromObject(MyPoint obj)
        {
            double distance = Math.Sqrt(Math.Pow((this.x - obj.getX()), 2) + Math.Pow((this.y - obj.getY()), 2));
            return distance;
        }
        public double DistanceFromZero()
        {
            double distance = Math.Sqrt(Math.Pow((this.x - 0), 2) + Math.Pow((this.y - 0), 2));
            return distance;
        }
    }
}
