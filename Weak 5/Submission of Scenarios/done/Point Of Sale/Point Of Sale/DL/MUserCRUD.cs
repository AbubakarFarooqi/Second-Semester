using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_Of_Sale.BL;
using System.IO;
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
        public static string getUserID(int index)
        {
            return listOfUsers[index].getID();
        }
        public static string getUserPassword(int index)
        {
            return listOfUsers[index].getPassword();
        }
        public static void ReadFromFile()
        {

            string path = "Users.txt";
            StreamReader File = new StreamReader(path);
            string temp = " ";

            while ((temp = File.ReadLine()) != null)
            {
                string ID;
                string Password;
                string Role;
                string[] fields = temp.Split(',');
                ID = fields[0];
                Password = fields[1];
                Role = fields[2];
                MUserCRUD.AddUserInList(new MUser(ID, Password, Role));
            }
            File.Close();
        }
        public static void WritingToFile()
        {
            string path = "Users.txt";
            StreamWriter File = new StreamWriter(path);
            for (int i = 0; i < listOfUsers.Count; i++)
            {
                File.WriteLine(listOfUsers[i].getID() + "," + listOfUsers[i].getPassword() + "," + listOfUsers[i].getRole());
                File.Flush();
            }
            File.Close();
        }
    }
}
