using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_Of_Sale.BL;
using Point_Of_Sale.UI;
using Point_Of_Sale.DL;
namespace Point_Of_Sale.UI
{
    class CustomerUI
    {
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
        public static void ErrorMsg()
        {
            Console.WriteLine("There is some Error in Database...");
            Console.ReadLine();
        }
        public static void DisplayAllProducts()
        {

            Console.WriteLine(".....All Products.......");
            HeaderOfDisplayProduct();
            for (int i = 0; i < ProductCRUD.ListOfProducts.Count; i++)
            {

                string name = ProductCRUD.ListOfProducts[i].getName();
                string category = ProductCRUD.ListOfProducts[i].getCategory();
                float price = ProductCRUD.ListOfProducts[i].getPrice();
                DisplayProduct(name, category, price);
            }
        }
        public static void PrintInvoice(float Invoice)
        {
            Console.WriteLine("You Have To Pay = " + Invoice);
        }
        public static Product BuyProduct()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Which Product You want to buy");
            string option = Console.ReadLine();
            int index = int.Parse(option);
            Product temp = ProductCRUD.getProduct(index - 1);
            return temp;
        }
        public static void NoProduct()
        {
            Console.WriteLine("No Product Available....");
        }
    }
}
