using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAdmissionManagementSystem.BL;
using UniversityAdmissionManagementSystem.DL;
using UniversityAdmissionManagementSystem.UI;
namespace UniversityAdmissionManagementSystem
{
    class Program
    {
        static void Option_1()
        {
            MenuUI.Header();
            if (DegreeProgramCRUD.OfferedPrograms.Count == 0)
            {
                StudentUI.DisplayMsg(".....First Add a Degree in System.....");
            }
            else
            {
                Student temp = StudentUI.TakeInputOfStudent();
                StudentCRUD.AddStudentInList(temp);
                StudentCRUD.Candidates[StudentCRUD.Candidates.Count - 1].AssignPreferences(StudentUI.InputOfPreferences());
                StudentCRUD.WriteToFlle();
            }
        }
        static void Option_2()
        {
            MenuUI.Header();
            if (SubjectCRUD.AvailableSubjects.Count == 0)
            {
                SubjectUI.DisplayMsg("....First Add Subjects in System....");
                SubjectUI.TakeString();
            }
            else
            {
                DegreeProgram temp = DegreeProgramUI.TakeInputOfDegreeProgram();
                DegreeProgramCRUD.AddDegreeInList(temp);
                DegreeProgramUI.AddSubjectInDegree();
                DegreeProgramCRUD.WriteToFlle();
            }
        }
        static void Option_3()
        {
            MenuUI.Header();
            if (StudentCRUD.Candidates.Count == 0)
            {
                MenuUI.DisplayMsg(".....No Record Found....");
                MenuUI.TakeString();
            }
            else
            {
                StudentCRUD.GiveAdmission();
                for (int i = 0; i < StudentCRUD.Candidates.Count; i++)
                {
                    if (StudentCRUD.Candidates[i].isRegistered())
                    {
                        StudentUI.GenerateMeritList(StudentCRUD.Candidates[i]);
                    }
                }
                StudentCRUD.WriteToFlle();
            }
            MenuUI.TakeString();
        }
        static void Option_4()
        {
            MenuUI.Header();
            if (StudentCRUD.Candidates.Count == 0)
            {
                MenuUI.DisplayMsg(".....No Record Found....");
            }
            else
                StudentUI.ViewRegisteredStudents();
            MenuUI.TakeString(); ;
        }
        static void Option_5()
        {
            MenuUI.Header();
            MenuUI.DisplayMsg("Enter Degree Name");
            string name = MenuUI.TakeString();
            if (!StudentUI.ViewStudentOfSpecificProgram(name))
                MenuUI.DisplayMsg(".....No Record FOund....");
        }
        static void Option_6()
        {
            MenuUI.Header();
            if (StudentCRUD.Candidates.Count == 0)
                MenuUI.DisplayMsg("......No Student Found.......");
            else if (SubjectCRUD.AvailableSubjects.Count == 0)
                MenuUI.DisplayMsg(".....No Subject is Available.....");
            else
            {
                int stu = StudentUI.WhichStudent();
                if (stu != -1)
                {
                    int index1 = StudentUI.WhichSubjetcRegister(StudentCRUD.Candidates[stu]);
                    if (StudentCRUD.Candidates[index1 - 1].RegisterSubject(SubjectCRUD.AvailableSubjects[index1 - 1]))
                    {
                        MenuUI.DisplayMsg("Subject Has been Registered...");
                        StudentCRUD.WriteToFlle();
                    }
                    else
                        MenuUI.DisplayMsg("You cannot register More Subjetcs...");
                }
                else
                    MenuUI.DisplayMsg("Student Is not registered");
            }
        }
        static void Option_7()
        {

            MenuUI.Header();
            StudentUI.ViewFeeHeader();
            for (int i = 0; i < StudentCRUD.Candidates.Count; i++)
            {
                StudentUI.ViewFee(StudentCRUD.getStudent(i).getName(), StudentCRUD.getStudent(i).CalculateDues());
            }
        }
        static void Option_8()
        {
            MenuUI.Header();
            SubjectCRUD.AddSubjectInList(SubjectUI.TakeInputOfSubject());
            SubjectCRUD.WriteToFlle();
        }

        static void Main(string[] args)
        {

            SubjectCRUD.ReadFromFile();
            DegreeProgramCRUD.ReadFromFile();
            StudentCRUD.ReadFromFile();
            string option;
            do
            {

                MenuUI.Header();
                option = MenuUI.MainMenu();
                switch (option)
                {
                    case "1":
                        Option_1();

                        break;
                    case "2":
                        Option_2();
                        break;
                    case "3":
                        Option_3();
                        break;
                    case "4":
                        Option_4();
                        break;
                    case "5":
                        Option_5();
                        break;
                    case "6":
                        Option_6();
                        break;
                    case "7":
                        Option_7();
                        break;
                    case "8":
                        Option_8();
                        break;


                }
                MenuUI.TakeString();

            } while (option != "9");
            Console.Read();
        }
    }
}
