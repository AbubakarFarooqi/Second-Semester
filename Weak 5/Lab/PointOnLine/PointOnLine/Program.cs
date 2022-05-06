using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOnLine.BL;

namespace PointOnLine
{
    class Program
    {
        static void Header()

        {
            Console.Clear();
            Console.WriteLine("###############################################");
            Console.WriteLine("#          Point on Line Application          #");
            Console.WriteLine("###############################################");
        }
        static string Menu()
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
        static MyPoint TakeInputOfPoint()
        {
            Console.WriteLine("ENter Value of abcissa :");
            int x;
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Value of Ordinate : ");
            int y;
            y = int.Parse(Console.ReadLine());
            MyPoint temp = new MyPoint(x, y);
            return temp;

        }
        static void Main(string[] args)
        {

            MyLine Line = null;
            string option;
            do
            {
                Header();
                option = Menu();
                switch (option)
                {
                    case "1":
                        Header();
                        Console.WriteLine(".........Enter Begin Point......");
                        MyPoint Begin = TakeInputOfPoint();
                        Console.WriteLine(".........Enter End Point......");
                        MyPoint End = TakeInputOfPoint();
                        Line = new MyLine(Begin, End);
                        Console.ReadKey();
                        break;
                    case "2":
                        Header();
                        Console.WriteLine("......Update Begin Point.....");
                        Line.setBegin(TakeInputOfPoint());
                        Console.ReadKey();
                        break;
                    case "3":
                        Header();
                        Console.WriteLine("......Update End Point.....");
                        Line.setBegin(TakeInputOfPoint());
                        Console.ReadKey();
                        break;
                    case "4":
                        Header();
                        Console.WriteLine("......Show Begin Point.....");
                        Console.WriteLine("Begin Point = (" + (Line.getBegin()).getX() + " , " + (Line.getBegin()).getY() + " )");
                        Console.ReadKey();
                        break;
                    case "5":
                        Header();
                        Console.WriteLine("......Show End Point.....");
                        Console.WriteLine("Begin Point = (" + (Line.getEnd()).getX() + " , " + (Line.getEnd()).getY() + " )");
                        Console.ReadKey();
                        break;
                    case "6":
                        Header();
                        Console.WriteLine(".........Length of Line........");
                        Console.WriteLine("Length of Line  = " + Line.getLength());
                        Console.ReadKey();
                        break;
                    case "7":
                        Header();
                        Console.WriteLine(".........Gradient of Line........");
                        Console.WriteLine("Gradient of Line  = " + Line.getGradient());
                        Console.ReadKey();
                        break;
                    case "8":
                        Header();
                        Console.WriteLine("........Diatance of begin From Origin.........");
                        Console.WriteLine("Distance  = " + (Line.getBegin()).DistanceFromZero());
                        Console.ReadKey();
                        break;
                    case "9":
                        Header();
                        Console.WriteLine("........Diatance of End From Origin.........");
                        Console.WriteLine("Distance  = " + (Line.getEnd()).DistanceFromZero());
                        Console.ReadKey();
                        break;
                    case "10":
                        Header();
                        Console.WriteLine("............Thanks For Using our Application........");
                        Console.ReadKey();
                        break;
                    default:
                        Header();
                        Console.WriteLine("........Wrong Opiton.....");
                        break;
                }
            } while (option != "10");
        }
    }
}
