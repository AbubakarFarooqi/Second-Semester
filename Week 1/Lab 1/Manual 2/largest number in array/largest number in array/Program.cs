using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace largest_number_in_array
{
    class Program
    {
        static void Pass()
        {
            int number;
            Console.WriteLine("enter your marks");
            number = int.Parse(Console.ReadLine());
            if (number > 50)
                Console.WriteLine("Your are passed");
            else
                 Console.WriteLine("Your are fail"); 

        }
        static void takeInput(int[] input)
        {
            for(int i= 0; i < 3; i++)
            {
                Console.WriteLine("enter {0} Value", i + 1);
                input[i] = int.Parse(Console.ReadLine());
            }
        }
        static int Largest (int[] source)
        {
            int largest = source[0];
            for(int i = 1; i<3; i++)
            {
                if (source[i] > largest)
                    largest = source[i];
            }
            return largest;
        }
        static void Main(string[] args)
        {
            int[] input = new int[3];
            takeInput(input);
            Console.WriteLine("Largest number is "+ Largest(input));
            Console.Read();
        }
    }
}
