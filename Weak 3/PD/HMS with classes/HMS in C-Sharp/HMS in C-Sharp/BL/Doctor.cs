using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS_in_C_Sharp;
namespace HMS_in_C_Sharp.BL
{
    class Doctor
    {
        public Doctor() { }
        public Doctor(string name, string speciality, string ID, string pssword, string status)
        {
            this.name = name;
            this.speciality = speciality;
            this.ID = ID;
            this.pssword = pssword;
            this.status = status;

        }
        public string name;
        public string speciality;
        public int salary;
        public string ID;
        public string pssword;
        public string status;
        public void View()
        {
            Console.WriteLine(name + "\t" + speciality + "\t" + salary + "\t" + ID);
        }
        public void ViewStatus()
        {
            Console.WriteLine(name + "\t" + status + "\t" + ID);
        }

        public bool isValid(string pssword, string ID)
        {
            if (this.pssword == pssword && this.ID == ID)
                return true;
            return false;
        }


        public void AssignSalary(int salary)
        {

            this.salary = salary;
        }

        public bool isAvailable(string ID)
        {

            if (ID == this.ID)
                return true;
            return false;
        }
        public bool isValidSalary(string source)
        {
            int i = 0;
            while (i < source.Length)
            {
                if (!(source[i] >= 48 && source[i] <= 57))
                    return false;
                i++;
            }
            return true;
        }
        public string ReturnID(int encrptionLevel)
        {
            string returnValue = "";
            for (int i = 0; i < ID.Length; i++)
            {
                returnValue = returnValue + ID[i] + encrptionLevel.ToString();

            }
            return returnValue;
        }

        public int getSalary()
        {
            int salary = this.salary;
            return salary;
        }

        public void ChangeStatus(string status)
        {
            this.status = status;
        }

        public void AssignPassword(string pssword)
        {
            this.pssword = pssword;
        }
    }
}
