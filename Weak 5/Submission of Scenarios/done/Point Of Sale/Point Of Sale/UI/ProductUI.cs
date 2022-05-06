using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_Of_Sale.BL;
namespace Point_Of_Sale.UI
{
    class ProductUI
    {
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
