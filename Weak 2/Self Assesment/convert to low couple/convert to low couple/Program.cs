using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using convert_to_low_couple.BL;
namespace convert_to_low_couple
{
    class Program
    {
        static Student InputData()
        {
            Student S1 = new Student();

            Console.Write("Enter NAme of Student : ");
            S1.name = Console.ReadLine();
            Console.Write("ENter Urdu marks : ");
            S1.urdu = float.Parse(Console.ReadLine());
            Console.Write("enter English MArks : ");
            S1.eng = float.Parse(Console.ReadLine());
            Console.Write("enter MAth MArks : ");
            S1.math = float.Parse(Console.ReadLine());
            return S1;
        }
        static void TotalMarks(Student S)
        {
            S.result = S.math + S.eng + S.urdu;
        }
        static void output(Student S)
        {
            Console.WriteLine("NAme : {0}\nUrdu Marks : {1}\nEnglish MArks : {2}\nMath Marks : {3}\nTotal Marks : {4}", S.name, S.urdu, S.eng, S.math, S.result);
        }
        static void Main(string[] args)
        {

            Student[] Sarr = new Student[3];
            for (int i = 0; i < 3; i++)
            {
                Sarr[i] = InputData();
                TotalMarks(Sarr[i]);
            }
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                output(Sarr[i]);
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}
