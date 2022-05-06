using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Packman.BL;

namespace Packman.UI
{
    class MazeUI
    {
        public static void DrawMaze(Cell[,] maze, int rowSize, int colSize)
        {
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    Console.Write(maze[i, j].getValue());
                }
                Console.WriteLine();
            }
        }
    }
}
