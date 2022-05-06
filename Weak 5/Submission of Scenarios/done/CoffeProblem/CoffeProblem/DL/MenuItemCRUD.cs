using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeProblem.BL;
using System.IO;
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
        public static string CheapestItem(List<MenuItem> ListOfMenuItems)
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
        public static void WriteToFile()
        {
            string Path = "MenuItem.txt";
            StreamWriter File = new StreamWriter(Path);
            for (int i = 0; i < ListOfMenuItems.Count; i++)
            {
                File.WriteLine(ListOfMenuItems[i].getName() + "," + ListOfMenuItems[i].getType() + "," + ListOfMenuItems[i].getPrice());
                File.Flush();
            }
            File.Close();
        }
        public static void ReadFromFile()
        {

            string Path = "MenuItem.txt";
            StreamReader File = new StreamReader(Path);
            string Temp = "";
            while ((Temp = File.ReadLine()) != null)
            {
                string[] SeparatedFields = Temp.Split(',');
                MenuItem item = new MenuItem(SeparatedFields[0], SeparatedFields[1], float.Parse(SeparatedFields[2]));
                ListOfMenuItems.Add(item);
            }
            File.Close();
        }
        public static MenuItem getMenuByName(string name)
        {
            for (int i = 0; i < ListOfMenuItems.Count; i++)
            {
                if (name == ListOfMenuItems[i].getName())
                    return ListOfMenuItems[i];

            }
            return null;
        }
    }
}
