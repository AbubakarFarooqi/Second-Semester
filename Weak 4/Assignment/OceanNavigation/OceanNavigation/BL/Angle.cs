using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanNavigation.BL
{
    class Angle
    {
        public Angle(int Degree, float minutes, char Direction)
        {
            this.Degree = Degree;
            this.minutes = minutes;
            this.Direction = Direction;
        }
        private int Degree;
        private float minutes;
        char Direction;
        public void setAngle(int Degree, float minutes, char Direction)
        {
            this.Degree = Degree;
            this.minutes = minutes;
            this.Direction = Direction;
        }
        public string getAngle()
        {
            string output = Degree.ToString() + "\u00b0" + minutes.ToString() + "\'" + " " + Direction.ToString();
            return output;
        }
    }
}
