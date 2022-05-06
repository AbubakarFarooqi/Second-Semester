using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Direction = "Patrol";
        }
        public GameObject(char[,] Shape, Point StartingPoint, Boundry Permises, string Direction)
        {
            this.Shape = Shape;
            this.StartngPoint = StartingPoint;
            this.Permises = Permises;
            this.Direction = Direction;
        }
        public char[,] Shape;
        public Point StartngPoint;
        public Boundry Permises;
        public string Direction;
        public void Draw()
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
                                Console.Write(Shape[k, l]);
                            }
                            Console.WriteLine();
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
                    StartngPoint.setX(StartngPoint.getX() + 1);
                    break;
                case "RightToLeft":
                    StartngPoint.setX(StartngPoint.getX() - 1);
                    break;
                case "Patrol":
                    StartngPoint.setX(StartngPoint.getX() - 1);
                    if (StartngPoint.getX() == Permises.getBLX())
                        Direction = "LeftToRight";
                    if (StartngPoint.getX() == Permises.getBRX())
                        Direction = "RightToLeft";
                    break;
                case "Projectile":
                    {
                        int x = StartngPoint.getX();
                        int y = StartngPoint.getY();
                        int m = ((y - Permises.getTRY()) / (x - Permises.getTRX()));
                        for (int i = 0; i < Permises.getTRY(); i++)
                        {
                            for (int j = 0; j < Permises.getTRX(); j++)
                            {


                                if (i - y == m * (j - x))
                                {
                                    double distance = Math.Sqrt(Math.Pow(j - x, 2) + Math.Pow(i - y, 2));
                                    if ((int)distance == 5)
                                    {
                                        StartngPoint.setX(j);
                                        StartngPoint.setY(i);
                                    }
                                }
                            }
                        }
                    }
                    break;
                    /*      case :
                              break;*/
            }
        }


    }
}
