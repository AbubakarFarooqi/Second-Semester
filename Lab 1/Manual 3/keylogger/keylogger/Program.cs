using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace keylogger
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter file = new StreamWriter("key.txt");
            file.WriteLine(window);
        }
    }
}
