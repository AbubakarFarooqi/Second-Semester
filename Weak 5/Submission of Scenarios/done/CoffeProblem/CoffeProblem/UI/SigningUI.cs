using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeProblem.UI
{
    class SigningUI
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("##############################################");
            Console.WriteLine("              Welcome To Coffe Shop          ");
            Console.WriteLine("##############################################");
        }
        public static char MainMenu()
        {
            Console.WriteLine("Press 1. To Sign in Your Shop");
            Console.WriteLine("Press 2. To Sign up a Shop");
            char option;
            char.TryParse(Console.ReadLine(), out option);
            return option;
        }
        public static string TakeSigningInfo()
        {
            Console.WriteLine("Enter NAme of Your Shop.....");
            return Console.ReadLine();
        }
        public static void WrongMSg()
        {
            Console.WriteLine("Wrong NAme.....");
            Console.ReadLine();
        }
    }
}
