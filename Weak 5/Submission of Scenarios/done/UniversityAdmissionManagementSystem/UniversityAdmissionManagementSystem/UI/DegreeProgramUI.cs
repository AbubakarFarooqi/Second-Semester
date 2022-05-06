using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAdmissionManagementSystem.BL;
using UniversityAdmissionManagementSystem.DL;
using UniversityAdmissionManagementSystem.UI;
using System.IO;
namespace UniversityAdmissionManagementSystem.UI
{
    class DegreeProgramUI
    {
        public static int AddSubjectInWhichDegree()
        {
            char option;
            Console.WriteLine("Select Subject....");
            char.TryParse(Console.ReadLine(), out option);
            return int.Parse(option.ToString());

        }
        public static void ViewAllPrograms()
        {
            int Y = Console.CursorTop;
            Console.SetCursorPosition(5, Y);
            Console.Write("Name");
            Console.SetCursorPosition(30, Y);
            Console.WriteLine("Duration");
            for (int i = 0; i < DegreeProgramCRUD.OfferedPrograms.Count; i++)
            {
                Y = Console.CursorTop;
                Console.SetCursorPosition(5, Y);
                Console.Write(i + 1 + ". ");
                Console.Write(DegreeProgramCRUD.OfferedPrograms[i].getTitle());
                Console.SetCursorPosition(30, Y);
                Console.WriteLine(DegreeProgramCRUD.OfferedPrograms[i].getDuration());
            }
        }


        public static DegreeProgram TakeInputOfDegreeProgram()
        {
            string title;
            string Duration;
            int seats;
            Console.WriteLine("Enter Title of Degree ");
            title = Console.ReadLine();
            Console.WriteLine("Enter Duration of Degree Program = ");
            Duration = Console.ReadLine();
            Console.WriteLine("Enter Seats in Program ");
            seats = int.Parse(Console.ReadLine());
            DegreeProgram temp = new DegreeProgram(title, Duration, seats);
            return temp;

        }

        public static void AddSubjectInDegree()
        {
            int op = DegreeProgramCRUD.OfferedPrograms.Count - 1;// op stores index of DegreeProgram
            char TerminationOption = ' ';
            while (TerminationOption != 'E' && TerminationOption != 'e')
            {
                MenuUI.Header();
                Console.WriteLine(".....Select Subject.....");
                SubjectUI.SubjectHeader();
                for (int i = 0; i < SubjectCRUD.AvailableSubjects.Count; i++)
                {

                    SubjectUI.ViewSubject(i);
                }
                int index = DegreeProgramUI.AddSubjectInWhichDegree();
                if (!DegreeProgramCRUD.OfferedPrograms[op].isRedundancyInSubjects(SubjectCRUD.AvailableSubjects[index - 1]))
                {
                    if (!DegreeProgramCRUD.OfferedPrograms[op].isLimitOfSubjectsApproach(SubjectCRUD.AvailableSubjects[index - 1].getCH()))
                        DegreeProgramCRUD.OfferedPrograms[op].AddSubject(SubjectCRUD.AvailableSubjects[index - 1]);
                    /* AddSubjectInDegree(AcedBrach, op);*///Ch inacedemic branch
                    else
                        Console.WriteLine("You Cannot Add More Subjects...");
                }
                else
                    Console.WriteLine("......Subject Redundancy....");
                Console.WriteLine("To Exit Press E....");
                char.TryParse(MenuUI.TakeString(), out TerminationOption);
            }
        }

    }
}
