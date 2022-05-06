using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAdmissionManagementSystem.BL;
using UniversityAdmissionManagementSystem.DL;
using UniversityAdmissionManagementSystem.UI;

namespace UniversityAdmissionManagementSystem.UI
{
    class StudentUI
    {
        public static void DisplayMsg(string Msg)
        {
            Console.WriteLine(Msg);
        }
        public static string TakeString()
        {
            return Console.ReadLine();
        }

        public static Student TakeInputOfStudent()
        {
            Student temp;
            string name;
            int age;
            int fsc;
            int ecat;
            Console.WriteLine("ENter Your Name ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Your Age ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your FSC MArks ");
            fsc = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your ECAT MArks ");
            ecat = int.Parse(Console.ReadLine());
            temp = new Student(name, age, fsc, ecat);
            return temp;
        }
        public static int WhichSubjetcRegister(Student Source)
        {
            SubjectHeader();
            for (int i = 0; i < Source.getDegreeSubjectCount(); i++)
            {

                ViewSubject(Source.getSubjectOfDegree(i), i);
            }
            MenuUI.DisplayMsg("Choose Option...");
            int option;
            option = int.Parse(MenuUI.TakeString());
            return option;
        }

        public static int WhichStudent()
        {
            string name;
            MenuUI.DisplayMsg("ENter Your NAme...");
            name = MenuUI.TakeString();
            for (int i = 0; i < StudentCRUD.Candidates.Count; i++)
            {
                if (StudentCRUD.Candidates[i].getName() == name && StudentCRUD.Candidates[i].isRegistered())
                    return i;
            }
            return -1;
        }
        public static void GenerateMeritList(Student Source)
        {
            Console.WriteLine(Source.getName() + " is Enrolled in " + Source.getDegreeName());
        }
        public static void ViewRegisteredStudents()
        {
            int Y = Console.CursorTop;
            Console.SetCursorPosition(0, Y);
            Console.Write("Name");
            Console.SetCursorPosition(10, Y);
            Console.Write("Fsc Marks");
            Console.SetCursorPosition(20, Y);
            Console.Write("Ecat Marks");
            Console.SetCursorPosition(50, Y);
            Console.WriteLine("Degree Program");
            for (int i = 0; i < StudentCRUD.Candidates.Count; i++)
            {
                if (StudentCRUD.Candidates[i].isRegistered())
                {
                    Y = Console.CursorTop;
                    Console.SetCursorPosition(0, Y);
                    Console.Write(StudentCRUD.Candidates[i].getName());
                    Console.SetCursorPosition(10, Y);
                    Console.Write(StudentCRUD.Candidates[i].getFsc().ToString());
                    Console.SetCursorPosition(20, Y);
                    Console.Write(StudentCRUD.Candidates[i].getEcat().ToString());
                    Console.SetCursorPosition(50, Y);
                    Console.WriteLine(StudentCRUD.Candidates[i].getDegreeName());
                }
            }
        }
        public static bool ViewStudentOfSpecificProgram(string DegreeName)
        {
            bool flag = false;
            int Y = Console.CursorTop;
            Console.SetCursorPosition(0, Y);
            Console.Write("Name");
            Console.SetCursorPosition(10, Y);
            Console.Write("Fsc Marks");
            Console.SetCursorPosition(20, Y);
            Console.Write("Ecat Marks");
            Console.SetCursorPosition(50, Y);
            Console.WriteLine("Degree Program");
            for (int i = 0; i < StudentCRUD.Candidates.Count; i++)
            {
                if (StudentCRUD.Candidates[i].isRegistered())
                {
                    flag = true;
                    if (StudentCRUD.Candidates[i].getDegreeName() == DegreeName)
                    {
                        Y = Console.CursorTop;
                        Console.SetCursorPosition(0, Y);
                        Console.Write(StudentCRUD.Candidates[i].getName());
                        Console.SetCursorPosition(10, Y);
                        Console.Write(StudentCRUD.Candidates[i].getFsc().ToString());
                        Console.SetCursorPosition(20, Y);
                        Console.Write(StudentCRUD.Candidates[i].getEcat().ToString());
                        Console.SetCursorPosition(50, Y);
                        Console.WriteLine(StudentCRUD.Candidates[i].getDegreeName());
                    }
                }
            }
            return flag;

        }
        public static void ViewFeeHeader()
        {
            Console.WriteLine("STudent Name\tFee");
        }
        public static void ViewFee(string name, float fee)
        {
            Console.WriteLine(name + "\t" + fee);
        }
        public static List<DegreeProgram> InputOfPreferences() //AcedemicBranch acedBranch)
        {
            List<DegreeProgram> Preferences = new List<DegreeProgram>();
            string terminate = "1";
            while (terminate != "E" && terminate != "e")
            {
                Console.Clear();
                Console.WriteLine("Choose Preferences.....");
                Console.WriteLine();
                Console.WriteLine();
                DegreeProgramUI.ViewAllPrograms();
                int index = int.Parse(Console.ReadLine());
                if (!StudentCRUD.Candidates[StudentCRUD.Candidates.Count - 1].isRedundancyInPreference(Preferences, DegreeProgramCRUD.OfferedPrograms[index - 1]))
                    Preferences.Add(DegreeProgramCRUD.OfferedPrograms[index - 1]);
                else
                    Console.WriteLine(".....Redundancy Occurs......");
                Console.WriteLine("Press E. To Exit");
                terminate = Console.ReadLine();

            }
            return Preferences;
        }
        public static void ViewSubject(Subject Source, int index)
        {
            int Y = Console.CursorTop;
            Console.SetCursorPosition(0, Y);
            Console.Write("{0}. " + Source.getCode(), index + 1);
            Console.SetCursorPosition(30, Y);
            Console.WriteLine(Source.getCH().ToString());
        }
        public static void SubjectHeader()
        {
            int Y = Console.CursorTop;
            Console.SetCursorPosition(0, Y);
            Console.WriteLine("Code");
            Console.SetCursorPosition(30, Y);
            Console.WriteLine("CH");
        }
    }
}
