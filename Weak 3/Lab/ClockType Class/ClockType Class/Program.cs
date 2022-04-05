using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockType_Class.BL;
namespace ClockType_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            ClockType time = new ClockType();
            time.PrintTime();
            time.IncrementInHours();
            time.IncrementInMinutes();
            time.IncrementInSeconds();
            time.PrintTime();
            ClockType time2 = new ClockType(2, 3, 2);
            time2.PrintTime();
            if (time.isEqual(1, 1, 1))
            {
                Console.WriteLine("equal");
            }
            else
            {
                Console.WriteLine("not equal");
            }
            if (time2.isEqual(time))
            {
                Console.WriteLine("equal");
            }
            else
            {
                Console.WriteLine("not equal");
            }
            Console.ReadLine();
        }
    }
}
