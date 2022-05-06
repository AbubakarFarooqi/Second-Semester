using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_And_Boundry.BL;
using System.Threading;
namespace Point_And_Boundry
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] x = new char[5, 5] { { '1', '1', '1', '1', '1' }, { '2', '2', '2', '2', '2' }, { '2', '2', '2', '2', '2' }, { '2', '2', '2', '2', '2' }, { '2', '2', '2', '2', '2' } };
            GameObject o = new GameObject(x, new Point(35, 0));
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(50);
                o.Draw();
                o.Move();
                o.Draw();
            }

            Console.Read();
        }
    }
}
