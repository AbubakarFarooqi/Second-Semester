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
        static void Header()
        {
            Console.Clear();
            Console.WriteLine("*************************************************************");
            Console.WriteLine("         University Admission Management System             *");
            Console.WriteLine("*************************************************************");
        }
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
            DegreeProgram temp = new DegreeProgram(title, Duration, seats);
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
        static List<DegreeProgram> InputOfPreferences() //AcedemicBranch acedBranch)
        {
            List<DegreeProgram> Preferences = new List<DegreeProgram>();
            string terminate = "1";
            while (terminate != "E")
            {
                Console.Clear();
                Console.WriteLine("Press E. To Exit");
                Console.WriteLine("Choose Preferences.....");
                Console.WriteLine();
                Console.WriteLine();
                ViewAllPrograms();
                terminate = Console.ReadLine();
                if (terminate != "E")
                {
                    if (Student.Candidates[Student.Candidates.Count - 1].isRedundancyInPreference(DegreeProgram.OfferedPrograms[int.Parse(terminate) - 1])) ;
                    Preferences.Add(DegreeProgram.OfferedPrograms[int.Parse(terminate) - 1]);
                }
                else
                    Console.WriteLine(".....Redundancy Occurs......");

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
        static int WhichStudent()
        {
            string name;
            Console.WriteLine("ENter Your NAme...");
            name = Console.ReadLine();
            for (int i = 0; i < Student.Candidates.Count; i++)
            {
                if (Student.Candidates[i].getName() == name && Student.Candidates[i].isRegistered())
                    return i;
            }
            return -1;
        }

        static void GenerateMeritList()
        {
            List<Student> orderedList = new List<Student>();
            orderedList = Student.Candidates.OrderByDescending(o => o.CalculateMerit()).ToList();
            for (int i = 0; i < orderedList.Count; i++)
            {
                DegreeProgram temp;
                if ((temp = isStudentApplicable(orderedList[i])) != null)
                {
                    Console.WriteLine(orderedList[i].getName() + " is Applicable for " + temp.getTitle());
                    Student.Candidates[i].AssignDegree(temp);
                    /*listRegisteredStudents.Add(Source);*/
                }
            }
        }
        static DegreeProgram isStudentApplicable(Student Source)
        {
            for (int i = 0; i < Source.TotalPreferences(); i++)
            {

                DegreeProgram PrefOfStudent = Source.getSpecificPreference(i);
                if (PrefOfStudent.getSeats() != 0)
                {
                    PrefOfStudent.DecrementInSeats();
                    return PrefOfStudent;
                }

            }
            return null;
        }
        static void ViewAllPrograms()
        {
            Console.WriteLine("   Name\tDuration");
            for (int i = 0; i < DegreeProgram.OfferedPrograms.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                Console.WriteLine(DegreeProgram.OfferedPrograms[i].getTitle() + "\t" + DegreeProgram.OfferedPrograms[i].getDuration());
            }
        }
        static void ViewSubject(int index)
        {
            Console.WriteLine(Subject.OfferedSubjects[index].getCode() + "\t" + Subject.OfferedSubjects[index].getCH());
        }


        static void ViewRegisteredStudents()
        {
            Console.WriteLine("Name\tFsc Marks\tEcat Marks\tDegree Program");
            for (int i = 0; i < Student.Candidates.Count; i++)
            {
                if (Student.Candidates[i].isRegistered())
                {
                    Console.WriteLine(Student.Candidates[i].getName() + "\t" + Student.Candidates[i].getFsc() + "\t" + Student.Candidates[i].getEcat() + "\t" + Student.Candidates[i].getDegreeName());
                }
            }
        }
        static bool ViewStudentOfSpecificProgram(string DegreeName)
        {
            bool flag = false;
            Console.WriteLine("Name\tFsc Marks\tEcat Marks\tDegree Program");
            for (int i = 0; i < Student.Candidates.Count; i++)
            {
                if (Student.Candidates[i].isRegistered())
                {
                    flag = true;
                    if (Student.Candidates[i].getDegreeName() == DegreeName)
                        Console.WriteLine(Student.Candidates[i].getName() + "\t" + Student.Candidates[i].getFsc() + "\t" + Student.Candidates[i].getEcat() + "\t" + Student.Candidates[i].getDegreeName());
                }
            }
            return flag;

        }
        static void CalculateFeeOfAllStudents()
        {
            foreach (Student S in Student.Candidates)
            {
                S.CalculateDues();
            }
        }
        static void Main(string[] args)
        {



            string option;
            do
            {
                Header();
                option = MainMenu();
                switch (option)
                {
                    case "2":
                        Header();
                        if (Subject.OfferedSubjects.Count == 0)
                        {
                            Console.WriteLine("....First Add Subjects in System....");
                            Console.ReadLine();
                        }
                        else
                        {

                            DegreeProgram.AddDegreeInList(TakeInputOfDegreeProgram());
                            int op = DegreeProgram.OfferedPrograms.Count - 1;// op stores index of program
                            char TerminationOption = ' ';
                            while (TerminationOption != 'E' && TerminationOption != 'e')
                            {
                                Header();
                                Console.WriteLine(".....Select Subject.....");

                                for (int i = 0; i < Subject.OfferedSubjects.Count; i++)
                                {

                                    ViewSubject(i);
                                }
                                int index = AddSubjectInWhichDegree();
                                if (!DegreeProgram.OfferedPrograms[op].isRedundancyInSubjects(Subject.OfferedSubjects[index - 1]))
                                {
                                    if (!DegreeProgram.OfferedPrograms[op].isLimitOfSubjectsApproach(Subject.OfferedSubjects[index - 1].getCH()))
                                        DegreeProgram.OfferedPrograms[op].AddSubject(Subject.OfferedSubjects[index - 1]);
                                    /* AddSubjectInDegree(AcedBrach, op);*///Ch inacedemic branch
                                    else
                                        Console.WriteLine("You Cannot Add More Subjects...");
                                }
                                else
                                    Console.WriteLine("......Subject Redundancy....");
                                Console.WriteLine("To Exit Press E....");
                                char.TryParse(Console.ReadLine(), out TerminationOption);
                            }
                        }


                        break;

                    case "3":
                        Header();
                        if (Student.Candidates.Count == 0)
                        {
                            Console.WriteLine(".....No Record Found....");
                            Console.ReadLine();
                        }
                        GenerateMeritList();
                        Console.ReadLine();
                        break;
                    case "4":
                        Header();
                        if (Student.Candidates.Count == 0)
                        {
                            Console.WriteLine(".....No Record Found....");
                        }
                        else
                            ViewRegisteredStudents();
                        Console.ReadLine();
                        break;
                    case "5":
                        Header();
                        Console.WriteLine("Enter Degree Name");
                        string name = Console.ReadLine();
                        if (!ViewStudentOfSpecificProgram(name)) ;
                        Console.WriteLine(".....No Record FOund....");
                        break;
                    case "7":
                        Header();
                        CalculateFeeOfAllStudents();
                        break;
                    case "8":
                        Header();
                        Subject.AddSubjectInList(TakeInputOfSubject());
                        break;
                    case "6":
                        Header();
                        if (Student.Candidates.Count == 0)
                            Console.WriteLine("......No Student Found.......");

                        Console.WriteLine(".....No Subject is Available.....");
                        int stu = WhichStudent();
                        if (stu != -1)
                        {
                            int index1 = WhichSubjetcRegister(Student.Candidates[stu]);
                            if (Student.Candidates[index1 - 1].RegisterSubject(Subject.OfferedSubjects[index1 - 1]))
                                Console.WriteLine("Subject Has been Registered...");
                            else
                                Console.WriteLine("You cannot register More Subjetcs...");
                        }
                        else
                            Console.WriteLine("Student Is not registered");
                        break;
                    case "1":
                        Header();
                        if (DegreeProgram.OfferedPrograms.Count == 0)
                        {
                            Console.WriteLine(".....First Add a Degree in System.....");
                        }
                        else
                        {
                            //AdminAddApplicant(TakeInputOfStudent(), InputOfPreferences(OfferedPrograms));
                            Student.AddStudentInList(TakeInputOfStudent());
                            Student.Candidates[Student.Candidates.Count - 1].AssignPreferences(InputOfPreferences());
                        }
                        Console.ReadLine();
                        break;
                }

            } while (option != "10");
            Console.Read();
        }
    }
}
