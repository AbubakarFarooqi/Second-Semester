using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_And_Boundry.BL;
using System.IO;
namespace Point_And_Boundry.DL
{
    class GameObjectCRUD
    {
        public static List<GameObject> ListOfGameObjects = new List<GameObject>();

        public static void AddObjectInList(GameObject Source)
        {
            ListOfGameObjects.Add(Source);
        }
        public static void WriteToFile()
        {
            string path = "Objects.txt";
            StreamWriter File = new StreamWriter(path);
            for (int i = 0; i < ListOfGameObjects.Count; i++)
            {
                char[,] shape = ListOfGameObjects[i].getShape();
                File.Write(shape.GetLength(0) + "," + shape.GetLength(1) + ",");
                for (int j = 0; j < shape.GetLength(0) - 1; j++)
                {
                    for (int k = 0; k < shape.GetLength(1); k++)
                    {
                        File.Write(shape[j, k].ToString() + ";");
                    }
                }
                for (int j = 0; j < shape.GetLength(1) - 1; j++)
                {
                    File.Write(shape[shape.GetLength(0) - 1, j].ToString() + ";");
                }
                File.Write(shape[shape.GetLength(0) - 1, shape.GetLength(1) - 1].ToString() + ",");
                Point StartingPoint = ListOfGameObjects[i].getStartingPoint();
                File.Write(StartingPoint.getX().ToString() + ";" + StartingPoint.getY().ToString() + ",");
                Boundry permises = ListOfGameObjects[i].getBoundry();
                File.Write(permises.getTLX() + ";" + permises.getTLY() + ";" + permises.getTRX() + ";" + permises.getTRY() + ";" + permises.getBLX() + ";" + permises.getBLY() + ";" + permises.getBRX() + ";" + permises.getBRY() + ",");
                File.WriteLine(ListOfGameObjects[i].getDirection());
                File.Flush();
            }
            File.Close();
        }
        public static void ReadFromFile()
        {
            string path = "Objects.txt";
            StreamReader File = new StreamReader(path);
            string temp = "";
            while ((temp = File.ReadLine()) != null)
            {
                char[,] Shape;
                Point StartingPoint;
                Boundry Permises;
                string[] fields = temp.Split(',');
                Shape = new char[int.Parse(fields[0]), int.Parse(fields[1])];
                string[] shapeFields = fields[2].Split(';');
                int count = 0;
                for (int i = 0; i < int.Parse(fields[0]); i++)
                {
                    for (int j = 0; j < int.Parse(fields[1]); j++)
                    {
                        Shape[i, j] = char.Parse(shapeFields[count]);
                        count++;
                    }
                }
                string[] SP_Fields = fields[3].Split(';');
                StartingPoint = new Point(int.Parse(SP_Fields[0]), int.Parse(SP_Fields[1]));
                string[] Permises_Fields = fields[4].Split(';');
                Permises = new Boundry(new Point(int.Parse(Permises_Fields[0]), int.Parse(Permises_Fields[1])), new Point(int.Parse(Permises_Fields[2]), int.Parse(Permises_Fields[3])), new Point(int.Parse(Permises_Fields[4]), int.Parse(Permises_Fields[5])), new Point(int.Parse(Permises_Fields[6]), int.Parse(Permises_Fields[7])));
                GameObject Source = new GameObject(Shape, StartingPoint, Permises, fields[5]);
                ListOfGameObjects.Add(Source);
            }
            File.Close();
        }
    }
}
