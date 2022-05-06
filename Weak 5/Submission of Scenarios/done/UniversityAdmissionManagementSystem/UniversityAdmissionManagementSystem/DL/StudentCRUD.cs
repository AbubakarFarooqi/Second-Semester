using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UniversityAdmissionManagementSystem.BL;
namespace UniversityAdmissionManagementSystem.DL
{
    class StudentCRUD
    {
        public static List<Student> Candidates = new List<Student>();
        public static void AddStudentInList(Student Source)
        {
            Candidates.Add(Source);
        }
        public static void GiveAdmission()
        {

            List<Student> orderedList = new List<Student>();
            orderedList = StudentCRUD.Candidates.OrderByDescending(o => o.CalculateMerit()).ToList();
            List<Student> AdmittedStudents = new List<Student>();
            for (int i = 0; i < orderedList.Count; i++)
            {
                DegreeProgram temp;
                if ((temp = orderedList[i].isStudentApplicable()) != null)
                {
                    StudentCRUD.Candidates[i].AssignDegree(temp);


                }
            }
        }
        public static Student getStudent(int index)
        {
            return Candidates[index];
        }


        public static void ReadFromFile()
        {
            string path = "Student.txt";
            StreamReader File = new StreamReader(path);
            string CurrentLineInFile = "";
            while ((CurrentLineInFile = File.ReadLine()) != null)
            {
                string Source = "";
                Source = Source + CurrentLineInFile;
                string[] SeparatedFieldsByCommas = Source.Split(',');
                string[] SubjectsFields = SeparatedFieldsByCommas[7].Split(':');
                string[] PreferencesFields = SeparatedFieldsByCommas[5].Split(';');
                List<Subject> ListOfSubjects = new List<Subject>();
                List<DegreeProgram> ListOfPreferences = new List<DegreeProgram>();
                DegreeProgram Degree;
                for (int i = 0; i < PreferencesFields.Length; i++)
                {
                    DegreeProgram Pref = DegreeProgramCRUD.getDegree(PreferencesFields[i]);
                    if (Pref != null)
                        ListOfPreferences.Add(Pref);
                }
                if (SeparatedFieldsByCommas[6] != "-1")
                {
                    Degree = DegreeProgramCRUD.getDegree(SeparatedFieldsByCommas[6]);//return degree with this name
                    if (SeparatedFieldsByCommas[7] != "-1")
                    {
                        for (int j = 0; j < SubjectsFields.Length; j++)
                        {
                            Subject temp1 = SubjectCRUD.getSubject(SubjectsFields[j]);
                            if (temp1 != null)
                                ListOfSubjects.Add(temp1);
                        }
                    }
                    else
                    {
                        ListOfSubjects = null;
                    }
                }
                else
                {
                    Degree = null;
                }
                Student Stu = null;
                if (SeparatedFieldsByCommas[7] == "-1" && SeparatedFieldsByCommas[6] != "-1")
                    Stu = new Student(SeparatedFieldsByCommas[0], int.Parse(SeparatedFieldsByCommas[1]), int.Parse(SeparatedFieldsByCommas[2]), int.Parse(SeparatedFieldsByCommas[3]), int.Parse(SeparatedFieldsByCommas[4]), ListOfPreferences, Degree);
                else if (SeparatedFieldsByCommas[7] == "-1" && SeparatedFieldsByCommas[6] == "-1")
                    Stu = new Student(SeparatedFieldsByCommas[0], int.Parse(SeparatedFieldsByCommas[1]), int.Parse(SeparatedFieldsByCommas[2]), int.Parse(SeparatedFieldsByCommas[3]), int.Parse(SeparatedFieldsByCommas[4]), ListOfPreferences);
                else if (SeparatedFieldsByCommas[7] != "-1" && SeparatedFieldsByCommas[6] != "-1")
                    Stu = new Student(SeparatedFieldsByCommas[0], int.Parse(SeparatedFieldsByCommas[1]), int.Parse(SeparatedFieldsByCommas[2]), int.Parse(SeparatedFieldsByCommas[3]), int.Parse(SeparatedFieldsByCommas[4]), ListOfPreferences, Degree, ListOfSubjects);

                AddStudentInList(Stu);
            }
            File.Close();

        }

        public static void WriteToFlle()
        {
            string path = "Student.txt";
            StreamWriter File = new StreamWriter(path);
            for (int i = 0; i < Candidates.Count; i++)
            {
                File.Write(Candidates[i].getName() + "," + Candidates[i].getAge() + "," + Candidates[i].getFsc() + "," + Candidates[i].getEcat() + "," + Candidates[i].getCH() + ",");
                for (int j = 0; j < StudentCRUD.Candidates[i].getPreferenceCount() - 1; j++)
                {
                    File.Write(StudentCRUD.Candidates[i].getPreferenceName(j) + ";");
                }
                File.Write(StudentCRUD.Candidates[i].getPreferenceName(StudentCRUD.Candidates[i].getPreferenceCount() - 1) + ",");//Last Preference
                if (Candidates[i].isRegistered())
                {
                    File.Write(StudentCRUD.Candidates[i].getDegreeName() + ",");
                    if (StudentCRUD.Candidates[i].isAnySubjectRegistered())// cheking if subjects are registered
                    {
                        for (int j = 0; j < StudentCRUD.Candidates[i].getDegreeSubjectCount() - 1; j++)
                        {
                            File.Write(StudentCRUD.Candidates[i].getSubjectCode(j) + ";");
                        }
                        File.Write(StudentCRUD.Candidates[i].getSubjectCode(StudentCRUD.Candidates[i].getDegreeSubjectCount() - 1));
                    }
                    else
                    {
                        File.Write("-1");
                    }
                }
                else
                {
                    File.Write("-1,-1");
                }
                File.WriteLine();
                File.Flush();
            }
            File.Close();
        }
    }
}
