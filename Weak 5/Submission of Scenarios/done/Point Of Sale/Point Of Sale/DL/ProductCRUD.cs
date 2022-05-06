using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Point_Of_Sale.BL
{
    class ProductCRUD
    {
        public static List<Product> ListOfProducts = new List<Product>();
        public static void AddProduct(Product Source)
        {
            ListOfProducts.Add(Source);
        }
        public static Product getProduct(int index)
        {
            return ListOfProducts[index];
        }
        public static Product getProductByName(string name)
        {
            for (int i = 0; i < ListOfProducts.Count; i++)
            {
                if (ListOfProducts[i].getName() == name)
                {
                    return ListOfProducts[i];
                }
            }
            return null;

        }
        public static int getProductCount()
        {
            return ListOfProducts.Count;
        }
        public static Product getProductOfHighestPrice()
        {
            float HighestPrice;
            int HighestPriceIndex = 0;

            HighestPrice = ListOfProducts[0].getPrice();
            for (int i = 1; i < ListOfProducts.Count; i++)
            {
                if (HighestPrice < ListOfProducts[i].getPrice())
                {
                    HighestPriceIndex = i;
                    HighestPrice = ListOfProducts[i].getPrice();
                }
            }
            return ListOfProducts[HighestPriceIndex];
        }
        public static void WriteToFile()
        {
            string Path = "Products.txt";
            StreamWriter File = new StreamWriter(Path);
            for (int i = 0; i < ListOfProducts.Count; i++)
            {
                File.WriteLine(ListOfProducts[i].getName() + "," + ListOfProducts[i].getCategory() + "," + ListOfProducts[i].getPrice() + "," + ListOfProducts[i].getStock() + "," + ListOfProducts[i].getStockThreshold());
            File.Flush();
            }
            File.Close();
        }
        public static void ReadFromFile()
        {

            string path = "Products.txt";
            StreamReader File = new StreamReader(path);
            string temp = " ";

            while ((temp = File.ReadLine()) != null)
            {
                string[] fields = temp.Split(',');
                ProductCRUD.AddProduct(new Product(fields[0], fields[1], float.Parse(fields[2]), int.Parse(fields[3]), int.Parse(fields[4])));
            }
            File.Close();
        }
    }
}
