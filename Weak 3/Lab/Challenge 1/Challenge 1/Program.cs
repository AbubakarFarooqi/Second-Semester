using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockType_Class.BL;
namespace Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ClockType c = new ClockType(0, 5, 10);
            ClockType d = new ClockType(0, 5, 16);
            c.TimeDifference(d);
            Console.Read();
        }
    }
}
