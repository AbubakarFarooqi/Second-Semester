using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_And_Boundry.BL;
namespace Point_And_Boundry.UI
{
    class MenuUI
    {
        public static void clrscr()
        {
            Console.Clear();
        }
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("##################################");
            Console.WriteLine("#         ...Game Object...      #");
            Console.WriteLine("##################################");
        }
        public static void DisplayMsg(string Msg)
        {
            Console.Write(Msg);
        }
        public static string InputString()
        {
            return Console.ReadLine();
        }



        public static char Menu()
        {
            Console.WriteLine("Press 1. To Add Game Object");
            Console.WriteLine("Press 2. To View All Game Objects");
            Console.WriteLine("Press 3. To View Moving Game Objects");
            Console.WriteLine("Press 4. To Erase All Objects");
            Console.WriteLine("Press 5. To Exit");
            char option;
            char.TryParse(Console.ReadLine(), out option);
            return option;
        }
    }
}
