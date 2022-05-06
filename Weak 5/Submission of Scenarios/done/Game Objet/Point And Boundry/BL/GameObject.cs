using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Point_And_Boundry.UI;
namespace Point_And_Boundry.BL
{
    class GameObject
    {
        public GameObject()
        {
            Shape = new char[1, 3] { { '-', '-', '-' } };
            StartngPoint = new Point();
            Permises = new Boundry();
            Direction = "LeftToRight";
        }
        public GameObject(char[,] Shape, Point StartingPoint)
        {
            this.Shape = Shape;
            this.StartngPoint = StartingPoint;
            Permises = new Boundry();
            Direction = "Diagonal";
        }
        public GameObject(char[,] Shape, Point StartingPoint, Boundry Permises, string Direction)
        {
            this.Shape = Shape;
            this.StartngPoint = StartingPoint;
            this.Permises = Permises;
            this.Direction = Direction;
            startingPointCopy = new Point(StartngPoint);
        }
        private char[,] Shape;
        private Point StartngPoint;
        private Point startingPointCopy;
        private Boundry Permises;
        private string Direction;
        private int Dir = 1;//Patrol controller
        private int ProjectileCount = 0;

        public void Draw(bool erase = false)
        {

            bool flagOfShapePrint = false;
            for (int i = Permises.getTLY(); i <= Permises.getBLY(); i++)
            {
                for (int j = Permises.getTLX(); j <= Permises.getTRX(); j++)
                {
                    if (j == StartngPoint.getX() && i == StartngPoint.getY())
                        flagOfShapePrint = true;
                    if (flagOfShapePrint)
                    {
                        Console.SetCursorPosition(j, i);

                        for (int k = 0; k < Shape.GetLength(0); k++)
                        {
                            for (int l = 0; l < Shape.GetLength(1); l++)
                            {
                                if (erase)
                                {
                                    GameObjetUI.DisplayMsg(" ");
                                }
                                else
                                {
                                    GameObjetUI.DisplayMsg(Shape[k, l].ToString());
                                }
                            }
                            GameObjetUI.DisplayMsg("\n");
                            i++;
                            Console.SetCursorPosition(j, i);
                        }
                        flagOfShapePrint = false;
                        break;
                    }
                }
            }

        }
        public void Move()
        {
            switch (Direction)
            {
                case "LeftToRight":
                    if (StartngPoint.getX() != Permises.getTRX())
                        StartngPoint.setX(StartngPoint.getX() + 1);
                    break;
                case "RightToLeft":
                    if (StartngPoint.getX() != Permises.getTLX())
                        StartngPoint.setX(StartngPoint.getX() - 1);
                    break;
                case "Patrol":

                    if (Dir == 1)
                        StartngPoint.setX(StartngPoint.getX() - 1);
                    if (Dir == 2)
                        StartngPoint.setX(StartngPoint.getX() + 1);
                    if (StartngPoint.getX() == Permises.getBLX())
                        Dir = 2;
                    if (StartngPoint.getX() == Permises.getBRX())
                        Dir = 1;
                    break;
                case "Projectile":
                    {
                        if (ProjectileCount >= 0 && ProjectileCount <= 5)
                        {
                            StartngPoint.setX(StartngPoint.getX() + 1);
                            StartngPoint.setY(StartngPoint.getY() - 1);
                        }
                        if (ProjectileCount == 6 || ProjectileCount == 7)
                        {
                            StartngPoint.setX(StartngPoint.getX() + 1);
                        }
                        if (ProjectileCount >= 8 && ProjectileCount <= 11)
                        {
                            StartngPoint.setX(StartngPoint.getX() + 1);
                            StartngPoint.setY(StartngPoint.getY() + 1);
                        }
                        ProjectileCount++;
                        if (ProjectileCount == 11)
                            ProjectileCount = 0;
                    }
                    break;
                case "Diagonal":
                    if (StartngPoint.getX() != Permises.getTRX())
                    {
                        StartngPoint.setX(StartngPoint.getX() + 1);
                        StartngPoint.setY(StartngPoint.getY() + 1);
                    }
                    break;
            }
        }
        public void Erase()
        {
            Draw(true);

        }
        public void ResetStartingPoint()
        {
            StartngPoint.setX(startingPointCopy.getX());
            StartngPoint.setY(startingPointCopy.getY());
        }
        public char[,] getShape()
        {
            return Shape;
        }
        public Point getStartingPoint()
        {
            return StartngPoint;
        }
        public Boundry getBoundry()
        {
            return Permises;
        }
        public string getDirection()
        {
            return Direction;
        }
    }
}
