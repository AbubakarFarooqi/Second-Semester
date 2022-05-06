using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.BL;
using OceanNavigation.DL;
using OceanNavigation;
namespace OceanNavigation.UI
{
    class MenuUI
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("|            Ship Navigation System          |");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||");
        }
        public static char ShipMenu()
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

        public static string InputMsg()
        {
            return Console.ReadLine();
        }
        public static void PrintMsg(string Msg)
        {
            Console.WriteLine(Msg);
        }

    }
}
