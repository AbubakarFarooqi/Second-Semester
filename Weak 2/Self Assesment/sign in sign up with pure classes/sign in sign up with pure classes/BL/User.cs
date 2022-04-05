using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sign_in_sign_up_with_pure_classes.BL
{
    class User
    {
        private string Name;
        private string Password;
        public void GetData()
        {
            Console.WriteLine("ENter NAme of CUstomer : ");
            Name = Console.ReadLine();
            Console.WriteLine("ENter PAssword of CUstomer : ");
            Password = Console.ReadLine();
        }
        public void ShowData()
        {
            Console.WriteLine("NAme  = {0}\nPassword = {1}", Name, Password);
        }
        public void ReadFromFile(ref StreamReader file, string Path)

        {
            if (File.Exists(Path))
            {

                string Source;
                if ((Source = file.ReadLine()) != null)
                {
                    Name = extractionOfField(Source, 1);
                    Password = extractionOfField(Source, 2);
                }

            }

        }
        private string extractionOfField(string source, int field)
        {
            int comma = 1;
            string output = "";
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == ',')
                {
                    comma++;
                    i++;
                }
                if (comma == field)
                {
                    output = output + source[i];
                }

            }

            return output;
        }

    }
}
