using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAdmissionManagementSystem.BL;
using System.IO;
namespace UniversityAdmissionManagementSystem.DL
{
    class DegreeProgramCRUD
    {
        public static List<DegreeProgram> OfferedPrograms = new List<DegreeProgram>();
        public static void AddDegreeInList(DegreeProgram Source)
        {
            OfferedPrograms.Add(Source);
        }
        public static DegreeProgram getDegree(string title)
        {
            for (int i = 0; i < OfferedPrograms.Count; i++)
            {
                if (OfferedPrograms[i].getTitle() == title)
                    return OfferedPrograms[i];
            }
            return null;
        }
        public static void ReadFromFile()
        {
            string path = "DegreeProgram.txt";
            StreamReader File = new StreamReader(path);
            string temp = "";
            while ((temp = File.ReadLine()) != null)
            {
                string Source = "";
                Source = Source + temp;
                string[] SeparatedFields = Source.Split(',');
                /*  Console.WriteLine(SeparatedFields[3]);
                  Console.ReadLine();*/
                DegreeProgram degree = new DegreeProgram(SeparatedFields[0], SeparatedFields[1], int.Parse(SeparatedFields[2]), int.Parse(SeparatedFields[3]));
                string[] separatedSubjects = SeparatedFields[4].Split(';');
                for (int i = 0; i < separatedSubjects.Length; i++)
                {
                    Subject sub;
                    if ((sub = SubjectCRUD.getSubject(separatedSubjects[i])) != null)
                        degree.AddSubject(sub);
                }
                AddDegreeInList(degree);
            }
            File.Close();

        }

        public static void WriteToFlle()
        {
            string path = "DegreeProgram.txt";
            StreamWriter File = new StreamWriter(path, true);
            for (int i = 0; i < OfferedPrograms.Count; i++)
            {
                File.Write(OfferedPrograms[i].getTitle() + "," + OfferedPrograms[i].getDuration() + "," + OfferedPrograms[i].getSeats() + "," + OfferedPrograms[i].getCH() + ",");
                for (int j = 0; j < OfferedPrograms[i].getSubjectCount() - 1; j++)
                {
                    File.Write(OfferedPrograms[i].getCodeOfSubject(j) + ";");
                }
                File.WriteLine(OfferedPrograms[i].getCodeOfSubject(OfferedPrograms[i].getSubjectCount() - 1));
                File.Flush();
            }

            File.Close();
        }
    }
}
