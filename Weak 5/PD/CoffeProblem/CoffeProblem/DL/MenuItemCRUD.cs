using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeProblem.BL;
namespace CoffeProblem.DL
{
    class MenuItemCRUD
    {
        public static List<MenuItem> ListOfMenuItems = new List<MenuItem>();
        public static void AddMenuItem(MenuItem Source)
        {
            ListOfMenuItems.Add(Source);
        }
        public static MenuItem getMenuItem(int index)
        {
            return ListOfMenuItems[index];
        }
        public static string CheapestItem()
        {
            float CheapestItemPrice;
            int CheapestItemIndex;
            CheapestItemIndex = 0;
            CheapestItemPrice = ListOfMenuItems[0].getPrice();
            for (int i = 1; i < ListOfMenuItems.Count; i++)
            {
                if (CheapestItemPrice > ListOfMenuItems[i].getPrice())
                {
                    CheapestItemIndex = i;
                    CheapestItemPrice = ListOfMenuItems[i].getPrice();
                }
            }
            return ListOfMenuItems[CheapestItemIndex].getName();
        }
        public static MenuItem GetItemOfType(int index, string type)
        {
            if (ListOfMenuItems[index].getType() == type)
                return ListOfMenuItems[index];
            return null;
        }

    }
}
