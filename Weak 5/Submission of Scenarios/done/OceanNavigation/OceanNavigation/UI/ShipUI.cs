using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.BL;
namespace OceanNavigation.UI
{
    class ShipUI
    {
        public static string TakeShipSerial()
        {
            Console.WriteLine("Enter Serial Number Of Ship....");
            string Serial = Console.ReadLine();
            return Serial;
        }
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("|            Ship Navigation System          |");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||");
        }
        public static Ship AddShip()
        {
            string SerialNumber = "";
            Angle Longitude;
            Angle Latitude;
            Ship Temp;
            Console.WriteLine("ENter Ship Serial Number...");
            SerialNumber = Console.ReadLine();
        Label_1:
            Longitude = AngleUI.TakeInputOfAngle("Longitude");
            if (Longitude == null)
            {
                Console.WriteLine("Wrong input...");
                goto Label_1;
            }
        Label_2:
            Latitude = AngleUI.TakeInputOfAngle("Latitude");
            if (Latitude == null)
            {
                Console.WriteLine("Wrong input...");
                goto Label_2;
            }
            Temp = new Ship(SerialNumber, Longitude, Latitude);
            return Temp;
        }
        public static void DisplayPosition(Ship Souce)
        {
            Console.WriteLine(Souce.getPosition());
        }
        public static void WrongSerial()
        {
            Console.WriteLine("wrong Serial");
        }
        public static void ShipNotFound()
        {
            Console.WriteLine("Ship Not Found");
        }
        public static void DisplaySerial(string SerialNumber)
        {
            Console.WriteLine("Ship Serial is " + SerialNumber);

        }
    }
}
