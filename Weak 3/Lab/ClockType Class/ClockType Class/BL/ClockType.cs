using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockType_Class.BL
{
    class ClockType
    {
        public ClockType()
        {
            hr = 0;
            sec = 0;
            min = 0;
        }
        public ClockType(int h, int m, int s)
        {
            hr = h;
            sec = s;
            min = m;
        }
        public int hr;
        public int sec;
        public int min;
        public void PrintTime()
        {
            Console.WriteLine("Hours / Minutes / Seconds = {0} / {1} / {2}", hr, min, sec);
        }
        public void IncrementInHours()
        {
            hr++;
        }
        public void IncrementInMinutes()
        {
            min++;
        }
        public void IncrementInSeconds()
        {
            sec++;
        }
        public bool isEqual(int h, int m, int s)
        {
            if (hr == h && min == m && sec == s)
                return true;
            return false;
        }
        public bool isEqual(ClockType Source)
        {
            if (hr == Source.hr && min == Source.min && sec == Source.sec)
                return true;
            return false;
        }

    }
}
