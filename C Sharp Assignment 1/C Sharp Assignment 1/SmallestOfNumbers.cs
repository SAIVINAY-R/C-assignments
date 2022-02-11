using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_1
{
    internal class SmallestOfNumbers
    {
        public void FindThreeSmallNumbers()
        {
            while (true)
            {
                Console.WriteLine("Enter a series of numbers seperated by comma(e.g \"5,3,8,1,4\") : ");
                var numbers = Console.ReadLine().Split(',');
                if (numbers.Length < 5)
                {
                    Console.WriteLine("Invalid List");
                    continue;
                }
                else
                {
                    var NumbersArray = Array.ConvertAll(numbers, s => int.Parse(s));
                    Array.Sort(NumbersArray);
                    Console.WriteLine("3 smallest numbers in the list are : ");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine(NumbersArray[i]);
                    }
                    break;
                }
            }

        }
    }
}
