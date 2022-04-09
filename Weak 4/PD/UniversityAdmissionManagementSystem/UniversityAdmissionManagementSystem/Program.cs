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
        static string MainMenu()
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Program");
            Console.WriteLine("6. Register Subjects for a Specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Add Subject in System");
            Console.WriteLine("9. Exit");
            Console.Write("Enter Option: ");
            string option;
            option = Console.ReadLine();
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
        static List<DegreeProgram> InputOfPreferences(List<DegreeProgram> OfferedPrograms) //AcedemicBranch acedBranch)
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
                ViewAllPrograms(OfferedPrograms);
                char.TryParse(Console.ReadLine(), out terminate);
                if (terminate != '0')
                    Preferences.Add(OfferedPrograms[int.Parse(terminate.ToString()) - 1]);
                ;
            }
            return Preferences;
        }
        static Subject TakeInputOfSubject()
        {
            string code;
            string SubjectType;
            int CH;
            int fee;
            Console.WriteLine("Enter code of Course ");
            code = Console.ReadLine();
            Console.WriteLine("ENter SubjetcType ");
            SubjectType = Console.ReadLine();
            Console.WriteLine("ENter Number of Credit Hours ");
            CH = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter Fee..");
            fee = int.Parse(Console.ReadLine());
            Subject temp = new Subject(code, CH, SubjectType, fee);
            return temp;
        }
        static int AddSubjectInWhichDegree()
        {
            char option;
            Console.WriteLine("Select Subject....");
            char.TryParse(Console.ReadLine(), out option);
            return int.Parse(option.ToString());

        }
        static int WhichSubjetcRegister(Student Source)
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
        static int WhichStudent(List<Student> Applicants)
        {
            string name;
            Console.WriteLine("ENter Your NAme...");
            name = Console.ReadLine();
            for (int i = 0; i < Applicants.Count; i++)
            {
                if (Applicants[i].getName() == name && Applicants[i].isRegistered())
                    return i;
            }
            return -1;
        }

        static void GenerateMeritList(List<Student> Applicants)
        {
            for (int i = 0; i < Applicants.Count; i++)
            {
                DegreeProgram temp;
                if ((temp = isStudentApplicable(Applicants[i])) != null)
                {
                    Console.WriteLine(Applicants[i].getName() + " is Applicable for " + temp.getTitle());
                    Applicants[i].AssignDegree(temp);
                    /*listRegisteredStudents.Add(Source);*/
                }
            }
        }
        static DegreeProgram isStudentApplicable(Student Source)
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
        static void ViewAllPrograms(List<DegreeProgram> OfferedPrograms)
        {
            Console.WriteLine("   Name\tDuration");
            for (int i = 0; i < OfferedPrograms.Count; i++)
            {
                Console.WriteLine(OfferedPrograms[i].getTitle() + "\t" + OfferedPrograms[i].getDuration());
            }
        }
        static void ViewSubject(List<Subject> OfferedSubjects, int index)
        {
            Console.WriteLine(OfferedSubjects[index].getCode() + "\t" + OfferedSubjects[index].getCH());
        }
        static bool isLimitOfSubjectsApproach(List<DegreeProgram> OfferedPrograms, int index, int CH)
        {
            if ((OfferedPrograms[index - 1].getCH() + CH) > 20)
                return true;
            return false;
        }

        static void ViewRegisteredStudents(List<Student> ListOfStudents)
        {
            Console.WriteLine("Name\tFsc Marks\tEcat Marks\tDegree Program");
            for (int i = 0; i < ListOfStudents.Count; i++)
            {
                if (ListOfStudents[i].isRegistered())
                {
                    Console.WriteLine(ListOfStudents[i].getName() + "\t" + ListOfStudents[i].getFsc() + "\t" + ListOfStudents[i].getEcat() + "\t" + ListOfStudents[i].getDegreeName());
                }
            }
        }
        static void ViewStudentOfSpecificProgram(string DegreeName, List<Student> ListOfStudents)
        {

            Console.WriteLine("Name\tFsc Marks\tEcat Marks\tDegree Program");
            for (int i = 0; i < ListOfStudents.Count; i++)
            {
                if (ListOfStudents[i].isRegistered())
                {
                    if (ListOfStudents[i].getDegreeName() == DegreeName)
                        Console.WriteLine(ListOfStudents[i].getName() + "\t" + ListOfStudents[i].getFsc() + "\t" + ListOfStudents[i].getEcat() + "\t" + ListOfStudents[i].getDegreeName());
                }
            }

        }
        static void CalculateFeeOfAllStudents(List<Student> ListOfStudents)
        {
            foreach (Student S in ListOfStudents)
            {
                S.CalculateDues();
            }
        }
        static void Main(string[] args)
        {
            List<Student> Applicants = new List<Student>();
            List<DegreeProgram> OfferedPrograms = new List<DegreeProgram>();
            List<Subject> OfferedSubjects = new List<Subject>();

            string option;
            do
            {
                Console.Clear();

                option = MainMenu();
                switch (option)
                {
                    case "2":

                        OfferedPrograms.Add(TakeInputOfDegreeProgram());
                        int op = OfferedPrograms.Count - 1;// op stores index of program
                        for (int i = 0; i < OfferedSubjects.Count; i++)
                        {
                            ViewSubject(OfferedSubjects, i);
                        }
                        int index = AddSubjectInWhichDegree();
                        if (!isLimitOfSubjectsApproach(OfferedPrograms, op + 1, OfferedSubjects[index - 1].getCH()))
                            OfferedPrograms[op].AddSubject(OfferedSubjects[index - 1]);
                        /* AddSubjectInDegree(AcedBrach, op);*///Ch inacedemic branch
                        else
                            Console.WriteLine("You Cannot Add More Subjects...");
                        Console.ReadLine();
                        break;

                    case "3":
                        GenerateMeritList(Applicants);
                        Console.ReadLine();
                        break;
                    case "4":
                        ViewRegisteredStudents(Applicants);
                        break;
                    case "5":
                        Console.WriteLine("Enter Degree Name");
                        string name = Console.ReadLine();
                        ViewStudentOfSpecificProgram(name, Applicants);
                        break;
                    case "7":
                        CalculateFeeOfAllStudents(Applicants);
                        break;
                    case "8":
                        OfferedSubjects.Add(TakeInputOfSubject());
                        break;
                    case "6":

                        int stu;
                        if ((stu = WhichStudent(Applicants)) != -1)
                        {
                            int index1 = WhichSubjetcRegister(Applicants[stu]);
                            if (Applicants[index1 - 1].RegisterSubject(OfferedSubjects[index1 - 1]))
                                Console.WriteLine("Subject Has been Registered...");
                            else
                                Console.WriteLine("You cannot register More Subjetcs...");
                        }
                        else
                            Console.WriteLine("Student Is not registered");
                        break;
                    case "1":
                        //AdminAddApplicant(TakeInputOfStudent(), InputOfPreferences(OfferedPrograms));
                        Applicants.Add(TakeInputOfStudent());
                        Applicants[Applicants.Count - 1].AssignPreferences(InputOfPreferences(OfferedPrograms));

                        break;
                }

            } while (option != "10");
            Console.Read();
        }
    }
}
