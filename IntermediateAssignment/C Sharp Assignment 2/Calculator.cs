using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_2
{
    internal class Calculator : ICalculator
    {
        private double Result { get; set; }
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

        protected void setResult(double result)
        {
            Result = result;
        }

        public void Power(float baseValue, float power)
        {
        }
    }
}
// add a set method to set result
