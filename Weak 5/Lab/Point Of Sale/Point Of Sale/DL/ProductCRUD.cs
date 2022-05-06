using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
