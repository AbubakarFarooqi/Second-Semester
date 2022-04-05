using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_1.BL;
namespace Challenge_1
{
    class Program
    {
        static char Menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Product Management System");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Press 1 : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("To Add Product");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Press 2 : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("To Display All Products");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Press 3 : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("To See Total Worth");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Press 4 : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("To Exit");
            char option;
            option = Console.ReadLine()[0];
            return option;

        }
        static Product AddProduct()
        {
            Product Prodct = new Product();
            Console.Write("ENter Product ID");
            Prodct.ID = Console.ReadLine();
            Console.WriteLine();
            Console.Write("ENter Product Name");
            Prodct.name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("ENter Product Price");
            Prodct.price = float.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("ENter Product category");
            Prodct.category = Console.ReadLine();
            Console.WriteLine();
            Console.Write("ENter Product Brand NAme");
            Prodct.BrandName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("ENter Product Country");
            Prodct.country = Console.ReadLine();
            return Prodct;


        }
        static void ShowProducts(Product p)
        {
            Console.WriteLine(p.ID + "\t" + p.name + "\t" + p.price + "\t" + p.category + "\t" + p.BrandName + "\t" + p.country);
        }
        static float TotalWorth(Product[] p, int count)

        {

            float worth = 0;
            for (int i = 0; i < count; i++)
            {
                worth = worth + p[i].price;
            }
            return worth;
        }
        static void Main(string[] args)
        {
            int SIZE = 10;
            int count = 0;
            Product[] P = new Product[SIZE];
            char option = ' ';
            while (option != '4')
            {
                option = Menu();
                if (option == '1')
                {
                    Console.Clear();
                    P[count] = AddProduct();
                    count++;
                }
                if (option == '2')
                {
                    Console.Clear();
                    if (count == 0)
                    {
                        Console.WriteLine("No Record Found");
                    }
                    else
                    {
                        Console.WriteLine("ID\tNAme\tPrice\tCategory\tBrand NAme\tCountry");
                        for (int i = 0; i < count; i++)
                        {
                            ShowProducts(P[i]);
                        }
                    }

                }
                if (option == '3')
                {
                    Console.Clear();
                    Console.WriteLine("Total Worth = " + TotalWorth(P, count));

                }
            }

        }
    }
}
