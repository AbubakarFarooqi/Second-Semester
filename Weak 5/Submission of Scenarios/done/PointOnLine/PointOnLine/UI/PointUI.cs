using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOnLine.BL;
namespace PointOnLine.UI
{
    class PointUI
    {
        public static void Header()

        {
            Console.Clear();
            Console.WriteLine("###############################################");
            Console.WriteLine("#          Point on Line Application          #");
            Console.WriteLine("###############################################");
        }
        public static MyPoint TakeInputOfPoint(string type)
        {
            Console.WriteLine(".........Enter " + type + " Point......");
            Console.WriteLine("ENter Value of abcissa :");
            int x;
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Value of Ordinate : ");
            int y;
            y = int.Parse(Console.ReadLine());
            MyPoint temp = new MyPoint(x, y);
            return temp;

        }
        public static void DisplayBeginPoint(MyPoint P)
        {
            Console.WriteLine("Begin Point = ( " + P.getX() + " , " + P.getY() + " )");
        }
        public static void DisplayEndPoint(MyPoint P)
        {
            Console.WriteLine("End Point = ( " + P.getX() + " , " + P.getY() + " )");
        }
    }
}
