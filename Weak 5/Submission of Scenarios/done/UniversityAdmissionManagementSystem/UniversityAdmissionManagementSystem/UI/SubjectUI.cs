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
    class SubjectUI
    {
        public static void DisplayMsg(string Msg)
        {
            Console.WriteLine(Msg);
        }
        public static string TakeString()
        {
            return Console.ReadLine();
        }

        public static Subject TakeInputOfSubject()
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
        public static void ViewSubject(int index)
        {
            int Y = Console.CursorTop;
            Console.SetCursorPosition(0, Y);
            Console.Write("{0}. " + SubjectCRUD.AvailableSubjects[index].getCode(), index + 1);
            Console.SetCursorPosition(30, Y);
            Console.WriteLine(SubjectCRUD.AvailableSubjects[index].getCH().ToString());
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
