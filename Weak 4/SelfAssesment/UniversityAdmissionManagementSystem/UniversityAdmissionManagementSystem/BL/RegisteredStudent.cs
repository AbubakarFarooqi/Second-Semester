using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdmissionManagementSystem.BL
{
    class RegisteredStudent
    {
        public RegisteredStudent(Student Applicant, DegreeProgram Degree)
        {
            this.Applicant = Applicant;
            this.Degree = Degree;
        }
        private Student Applicant;
        private DegreeProgram Degree;
        private List<Subject> RegisteredSubjects = new List<Subject>();
        private int StuCH;

        public bool RegisterSubject(Subject Source)
        {
            if (StuCH + Source.getCH() <= 9)
            {
                RegisteredSubjects.Add(Source);
                return true;

            }
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


    }
}
