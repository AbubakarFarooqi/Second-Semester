using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_Of_Sale.BL;
using Point_Of_Sale.DL;
namespace Point_Of_Sale.UI
{
    class AdminUI
    {
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
        public static void ViewAllProductsSalesTax()
        {
            Console.WriteLine(".......Sales tax of all Products.......");
            for (int i = 0; i < ProductCRUD.ListOfProducts.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + ".  " + ProductCRUD.ListOfProducts[i].getName() + " With Sales tax " + ProductCRUD.ListOfProducts[i].getSalesTax().ToString());
            }
        }
        public static void NeededProducts()
        {
            bool flag = true;

            for (int i = 0; i < ProductCRUD.ListOfProducts.Count; i++)
            {
                if (ProductCRUD.ListOfProducts[i].isNeeded())
                {
                    Console.WriteLine(ProductCRUD.ListOfProducts[i].getName() + " is Needed to be Ordered...");
                    flag = false;
                }
            }
            if (flag)
                Console.WriteLine("Nothing to Order....");
        }
    }
}
