using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Packman.UI;
using Packman.DL;
namespace Packman.BL
{
    class Grid
    {
        public Grid(int rowSize, int colSize, string path)
        {
            this.rowSize = rowSize;
            this.colSize = colSize;
            maze = new Cell[rowSize, colSize];
            readMaze();

        }



        private Cell[,] maze;
        private int rowSize;
        private int colSize;
        private void readMaze()
        {
            StreamReader fp = new StreamReader("maze.txt");
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 71; x++)
                {
                    maze[row, x] = new Cell(record[x], x, row);
                }
                row++;
            }

            fp.Close();
        }
        public Cell getLeftCell(Cell C)
        {
            int x = C.getX();
            int y = C.getY();
            Cell LeftCell = maze[y, x - 1];
            return LeftCell;
        }
        public Cell getRightCell(Cell C)
        {
            int x = C.getX();
            int y = C.getY();
            Cell RightCell = maze[y, x + 1];
            return RightCell;
        }
        public Cell getUpCell(Cell C)
        {
            int x = C.getX();
            int y = C.getY();
            Cell UpCell = maze[y - 1, x];
            return UpCell;
        }
        public Cell getDownCell(Cell C)
        {
            int x = C.getX();
            int y = C.getY();
            Cell DownCell = maze[y + 1, x];
            return DownCell;
        }
        public Cell FindPacMan()
        {
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    if (maze[i, j].isPacManPresent())
                        return maze[i, j];
                }
            }
            return null;
        }
        public bool isGhostThere(char character)
        {
            for (int k = 0; k < GhostCRUD.enemies.Count; k++)
            {
                if (GhostCRUD.enemies[k].getCharacter() == character)
                    return true;
            }
            return false; ;
        }
        public void Draw()
        {
            MazeUI.DrawMaze(maze, rowSize, colSize);
        }
        public void setCellValue(char Value, int x, int y)
        {
            maze[y, x].setValue(Value);
        }
        public char getCellValue(int x, int y)
        {
            return maze[y, x].getValue();
        }
        public Cell getCellByCoordinates(int x, int y)
        {
            return maze[y, x];
        }
        public int getRowSize()
        {
            return rowSize;
        }
        public int getColSize()
        {
            return colSize;
        }
    }
}
