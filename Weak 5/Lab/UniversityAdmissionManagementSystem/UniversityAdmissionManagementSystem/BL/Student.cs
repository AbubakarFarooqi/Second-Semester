using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdmissionManagementSystem.BL
{
    class Student
    {
        public static List<Student> Candidates = new List<Student>();
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



        private DegreeProgram Degree = null;
        private List<Subject> RegisteredSubjects = new List<Subject>();
        private int StuCH;
        private int Dues;




        public double CalculateMerit()
        {
            double Merit = ((float)fsc / 1100 * 70) + ((float)ecat / 400 * 30);
            return Merit;
        }
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
        public void AssignDegree(DegreeProgram source)
        {
            this.Degree = source;
        }
        public bool isRegistered()
        {
            if (Degree != null)
                return true;
            return false;
        }
        public int getDegreeSubjectCount()
        {
            return Degree.getSubjectCount();

        }
        public void ViewSubjectOfDegree(int index)
        {
            Degree.ViewSubject(index + 1);
        }
        public bool RegisterSubject(Subject Source)
        {

            if (StuCH + Source.getCH() <= 9)
            {
                RegisteredSubjects.Add(Source);
                StuCH = StuCH + Source.getCH();
                return true;

            }
            return false;
        }
        public string getDegreeName()
        {
            return Degree.getTitle();
        }
        public int getFsc()
        {
            return fsc;
        }
        public int getEcat()
        {
            return ecat;
        }
        public void CalculateDues()
        {
            Dues = 0;
            for (int i = 0; i < RegisteredSubjects.Count; i++)
            {
                Dues = Dues + RegisteredSubjects[i].getFee();
            }
        }
        public static void AddStudentInList(Student Source)
        {
            Candidates.Add(Source);
        }
        public bool isRedundancyInPreference(DegreeProgram Source)
        {
            for (int i = 0; i < Preferences.Count; i++)
            {
                if (Preferences[i] == Source)
                    return true;
            }
            return false;
        }
    }

}
