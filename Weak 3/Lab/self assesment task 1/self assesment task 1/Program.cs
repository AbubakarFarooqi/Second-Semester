using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using self_assesment_task_1.BL;

namespace self_assesment_task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student S1 = new Student("azan", 1200);
            Student S2 = new Student(S1);
            S1.ShowData();
            S2.ShowData();
            S2.name = "ali";
            S2.ShowData();
            S1.ShowData();
            Console.Read();

        }
    }
}
