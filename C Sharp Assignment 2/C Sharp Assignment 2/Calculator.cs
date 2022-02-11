using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_2
{
    internal class Calculator
    {
        public double Result { get; set; }
        public void Add(int number1, int number2)
        {
            Result = number1 + number2; 
        }
        public void Add(float number1, float number2)
        {
            Result = number1 + number2;
        }
        public void Add(int number1, int number2, int number3)
        {
            Result = number1 + number2 + number3;
        }

        public virtual double GetResult()
        {
            return Result;
        }
    }
}
