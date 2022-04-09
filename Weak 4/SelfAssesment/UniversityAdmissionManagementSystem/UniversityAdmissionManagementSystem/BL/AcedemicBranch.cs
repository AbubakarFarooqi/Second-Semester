using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdmissionManagementSystem.BL
{
    class AcedemicBranch
    {
        private List<DegreeProgram> OfferedPrograms = new List<DegreeProgram>();
        private List<Subject> OfferedSubjects = new List<Subject>();

        public void AddDegreeProgram(DegreeProgram Source)
        {
            OfferedPrograms.Add(Source);
        }
        public void AddSubjectInDegree(Subject Source, int index)
        {
            OfferedPrograms[index - 1].AddSubject(Source);
        }
        public void ViewAllPrograms()
        {
            Console.WriteLine("   Name\tDuration");
            for (int i = 0; i < OfferedPrograms.Count; i++)
            {
                Console.WriteLine(OfferedPrograms[i].getTitle() + "\t" + OfferedPrograms[i].getDuration());
            }
        }
        public DegreeProgram returnDegreeProgram(int i)
        {
            return OfferedPrograms[i - 1];
        }
        public void AddSubject(Subject Source)
        {
            OfferedSubjects.Add(Source);
        }
        public void ViewSubject(int index)
        {
            Console.WriteLine(OfferedSubjects[index].getCode() + "\t" + OfferedSubjects[index].getCH());
        }
        public Subject getSubject(int index)
        {
            return OfferedSubjects[index - 1];
        }
        public int getSubjectsCount()
        {
            return OfferedSubjects.Count;
        }
        public bool isLimitOfSubjectsApproach(int index, int CH)
        {
            if ((OfferedPrograms[index - 1].getCH() + CH) > 20)
                return true;
            return false;
        }
        public int getSubjectCH(int index)
        {
            return OfferedSubjects[index - 1].getCH();
        }
        public void ViewProgram(int index)
        {
            Console.WriteLine(OfferedSubjects[index - 1].getCode() + "\t" + OfferedSubjects[index - 1].getCH());
        }
    }
}
