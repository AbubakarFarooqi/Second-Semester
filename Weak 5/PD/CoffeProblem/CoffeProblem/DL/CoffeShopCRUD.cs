using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeProblem.BL;
using CoffeProblem.DL;
namespace CoffeProblem.DL
{
    class CoffeShopCRUD
    {
        public static CoffeShop Shop;
        public static void AddShop(string name)
        {
            Shop = new CoffeShop(name);
        }
    }
}
