using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeProblem.BL;
using CoffeProblem.DL;
namespace CoffeProblem.UI
{
    class CoffeShopUI
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("##############################################");
            Console.WriteLine("              Welcome To Coffe Shop          ");
            Console.WriteLine("##############################################");
        }
        public static CoffeShop TakeInputOfCoffeShop()
        {
            CoffeShop temp;
            Console.WriteLine("ENter Name of Coffe SHop....");
            string name;
            name = Console.ReadLine();
            temp = new CoffeShop(name);
            return temp;
        }
        public static char MainMenu()
        {
            Console.WriteLine("Press 1. To Add a Menu item");
            Console.WriteLine("Press 2.To View the Cheapest Item in the menu");
            Console.WriteLine("Press 3.To View the Drink’s Menu");
            Console.WriteLine("Press 4.To View the Food’s Menu");
            Console.WriteLine("Press 5.To Add Order");
            Console.WriteLine("Press 6.To Fulfill the Order");
            Console.WriteLine("Press 7.To View The orders List");
            Console.WriteLine("Press 8.To Total Payable Amount");
            Console.WriteLine("Press 9.To Exit");
            char option;
            char.TryParse(Console.ReadLine(), out option);
            return option;

        }

        public static string PlaceOrder()
        {
            string NameOfItem;
            Console.WriteLine();
            Console.WriteLine("Enter Name Of item.....");
            NameOfItem = Console.ReadLine();
            return NameOfItem;
        }
        public static void DisplayMessage(string Msg)
        {
            Console.WriteLine(Msg);
        }
    }
}
