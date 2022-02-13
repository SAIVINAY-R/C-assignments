using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_1
{
    internal class MaximumOfNumbers
    {
        public void FindMaximum()
        {
            Console.WriteLine("Enter a series of numbers seperated by comma(e.g \"5,3,8,1,4\") : ");
            var numbers = Console.ReadLine().Split(',');

            var maximum = int.Parse(numbers[0]);
            foreach (var number in numbers)
                if (maximum < int.Parse(number))
                    maximum = int.Parse(number);
            Console.WriteLine("Maximum of the numbers is " + maximum);
        }
    }
}
