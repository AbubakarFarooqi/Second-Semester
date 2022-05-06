using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.BL;
namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            FlooringCost f = new FlooringCost("marble");
            Console.WriteLine(f.FindTotalCost());
            Console.ReadKey();
            f = new FlooringCost("gg", 34);
            Console.ReadKey();
            Console.WriteLine(f.FindTotalCost());
            Console.ReadKey();



        }

    }
}
