using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using sign_in_sign_up_with_pure_classes.BL;
using EZInput;
namespace sign_in_sign_up_with_pure_classes
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] u = new User[2];
            StreamReader file = new StreamReader("G:\\BSCS\\2nd Semester\\OOP\\Weak 1\\Lab 1\\Manual 3\\Sign in Sign Up\\Cust.txt");
            for (int i = 0; i < 2; i++)
            {
                User temp = new User();
                temp.ReadFromFile(ref file, "G:\\BSCS\\2nd Semester\\OOP\\Weak 1\\Lab 1\\Manual 3\\Sign in Sign Up\\Cust.txt");
                u[i] = temp;
            }
            file.Close();
            Console.SetCursorPosition(5, 5);
            Console.Write("Show Data");
            while (true)
            {
                if (Mouse.IsButtonPressed(MouseButton.Middle))
                {
                    Point p = new Point();
                    p = Mouse.GetCursorPosition();
                    Console.Write(p.x + "\n" + p.y);
                    Console.ReadLine();

                    if (p.x == 5 && p.y == 5)
                    {
                        Console.WriteLine("azan");
                        u[0].ShowData();
                        u[1].ShowData();
                        Console.Read();
                        break;
                    }

                }
            }
            Console.Read();



        }
    }
}
