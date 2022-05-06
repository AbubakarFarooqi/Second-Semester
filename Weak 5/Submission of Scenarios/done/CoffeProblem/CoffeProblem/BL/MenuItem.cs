using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeProblem.DL;

namespace CoffeProblem.BL
{
    class MenuItem
    {
        public MenuItem(string name, string type, float price)
        {
            this.name = name;
            this.type = type;
            this.price = price;

        }
        private string name;
        private string type;
        private float price;
        public string getName()
        {
            return name;
        }
        public float getPrice()
        {
            return price;
        }
        public string getType()
        {
            return type;
        }
    }
}
