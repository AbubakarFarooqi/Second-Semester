using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Of_Sale.BL
{
    class Customer
    {
        public Customer(string ID, string password)
        {
            this.ID = ID;
            this.password = password;
        }
        public Customer(string ID, string password, List<Product> BuyList)
        {
            this.ID = ID;
            this.password = password;
            this.BuyList = BuyList;
        }
        private string ID;
        private string password;
        private List<Product> BuyList = new List<Product>();
        public void AddbuyProductInList(Product Source)
        {
            BuyList.Add(Source);
        }
        public string getID()
        {
            return ID;
        }
        public string getPassword()
        {
            return password;
        }
        public float GenerateInvoice()
        {
            float Invoice = 0;
            for (int i = 0; i < BuyList.Count; i++)
            {
                Invoice = Invoice + BuyList[i].getTaxedPrice();
            }
            return Invoice;
        }
        public int getBuyListCount()
        {
            return BuyList.Count;
        }
        public string getItemName(int index)
        {
            return BuyList[index].getName();
        }
    }
}
