using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdmissionManagementSystem.BL
{
    class Student
    {
        public Student(string name, int age, int fsc, int ecat)
        {
            this.name = name;
            this.age = age;
            this.fsc = fsc;
            this.ecat = ecat;
        }
        private string name;
        private int fsc;
        private int age;
        private int ecat;
        private List<DegreeProgram> Preferences = new List<DegreeProgram>();
        public double CalculateMerit()
        {
            double Merit = ((float)fsc / 1100 * 70) + ((float)ecat / 400 * 30);
            return Merit;
        }
        /*  public void AddPreference(DegreeProgram Source)
          {
              Preferences.Add(Source);
          }*/
        public string getName()
        {
            return name;
        }
        public DegreeProgram getSpecificPreference(int prefNum)
        {
            return Preferences[prefNum];
        }
        public int TotalPreferences()
        {
            return Preferences.Count;
        }
        public void AssignPreferences(List<DegreeProgram> prefereces)
        {
            this.Preferences = prefereces;
        }

    }

}
