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
        public void setLongitude(Angle Longitude)
        {
            this.Longitude = Longitude;
        }
        public void setLatitude(Angle Latitude)
        {
            this.Latitude = Latitude;
        }
        public void setSerialNumber(string SerialNumber)
        {
            this.SerialNumber = SerialNumber;
        }
        public string getPosition()
        {
            return "Ship is at " + Longitude.getAngle() + " and " + Latitude.getAngle();
        }
        public string getSerial()
        {
            return SerialNumber;
        }
        public bool isValidSerial(string serial)
        {
            if (serial == SerialNumber)
                return true;
            return false;
        }
        public bool isValidPosition(Angle Longitude, Angle Latitude)
        {
            if (Longitude.getDegree() == this.Longitude.getDegree() && Longitude.getMinutes() == this.Longitude.getMinutes() && Longitude.getDirection() == this.Longitude.getDirection() && Latitude.getDegree() == this.Latitude.getDegree() && Latitude.getMinutes() == this.Latitude.getMinutes() && Latitude.getDirection() == this.Latitude.getDirection())
                return true;
            return false;
        }
        public Angle getLongitude()
        {
            return Longitude;
        }
        public Angle getLatitude()
        {
            return Latitude;
        }
    }
}
