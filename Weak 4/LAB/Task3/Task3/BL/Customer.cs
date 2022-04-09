using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.BL
{
    class Customer
    {
        public Customer(string name, string Address, string Contact)
        {
            this.name = name;
            this.Address = Address;
            this.Contact = Contact;

        }
        public string name;
        public string Address;
        public string Contact;
        public List<Product> ProductList = new List<Product>();

        public void AddProduct(Product P)
        {
            ProductList.Add(P);
        }

        public void getAllProducts()
        {
            Console.WriteLine("Name\tPrice\tCategory");
            for (int i = 0; i < ProductList.Count; i++)
            {

                Console.WriteLine(ProductList[i].getName() + "\t" + ProductList[i].getPrice() + "\t" + ProductList[i].getCategory());
            }
        }

        public double TotalTax()
        {
            float Total = 0;
            foreach (Product P in ProductList)
            {
                Total = Total + P.calculateTax();
            }
            return Total;
        }


    }
}
