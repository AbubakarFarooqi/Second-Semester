using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanNavigation.BL
{
    class Angle
    {
        private int Degree;
        private float minutes;
        private char Direction;
        public bool setLongitude(int Degree, float minutes, char Direction)
        {

            if (Degree >= 0 && Degree <= 180)
                if (Direction == 'E' || Direction == 'W')
                {
                    this.Degree = Degree;
                    this.minutes = minutes;
                    this.Direction = Direction;
                    return true;
                }
            return false;

        }
        public bool setLatitude(int Degree, float minutes, char Direction)
        {

            if (Degree >= 0 && Degree <= 90)
                if (Direction == 'N' || Direction == 'S')
                {
                    this.Degree = Degree;
                    this.minutes = minutes;
                    this.Direction = Direction;
                    return true;
                }
            return false;

        }
        public string getAngle()
        {
            string output = Degree.ToString() + "\u00b0" + minutes.ToString() + "\'" + " " + Direction.ToString();
            return output;
        }
        public int getDegree()
        {
            return Degree;
        }
        public float getMinutes()
        {
            return minutes;
        }
        public char getDirection()
        {
            return Direction;
        }

    }
}
