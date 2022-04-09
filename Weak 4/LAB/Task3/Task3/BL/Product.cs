using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.BL
{
    class Product
    {
        public Product(string name, string category, float price)
        {
            this.name = name;
            this.category = category;
            this.price = price;
        }

        public string name;
        public float price;
        public string category;

        public string getName()
        {
            return name;

        }
        public string getCategory()
        {
            return category;

        }
        public float getPrice()
        {
            return price;

        }

        public float calculateTax()
        {
            float ratio;
            if (category == "f")
            {
                ratio = 0.1F;
            }
            else
                ratio = 0.2F;
            float tax = price * ratio;
            return tax;
        }
    }
}
