using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packman.UI
{
    class GhostUI

    {
        public static void DrawGhost(int x, int y, char GhostCharacter)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(GhostCharacter);
        }
        public static void RemoveFromScreen(int x, int y, char prev)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(prev);
        }
        public static void SDrawPrev(int x, int y, char prevItem)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(prevItem);

        }
    }
}
