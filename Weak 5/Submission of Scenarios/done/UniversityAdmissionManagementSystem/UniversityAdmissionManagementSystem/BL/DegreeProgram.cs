using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAdmissionManagementSystem.UI;
namespace UniversityAdmissionManagementSystem.BL
{
    class DegreeProgram
    {
        public DegreeProgram(string Title, string Duration, int seats)
        {
            this.Title = Title;
            this.Duration = Duration;
            this.seats = seats;
        }
        public DegreeProgram(string Title, string Duration, int seats, int CH)
        {
            this.Title = Title;
            this.Duration = Duration;
            this.seats = seats;
            this.CH = CH;
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
                MenuUI.DisplayMsg("Cannnot add more subjects");
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
            MenuUI.DisplayMsg(OfferedSubjects[index - 1].getCode() + "\t" + OfferedSubjects[index - 1].getCH());
        }
        public int getSubjectCount()
        {
            return OfferedSubjects.Count;
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
        public Subject getSubject(int index)
        {
            return OfferedSubjects[index];
        }
        public string getCodeOfSubject(int index)
        {
            return OfferedSubjects[index].getCode();
        }
    }
}
