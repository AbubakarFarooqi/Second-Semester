using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UniversityAdmissionManagementSystem.BL;
namespace UniversityAdmissionManagementSystem.DL
{
    class SubjectCRUD
    {
        public static List<Subject> AvailableSubjects = new List<Subject>();
        public static void AddSubjectInList(Subject Source)
        {
            AvailableSubjects.Add(Source);
        }
        public static void ReadFromFile()
        {
            string path = "Subjects.txt";
            StreamReader File = new StreamReader(path);

            string temp = "";
            while ((temp = File.ReadLine()) != null)
            {
                string Source = "";
                Source = Source + temp;
                string[] SeparatedFields = Source.Split(',');
                Subject sub = new Subject(SeparatedFields[0], int.Parse(SeparatedFields[1]), SeparatedFields[2], int.Parse(SeparatedFields[3]));
                AddSubjectInList(sub);
            }
            File.Close();

        }

        public static void WriteToFlle()
        {
            string path = "Subjects.txt";
            StreamWriter File = new StreamWriter(path);
            for (int i = 0; i < AvailableSubjects.Count; i++)
            {
                File.WriteLine(AvailableSubjects[i].getCode() + "," + AvailableSubjects[i].getCH() + "," + AvailableSubjects[i].getSubjectType() + "," + AvailableSubjects[i].getFee());
                File.Flush();
            }
            File.Close();
        }
        public static Subject getSubject(string code)
        {
            for (int i = 0; i < AvailableSubjects.Count; i++)
            {
                if (code == AvailableSubjects[i].getCode())
                    return AvailableSubjects[i];
            }
            return null;
        }
    }

}
