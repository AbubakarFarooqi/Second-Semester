using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAdmissionManagementSystem.BL;
namespace UniversityAdmissionManagementSystem
{
    class Program
    {
        static char MainMenu()
        {
            Console.WriteLine("Press 1. To Login as Admin");
            Console.WriteLine("Press 2. To Login in as Student");
            Console.WriteLine("Press 3. To Apply For Admission");
            Console.WriteLine("Press 4. To Exit");
            char option;
            char.TryParse(Console.ReadLine(), out option);
            return option;
        }
        static char AdminMenu()
        {
            Console.WriteLine("press 1. To add Degree Program");
            Console.WriteLine("press 2. To generate MErit List");
            Console.WriteLine("press 3. To Add Subject in University");
            Console.WriteLine("press 4. To Add Subject in Degree Program");
            char option;
            char.TryParse(Console.ReadLine(), out option);
            return option;
        }
        static char StudentMenu()
        {
            Console.WriteLine("Press 1. To Register Student");
            char option;
            char.TryParse(Console.ReadLine(), out option);
            return option;
        }
        static DegreeProgram TakeInputOfDegreeProgram()
        {
            string title;
            string Duration;
            int seats;
            float merit;
            Console.WriteLine("Enter Title of Degree ");
            title = Console.ReadLine();
            Console.WriteLine("Enter Duration of Degree Program = ");
            Duration = Console.ReadLine();
            Console.WriteLine("Enter Seats in Program ");
            seats = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter Merit of Progam ");
            merit = float.Parse(Console.ReadLine());
            DegreeProgram temp = new DegreeProgram(title, Duration, seats, merit);
            return temp;

        }
        static Student TakeInputOfStudent()
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
        static List<DegreeProgram> InputOfPreferences(AcedemicBranch acedBranch)
        {
            List<DegreeProgram> Preferences = new List<DegreeProgram>();
            char terminate = '1';
            while (terminate != '0')
            {
                Console.Clear();
                Console.WriteLine("Press 0. To Exit");
                Console.WriteLine("Choose Preferences.....");
                Console.WriteLine();
                Console.WriteLine();
                acedBranch.ViewAllPrograms();
                char.TryParse(Console.ReadLine(), out terminate);
                if (terminate != '0')
                    Preferences.Add(acedBranch.returnDegreeProgram(int.Parse(terminate.ToString())));
            }
            return Preferences;
        }
        static Subject TakeInputOfSubject()
        {
            string code;
            string SubjectType;
            int CH;
            Console.WriteLine("Enter code of Course ");
            code = Console.ReadLine();
            Console.WriteLine("ENter SubjetcType ");
            SubjectType = Console.ReadLine();
            Console.WriteLine("ENter Number of Credit Hours ");
            CH = int.Parse(Console.ReadLine());
            Subject temp = new Subject(code, CH, SubjectType);
            return temp;
        }
        static int AddSubjectInWhichDegree()
        {
            char option;
            Console.WriteLine("Select Subject....");
            char.TryParse(Console.ReadLine(), out option);
            return int.Parse(option.ToString());

        }
        static int WhichSubjetcRegister(RegisteredStudent Source)
        {
            for (int i = 0; i < Source.getDegreeSubjectCount(); i++)
            {
                Console.Write(i + 1 + " . ");
                Source.ViewSubjectOfDegree(i);
            }
            Console.WriteLine("Choose Option...");
            int option;
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static void Main(string[] args)
        {
            AdmissionBranch AdminBranch = new AdmissionBranch();
            AcedemicBranch AcedBrach = new AcedemicBranch();
            char option;
            do
            {
                Console.Clear();

                option = MainMenu();
                switch (option)
                {
                    case '1':
                        char AdminOption;
                        AdminOption = AdminMenu();
                        if (AdminOption == '1')
                        {
                            AcedBrach.AddDegreeProgram(TakeInputOfDegreeProgram());
                        }

                        else if (AdminOption == '2')
                        {
                            AdminBranch.GenerateMeritList();
                            Console.ReadLine();

                        }
                        else if (AdminOption == '3')
                        {
                            AcedBrach.AddSubject(TakeInputOfSubject());
                        }
                        else if (AdminOption == '4')
                        {
                            int op;
                            AcedBrach.ViewAllPrograms();
                            Console.Write("Which Degree....");
                            op = int.Parse(Console.ReadLine());
                            Console.Clear();
                            for (int i = 0; i < AcedBrach.getSubjectsCount(); i++)
                            {
                                AcedBrach.ViewSubject(i);
                            }
                            int index = AddSubjectInWhichDegree();

                            if (!AcedBrach.isLimitOfSubjectsApproach(op, AcedBrach.getSubjectCH(index)))
                                AcedBrach.AddSubjectInDegree(AcedBrach.getSubject(index), op);
                            /* AddSubjectInDegree(AcedBrach, op);*///Ch inacedemic branch
                            else
                                Console.WriteLine("You Cannot Add More Subjects...");
                            Console.ReadLine();
                        }

                        break;
                    case '2':
                        char StudentOption = StudentMenu();
                        if (StudentOption == '1')
                        {
                            int index = WhichSubjetcRegister(AdminBranch.getStudent(1));
                            if (AdminBranch.RegisteredStudentSubjectInStudent(index, AcedBrach.getSubject(index)))
                                Console.WriteLine("Subject Has been Registered...");
                            else
                                Console.WriteLine("You cannot register More Subjetcs...");

                        }
                        break;
                    case '3':
                        AdminBranch.AddApplicant(TakeInputOfStudent(), InputOfPreferences(AcedBrach));

                        break;
                }

            } while (option != '4');
            Console.Read();
        }
    }
}
