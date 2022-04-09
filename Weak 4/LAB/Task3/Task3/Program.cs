using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.BL;
namespace Task3
{
    class Program
    {
        static char menu()
        {
            Console.WriteLine("Press 1. to purchase PRoduct");
            Console.WriteLine("Press 2. to view purchased PRoducts");
            Console.WriteLine("Press 3. to view Tax on PRoducts");
            Console.WriteLine("Press 4. Exit ");
            char option;
            char.TryParse(Console.ReadLine(), out option);
            return option;



        }
        static void Main(string[] args)
        {
            List<Product> P = new List<Product>();
            for (int i = 0; i < 3; i++)
            {
                string name;
                string category;
                float price;
                Console.WriteLine("name = ");
                name = Console.ReadLine();
                Console.WriteLine("category = ");
                category = Console.ReadLine();
                Console.WriteLine("price = ");
                price = float.Parse(Console.ReadLine());
                Product temp = new Product(name, category, price);
                P.Add(temp);
            }
            Customer C = new Customer("jhaplo", "Tajpura", "031145611230");
            char option;
            do
            {
                Console.Clear();
                option = menu();
                switch (option)
                {
                    case '1':
                        Console.WriteLine("   name\tPrice");
                        int i = 1;
                        foreach (Product temp in P)
                        {

                            Console.WriteLine(i + " " + temp.getName() + "\t" + temp.getPrice());
                            i++;

                        }
                        Console.WriteLine("select Product ");
                        char option1;
                        char.TryParse(Console.ReadLine(), out option1);
                        C.AddProduct(P[int.Parse(option1.ToString()) - 1]);

                        break;
                    case '2':
                        C.getAllProducts();
                        Console.Read();
                        break;
                    case '3':
                        Console.WriteLine("Total Tax " + C.TotalTax());
                        Console.Read();

                        break;
                    case '4':
                        Console.WriteLine("Thanks for using our application");
                        Console.Read();

                        break;
                    default:
                        Console.WriteLine("Invalid opiton");
                        break;
                }



            } while (option != '4');

        }
    }
}
