using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOnLine.BL
{
    class MyLine
    {
        public MyLine(MyPoint Begin, MyPoint End)
        {
            this.Begin = Begin;
            this.End = End;
        }
        private MyPoint Begin;
        private MyPoint End;
        public MyPoint getBegin()
        {
            return Begin;

        }
        public MyPoint getEnd()
        {
            return End;
        }
        public void setBegin(MyPoint Begin)
        {
            this.Begin = Begin;
        }
        public void setEnd(MyPoint End)
        {
            this.End = End;
        }
        public double getLength()
        {
            double length = Begin.DistanceFromObject(End);
            return length;
        }
        public double getGradient()
        {
            double m;
            m = (End.getY() - Begin.getY()) / (End.getX() - Begin.getX());
            return m;
        }
    }
}
