using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_And_Boundry.BL;
using Point_And_Boundry.DL;
namespace Point_And_Boundry.UI
{
    class GameObjetUI
    {
        public static char[,] TakeInputOfShape()
        {
            int row, col;
            Console.WriteLine("NEter no of Rows = ");
            row = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter No of Columns = ");
            col = int.Parse(Console.ReadLine());
            char[,] input = new char[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write("Enter {0} row and {1} column item = ", i + 1, j + 1);
                    char.TryParse(Console.ReadLine(), out input[i, j]);
                }

            }
            return input;
        }
        public static GameObject TakeInputOfGameObject()
        {
            char[,] shape = TakeInputOfShape();
            Boundry permises = BoundryUI.TakeInputOfBoundry();
            int x, y;
            Console.WriteLine("ENter X-cordinate of Starting Point = ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter Y-cordinate of Starting Point = ");
            y = int.Parse(Console.ReadLine());
            Point StartingPoint = new Point(x, y);
            Console.WriteLine("Enter Direction");
            string Direction = Console.ReadLine();
            GameObject temp = new GameObject(shape, StartingPoint, permises, Direction);
            return temp;
        }
        public static void DisplayMsg(string Msg)
        {
            Console.Write(Msg);
        }
        public static string InputString()
        {
            return Console.ReadLine();
        }
    }
}
