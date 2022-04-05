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
        public ClockType(int h)
        {
            hr = h;

        }
        public ClockType(int h, int m)
        {
            hr = h;
            min = m;
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
        public int ElapsedTime()
        {
            int TotalSeconds = 0;
            TotalSeconds = (hr * 60 * 60) + (min * 60) + sec;
            return TotalSeconds;
        }
        public int RemaingingTime()
        {
            return (24 * 60 * 60) - ElapsedTime();
        }
        public void setHours(int h)
        {
            hr = h;
        }
        public void setMinutes(int m)
        {
            min = m;

        }
        public void setSeconds(int s)
        {
            sec = s;
        }
        public void TimeDifference(ClockType Compaere)
        {

            int Diiference_in_seconds = Math.Abs(ElapsedTime() - Compaere.ElapsedTime());
            if (Diiference_in_seconds < 60)
            {
                Console.WriteLine("Hours / Minutes / Seconds = {0} / {1} / {2}", 0, 0, Diiference_in_seconds);
            }
            else
            {
                int tempSec = Diiference_in_seconds % 60;
                int tempMin = (Diiference_in_seconds - (Diiference_in_seconds % 60)) / 60;
                if (tempMin >= 60)
                {

                    int tempHour = (tempMin - (tempMin % 60)) / 60;
                    tempMin = tempMin % 60;
                    Console.WriteLine("Hours / Minutes / Seconds = {0} / {1} / {2}", tempHour, tempMin, tempSec);

                }
                else
                {
                    Console.WriteLine("Hours / Minutes / Seconds = {0} / {1} / {2}", 0, tempMin, tempSec);

                }
            }

        }

    }
}
