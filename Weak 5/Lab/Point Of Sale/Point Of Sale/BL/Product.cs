using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Of_Sale.BL
{
    class Product
    {
        public Product(string name, string category, float price, int stock, int stockThreshold)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.stockThreshold = stockThreshold;
            this.Stock = stock;

        }
        public string name;
        public string category;
        public float price;
        public int Stock;
        public int stockThreshold;
        public float getPrice()
        {
            return price;
        }
        public string getName()
        {
            return name;
        }
        public string getCategory()
        {
            return category;
        }
        public void DecrementInStock()
        {
            Stock--;
        }
        public float getTaxedPrice()
        {
            float Tax = 0;
            if (category == "Grocery")
            {
                Tax = 10;
            }
            else if (category == "Fruit")
            {
                Tax = 5;
            }
            else
                Tax = 15;
            return price + ((price * Tax) / 100);
        }
        public float getSalesTax()
        {
            return getTaxedPrice() - price;
        }
        public bool isNeeded()
        {
            if (Stock < stockThreshold)
                return true;
            else return false;
        }

    }
}
