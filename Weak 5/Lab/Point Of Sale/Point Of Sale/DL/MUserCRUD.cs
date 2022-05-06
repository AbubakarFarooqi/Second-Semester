using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_Of_Sale.BL;

namespace Point_Of_Sale.DL
{
    class MUserCRUD
    {
        public static List<MUser> listOfUsers = new List<MUser>();
        public static void AddUserInList(MUser Source)
        {
            listOfUsers.Add(Source);
        }
        public static int getUserIndex(string ID, string Password)
        {
            for (int i = 0; i < listOfUsers.Count; i++)
            {
                if (ID == listOfUsers[i].getID() && Password == listOfUsers[i].getPassword())
                    return i;
            }
            return -1;
        }
        public static string getRole(int index)
        {
            return listOfUsers[index].getRole();
        }


    }
}
