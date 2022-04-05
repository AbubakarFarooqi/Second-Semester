using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Sign_in_Sign_Up.BL;
namespace Sign_in_Sign_Up
{
    class Program
    {
        static char Menu()
        {
            Console.WriteLine("Press 1 to Sign up \nPress 2 to Sign in");
            Console.WriteLine("Your Option...");
            char option;
            option = Console.ReadLine()[0];
            return option;
        }
        static Credentials SignUp()
        {
            string path = "G:\\BSCS\\2nd Semester\\OOP\\Weak 1\\Lab 1\\Manual 3\\Sign in Sign Up\\cust.txt";
            if (File.Exists(path))
            {
                Credentials user = new Credentials(); ;
                StreamWriter file = new StreamWriter(path, true);
                Console.WriteLine("Enter Your Name");
                user.UserName = Console.ReadLine();
                Console.WriteLine("Enter Your Password");
                user.UserPassword = Console.ReadLine();
                file.Write(user.UserName + ",");
                file.Flush();
                file.WriteLine(user.UserPassword);
                file.Flush();
                file.Close();
                return user;
            }
            else
                Console.WriteLine("File not exists");
            return null;
        }
        static string ExtractionOfSpecificField(string Source, int field)
        {
            string output = "";
            int comma = 1;
            for (int i = 0; i < Source.Length; i++)
            {

                if (comma == field)
                {
                    if (Source[i] != ',')
                        output = output + Source[i];
                }
                if (Source[i] == ',')
                    comma++;
            }

            return output;
        }
        static void PutDataIntoArray(Credentials[] user, ref int index)
        {
            string path = "G:\\BSCS\\2nd Semester\\OOP\\Weak 1\\Lab 1\\Manual 3\\Sign in Sign Up\\cust.txt";
            if (File.Exists(path))
            {

                StreamReader file = new StreamReader(path);
                string Line;
                while ((Line = file.ReadLine()) != null)
                {
                    Credentials tempp = new Credentials();
                    string temp;
                    temp = ExtractionOfSpecificField(Line, 1);
                    tempp.UserName = temp;
                    temp = ExtractionOfSpecificField(Line, 2);
                    tempp.UserPassword = temp;
                    user[index] = tempp;
                    index++;

                }
                file.Close();

            }
            else
                Console.WriteLine("File Not FOund");

        }
        static void signIN(Credentials[] user, int SIZE)
        {
            Console.WriteLine("Enter Your Name");
            string UserName;
            UserName = Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            string UserPassword;
            UserPassword = Console.ReadLine();
            bool isFound = false;
            for (int i = 0; i < SIZE; i++)
            {
                if (UserName == user[i].UserName && UserPassword == user[i].UserPassword)
                {
                    Console.WriteLine("You Are Signed In !");
                    isFound = true;
                    break;

                }
            }
            if (!isFound)
                Console.WriteLine("Invalid Credentials");

        }
        static void Main(string[] args)
        {
            char option = Menu();
            Credentials[] User = new Credentials[100];
            int count = 0;
            PutDataIntoArray(User, ref count);
            if (option == '1')
            {
                User[count] = SignUp();
                if (User[count] != null)
                    count++;
            }
            if (option == '2')
                signIN(User, count);
            Console.Read();
        }
    }
}
