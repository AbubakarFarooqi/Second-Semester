using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdmissionManagementSystem.BL
{
    class Subject
    {
        public Subject(string code, int CH, string SubjectType)
        {
            this.code = code;
            this.CH = CH;
            this.SubjectType = SubjectType;
        }
        private string code;
        private int CH;
        private string SubjectType;

        public int getCH()
        {
            return CH;
        }
        public string getCode()
        {
            return code;
        }

    }
}
