using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.BL;
using System.IO;
namespace OceanNavigation.DL
{
    class ShipCRUD
    {
        public static List<Ship> ListOfShips = new List<Ship>();
        public static void AddShipInList(Ship Source)
        {
            ListOfShips.Add(Source);
        }
        public static Ship getShip(int index)
        {
            return ListOfShips[index];
        }
        public static int FindShipBySerial(string SerialNumber)
        {
            for (int i = 0; i < ListOfShips.Count; i++)
            {
                if (SerialNumber == ListOfShips[i].getSerial())
                    return i;
            }
            return -1;
        }
        public static string getSerialOfShip(Angle Longitude, Angle Latitude)
        {
            for (int i = 0; i < ListOfShips.Count; i++)
            {
                if (ListOfShips[i].isValidPosition(Longitude, Latitude))
                    return ListOfShips[i].getSerial();
            }
            return null;
        }
        public static void ReadFromFile()
        {

            string path = "Ship.txt";
            StreamReader File = new StreamReader(path);
            string temp = " ";

            while ((temp = File.ReadLine()) != null)
            {

                string[] fields = temp.Split(',');
                string[] LongitudeFields = fields[1].Split(';');
                string[] LatitudeFields = fields[2].Split(';');
                Angle Longitude = new Angle();
                Angle Latitude = new Angle();
                Longitude.setLongitude(int.Parse(LongitudeFields[0]), float.Parse(LongitudeFields[1]), char.Parse(LongitudeFields[2]));
                Latitude.setLatitude(int.Parse(LatitudeFields[0]), float.Parse(LatitudeFields[1]), char.Parse(LatitudeFields[2]));
                AddShipInList(new Ship(fields[0], Longitude, Latitude));
            }
            File.Close();
        }
        public static void WritingToFile()
        {
            string path = "Ship.txt";
            StreamWriter File = new StreamWriter(path);
            for (int i = 0; i < ListOfShips.Count; i++)
            {
                Angle Longitude = ListOfShips[i].getLongitude();
                Angle Latitude = ListOfShips[i].getLatitude();
                File.WriteLine(ListOfShips[i].getSerial() + "," + Longitude.getDegree() + ";" + Longitude.getMinutes() + ";" + Longitude.getDirection() + "," + Latitude.getDegree() + ";" + Latitude.getMinutes() + ";" + Latitude.getDirection());
                File.Flush();
            }
            File.Close();
        }
    }
}
