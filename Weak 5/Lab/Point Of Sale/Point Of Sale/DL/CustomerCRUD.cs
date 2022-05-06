using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_Of_Sale.BL;
namespace Point_Of_Sale.DL
{
    class CustomerCRUD
    {
        public static List<Customer> ListOfCustomers = new List<Customer>();
        public static void AddCustomer(Customer source)
        {
            ListOfCustomers.Add(source);
        }
    }
}
