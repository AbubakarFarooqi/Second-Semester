using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_Of_Sale.BL;
using Point_Of_Sale.DL;
namespace Point_Of_Sale.UI
{
    class MenuUI
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("#####################################");
            Console.WriteLine("#            Point of Sale          #");
            Console.WriteLine("#####################################");
        }
        public static char SigningMenu()
        {
            Console.WriteLine("Press 1. To Sign In");
            Console.WriteLine("Press 2. To Sign Up");
            Console.WriteLine("Press 3. To Exit");
            char option;
            char.TryParse(Console.ReadLine(), out option);
            return option;
        }


        public static MUser TakeInputOfUser()
        {
            string Role;
            string ID;
            string Password;
            Console.WriteLine("ENter ID = ");
            ID = Console.ReadLine();
            Console.WriteLine("ENter Password = ");
            Password = Console.ReadLine();
            Console.WriteLine("ENter Role = ");
            Role = Console.ReadLine();
            MUser temp = new MUser(ID, Password, Role);
            return temp;
        }
        public static void DisplayMsg(string Msg)
        {
            Console.WriteLine(Msg);
        }
        public static string TakeMsg()
        {
            return Console.ReadLine();
        }

        public static int getUserIndex()
        {
            string ID = "";
            string Password = "";
            MenuUI.DisplayMsg("Enter Your ID....");
            ID = MenuUI.TakeMsg();
            MenuUI.DisplayMsg("Enter Your Password....");
            Password = MenuUI.TakeMsg();
            int Userindex = MUserCRUD.getUserIndex(ID, Password);
            return Userindex;
        }
    }
}
