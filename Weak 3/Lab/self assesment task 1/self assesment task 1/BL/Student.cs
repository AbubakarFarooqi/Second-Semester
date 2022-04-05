using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assesment_task_1.BL
{
    class Student
    {
        public Student(string n, int m)
        {
            name = n;
            marks = m;

        }
        public Student(Student Source)
        {
            name = Source.name;
            marks = Source.marks;
        }
        public string name;
        public int marks;
        public void ShowData()
        {
            Console.WriteLine("Name = {0}\nMArks = {1}", name, marks);
        }

    }
}
