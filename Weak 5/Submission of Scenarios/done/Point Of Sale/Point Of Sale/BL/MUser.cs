using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Of_Sale.BL
{
    class MUser
    {
        public MUser(string ID, string Password, string Role)
        {
            this.ID = ID;
            this.Password = Password;
            this.Role = Role;
        }
        private string ID;
        private string Password;
        private string Role;
        // public static List<> ListOfCustomers = new List<Customer>();

        public string getID()
        {
            return ID;

        }
        public string getPassword()
        {
            return Password;
        }
        public string getRole()
        {
            return Role;

        }
    }
}
