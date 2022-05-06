using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAdmissionManagementSystem.BL;
using UniversityAdmissionManagementSystem.DL;
namespace UniversityAdmissionManagementSystem.UI
{
    class MenuUI
    {
        public static void DisplayMsg(string Msg)
        {
            Console.WriteLine(Msg);
        }
        public static string TakeString()
        {
            return Console.ReadLine();
        }

        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("*************************************************************");
            Console.WriteLine("         University Admission Management System             *");
            Console.WriteLine("*************************************************************");
        }

        public static string MainMenu()
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Program");
            Console.WriteLine("6. Register Subjects for a Specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Add Subject in System");
            Console.WriteLine("9. Exit");
            Console.Write("Enter Option: ");
            string option;
            option = Console.ReadLine();
            return option;
        }









    }
}
