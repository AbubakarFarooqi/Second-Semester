using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_And_Boundry.BL
{
    class Boundry
    {
        public Boundry()
        {
            TopLeft = new Point(0, 0);
            TopRight = new Point(90, 0);
            BottomLeft = new Point(0, 90);
            BottomRight = new Point(90, 90);
        }
        public Boundry(Point TopLeft, Point TopRight, Point BottomLeft, Point BottomRight)
        {
            this.TopLeft = TopLeft;
            this.TopRight = TopRight;
            this.BottomLeft = BottomLeft;
            this.BottomRight = BottomRight;
        }
        private Point TopLeft;
        private Point TopRight;
        private Point BottomLeft;
        private Point BottomRight;
        public int getTLX()
        {
            return TopLeft.getX();
        }
        public int getTLY()
        {
            return TopLeft.getY();
        }
        public int getBLX()
        {
            return BottomLeft.getX();
        }
        public int getBLY()
        {
            return BottomLeft.getY();
        }


        public int getTRX()
        {
            return TopRight.getX();
        }
        public int getTRY()
        {
            return TopRight.getY();
        }
        public int getBRX()
        {
            return BottomRight.getX();
        }
        public int getBRY()
        {
            return BottomRight.getY();
        }
    }
}
