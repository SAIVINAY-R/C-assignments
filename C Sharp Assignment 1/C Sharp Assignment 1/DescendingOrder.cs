using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_1
{
    internal class DescendingOrder
    {
        public void FindDescendingOrder()
        {
            Console.WriteLine("Enter a series of numbers seperated by comma(e.g \"5,3,8,1,4\") : ");
            var numbers = Console.ReadLine().Split(',');
            var NumbersArray = Array.ConvertAll(numbers, s => int.Parse(s));
            Array.Sort(NumbersArray);
            Array.Reverse(NumbersArray);
            Console.WriteLine("The Descending order");
            for (int i = 0; i < NumbersArray.Length; i++)
                Console.WriteLine(NumbersArray[i]);
        }
    }
}
