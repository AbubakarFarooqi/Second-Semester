using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assesment.BL;

namespace assesment
{
    class Program
    {

        static void Main(string[] args)
        {
            Circle C1 = new Circle();
            Console.WriteLine("Area = {0}", C1.getArea());
            Console.WriteLine("Diameter = {0}", C1.getDiameter());
            Console.WriteLine("Circumference = {0}", C1.getCircumference());
            Console.Read();

        }
    }
}
