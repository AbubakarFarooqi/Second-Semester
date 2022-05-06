using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Packman.UI;

namespace Packman.BL
{
    class Ghost
    {
        public Ghost(int x, int y, char ghostCharacter, string ghostDirection, float speed, char previousItem, Grid MazeGrid)
        {
            this.x = x;
            this.y = y;
            this.ghostDirection = ghostDirection;
            this.ghostCharacter = ghostCharacter;
            this.speed = speed;
            this.previousItem = previousItem;
            this.MazeGrid = MazeGrid;
        }
        private int x;
        private int y;
        private string ghostDirection;
        private char ghostCharacter;
        private float speed;
        private char previousItem;
        private float deltaChange;
        private Grid MazeGrid;
        public void setDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
        }
        public string getDirection()
        {
            return ghostDirection;
        }
        public void Remove()
        {
            MazeGrid.setCellValue(previousItem, x, y);
            GhostUI.RemoveFromScreen(x, y, previousItem);
        }
        public void Draw()
        {

            GhostUI.DrawGhost(x, y, ghostCharacter);
        }
        public char getCharacter()
        {
            return ghostCharacter;
        }
        public void ChangeDelta()
        {
            deltaChange = deltaChange + speed;
        }
        public float getDelta()
        {
            return deltaChange;
        }
        public void setDeltaZero()
        {
            deltaChange = 0;
        }
        public bool Move()
        {
            ChangeDelta();
            if (true)
            {
                Random temp = new Random();
                int num = 0;
                Cell C = null;
                if (ghostDirection == "random")
                {

                    num = 1 + temp.Next() % 4;

                }
                if (ghostDirection == "smart")
                {
                    double[] Distance = calculateDistance(MazeGrid.FindPacMan());
                    // Finding Smallest Index
                    int index = 0;
                    double smallest = Distance[0];
                    for (int i = 1; i < 4; i++)
                    {
                        for (int j = 1; j < 4; j++)
                        {
                            if (smallest > Distance[j])
                            {
                                smallest = Distance[j];
                                index = j;
                            }
                        }
                    }
                    //choosong Direction
                    if (index == 0)
                        num = 1;
                    if (index == 1)
                        num = 4;
                    if (index == 2)
                        num = 2;
                    if (index == 3)
                        num = 3;

                }
                if (ghostDirection == "up" || num == 1)
                {
                    if (y - 1 == 1 || MazeGrid.getCellValue(x, y - 1) == '%' || MazeGrid.getCellValue(x, y - 1) == '|' || MazeGrid.getCellValue(x, y - 1) == '#')
                    {
                        if (num == 0)
                            ghostDirection = "down";
                    }
                    else
                    {
                        if (MazeGrid.getCellValue(x, y - 1) == ' ' || MazeGrid.getCellValue(x, y - 1) == '.' || MazeGrid.getCellValue(x, y - 1) == 'P')
                        {
                            C = MazeGrid.getUpCell(MazeGrid.getCellByCoordinates(x, y));
                            if (MazeGrid.getCellValue(x, y - 1) == 'P')
                                return true;
                        }
                    }
                }
                else if (ghostDirection == "down" || num == 2)
                {
                    if (y + 1 == 23 || MazeGrid.getCellValue(x, y + 1) == '%' || MazeGrid.getCellValue(x, y + 1) == '|' || MazeGrid.getCellValue(x, y + 1) == '#')
                    {
                        if (num == 0)
                            ghostDirection = "up";
                    }
                    else
                    {
                        if (MazeGrid.getCellValue(x, y + 1) == ' ' || MazeGrid.getCellValue(x, y + 1) == '.' || MazeGrid.getCellValue(x, y + 1) == 'P')

                            C = MazeGrid.getDownCell(MazeGrid.getCellByCoordinates(x, y));
                        if (MazeGrid.getCellValue(x, y + 1) == 'P')
                            return true;
                    }

                }

                else if (ghostDirection == "left" || num == 3)
                {
                    if (x - 1 == 1 || MazeGrid.getCellValue(x - 1, y) == '%' || MazeGrid.getCellValue(x - 1, y) == '|' || MazeGrid.getCellValue(x - 1, y) == '#')
                    {
                        if (num == 0)
                            ghostDirection = "right";
                    }
                    else
                    {
                        if (MazeGrid.getCellValue(x - 1, y) == ' ' || MazeGrid.getCellValue(x - 1, y) == '.' || MazeGrid.getCellValue(x - 1, y) == 'P')
                            C = MazeGrid.getLeftCell(MazeGrid.getCellByCoordinates(x, y));
                        if (MazeGrid.getCellValue(x - 1, y) == 'P')
                            return true;
                    }
                }
                else if (ghostDirection == "right" || num == 4)
                {
                    if (x + 1 == 70 || MazeGrid.getCellValue(x + 1, y) == '%' || MazeGrid.getCellValue(x + 1, y) == '|' || MazeGrid.getCellValue(x + 1, y) == '#')
                    {
                        if (num == 0)
                            ghostDirection = "left";
                    }
                    else
                    {
                        if (MazeGrid.getCellValue(x + 1, y) == ' ' || MazeGrid.getCellValue(x + 1, y) == '.' || MazeGrid.getCellValue(x + 1, y) == 'P')
                            C = MazeGrid.getRightCell(MazeGrid.getCellByCoordinates(x, y));
                        if (MazeGrid.getCellValue(x + 1, y) == 'P')
                            return true;
                    }
                }
                setDeltaZero();
                if (C != null)
                {
                    Remove();
                    previousItem = C.getValue();
                    x = C.getX();
                    y = C.getY();
                    MazeGrid.setCellValue(ghostCharacter, C.getX(), C.getY());
                    return false;
                }
            }
            return false;

        }
        public void MoveHorizontal()
        {
            if (x == MazeGrid.getColSize())
            {
                ghostDirection = "right";
            }
            else if (x == 1)
            {
                ghostDirection = "right";
            }
            Move();
        }
        public void MoveVertical()
        {

            if (y == MazeGrid.getRowSize())
            {
                ghostDirection = "up";
            }
            else if (y == 1)
            {
                ghostDirection = "down";
            }
            Move();

        }
        public double[] calculateDistance(Cell PKman)
        {
            double[] Distance = new double[4];
            Distance[0] = Math.Sqrt(Math.Pow((x - PKman.getX()), 2) + Math.Pow((y - 1 - PKman.getY()), 2));// for up
            Distance[1] = Math.Sqrt(Math.Pow((x + 1 - PKman.getX()), 2) + Math.Pow((y - PKman.getY()), 2)); // for Right
            Distance[2] = Math.Sqrt(Math.Pow((x - PKman.getX()), 2) + Math.Pow((y + 1 - PKman.getY()), 2)); // for down
            Distance[3] = Math.Sqrt(Math.Pow((x - 1 - PKman.getX()), 2) + Math.Pow((y - PKman.getY()), 2));//for LEft
            return Distance;
        }
    }
}
