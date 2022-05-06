using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOnLine.UI
{
    class MenuUI
    {
        public static void DisplayMsg(string msg)
        {
            Console.WriteLine(msg);
        }
        public static string InputString()
        {
            return Console.ReadLine();
        }
        public static void Header()

        {
            Console.Clear();
            Console.WriteLine("###############################################");
            Console.WriteLine("#          Point on Line Application          #");
            Console.WriteLine("###############################################");
        }
        public static string Menu()
        {
            Console.WriteLine("Press 1. To Make a Line");
            Console.WriteLine("Press 2. Update The Begin Point");
            Console.WriteLine("Press 3. Update the End Point");
            Console.WriteLine("Press 4. Show the begin Point");
            Console.WriteLine("Press 5. Show The End Point");
            Console.WriteLine("Press 6. Get The Lenght of the Line");
            Console.WriteLine("Press 7. Get The Gradient of The Line");
            Console.WriteLine("Press 8. Find Distance of the Begin Point From Origin");
            Console.WriteLine("Press 9. Find Distance of the End Point From Origin");
            Console.WriteLine("Press 10. Exit");
            string option;
            option = Console.ReadLine();
            return option;
        }
        public static void EndiingMsg()
        {
            Console.WriteLine("............Thanks For Using our Application........");
        }
    }
}
