using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdmissionManagementSystem.BL
{
    class DegreeProgram
    {
        public static List<DegreeProgram> OfferedPrograms = new List<DegreeProgram>();
        public DegreeProgram(string Title, string Duration, int seats)
        {
            this.Title = Title;
            this.Duration = Duration;
            this.seats = seats;
        }


        private List<Subject> OfferedSubjects = new List<Subject>();
        private string Title;
        private string Duration;
        private int seats;
        private int CH = 0;

        public string getTitle()
        {
            return Title;
        }
        public string getDuration()
        {
            return Duration;
        }
        public int getSeats()
        {
            return seats;
        }
        public void DecrementInSeats()
        {
            seats--;
        }
        public void AddSubject(Subject Source)
        {
            if (CH <= 20)
            {
                OfferedSubjects.Add(Source);
                IncrementInCH(Source.getCH());
            }
            else
                Console.WriteLine("Cannnot add more subjects");
        }
        private void IncrementInCH(int value)
        {
            CH = CH + value;
        }
        public int getCH()
        {
            return CH;
        }
        public int getSubjectCH(int index)
        {
            return OfferedSubjects[index - 1].getCH();
        }
        public void ViewSubject(int index)
        {
            Console.WriteLine(OfferedSubjects[index - 1].getCode() + "\t" + OfferedSubjects[index - 1].getCH());
        }
        public int getSubjectCount()
        {
            return OfferedSubjects.Count;
        }
        public static void AddDegreeInList(DegreeProgram Source)
        {
            OfferedPrograms.Add(Source);
        }
        public bool isLimitOfSubjectsApproach(int SubjectCH)
        {
            if ((SubjectCH + CH) > 20)
                return true;
            return false;
        }
        public bool isRedundancyInSubjects(Subject Source)
        {
            for (int i = 0; i < OfferedSubjects.Count; i++)
            {
                if (OfferedSubjects[i] == Source)
                    return true;
            }
            return false;
        }
    }
}
