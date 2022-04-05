using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Sign_in_Sign_Up
{
    class Program
    {
        static char Menu()
        {
            Console.WriteLine("Press 1 to Sign up \n Press 2 to Sign in");
            Console.WriteLine("Your Option...");
            char option;
            option = Console.ReadLine()[0];
            return option;
        }
        static void SignUp()
        {
            string path = "D:\\BSCS\\2nd Semester\\OOP\\Weak 1\\Lab 1\\Manual 3\\Sign in Sign Up\\cust.txt";
            if (File.Exists(path))
            {
                StreamWriter file = new StreamWriter(path, true);
                Console.WriteLine("Enter Your Name");
                string name;
                name = Console.ReadLine();
                file.Write(name + ",");
                file.Flush();
                Console.WriteLine("Enter Your Password");
                string pass;
                pass = Console.ReadLine();
                file.WriteLine(pass);
                file.Flush();
                file.Close();
            }
            else
                Console.WriteLine("File not exists");
        }
        static string ExtractionOfSpecificField(string Source, int field)
        {
            string output = "";
            int comma = 1;
            for (int i = 0; i<Source.Length; i++)
            {

                if (comma == field)
                {
                    if (Source[i] != ',')
                    output = output + Source[i];
                }
                if (Source[i] == ',')
                    comma++;
            }
            Console.WriteLine(output);
            return output;
        }
        static void PutDataIntoArray(string[] Name , String[] Pass)
        {
            string path = "D:\\BSCS\\2nd Semester\\OOP\\Weak 1\\Lab 1\\Manual 3\\Sign in Sign Up\\cust.txt";
            if (File.Exists(path))
            {
                int index = 0;
                StreamReader file = new StreamReader(path);
                string Line;
                while ((Line=file.ReadLine()) != null)
                {
                   
                    string temp;
                    temp = ExtractionOfSpecificField(Line, 1);
                    Name[index] = temp;
                    temp = ExtractionOfSpecificField(Line, 2);
                    Pass[index] = temp;
                    index++;

                }
                file.Close();

            }
            else
                Console.WriteLine("File Not FOund");

        }
        static void signIN()
        {
            string[] Name = new string[10];
            string[] Pass = new string[10];
            PutDataIntoArray(Name, Pass);
            Console.WriteLine("Enter Your Name");
            string UserName;
            UserName = Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            string UserPassword ;
            UserPassword = Console.ReadLine();
            for(int i = 0; i < 10; i++)
            {
                if (UserName == Name[i] && UserPassword == Pass[i])
                    Console.WriteLine("You Are Signed In !");
            }
 
        }
        static void Main(string[] args)
        {
            char option = Menu();
            if (option == '1')
                SignUp();
            if (option == '2')
                signIN();
            Console.Read();
        }
    }
}
