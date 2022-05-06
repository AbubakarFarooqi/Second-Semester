using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packman.BL
{
    class Cell
    {
        public Cell(char value, int x, int y)
        {
            this.value = value;
            this.x = x;
            this.y = y;
        }
        private char value;
        private int x;
        private int y;
        public void setValue(char value)
        {
            this.value = value;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public char getValue()
        {
            return value;
        }
        public bool isPacManPresent()
        {
            if (value == 'P')
                return true;
            return false;
        }
        public bool isGhostPresent(char Character)
        {
            if (value == Character)
                return true;
            return false;
        }

    }
}
