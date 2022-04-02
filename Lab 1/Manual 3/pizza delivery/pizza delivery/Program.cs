using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace pizza_delivery
{
    class Program
    {
        static void ReadFile()
        {
            string path = "G:\\BSCS\\2nd Semester\\OOP\\Weak 1\\Lab 1\\Manual 3\\pizza delivery\\cust.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line = "";
                while((line = file.ReadLine()) != null)
                {
                    string output = "";

                    for(int i = 0; i< line.Length; i++)
                    {

                        if(line[i] == 32)
                        {
                            int j = i;
                        }
                            
                    }
                }
            }
            else
                Console.WriteLine("File Opening Error");
        }
        static void Main(string[] args)
        {
        }
    }
}
