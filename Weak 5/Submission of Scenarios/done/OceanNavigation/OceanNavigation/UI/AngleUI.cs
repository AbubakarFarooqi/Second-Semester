using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.BL;
namespace OceanNavigation.UI
{
    class AngleUI
    {
        public static Angle TakeInputOfAngle(string type)
        {
            Angle Temp = new Angle();
            int Degree;
            float Minutes;
            char Direction;
            Console.WriteLine("....." + type + ".....");
            Console.WriteLine("ENter " + type + "'s Degree...");
            Degree = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter " + type + "'s Minutes...");
            Minutes = float.Parse(Console.ReadLine());
            Console.WriteLine("ENter " + type + "'s Direction...");
            char.TryParse(Console.ReadLine(), out Direction);
            if (type == "Longitude")
            {
                if (Temp.setLongitude(Degree, Minutes, Direction))
                    return Temp;
            }
            if (type == "Latitude")
            {
                if (Temp.setLatitude(Degree, Minutes, Direction))
                    return Temp;
            }
            return null;
        }
        public static void WrongAngle()
        {
            Console.WriteLine("Wrong ANgle....");
        }
    }
}
