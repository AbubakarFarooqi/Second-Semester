using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_Of_Sale.BL;
namespace Point_Of_Sale.UI
{
    class Ui
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
        public static char CustomerMenu()
        {
            Console.WriteLine("Press 1. To View All Products");
            Console.WriteLine("Press 2. To Buy Products");
            Console.WriteLine("Press 3. To Generate Invoice");
            Console.WriteLine("Press 4. To Exit");
            char option;
            char.TryParse(Console.ReadLine(), out option);
            return option;
        }
        public static char AdminMenu()
        {
            Console.WriteLine("Press 1. To Add Product");
            Console.WriteLine("Press 2. To View All Products");
            Console.WriteLine("Press 3. To Find Product With Highest Price");
            Console.WriteLine("Press 4. To View Sales Tax Of All Products");
            Console.WriteLine("Press 5. To Products To Be Ordered");
            Console.WriteLine("Press 6. To Exit");
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
        public static void HeaderOfDisplayProduct()
        {
            int y = Console.CursorTop;
            Console.Write("Name");
            Console.SetCursorPosition(20, y);
            Console.Write("Category");
            Console.SetCursorPosition(40, y);
            Console.WriteLine("Price");
        }
        public static void DisplayProduct(string name, string category, float price)
        {
            int y = Console.CursorTop;
            Console.Write(name);
            Console.SetCursorPosition(20, y);
            Console.Write(category);
            Console.SetCursorPosition(40, y);
            Console.WriteLine(price);
        }
        public static Product TakeInputOfProduct()
        {
            string name;
            string category;
            float price;
            int stock;
            int threshold;
            Console.WriteLine("ENter Name Of Product...");
            name = Console.ReadLine();
            Console.WriteLine("Enter Category of Product...");
            category = Console.ReadLine();
            Console.WriteLine("Enter Price Of Product...");
            price = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Available Stock...");
            stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Stock Threshold...");
            threshold = int.Parse(Console.ReadLine());
            Product temp = new Product(name, category, price, stock, threshold);
            return temp;

        }
    }
}
