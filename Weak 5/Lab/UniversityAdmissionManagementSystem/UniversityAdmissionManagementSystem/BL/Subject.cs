using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdmissionManagementSystem.BL
{
    class Subject
    {
        public static List<Subject> OfferedSubjects = new List<Subject>();

        public Subject(string code, int CH, string SubjectType, int fee)
        {
            this.code = code;
            this.CH = CH;
            this.SubjectType = SubjectType;
            this.fee = fee;
        }
        private string code;
        private int CH;
        private string SubjectType;
        private int fee;


        public int getCH()
        {
            return CH;
        }
        public string getCode()
        {
            return code;
        }
        public int getFee()
        {
            return fee;
        }
        public static void AddSubjectInList(Subject Source)
        {
            OfferedSubjects.Add(Source);
        }

    }
}
