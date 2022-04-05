using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assesment.BL
{
    class Circle
    {
        public Circle(Circle Source)
        {
            Radius = Source.Radius;
        }
        public Circle()
        {
            Console.WriteLine("ENter Value of Radius : ");
            Radius = int.Parse(Console.ReadLine());
        }
        private float Radius;
        public double getArea()
        {
            return Math.PI * Math.Pow((double)Radius, 2);
        }
        public double getDiameter()
        {
            return 2 * Radius;
        }
        public double getCircumference()
        {
            return Math.PI * getDiameter();
        }


    }
}
