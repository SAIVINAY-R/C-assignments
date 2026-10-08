using C_Sharp_Assignment_2;


while (true)
{
    Console.Write("\nEnter the Program number to execute i.e 1,2 or \"0\" to exit : ");
    var programNumber = int.Parse(Console.ReadLine());

    if (programNumber == 0)
        break;
    ICalculator calculator;
    float number1, number2, number3;
    switch (programNumber)
    {
        case 1:
            calculator = new Calculator();
            while (true)
            {
                Console.WriteLine("\n1 to Get the Result");
                Console.WriteLine("2 to add two integers");
                Console.WriteLine("3 to add three integers");
                Console.WriteLine("4 to add two floating point numbers");
                Console.Write("Enter your choice or \"0\" to exit : ");
                var choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                    break;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("The Result is {0}", calculator.GetResult());
                        break;
                    case 2:
                        Console.WriteLine("Enter 2 Integers : ");
                        number1 = int.Parse(Console.ReadLine());
                        number2 = int.Parse(Console.ReadLine());
                        calculator.Add((int)number1, (int)number2);
                        break;
                    case 3:
                        Console.WriteLine("Enter 3 Integers : ");
                        number1 = int.Parse(Console.ReadLine());
                        number2 = int.Parse(Console.ReadLine());
                        number3 = int.Parse(Console.ReadLine());
                        calculator.Add((int)number1, (int)number2, (int)number3);
                        break;
                    case 4:
                        Console.WriteLine("Enter 2 Integers : ");
                        number1 = float.Parse(Console.ReadLine());
                        number2 = float.Parse(Console.ReadLine());
                        calculator.Add(number1, number2);
                        break;
                    default:
                        Console.WriteLine("Enter the correct choice");
                        break;
                }
            }
                break;
        case 2:
            calculator = new AdvancedCalculator();
            while (true)
            {
                Console.WriteLine("\n1 to Get the Result");
                Console.WriteLine("2 to add two integers");
                Console.WriteLine("3 to add three integers");
                Console.WriteLine("4 to add two floating point numbers");
                Console.WriteLine("5 to find the Power");
                Console.Write("Enter your choice or \"0\" to exit : ");
                var choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                    break;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("The Result is {0}", calculator.GetResult());
                        break;
                    case 2:
                        Console.WriteLine("Enter 2 Integers : ");
                        number1 = int.Parse(Console.ReadLine());
                        number2 = int.Parse(Console.ReadLine());
                        calculator.Add((int)number1, (int)number2);
                        break;
                    case 3:
                        Console.WriteLine("Enter 3 Integers : ");
                        number1 = int.Parse(Console.ReadLine());
                        number2 = int.Parse(Console.ReadLine());
                        number3 = int.Parse(Console.ReadLine());
                        calculator.Add((int)number1, (int)number2, (int)number3);
                        break;
                    case 4:
                        Console.WriteLine("Enter 2 Integers : ");
                        number1 = float.Parse(Console.ReadLine());
                        number2 = float.Parse(Console.ReadLine());
                        calculator.Add(number1, number2);
                        break;
                    case 5:
                        Console.WriteLine("Enter 2 Numbers : ");
                        number1 = float.Parse(Console.ReadLine());
                        number2 = float.Parse(Console.ReadLine());
                        calculator.Power(number1, number2);
                        break;
                    default:
                        Console.WriteLine("Enter the correct choice");
                        break;
                }
            }

            break;
        default:
            Console.WriteLine("Enter the correct programNumber");
            break;
    }

}