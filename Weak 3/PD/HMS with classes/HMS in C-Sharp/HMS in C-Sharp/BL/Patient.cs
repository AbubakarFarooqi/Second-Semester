using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_in_C_Sharp.BL
{

    class Patient
    {
        public Patient(string Name, string Disease, string ID, string Password)
        {
            this.Name = Name;
            this.Disease = Disease;
            this.ID = ID;
            this.Password = Password;

        }
        public Patient() { }
        public string Name;
        public string Disease;
        public string Doc_ID;
        public string ID;
        public string Password;


        public void View()
        {
            Console.WriteLine(Name + "\t" + Disease + "\t" + Doc_ID + "\t" + ID);
        }



        public bool isValid(string Password, string ID)
        {
            if (this.Password == Password && this.ID == ID)
                return true;
            return false;
        }



        public void Recommend_Doctor(List<Doctor> DoctorArray)
        {

            bool flag = true; // if it is true then no doctor is availbe for recomendation
            for (int i = 0; i < DoctorArray.Count; i++)
            {
                if (DoctorArray[i].speciality == Disease)
                {
                    Console.WriteLine("Doctor " + "\t" + DoctorArray[i].name + "\t" + " with ID : " + "\t" + DoctorArray[i].ID + "\t" + " is recommended for this patient");
                    flag = false;
                    break;
                }
            }
            if (flag)

                Console.WriteLine("No recommendations availabe...");

        } // End of Recommend Doctor




        public void AssignDoctor()
        {
            Console.WriteLine("Enter Patient's Doctor ID : ");
            Doc_ID = Console.ReadLine();
        }
        public void AssignDoctor(string Doc_ID)
        {

            this.Doc_ID = Doc_ID;
        }


        public bool isAvailble(string ID)
        {
            if (ID == this.ID)
                return true;
            return false;
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

        public void AssignPassword(string Password)
        {
            this.Password = Password;
        }
    }

}
