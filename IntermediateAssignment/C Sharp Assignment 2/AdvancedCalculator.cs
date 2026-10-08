using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_2
{
    internal class AdvancedCalculator : Calculator, ICalculator
    {
        public void Power(float baseValue, float exponent)
        {
            setResult(Math.Pow(baseValue, exponent));
        }

        public override double GetResult()
        {
            return base.GetResult() * Math.Pow(10, 6);
        }
    }
}
