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
            RegisteredSubjects = null;

        }
        public Student(string name, int age, int fsc, int ecat, int StuCH, List<DegreeProgram> Preferences, DegreeProgram RegisteredDegree, List<Subject> RegisteredSubjects)
        {
            this.name = name;
            this.age = age;
            this.fsc = fsc;
            this.ecat = ecat;
            this.StuCH = StuCH;
            this.RegisteredDegree = RegisteredDegree;
            this.RegisteredSubjects = RegisteredSubjects;
            this.Preferences = Preferences;
        }
        public Student(string name, int age, int fsc, int ecat, int StuCH, List<DegreeProgram> Preferences, DegreeProgram RegisteredDegree)
        {
            this.name = name;
            this.age = age;
            this.fsc = fsc;
            this.ecat = ecat;
            this.StuCH = StuCH;
            this.RegisteredDegree = RegisteredDegree;
            this.Preferences = Preferences;
        }
        public Student(string name, int age, int fsc, int ecat, int StuCH, List<DegreeProgram> Preferences)
        {
            this.name = name;
            this.age = age;
            this.fsc = fsc;
            this.ecat = ecat;
            this.StuCH = StuCH;
            this.Preferences = Preferences;
        }
        private string name;
        private int fsc;
        private int age;
        private int ecat;
        private List<DegreeProgram> Preferences = new List<DegreeProgram>();



        private DegreeProgram RegisteredDegree = null;
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
            this.RegisteredDegree = source;
        }
        public bool isRegistered()
        {
            if (RegisteredDegree != null)
                return true;
            return false;
        }
        public int getDegreeSubjectCount()
        {
            if (RegisteredDegree == null)
                return 0;
            return RegisteredDegree.getSubjectCount();

        }
        public Subject getSubjectOfDegree(int index)
        {
            return RegisteredDegree.getSubject(index);
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
            if (RegisteredDegree == null)
                return null;
            return RegisteredDegree.getTitle();
        }
        public int getFsc()
        {
            return fsc;
        }
        public int getEcat()
        {
            return ecat;
        }
        public float CalculateDues()
        {
            Dues = 0;
            for (int i = 0; i < RegisteredSubjects.Count; i++)
            {
                Dues = Dues + RegisteredSubjects[i].getFee();
            }
            return Dues;
        }

        public bool isRedundancyInPreference(List<DegreeProgram> Pref, DegreeProgram Source)
        {
            for (int i = 0; i < Pref.Count; i++)
            {

                Console.ReadLine();
                if (Pref[i].getTitle() == Source.getTitle())
                    return true;
            }
            return false;
        }
        public DegreeProgram isStudentApplicable()
        {
            for (int i = 0; i < Preferences.Count; i++)
            {

                DegreeProgram PrefOfStudent = getSpecificPreference(i);
                if (PrefOfStudent.getSeats() != 0)
                {
                    PrefOfStudent.DecrementInSeats();
                    return PrefOfStudent;
                }

            }
            return null;
        }
        public int getAge()
        {
            return age;
        }
        public int getCH()
        {
            return StuCH;
        }
        public string getSubjectCode(int index)
        {
            return RegisteredSubjects[index].getCode();
        }
        public int getPreferenceCount()
        {
            return Preferences.Count;
        }
        public bool isAnySubjectRegistered()
        {
            if (RegisteredSubjects.Count != 0)
                return true;
            return false;
        }
        public string getPreferenceName(int index)
        {
            return Preferences[index].getTitle();
        }
    }

}
