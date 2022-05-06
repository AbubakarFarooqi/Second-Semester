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
        public string ID;
        public string password;
        public List<Product> BuyList = new List<Product>();
        public void AddbuyProductInList(Product Source)
        {
            BuyList.Add(Source);
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
    }
}
