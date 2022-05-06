using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeProblem.BL;
using CoffeProblem.DL;
namespace CoffeProblem.UI
{
    class ui
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("##############################################");
            Console.WriteLine("              Welcome To Coffe Shop          ");
            Console.WriteLine("##############################################");
        }
        public static string TakeInputOfCoffeShop()
        {
            string name;
            Console.WriteLine("ENter Name of Coffe SHop....");
            name = Console.ReadLine();
            return name;
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
        public static MenuItem TakeInputOfMenuItem()
        {
            string name;
            string type;
            float Price;
            Console.WriteLine("Enter NAme of Item...");
            name = Console.ReadLine();
            Console.WriteLine("ENter type of Item....");
            type = Console.ReadLine();
            Console.WriteLine("Enter Price Of Item...");
            Price = float.Parse(Console.ReadLine());
            MenuItem temp = new MenuItem(name, type, Price);
            return temp;
        }
        public static void HeaderOfDisplayItem()
        {
            int Y = Console.CursorTop;
            Console.Write("Name");
            Console.SetCursorPosition(20, Y);
            Console.Write("Category");
            Console.SetCursorPosition(40, Y);
            Console.WriteLine("Price");
        }
        public static void DisplayItem(MenuItem Source)
        {
            int Y = Console.CursorTop;
            Console.Write(Source.getName());
            Console.SetCursorPosition(20, Y);
            Console.Write(Source.getType());
            Console.SetCursorPosition(40, Y);
            Console.WriteLine(Source.getPrice());
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
