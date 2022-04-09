using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.BL
{
    class Book
    {
        public Book(string author, int Pages, int BookMark, int price)
        {
            this.author = author;
            this.pages = Pages;
            this.BookMark = BookMark;
            this.price = price;




        }

        public string author;
        public int pages;
        public List<string> Chapters = new List<string>();
        public int BookMark;
        public int price;



        public string getChapter(int chapterNum)
        {
            return Chapters[chapterNum - 1];
        }

        public int getBookMark()
        {
            return BookMark;
        }

        public void setBookMark(int pageNumber)
        {
            BookMark = pageNumber;
        }

        public int getBookPrice()
        {
            return price;
        }

        public void setBookPrice(int price)
        {
            this.price = price;
        }

        public void AddChapter(string source)
        {
            Chapters.Add(source);
        }
    }
}
