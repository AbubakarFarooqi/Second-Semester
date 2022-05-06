using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeProblem.BL;
namespace CoffeProblem.UI
{
    class MenuItemUI
    {
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
    }
}
