using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAdmissionManagementSystem.BL
{
    class AdmissionBranch
    {

        private List<Student> Applicants = new List<Student>();
        private List<RegisteredStudent> listRegisteredStudents = new List<RegisteredStudent>();
        public void AddApplicant(Student Source, List<DegreeProgram> Preferences)
        {
            Applicants.Add(Source);
            Applicants[Applicants.Count - 1].AssignPreferences(Preferences);
        }
        public void GenerateMeritList()
        {
            for (int i = 0; i < Applicants.Count; i++)
            {
                DegreeProgram temp;
                if ((temp = isStudentApplicable(Applicants[i])) != null)
                {
                    Console.WriteLine(Applicants[i].getName() + " is Applicable for " + temp.getTitle());
                    RegisteredStudent Source = new RegisteredStudent(Applicants[i], temp);
                    listRegisteredStudents.Add(Source);
                }
            }
        }
        private DegreeProgram isStudentApplicable(Student Source)
        {
            for (int i = 0; i < Source.TotalPreferences(); i++)
            {

                DegreeProgram PrefOfStudent = Source.getSpecificPreference(i);
                if (Source.CalculateMerit() >= PrefOfStudent.getMerit())
                {
                    if (PrefOfStudent.getSeats() != 0)
                    {
                        PrefOfStudent.DecrementInSeats();
                        return PrefOfStudent;
                    }
                }
            }
            return null;
        }
        public RegisteredStudent getStudent(int index)
        {
            return listRegisteredStudents[index - 1];
        }
        public bool RegisteredStudentSubjectInStudent(int index, Subject Source)
        {
            return listRegisteredStudents[index - 1].RegisterSubject(Source);
        }
    }
}
