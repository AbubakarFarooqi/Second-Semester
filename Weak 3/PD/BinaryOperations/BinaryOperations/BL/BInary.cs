using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryOperations.BL
{
    class BinaryA
    {
        public BinaryA(string number)
        {
            this.number = number;
        }
        public string number;
        public static string ConvertToBinary(int Source)
        {
            string output = null;
            if (Source == 0)
            {
                return "0000";
            }
            else
            {
                while (Source != 0)
                {
                    output = output + (Source % 2).ToString();
                    Source = Source / 2;
                }
                return (output);
            }
        }

        public string oneScomplement()
        {
            int place = 1;
            string output = null;
            while (place <= int.Parse(number))
            {
                int digit = (int.Parse(number) % (place * 10)) / place;
                if (digit == 0)
                {
                    output = output + "1";
                }
                else
                {
                    output = output + "0";
                }
                place *= 10;
            }
            return output;
        }

        public string Two_S_Complement()
        {
            string oneComplement = oneScomplement();
            int numberInBinary = int.Parse(oneComplement);
            string output = null;
            int remainder = 0;
            int quotient = 1;
            int place = 1;
            /*int digit = (numberInBinary % (place * 10)) / place;
            digit = digit + 1;
            if(digit == 2)
            {
                remainder = digit % 2;
                quotient = digit / 2;
                output = output + remainder.ToString();
            }
            else
            {
                output = output + digit.ToString();
            }
            place *= 10;*/
            int c = 1;
            while (c <= oneComplement.Length)
            {
                int digit = ((numberInBinary % (place * 10)) / place) + quotient;
                remainder = digit % 2;
                quotient = digit / 2;
                output = output + remainder.ToString();

                place *= 10;
                c++;

            }
            string temp = null;
            for (int i = output.Length - 1; i >= 0; i--)
            {
                temp = temp + output[i];
            }
            output = temp;
            return output;
        }


        public string Addition(string num)
        {
            if (num.Length != number.Length)
            {
                int differece = Math.Abs((num.Length - number.Length));
                string ExtraZero = null;
                for (int i = 1; i <= differece; i++)
                {
                    ExtraZero = "0" + ExtraZero;
                }
                ExtraZero = ExtraZero + num;
                num = ExtraZero;
            }
            string output = null;
            int remainder = 0;
            int quotient = 0;
            int place = 1;
            int c = 1;
            while (c <= number.Length)
            {
                int digit = ((int.Parse(number) % (place * 10)) / place) + ((int.Parse(num) % (place * 10)) / place) + quotient;
                remainder = digit % 2;
                quotient = digit / 2;
                output = output + remainder.ToString();
                place *= 10;
                c++;

            }
            string temp = null;
            for (int i = output.Length - 1; i >= 0; i--)
            {
                temp = temp + output[i];
            }
            output = temp;
            return output;
        }


    }
}
