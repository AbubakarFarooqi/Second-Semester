using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryOperations.BL;
namespace BinaryOperations
{
    class Program
    {
        static void Main(string[] args)
        {

            BinaryA num = new BinaryA(BinaryA.ConvertToBinary(27));
            Console.WriteLine(BinaryA.ConvertToBinary(27));
            Console.WriteLine(num.oneScomplement());
            Console.WriteLine(num.Two_S_Complement());
            Console.WriteLine(num.Addition("11"));
            Console.ReadKey();
        }
    }
}
