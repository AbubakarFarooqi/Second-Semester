using System;
using System.IO;
namespace Manual_1_Area_of_Square_and_Triangle
{
    class Program
    {
        static float Area(float side)
        {
            float area = side * side;
            return area;
        }
        static void Main(string[] args)
        {
            Console.Write("ENter length of side of Square");
            float Side;
           Side = float.Parse( Console.ReadLine());
            Console.WriteLine("area of square is =  {0}", Area(Side));
            Console.Read();

        }
    }
}
