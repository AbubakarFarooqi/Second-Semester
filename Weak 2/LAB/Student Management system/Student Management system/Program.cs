using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Management_system.BL;
namespace Student_Management_system
{
    class Program
    {
        static char Menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("University MAnagement System");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Press 1 : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("To Add Student");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Press 2 : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("To Display All Students");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Press 3 : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("To See Toppers");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Press 4 : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("To Exit");
            char option;
            option = Console.ReadLine()[0];
            return option;

        }
        static Student AddStudent()
        {
            Student stu = new Student();
            Console.Write("ENter NAme of STudent : ");
            stu.Name = Console.ReadLine();
            Console.WriteLine("ENter ROll No of Student  : ");

            stu.Roll = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter Cgpa of Student : ");
            stu.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Are YOu HOstilide = ");
            stu.isHostilide = Console.ReadLine()[0];
            Console.WriteLine("WHat is YOur Department = ");
            stu.Department = Console.ReadLine();
            return stu;

        }
        static void DisplayStudent(Student stu)
        {
            Console.WriteLine(stu.Name + "\t" + stu.Roll + "\t" + stu.cgpa + "\t" + stu.isHostilide + "\t" + stu.Department);
        }
        static void Topper(Student[] stu, int count)
        {

            if (count == 0)
            {
                Console.WriteLine("No Record FOund");
            }
            else if (count == 1)
            {
                DisplayStudent(stu[0]);
            }
            else if (count == 2)
            {
                if (stu[0].cgpa >= stu[1].cgpa)
                {
                    DisplayStudent(stu[0]);
                    DisplayStudent(stu[1]);

                }
                else
                {
                    DisplayStudent(stu[1]);
                    DisplayStudent(stu[0]);
                }
            }
            else
            {
                float[] temp = new float[count];
                for (int i = 0; i < count; i++)
                {
                    temp[i] = stu[i].cgpa;
                }
                for (int i = 0; i < 3; i++)
                {
                    int index = LargestCgpa(temp, count);
                    DisplayStudent(stu[index]);


                }

            }

        }
        static int LargestCgpa(float[] temp, int count)
        {
            int index = 0;
            for (int i = 0; i < count - 1; i++)
            {
                if (temp[index] < temp[i + 1])
                {
                    index = i + 1;
                }

            }
            temp[index] = -1;
            return index;

        }
        static void Main(string[] args)
        {
            const int SIZE = 10;
            int count = 0;
            Student[] stu = new Student[SIZE];
            char option = ' ';
            while (option != '4')
            {
                Console.Clear();
                option = Menu();
                if (option == '1')
                {
                    Console.Clear();
                    stu[count] = AddStudent();
                    count++;
                }
                if (option == '2')
                {
                    Console.Clear();
                    if (count == 0)
                    {
                        Console.WriteLine("No Record");
                    }
                    else
                    {
                        Console.WriteLine("Name\tRoll\tCGPA\tHostel\tDepartment");
                        for (int i = 0; i < count; i++)
                        {
                            DisplayStudent(stu[i]);

                        }
                    }
                    Console.ReadLine();
                }
                if (option == '3')
                {
                    Console.Clear();
                    Console.WriteLine("Name\tRoll\tCGPA\tHostel\tDepartment");
                    Topper(stu, count);
                    Console.ReadLine();
                }


            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thanks FOr Using our Application");
            Console.ReadLine();
        }
    }
}
