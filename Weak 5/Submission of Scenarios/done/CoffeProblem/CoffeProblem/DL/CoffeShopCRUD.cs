using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeProblem.BL;
using CoffeProblem.DL;
using System.IO;
namespace CoffeProblem.DL
{
    class CoffeShopCRUD
    {
        public static List<CoffeShop> ListOfShops = new List<CoffeShop>();
        public static void AddShop(CoffeShop source)
        {
            ListOfShops.Add(source);
        }
        public static int getListCount()
        {
            return ListOfShops.Count;
        }
        public static int getThisCoffeShopIndex(string name)
        {
            for (int i = 0; i < ListOfShops.Count; i++)
            {
                if (name == ListOfShops[i].getName())
                    return i;
            }
            return -1;
        }
        public static void WriteToFile()
        {
            string Path = "CoffeShop.txt";
            StreamWriter File = new StreamWriter(Path);
            for (int i = 0; i < ListOfShops.Count; i++)
            {
                File.Write(ListOfShops[i].getName() + ",");
                if (ListOfShops[i].getCountOFListOFMenuItems() != 0)
                {
                    for (int j = 0; j < ListOfShops[i].getCountOFListOFMenuItems() - 1; j++)
                    {
                        File.Write(ListOfShops[i].getMenuItem(j).getName() + ";");
                    }
                    File.Write(ListOfShops[i].getMenuItem(ListOfShops[i].getCountOFListOFMenuItems() - 1).getName() + ",");
                }
                else
                {
                    File.Write("-1,");
                }
                if (ListOfShops[i].getOrdersCount() != 0)
                {
                    for (int j = 0; j < ListOfShops[i].getOrdersCount() - 1; j++)
                    {
                        File.Write(ListOfShops[i].getSpecificOrder(j) + ";");
                    }
                    File.Write(ListOfShops[i].getSpecificOrder(ListOfShops[i].getOrdersCount() - 1));
                }
                else
                {
                    File.Write("-1");
                }
                File.Flush();
                File.WriteLine();
            }
            File.Close();

        }

        public static void ReadFromFile()
        {

            string Path = "CoffeShop.txt";
            StreamReader File = new StreamReader(Path);
            string Temp = "";
            CoffeShop shop = null;
            while ((Temp = File.ReadLine()) != null)
            {
                string[] SeparatedFields = Temp.Split(',');
                string[] MenuItems = SeparatedFields[1].Split(';');
                string[] order = SeparatedFields[2].Split(';');
                Console.WriteLine(SeparatedFields[0] + " " + SeparatedFields[1] + " " + SeparatedFields[2]);

                if (SeparatedFields[1] == "-1" && SeparatedFields[2] == "-1")
                {
                    shop = new CoffeShop(SeparatedFields[0]);
                }
                else if (SeparatedFields[1] != "-1" && SeparatedFields[2] == "-1")
                {
                    List<MenuItem> ListOfItems = new List<MenuItem>();
                    for (int j = 0; j < MenuItems.Length; j++)
                    {
                        MenuItem tempItem = MenuItemCRUD.getMenuByName(MenuItems[j]);
                        if (tempItem != null)
                            ListOfItems.Add(tempItem);
                    }
                    shop = new CoffeShop(SeparatedFields[0], ListOfItems);
                }
                else if (SeparatedFields[1] != "-1" && SeparatedFields[2] != "-1")
                {
                    List<MenuItem> ListOfItems = new List<MenuItem>();
                    for (int j = 0; j < MenuItems.Length; j++)
                    {

                        MenuItem tempItem = MenuItemCRUD.getMenuByName(MenuItems[j]);
                        if (tempItem != null)
                            ListOfItems.Add(tempItem);
                    }
                    List<string> Orders = new List<string>();
                    for (int j = 0; j < order.Length; j++)
                    {
                        Orders.Add(order[j]);
                    }
                    shop = new CoffeShop(SeparatedFields[0], ListOfItems, Orders);
                }
                ListOfShops.Add(shop);
            }
            File.Close();
        }
    }
}
