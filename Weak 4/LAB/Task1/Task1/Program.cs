using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.BL;
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student a = new Student("azan", 278, 996, 577508, "Tajpura", false);
            Console.WriteLine("Merit = " + a.CalculateMerit());
            if (a.isEligibleForScholarship(70))
            {
                Console.WriteLine("yes Avail");
            }
            else
            {
                Console.WriteLine("NO Avail");

            }
            Console.ReadLine();
        }
    }
}
