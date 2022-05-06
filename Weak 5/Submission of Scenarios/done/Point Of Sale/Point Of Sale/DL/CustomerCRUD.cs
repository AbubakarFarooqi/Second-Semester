using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_Of_Sale.BL;
using System.IO;
namespace Point_Of_Sale.DL
{
    class CustomerCRUD
    {
        public static List<Customer> ListOfCustomers = new List<Customer>();
        public static int getCustomerIndex(string ID, string password)
        {
            for (int i = 0; i < ListOfCustomers.Count; i++)
            {
                if (ListOfCustomers[i].getID() == ID && ListOfCustomers[i].getPassword() == password)
                    return i;
            }
            return -1;
        }
        public static void AddCustomerInList(Customer source)
        {
            ListOfCustomers.Add(source);
        }
        public static void WriteToFile()
        {

            string Path = "Cust.txt";
            StreamWriter File = new StreamWriter(Path);
            for (int i = 0; i < ListOfCustomers.Count; i++)
            {
                File.Write(ListOfCustomers[i].getID() + "," + ListOfCustomers[i].getPassword() + ",");
                if (ListOfCustomers[i].getBuyListCount() != 0)
                {
                    for (int j = 0; j < ListOfCustomers[i].getBuyListCount() - 1; j++)
                    {
                        File.Write(ListOfCustomers[i].getItemName(j) + ";");
                    }
                    File.Write(ListOfCustomers[i].getItemName(ListOfCustomers[i].getBuyListCount() - 1));
                }
                else
                {
                    File.Write("-1");
                }
                File.WriteLine();
                File.Flush();
            }
            File.Close();
        }
        public static void ReadFromFile()
        {

            string path = "Cust.txt";
            StreamReader File = new StreamReader(path);
            string temp = " ";

            while ((temp = File.ReadLine()) != null)
            {
                string[] fields = temp.Split(',');
                if (fields[2] != "-1")
                {
                    string[] field_2 = fields[2].Split(';');
                    List<Product> buyList = new List<Product>();
                    for (int j = 0; j < field_2.Length; j++)
                    {
                        Product Temp = ProductCRUD.getProductByName(field_2[j]);
                        if (Temp != null)
                            buyList.Add(Temp);
                    }
                    ListOfCustomers.Add(new Customer(fields[0], fields[1], buyList));
                }
                else
                {
                    ListOfCustomers.Add(new Customer(fields[0], fields[1]));
                }
            }
            File.Close();
        }
    }
}
