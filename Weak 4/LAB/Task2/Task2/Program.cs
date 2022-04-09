using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.BL;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b = new Book("Thomas", 100, 5, 150);
            Console.WriteLine("How many CHapters you HAve ");
            int chapters;
            chapters = int.Parse(Console.ReadLine());
            for (int i = 0; i < chapters; i++)
            {
                Console.WriteLine("CHapter Name : ");
                string Chapter;
                Chapter = Console.ReadLine();
                b.AddChapter(Chapter);

            }
            Console.WriteLine(b.getChapter(2));
            Console.WriteLine(b.getBookMark());
            b.setBookMark(5);
            Console.WriteLine(b.getBookMark());
            Console.WriteLine(b.getBookPrice());
            b.setBookPrice(100);
            Console.WriteLine(b.getBookPrice());

            Console.ReadLine();

        }
    }
}
