using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.BL;
using OceanNavigation.DL;
using OceanNavigation.UI;
namespace OceanNavigation
{
    class Program
    {
        public static int vari = 9;
        static void option_1()
        {
            ShipUI.Header();
            ShipCRUD.ListOfShips.Add(ShipUI.AddShip());
            ShipCRUD.WritingToFile();
        }
        static void option_2()
        {
            ShipUI.Header();

            int indexOfShip = ShipCRUD.FindShipBySerial(ShipUI.TakeShipSerial());
            if (indexOfShip != -1)
                ShipUI.DisplayPosition(ShipCRUD.ListOfShips[indexOfShip]);
            else
                ShipUI.WrongSerial();
        }
        static void option_3()
        {
            ShipUI.Header();

            Angle Longitude = AngleUI.TakeInputOfAngle("Longitude");
            if (Longitude == null)
            {
                AngleUI.WrongAngle();
                goto label;

            }
            Angle Latitude = AngleUI.TakeInputOfAngle("Latitude");

            if (Longitude == null)
            {
                AngleUI.WrongAngle();
            }
            string SerialNumber = ShipCRUD.getSerialOfShip(Longitude, Latitude);
            if (SerialNumber == null)
                ShipUI.ShipNotFound();
            else
                ShipUI.DisplaySerial(SerialNumber);
            label:;
        }
        static void option_4()
        {
            ShipUI.Header();
            string serial = ShipUI.TakeShipSerial();
            int index = ShipCRUD.FindShipBySerial(serial);
            if (index != -1)
            {
                Angle longitude;
                Angle latitude;
                if ((longitude = AngleUI.TakeInputOfAngle("Longitude")) == null)
                {
                    AngleUI.WrongAngle();
                }

                else if ((latitude = AngleUI.TakeInputOfAngle("Latitude")) == null)
                {
                    AngleUI.WrongAngle();
                }
                else
                {
                    ShipCRUD.ListOfShips[index].setLatitude(latitude);
                    ShipCRUD.ListOfShips[index].setLongitude(longitude);
                }
                ShipCRUD.WritingToFile();

            }
            else
                ShipUI.ShipNotFound();
        }

        static void Main(string[] args)
        {
            ShipCRUD.ReadFromFile();
            char option;
            do
            {
                MenuUI.Header();
                option = MenuUI.ShipMenu();
                switch (option)
                {
                    case '1':
                        option_1();
                        break;
                    case '2':
                        option_2();
                        break;
                    case '3':
                        option_3();
                        break;
                    case '4':
                        option_4();
                        break;
                    case '5':
                        MenuUI.Header();
                        MenuUI.PrintMsg("Thansks FOr Using Our Application....");
                        break;
                }
                MenuUI.InputMsg();

            } while (option != '5');
        }
    }
}
