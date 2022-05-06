using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeProblem.DL;
namespace CoffeProblem.BL
{
    class CoffeShop
    {

        public CoffeShop(string name)
        {
            this.name = name;
        }
        public CoffeShop(string name, List<MenuItem> ListOfMenuItems)
        {
            this.name = name;
            this.ListOfMenuItems = ListOfMenuItems;
        }
        public CoffeShop(string name, List<MenuItem> ListOfMenuItems, List<string> Orders)
        {
            this.name = name;
            this.ListOfMenuItems = ListOfMenuItems;
            this.Orders = Orders;
        }
        private string name;
        private List<MenuItem> ListOfMenuItems = new List<MenuItem>();
        private List<string> Orders = new List<string>();

        public void AddMenuItem(MenuItem Source)
        {
            ListOfMenuItems.Add(Source);
            MenuItemCRUD.AddMenuItem(Source);
        }
        public string AddOrder(string name)
        {
            for (int i = 0; i < ListOfMenuItems.Count; i++)
            {
                if (name == ListOfMenuItems[i].getName())
                {
                    Orders.Add(name);
                    return "Item Has been Added!";
                }
            }
            return "This Item Is not available!";
        }
        public string FulfillOrder(int index)
        {
            if (Orders.Count != 0)
            {
                string ReturnValue = Orders[index];
                return "The " + ReturnValue + " is ready!";


            }
            else
                return "All orders Have Been Fulfilled!";
        }
        public List<string> ListOrders()
        {
            return Orders;
        }
        public float DueAmount()
        {
            float Total = 0;
            for (int i = 0; i < Orders.Count; i++)
            {
                for (int j = 0; j < ListOfMenuItems.Count; j++)
                {
                    if (Orders[i] == ListOfMenuItems[j].getName())
                    {
                        Total = Total + ListOfMenuItems[j].getPrice();
                    }
                }
            }
            return Total;
        }
        public string CheapestItem()
        {
            return MenuItemCRUD.CheapestItem(ListOfMenuItems);
        }
        public List<MenuItem> FoodOnly()
        {
            List<MenuItem> Foods = new List<MenuItem>();
            for (int i = 0; i < ListOfMenuItems.Count; i++)
            {
                MenuItem name = MenuItemCRUD.GetItemOfType(i, "Food");
                if (name != null)
                    Foods.Add(name);
            }
            return Foods;
        }
        public List<MenuItem> DrinkOnly()
        {
            List<MenuItem> Drinks = new List<MenuItem>();
            for (int i = 0; i < ListOfMenuItems.Count; i++)
            {
                MenuItem temp = MenuItemCRUD.GetItemOfType(i, "Drink");
                if (temp != null)
                    Drinks.Add(temp);
            }
            return Drinks;
        }
        public string getName()
        {
            return name;
        }
        public int getCountOFListOFMenuItems()
        {
            return ListOfMenuItems.Count();
        }
        public MenuItem getMenuItem(int index)
        {

            return ListOfMenuItems[index];
        }
        public int getOrdersCount()
        {
            return Orders.Count;
        }
        public string getSpecificOrder(int index)
        {
            return Orders[index];
        }
        public void EmptyOrderList()
        {
            for (int i = 0; i < Orders.Count; i++)
                Orders.Clear();
        }
    }
}
