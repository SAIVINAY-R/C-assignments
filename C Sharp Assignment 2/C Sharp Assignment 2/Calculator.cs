using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_2
{
    internal class Calculator
    {
        private float result;
        public void Add(int number1, int number2)
        {
            result = number1 + number2; 
        }
        public void Add(float number1, float number2)
        {
            result = number1 + number2;
        }
        public void Add(int number1, int number2, int number3)
        {
            result = number1 + number2 + number3;
        }

        public float GetResult()
        {
            return result;
        }
    }
}
