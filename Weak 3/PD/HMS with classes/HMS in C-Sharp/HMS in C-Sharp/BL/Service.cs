using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_in_C_Sharp.BL
{

    class Service
    {

        public Service(string name, int fee)
        {
            this.name = name;
            this.fee = fee;
        }
        public string name;
        public int fee;
        public void View()
        {
            Console.WriteLine(name + "\t" + fee);
        }
    }
}
