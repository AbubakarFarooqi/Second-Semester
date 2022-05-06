using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOnLine.UI
{
    class LineUI
    {
        public static void Header()

        {
            Console.Clear();
            Console.WriteLine("###############################################");
            Console.WriteLine("#          Point on Line Application          #");
            Console.WriteLine("###############################################");
        }
        public static void PrintLenght(double lenght)
        {
            Console.WriteLine(".........Length of Line........");
            Console.WriteLine("Length = " + lenght);
        }
        public static void PrintGradient(double gradient)
        {
            Console.WriteLine(".........Gradient of Line........");
            Console.WriteLine("Gradient of Line  = " + gradient);
        }
        public static void DistanceOfBeginFromOrigin(double distance)
        {
            Console.WriteLine("........Diatance of begin From Origin.........");
            Console.WriteLine("Distance  = " + distance);
        }
        public static void DistanceOfEndFromOrigin(double distance)
        {
            Console.WriteLine("........Diatance of End From Origin.........");
            Console.WriteLine("Distance  = " + distance);
        }
    }
}
