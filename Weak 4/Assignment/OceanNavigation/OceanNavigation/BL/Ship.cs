using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanNavigation.BL
{
    class Ship
    {
        public Ship(string SerialNumber, Angle Longitude, Angle Latitude)
        {
            this.Longitude = Longitude;
            this.Latitude = Latitude;
            this.SerialNumber = SerialNumber;
        }
        private Angle Longitude;
        private Angle Latitude;
        private string SerialNumber;
        public void setLongitude(int Degree, float minutes, char Direction)
        {
            Longitude.setAngle(Degree, minutes, Direction);
        }
        public void setLatitude(int Degree, float minutes, char Direction)
        {
            Latitude.setAngle(Degree, minutes, Direction);
        }
        public void setSerialNumber(string SerialNumber)
        {
            this.SerialNumber = SerialNumber;
        }
        public void getPosition()
        {
            Console.WriteLine("Ship is at " + Longitude.getAngle() + " and " + Latitude.getAngle());
        }
        public void getSerial()
        {
            Console.WriteLine("Ship Serial is : " + SerialNumber);
        }
        public bool isValid(string serial)
        {
            if (serial == SerialNumber)
                return true;
            return false;
        }

    }
}
