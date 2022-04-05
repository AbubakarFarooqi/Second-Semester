using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void input(ref int age , ref int WM , ref int PriceOfToy)
        {
            Console.WriteLine("ENter Lilly Age ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter price of washing machine ");
            WM = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter price of toy ");
            PriceOfToy = int.Parse(Console.ReadLine());
        }
        static int MoneyOfBirthdays(int age , int price)
        {
           // int birthdayCounter = 1;
            int money = 0;
            int toyCounter = 0;
            int evenBirthdayIncrement = 10;
            for(int i = 1; i<= age; i++)
            {
                if (i % 2 == 0)
                {
                    money = money + evenBirthdayIncrement;
                    evenBirthdayIncrement += 10;
                    money -= 1;
                }
                else
                    toyCounter++;
            }
            int toyPrice = toyCounter * price;
            money += toyPrice;
            return money;
        }
        static void Main(string[] args)
        {
            int age = 0;
            int PriceOFToy = 0;
            int PriceOFWashingMachine = 0;
            input(ref age, ref PriceOFWashingMachine, ref PriceOFToy);
           int Money =  MoneyOfBirthdays(age, PriceOFToy);
            Console.WriteLine("You HAve Saved {0} USD", Money);
            if (Money >= PriceOFWashingMachine) 
            Console.WriteLine("You can Buy Washing MAchine");
            else
                Console.WriteLine("You cannot buy Washing MAchine");

            Console.Read();
        }
    }
}
