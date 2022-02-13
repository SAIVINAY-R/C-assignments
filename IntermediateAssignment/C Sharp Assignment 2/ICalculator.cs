using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_2
{
    internal interface ICalculator
    {
        void Add(int number1, int number2); 
        void Add(int number1, int number2, int number3);
        void Add(float number1, float number2);
        void Power(float baseValue, float power);
        double GetResult();
    }
}
