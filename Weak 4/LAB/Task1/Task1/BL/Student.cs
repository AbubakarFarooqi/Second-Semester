using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.BL
{
    class Student
    {
        public Student()
        {

        }
        public Student(string name, int Emarks, int FSCmarks, int rollNumber, string Town, bool isHostelite)

        {
            this.name = name;
            this.Emarks = Emarks;
            this.FSCmarks = FSCmarks;
            this.rollNumber = rollNumber;
            this.Town = Town;
            this.isHostelite = isHostelite;
        }

        public string name;
        public int rollNumber;
        public float cGPA;
        public int Emarks;
        public int FSCmarks;
        public string Town;
        public bool isHostelite;
        public bool isTakingScholarship = false;

        public double CalculateMerit()
        {
            double merit = ((double)FSCmarks / 1100.0 * 60) + ((double)Emarks / 400.0 * 40);
            return merit;
        }

        public bool isEligibleForScholarship(double Percentage)
        {
            double merit = CalculateMerit();
            if (merit >= Percentage && isHostelite)
            {
                isTakingScholarship = true;

            }

            return isTakingScholarship;
        }
    }
}
