using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Packman.BL;
namespace Packman.UI
{
    class PacManUI
    {
        public static void DrawPacMan(Cell PM)
        {
            Console.SetCursorPosition(PM.getX(), PM.getY());
            Console.Write("P");
        }
        public static void RemoveFromScreen(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        public static void DrawScores(int Score)
        {
            Console.SetCursorPosition(0, 26);
            Console.Write("Score = {0}", Score);
        }
    }
}
