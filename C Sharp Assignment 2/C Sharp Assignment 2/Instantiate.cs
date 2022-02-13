using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_2
{
internal class Instantiate
{
    private ICalculator Calculator { get; }

    public Instantiate(ICalculator calculator)
    {
        Calculator = calculator;
    }

    public void Calculate(int programNumber)
    {
        float number1, number2, number3;
        while (true)
        {
            Console.WriteLine("\n1 to Get the Result");
            Console.WriteLine("2 to add two integers");
            Console.WriteLine("3 to add three integers");
            Console.WriteLine("4 to add two floating point numbers");
            if (programNumber == 2)
                Console.WriteLine("5 to find the Power");
            Console.Write("Enter your choice or \"0\" to exit : ");
            var choice = int.Parse(Console.ReadLine());
            if (choice == 0)
                break;
            switch (choice)
            {
                case 1:
                     Console.WriteLine("The Result is {0}", Calculator.GetResult());
                     break;
                case 2:
                    Console.WriteLine("Enter 2 Integers : ");
                    number1 = int.Parse(Console.ReadLine());
                    number2 = int.Parse(Console.ReadLine());
                    Calculator.Add((int)number1, (int)number2);
                    break;
                case 3:
                    Console.WriteLine("Enter 3 Integers : ");
                    number1 = int.Parse(Console.ReadLine());
                    number2 = int.Parse(Console.ReadLine());
                    number3 = int.Parse(Console.ReadLine());
                    Calculator.Add((int)number1, (int)number2, (int)number3);
                    break;
                case 4:
                    Console.WriteLine("Enter 2 Integers : ");
                    number1 = float.Parse(Console.ReadLine());
                    number2 = float.Parse(Console.ReadLine());
                    Calculator.Add(number1, number2);
                    break;
                case 5:
                    if (programNumber == 2)
                    {
                        Console.WriteLine("Enter 2 Numbers : ");
                        number1 = float.Parse(Console.ReadLine());
                        number2 = float.Parse(Console.ReadLine());
                        Calculator.Power(number1, number2);
                    }
                    else
                        Console.WriteLine("Enter the correct choice");
                    break;
                default:
                        Console.WriteLine("Enter the correct choice");
                        break;
            }

        }
    }

    }


}

