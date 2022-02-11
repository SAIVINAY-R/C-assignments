using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_1
{
    internal class SumOfNumbers
    {
        public void Sum()
        {
            var sum = 0;

            while (true)
            {
                Console.Write("Enter a Number or \"ok\" to exit : ");
                var number = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(number) || number.Trim() == "ok")
                    break;
                else
                {
                    sum += int.Parse(number);
                }

            }

            Console.WriteLine("The sum of numbers is : " + sum);
        }
    }
}
