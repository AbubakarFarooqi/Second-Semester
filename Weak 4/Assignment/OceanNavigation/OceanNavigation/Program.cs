using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.BL;
namespace OceanNavigation
{
    class Program
    {
        static char Menu()
        {
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
            char option;
            char.TryParse(Console.ReadLine(), out option);
            return option;
        }

        static bool ValidationOnAngle(int Degree, char Direction, bool type)// if type is true then it is longitude and if false type in latitude
        {
            if (type)
            {
                if (Degree >= 0 && Degree <= 180)
                    if (Direction == 'E' || Direction == 'W')
                        return true;
            }
            else
            {
                if (Degree >= 0 && Degree <= 90)
                    if (Direction == 'N' || Direction == 'S')
                        return true;
            }
            return false;
        }
        static Ship AddShip(Ship Input = null)
        {
            string SerialNumber = "";
            Angle Longitude;
            Angle Latitude;
            Ship Temp;
            int Degree;
            float Minutes;
            char Direction;
            if (Input == null)
            {
                Console.WriteLine("ENter Ship Serial Number...");
                SerialNumber = Console.ReadLine();
            }
        Label_1:
            Console.WriteLine(".....Longitude.....");
            Console.WriteLine("ENter Longitude's Degree...");
            Degree = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter Longitude's Minutes...");
            Minutes = float.Parse(Console.ReadLine());
            Console.WriteLine("ENter Longitude's Direction...");
            char.TryParse(Console.ReadLine(), out Direction);
            if (ValidationOnAngle(Degree, Direction, true))
                Longitude = new Angle(Degree, Minutes, Direction);
            else
            {
                Console.WriteLine("Wrong input...");
                goto Label_1;
            }
            if (Input != null)
            {
                Input.setLongitude(Degree, Minutes, Direction);
            }
        Label_2:
            Console.WriteLine(".....Latitude.....");
            Console.WriteLine("ENter Latitude's Degree...");
            Degree = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter Latitude's Minutes...");
            Minutes = float.Parse(Console.ReadLine());
            Console.WriteLine("ENter Latitude's Direction...");
            char.TryParse(Console.ReadLine(), out Direction);
            if (ValidationOnAngle(Degree, Direction, false))
                Latitude = new Angle(Degree, Minutes, Direction);
            else
            {
                Console.WriteLine("Wrong input...");
                goto Label_2;
            }
            if (Input != null)
            {
                Input.setLatitude(Degree, Minutes, Direction);
                return null;
            }

            Temp = new Ship(SerialNumber, Longitude, Latitude);
            return Temp;



        }
        static bool ViewShipPosition(List<Ship> ListofShips)
        {
            string serial;
            Console.WriteLine("ENter SHip Serial Number ...");
            serial = Console.ReadLine();
            for (int i = 0; i < ListofShips.Count; i++)
            {
                if (ListofShips[i].isValid(serial))
                {
                    ListofShips[i].getPosition();
                    return true;
                }
            }
            return false;

        }
        /* static bool ViewShipSerial(List<Ship> ListofShips)
         {
             string serial;
             Console.WriteLine("ENter SHip Serial Number ...");
             serial = Console.ReadLine();
             for (int i = 0; i < ListofShips.Count; i++)
             {
                 if (ListofShips[i].isValid(serial))
                 {
                     ListofShips[i].getSerial();
                     return true;
                 }
             }
             return false;

         }*/
        static void Main(string[] args)
        {
            List<Ship> ListofShips = new List<Ship>();
            char option;
            do
            {
                Console.Clear();
                option = Menu();
                switch (option)
                {
                    case '1':
                        ListofShips.Add(AddShip());
                        break;
                    case '2':
                        if (!ViewShipPosition(ListofShips))
                            Console.WriteLine("wrong Serial Number...");
                        Console.ReadKey();
                        break;
                    case '3':
                        ListofShips[ListofShips.Count - 1].getSerial();
                        Console.ReadKey();

                        break;
                    case '4':
                        Console.WriteLine("ENter Ship Serial....");
                        string serial;
                        serial = Console.ReadLine();
                        int i;
                        bool flag = false;
                        for (i = 0; i < ListofShips.Count; i++)
                        {
                            if (ListofShips[i].isValid(serial))
                            {
                                ListofShips[i].getSerial();
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            AddShip(ListofShips[i]);
                        }
                        else
                            Console.WriteLine("SHip not FOund");
                        Console.ReadKey();

                        break;
                    case '5':
                        Console.WriteLine("Thansks FOr Using Our Application....");
                        break;
                }
            } while (option != '5');
            Console.ReadLine();
        }
    }
}
