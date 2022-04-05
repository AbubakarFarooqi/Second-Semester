using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Program
    {
        class Student
        {
            public string name;
            public int Roll;
            public float cgpa;
        }
        static Student TakeInput()
        {
            Student Stu = new Student();
            Console.WriteLine("ENter Name of Student : ");
            Stu.name = Console.ReadLine();
            Console.WriteLine("Enter Roll No :");
            Stu.Roll = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CGPA :");
            Stu.cgpa = float.Parse(Console.ReadLine());
            return Stu;

        }
        static void PrintRecord(Student Stu)
        {
            Console.WriteLine("Name = {0} \n Roll {1}\n CGPA = {2}", Stu.name, Stu.Roll, Stu.cgpa);
        }
        static void Main(string[] args)
        {
            Student[] StuArr = new Student[3];

            for (int i = 0; i < 3; i++)
            {
                StuArr[i] = TakeInput();
            }
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                PrintRecord(StuArr[i]);
                Console.Read();
                Console.Clear();
            }


        }
    }
}
