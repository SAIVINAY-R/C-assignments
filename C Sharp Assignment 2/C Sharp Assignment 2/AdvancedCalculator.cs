using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_2
{
    internal class AdvancedCalculator : Calculator
    {
        public void Power(float @base, float exponent)
        {
            Result = Math.Pow(@base, exponent);
        }

        public override double GetResult()
        {
            return Result * Math.Pow(10, 6);
        }
    }
}
